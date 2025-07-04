using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontologoWS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
        private PacienteWS.paciente pacienteActual;
        Label lblMensaje;
        private PacienteBO pacienteBO;
        private OdontologoBO odontologoBO ;
        private CitaBO citaBO ;
        private SalaBO salaBO ;
        private EspecialidadBO especialidadBO ;

        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }
        public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public SalaBO SalaBO { get => salaBO; set => salaBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }

        public gestionPaciente()
        {
            this.PacienteBO = new PacienteBO();
            this.OdontologoBO = new OdontologoBO();
            this.CitaBO = new CitaBO();
            this.SalaBO = new SalaBO();
            this.EspecialidadBO = new EspecialidadBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] == null ||
        !       int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                Response.Redirect("buscarPaciente.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarPaciente(idPaciente);
                calFiltro.SelectedDate = DateTime.Today;
                CargarCitas(idPaciente, DateTime.Today);
            }
        }

        private void CargarPaciente(int id)
        {
            try
            {
                pacienteActual = PacienteBO.paciente_obtenerPorId(id);

                if (pacienteActual != null)
                {
                    txtNombre.Text = pacienteActual.nombre ?? "";
                    txtApellido.Text = pacienteActual.apellidos ?? "";
                    txtDocumento.Text = pacienteActual.numeroDocumento ?? "";
                    txtCorreo.Text = pacienteActual.correo ?? "";
                    txtTelefono.Text = pacienteActual.telefono ?? "";
                    txtUsuario.Text = pacienteActual.nombreUsuario ?? "";
                }
                BloquearTodos();
                btnGuardar.Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar paciente: " + ex.Message);
                lblMensaje.Text = "Error al cargar datos del paciente.";
                lblMensaje.CssClass = "text-danger";
            }
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            if (e.CommandName == "Gestionar") 
            {
                string idCita = e.CommandArgument.ToString();
                Response.Redirect($"comprobanteCita.aspx?idCita={idCita}");
            }
            
        }

        protected void gvCitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var estado = DataBinder.Eval(e.Row.DataItem, "estado")?.ToString();
            bool mostrarBtn = estado == "ATENDIDA" || estado == "RESERVADA"; 
            bool mostrarChk = estado == "RESERVADA";

            var btn = (Button)e.Row.FindControl("btnGestionarComprobante");
            var chk = (CheckBox)e.Row.FindControl("chkSeleccionar");

            if (btn != null) btn.Visible = mostrarBtn;
            if (chk != null) chk.Visible = mostrarChk;
        }
        private void SetReadOnly(TextBox txt, bool readOnly)
        {
            txt.ReadOnly = readOnly;
            txt.CssClass = readOnly ? "form-control locked" : "form-control";
        }

        private void BloquearTodos()
        {
            SetReadOnly(txtNombre, true);
            SetReadOnly(txtApellido, true);
            SetReadOnly(txtDocumento, true);
            SetReadOnly(txtCorreo, true);
            SetReadOnly(txtTelefono, true);
            SetReadOnly(txtUsuario, true);
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetReadOnly(txtCorreo, false);
            SetReadOnly(txtTelefono, false);
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnCita.Visible = false;
            btnVolver.Visible = false;
            btnDescargarPDF.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                try
                {
                    var original = PacienteBO.paciente_obtenerPorId(idPaciente);

                    if (original != null)
                    {
                        if (Regex.IsMatch(txtTelefono.Text, @"^(9\d{8}|\d{3}-\d{4})$") &&
                            Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            original.correo = txtCorreo.Text;
                            original.telefono = txtTelefono.Text;
                            original.nombreUsuario = txtUsuario.Text;
                            PacienteBO.paciente_modificar(original);
                        }
                        else
                        {
                            
                            throw new Exception("El numero de telefono o correo son incorrectos");
                        }

                        pacienteActual = original;

                        pnlAlerta.Visible = true;
                        pnlError.Visible = false;
                        BloquearTodos();
                        btnGuardar.Visible = false;
                        btnEditar.Visible = true;
                        btnCita.Visible = true;
                        btnVolver.Visible = true;
                        btnDescargarPDF.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al guardar paciente: " + ex.Message);
                    Label lblMensaje = new Label();
                    lblMensaje.Text = "Error al guardar los cambios. "+ ex.Message;
                    lblMensaje.CssClass = "text-danger";
                    pnlError.Controls.Add(new LiteralControl(lblMensaje.Text));
                    pnlAlerta.Visible = false;
                    pnlError.Visible = true;
                }
            }
        }
        
        private void CargarCitas(int id, DateTime baseDate) 
        {
            DateTime desde = baseDate;
            DateTime hasta = baseDate;

            pacienteActual = PacienteBO.paciente_obtenerPorId(id);

            var listaCitas = CitaBO.cita_listarPorPacienteFechas(pacienteActual.idPaciente,desde.ToString("yyyy-MM-dd"),hasta.ToString("yyyy-MM-dd"));
            foreach (var cita in listaCitas)
            {
                var odontologo = OdontologoBO.odontologo_obtenerPorId(cita.odontologo.idOdontologo);
                var consultorioOd = SalaBO.sala_obtenerPorId(odontologo.consultorio.idSala);
                var consultorio = new CitaWS.sala
                {
                    idSala = odontologo.consultorio.idSala,
                    idSalaSpecified = true,
                    numero = consultorioOd.numero,
                };
                var od = new CitaWS.odontologo
                {
                    idOdontologo = odontologo.idOdontologo,
                    idOdontologoSpecified = true,
                    nombre = odontologo.nombre,
                    apellidos = odontologo.apellidos,
                    consultorio = consultorio
                };
                cita.odontologo = od;
                cita.odontologo.nombre += (" " + cita.odontologo.apellidos);
            }
            gvCitas.DataSource = listaCitas;
            gvCitas.DataBind();
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
            if (int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPa))
            {
                DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue
                                        ? DateTime.Today
                                        : calFiltro.SelectedDate;

                CargarCitas(idPa, fechaBase);
            }
        }
        

        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitas(idPaciente, baseDate);
            }
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idPacienteSeleccionado"] != null &&
                    int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
                {

                    byte[] pdfBytes = PacienteBO.reporteHistoriaClinica(idPaciente);

                    if (pdfBytes != null && pdfBytes.Length > 0)
                    {

                        Response.Clear();
                        Response.ContentType = "application/pdf";


                        string nombreArchivo = $"Historia_Clinica_{pacienteActual?.numeroDocumento ?? idPaciente.ToString()}_{DateTime.Now:yyyyMMdd}.pdf";


                        Response.AddHeader("Content-Disposition", $"inline; filename={nombreArchivo}");
                        Response.AddHeader("Content-Length", pdfBytes.Length.ToString());


                        Response.BinaryWrite(pdfBytes);
                        Response.Flush();
                        Response.End();
                    }
                    else
                    {
                        throw new Exception("No se pudo generar el reporte PDF.");
                    }
                }
                else
                {

                    pnlError.Controls.Clear();
                    pnlError.Controls.Add(new LiteralControl("No se pudo identificar el paciente."));
                    pnlError.Visible = true;
                    pnlAlerta.Visible = false;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al generar PDF: " + ex.Message);


                pnlError.Controls.Clear();
                pnlError.Controls.Add(new LiteralControl($"Error al generar el PDF: {ex.Message}"));
                pnlError.Visible = true;
                pnlAlerta.Visible = false;
            }
        }

        protected void btnCita_Click(object sender, EventArgs e)
        {
            Response.Redirect("reservaCitaPorRecepcionista.aspx", false);  // ← false evita ThreadAbortException
            Context.ApplicationInstance.CompleteRequest();
        }

         
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarPaciente.aspx");
        }
    }
}