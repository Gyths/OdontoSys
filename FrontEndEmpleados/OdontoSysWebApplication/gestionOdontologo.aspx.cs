using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class gestionOdontologo : System.Web.UI.Page
    {
        private OdontologoWS.odontologo odontologoActual;
        private OdontologoBO odontologoBO;
        private EspecialidadBO especialidadBO ;  
        private CitaBO citaBO ;
        private PacienteBO pacienteBO;
        private SalaBO salaBO ; 
        private TurnoBO turnoBO ;

        public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }
        public SalaBO SalaBO { get => salaBO; set => salaBO = value; }
        public TurnoBO TurnoBO { get => turnoBO; set => turnoBO = value; }

        public gestionOdontologo()
        {
            this.OdontologoBO = new OdontologoBO();
            this.EspecialidadBO = new EspecialidadBO();
            this.CitaBO = new CitaBO();
            this.PacienteBO = new PacienteBO();
            this.SalaBO = new SalaBO();
            this.TurnoBO = new TurnoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] == null || !int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                Response.Redirect("buscarOdontologo.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarOdontologo(idOdo);
                calFiltro.SelectedDate = DateTime.Today;
                CargarCitasOdontologo(idOdo, DateTime.Today);
                CargarTurnos(idOdo);
            }
        }

        private void CargarOdontologo(int id)
        {
            odontologoActual = OdontologoBO.odontologo_obtenerCompletoPorId(id);

            txtNombre.Text = odontologoActual.nombre;
            txtApellido.Text = odontologoActual.apellidos;
            txtDocumento.Text = odontologoActual.numeroDocumento;
            txtEspecialidad.Text = odontologoActual.especialidad.nombre;
            txtCorreo.Text = odontologoActual.correo;
            txtTelefono.Text = odontologoActual.telefono;
            txtUsuario.Text = odontologoActual.nombreUsuario;
        }
            

        protected void btnEliminarTurnoSelec_Click(object sender, EventArgs e) 
        {
            string idOdontologoActual = Session["idOdontologoSeleccionado"].ToString();
            foreach (GridViewRow row in gvTurnos.Rows) 
            {
                CheckBox chkSeleccionar1 = (CheckBox)row.FindControl("chkSeleccionar1");
                TurnoXOdontologoBO boTurnoOdontologo = new TurnoXOdontologoBO();
                if (chkSeleccionar1 != null && chkSeleccionar1.Checked)
                {
                    boTurnoOdontologo.turnoXOdontologo_eliminar(Int32.Parse(idOdontologoActual), Int32.Parse(gvTurnos.DataKeys[row.RowIndex].Value.ToString()));
                }
            }
            CargarTurnos(Int32.Parse(idOdontologoActual));
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetReadOnly(txtCorreo, false);
            SetReadOnly(txtTelefono, false);
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
        }

        private void SetReadOnly(TextBox txt, bool readOnly)
        {
            txt.ReadOnly = readOnly;
            txt.CssClass = readOnly ? "form-control locked" : "form-control";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null && int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int id))
            {
                try
                {
                    var original = OdontologoBO.odontologo_obtenerPorId(id);
                    if (original != null)
                    {
                        if (Regex.IsMatch(txtTelefono.Text, @"^(9\d{8}|\d{3}-\d{4})$") &&
                            Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            original.correo = txtCorreo.Text;
                            original.telefono = txtTelefono.Text;
                            OdontologoBO.odontologo_modificar(original);
                        }
                        else
                        {
                            throw new Exception("El numero de telefono o correo son incorrectos");
                        }

                        odontologoActual = original;
                        pnlAlerta.Visible = true;
                        pnlError.Visible = false;
                        SetReadOnly(txtCorreo, true);
                        SetReadOnly(txtTelefono, true);

                        btnGuardar.Visible = false;
                        btnEditar.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al guardar odontologo: " + ex.Message);
                    Label lblMensaje = new Label();
                    lblMensaje.Text = "Error al guardar los cambios. " + ex.Message;
                    lblMensaje.CssClass = "text-danger";
                    pnlError.Controls.Add(new LiteralControl(lblMensaje.Text));
                    pnlError.Visible = true;
                }
                
            }
        }

        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null &&
                int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitasOdontologo(idOdo, baseDate);
            }
        }

        private void CargarCitasOdontologo(int idOdo, DateTime baseDate)
        {

            DateTime desde = baseDate;
            DateTime hasta = baseDate;

            var odontologoActual = OdontologoBO.odontologo_obtenerPorId(idOdo);

            try { 
                var listaCitas = CitaBO.cita_listarPorOdontologoFechas(odontologoActual.idOdontologo, desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
                
                foreach (var cita in listaCitas)
                {
                    cita.paciente.nombre += (" " + cita.paciente.apellidos);
                }
                gvCitas.DataSource = listaCitas;
                gvCitas.DataBind();
            }catch (Exception e)
            {
                gvCitas.DataSource = null;
                gvCitas.DataBind();

                // Log en consola del servidor
                System.Diagnostics.Debug.WriteLine("Error en CargarCitasOdontologo: " + e.ToString());
            }

        }
        private void CargarTurnos(int idOdo)
        {
            try { 
                var listaTurnos = TurnoBO.turno_listarPorOdontologo(idOdo);
                gvTurnos.DataSource = listaTurnos;
                gvTurnos.DataBind();
            }catch (Exception e) {
                lblError.Text = "Ocurrió un error al cargar los turnos: " + e.Message;
                lblError.Visible = true;
                gvTurnos.DataSource=null;
                gvTurnos.DataBind();
                throw;
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarOdontologo.aspx");
        }
        protected void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            List<int> idsCitasCancelar = new List<int>();
            foreach (GridViewRow fila in gvCitas.Rows)
            {
                if (fila.RowType != DataControlRowType.DataRow) continue;
                var chk = (CheckBox)fila.FindControl("chkSeleccionar");
                if (chk != null && chk.Checked)
                {
                    int idCita = (int)gvCitas.DataKeys[fila.RowIndex].Value;
                    idsCitasCancelar.Add(idCita);
                }
            }
            if (idsCitasCancelar.Count == 0)
            {
                pnlError.Controls.Clear();
                pnlError.Controls.Add(new Literal
                {
                    Text = "Seleccione al menos una cita en estado <strong>Reservada</strong>."
                });
                pnlError.Visible = true;
                return;
            }

            foreach (int idCita in idsCitasCancelar)
            {
                var cita = CitaBO.cita_obtenerPorId(idCita);
                cita.estado = CitaWS.estadoCita.CANCELADA;
                CitaBO.cita_modificar(cita);
            }
            if (int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue
                                        ? DateTime.Today
                                        : calFiltro.SelectedDate;

                CargarCitasOdontologo(idOdo, fechaBase);
            }
        }

        protected void gvCitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;
            var estado = DataBinder.Eval(e.Row.DataItem, "estado")?.ToString();
            bool mostrarChk = estado == "RESERVADA";
            var chk = (CheckBox)e.Row.FindControl("chkSeleccionar");
            if (chk != null) chk.Visible = mostrarChk;
        }

        protected void gvTurnos_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}