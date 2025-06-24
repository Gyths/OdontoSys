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
        private OdontologoBO odontologoBO = new OdontologoBO();
        private EspecialidadBO especialidadBO = new EspecialidadBO();  
        private CitaBO citaBO = new CitaBO();
        private PacienteBO pacienteBO = new PacienteBO();
        private SalaBO salaBO = new SalaBO(); 
        private TurnoBO turnoBO = new TurnoBO();
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
            odontologoActual = odontologoBO.odontologo_obtenerPorId(id);


            txtNombre.Text = odontologoActual.nombre;
            txtApellido.Text = odontologoActual.apellidos;
            txtDocumento.Text = odontologoActual.numeroDocumento;
            var especialidadOd = especialidadBO.especialidad_obtenerPorId(odontologoActual.especialidad.idEspecialidad);
            txtEspecialidad.Text = especialidadOd.nombre;
            txtCorreo.Text = odontologoActual.correo;
            txtTelefono.Text = odontologoActual.telefono;
            txtUsuario.Text = odontologoActual.nombreUsuario;
        }
            

        protected void btnEliminarTurnoSelec_Click(object sender, EventArgs e) 
        {
            

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
                    var original = odontologoBO.odontologo_obtenerPorId(id);
                    if (original != null)
                    {
                        if (Regex.IsMatch(txtTelefono.Text, @"^(9\d{8}|\d{3}-\d{4})$") &&
                            Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            original.correo = txtCorreo.Text;
                            original.telefono = txtTelefono.Text;
                            odontologoBO.odontologo_modificar(original);
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

            var odontologoActual = odontologoBO.odontologo_obtenerPorId(idOdo);
            var odontologo = new CitaWS.odontologo
            {
                idOdontologo = odontologoActual.idOdontologo,
                idOdontologoSpecified = true
            };

            try { 
                var listaCitas = citaBO.cita_listarPorOdontologoFechas(odontologo, desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
                
                foreach (var cita in listaCitas)
                {
                    var paciente = pacienteBO.paciente_obtenerPorId(cita.paciente.idPaciente);
                    var pac = new CitaWS.paciente
                    {
                        idPaciente = paciente.idPaciente,
                        idPacienteSpecified = true,
                        nombre = paciente.nombre,
                        apellidos = paciente.apellidos,
                    };
                    cita.paciente = pac;
                    cita.paciente.nombre += (" " + cita.paciente.apellidos);
                }
                gvCitas.DataSource = listaCitas;
                gvCitas.DataBind();
            }catch (Exception e)
            {
                gvCitas.DataSource = null;
                gvCitas.DataBind();
            }

        }
        private void CargarTurnos(int idOdo)
        {
            var odontologo = new TurnoWS.odontologo
            {
                idOdontologo = idOdo,
                idOdontologoSpecified = true
            };
            try { 
                var listaTurnos = turnoBO.turno_listarPorOdontologo(odontologo);
                gvTurnos.DataSource = listaTurnos;
                gvTurnos.DataBind();
            }catch (Exception e) {
                gvTurnos.DataSource=null;
                gvTurnos.DataBind();
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
                var cita = new CitaWS.cita
                {
                    idCita = idCita,
                    idCitaSpecified = true,
                    estado = CitaWS.estadoCita.CANCELADA,
                    estadoSpecified = true
                };
                citaBO.cita_actualizarEstado(cita);
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