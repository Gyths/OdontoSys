using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
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
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] == null || !int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                Response.Redirect("buscarOdontologo.aspx");
                return;
            }
            if (IsPostBack && Request.Form["accion"] == "cancelar")
            {
                if (int.TryParse(Request.Form["idCita"], out int idCita))
                    CancelarCita(idCita, idOdo);
            }
            if (!IsPostBack)
            {
                CargarOdontologo(idOdo);
                calFiltro.SelectedDate = DateTime.Today;
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasOdontologo(idOdo, fechaBase);
        }

        private void CancelarCita(int idCita, int idOdo)
        {
            var cliCita = new CitaBO();
            var cita = cliCita.cita_obtenerPorId(idCita);
            if (cita != null && cita.estado == CitaWS.estadoCita.RESERVADA)
            {
                cita.estado = CitaWS.estadoCita.CANCELADA;
                cliCita.cita_actualizarEstado(cita);

                lblMensaje.Text = "La cita fue cancelada correctamente.";
                lblMensaje.CssClass = "text-success";
            }
            else
            {
                lblMensaje.Text = "No se pudo cancelar la cita.";
                lblMensaje.CssClass = "text-danger";
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasOdontologo(idOdo, fechaBase);
        }

        private void CargarOdontologo(int id)
        {
            // Simulación. Reemplazar con la llamada real al servicio web.
            var odontologoBO = new OdontologoBO(); // Método ficticio

            OdontologoWS.odontologo odontologo = odontologoBO.odontologo_obtenerPorId(id);

            // Llenar campos
            txtNombre.Text = odontologo.nombre;
            txtApellido.Text = odontologo.apellidos;
            txtDocumento.Text = odontologo.numeroDocumento;
            txtEspecialidad.Text = odontologo.especialidad.nombre;
            txtCorreo.Text = odontologo.correo;
            txtTelefono.Text = odontologo.telefono;
            txtUsuario.Text = odontologo.nombreUsuario;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtUsuario.ReadOnly = false;

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null && int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int id))
            {
                var odontologoBO = new OdontologoBO();

                var original = odontologoBO.odontologo_obtenerPorId(id); // obtener objeto completo

                original.correo = txtCorreo.Text;
                original.telefono = txtTelefono.Text;
                original.nombreUsuario = txtUsuario.Text;

                odontologoBO.odontologo_modificar(original);

                // Volver a modo solo lectura
                txtCorreo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtUsuario.ReadOnly = true;

                btnGuardar.Visible = false;
                btnEditar.Visible = true;
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
            DateTime desde = baseDate.AddDays(-1);
            DateTime hasta = baseDate.AddDays(+1);

            var cliCita = new CitaWAClient();
            var cliEsp = new EspecialidadWAClient();
            var cliPac = new PacienteWAClient();
            var odontologoCita = new CitaWS.odontologo
            {
                idOdontologo = idOdo,
                idOdontologoSpecified = true
            };
            try
            {
                var citas = cliCita.cita_listarPorOdontologoFechas(odontologoCita, desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
                if (citas == null)
                {
                    ltCitas.Text = "<div class='alert alert-warning'>No hay citas en el rango seleccionado.</div>";
                    return;
                }
                var clienteOdontologo = new OdontologoBO();
                var sb = new StringBuilder();
                foreach (var c in citas.OrderBy(c => c.fecha).ThenBy(c => c.horaInicio))
                {
                    var paciente = cliPac.paciente_obtenerPorId(c.paciente.idPaciente);
                    var odontologo = clienteOdontologo.odontologo_obtenerPorId(c.odontologo.idOdontologo);
                    var especialidad = cliEsp.especialidad_obtenerPorId(odontologo.especialidad.idEspecialidad);

                    sb.AppendLine("<div class='card mb-3 shadow-sm'>");
                    sb.AppendLine("  <div class='card-body'>");
                    sb.AppendLine($"   <h5 class='card-title'>Fecha: {c.fecha:d} – Hora: {c.horaInicio:hh\\:mm}</h5>");
                    sb.AppendLine($"   <p class='card-text'><strong>Paciente:</strong> {paciente.nombre} {paciente.apellidos}</p>");
                    sb.AppendLine($"   <p class='card-text'><strong>Especialidad:</strong> {especialidad.nombre}</p>");
                    sb.AppendLine($"   <p class='card-text'><strong>Estado:</strong> " +
                                    $"<span class='badge bg-{GetBadgeColor(c.estado.ToString())}'>" +
                                    $"{ToTitleCase(c.estado.ToString())}</span></p>");
                    sb.AppendLine("  </div>");
                    sb.AppendLine("</div>");
                    if (c.estado == CitaWS.estadoCita.RESERVADA)              
                    {                                                            
                        sb.AppendLine("<form method='post' class='d-inline me-2'>");    
                        sb.AppendLine("  <input type='hidden' name='accion' value='cancelar' />");
                        sb.AppendLine($" <input type='hidden' name='idCita' value='{c.idCita}' />"); 
                        sb.AppendLine("  <button type='submit' class='btn btn-danger btn-sm'>");    
                        sb.AppendLine("      Cancelar cita</button></form>");    
                    }
                }
                ltCitas.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }
        private string GetBadgeColor(string estado)
        {
            switch (estado.ToUpper())
            {
                case "RESERVADA": return "warning";
                case "ATENDIDA": return "success";
                case "CANCELADA": return "danger";
                default: return "secondary";
            }
        }

        private string ToTitleCase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarOdontologo.aspx");
        }
    }
}