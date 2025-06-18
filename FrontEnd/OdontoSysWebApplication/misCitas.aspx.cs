using System;
using System.Text;
using OdontoSysBusiness.CitaWS;
using OdontoSysBusiness.OdontologoWS;
using OdontoSysBusiness.PacienteWS;
using OdontoSysBusiness.ValoracionWS;

namespace OdontoSysWebApplication
{
    public partial class misCitas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCitasPaciente();
        }

        private void CargarCitasPaciente()
        {
            var paciente = (OdontoSysBusiness.PacienteWS.paciente)Session["Paciente"];
            if (paciente == null) return;

            var clienteCita = new CitaWAClient();
            var clienteOdontologo = new OdontologoWAClient();

            var pacienteCita = new OdontoSysBusiness.CitaWS.paciente
            {
                idPaciente = paciente.idPaciente,
                idPacienteSpecified = true
            };

            var citas = clienteCita.cita_listarPorPaciente(pacienteCita);
            

            if (citas == null || citas.Length == 0)
            {
                ltCitas.Text = "<div class='alert alert-warning'>No tienes citas registradas.</div>";
                return;
            }

            var sb = new StringBuilder();

            foreach (var cita in citas)
            {
                var odontologo = clienteOdontologo.odontologo_obtenerPorId(cita.odontologo.idOdontologo);
                string fechaTexto = DateTime.TryParse(cita.fecha, out DateTime fechaObj)
                    ? fechaObj.ToString("dddd dd/MM/yyyy")
                    : cita.fecha;

                sb.AppendLine("<div class='card mb-3'>");
                sb.AppendLine("<div class='card-body'>");
                sb.AppendLine($"<h5 class='card-title'>Fecha: {fechaTexto} - Hora: {cita.horaInicio}</h5>");
                sb.AppendLine($"<p class='card-text'><strong>Odontólogo:</strong> {odontologo.nombre} {odontologo.apellidos}</p>");
                sb.AppendLine($"<p class='card-text'><strong>Estado:</strong> {cita.estado}</p>");

                // Mostrar botón de valoración si la fecha ya pasó y no tiene valoracion asignada aún
                if (DateTime.TryParse(cita.fecha, out DateTime fechaCita) &&
                    fechaCita.Date < DateTime.Today)
                {
                    if (cita.valoracion.idValoracion <= 1) {
                        sb.AppendLine($"<button type='button' class='btn btn-outline-primary btn-sm' onclick='valorarCita(event, {cita.idCita})'>Valorar Cita</button>");
                    }
                }

                sb.AppendLine("</div>");
                sb.AppendLine("</div>");
            }

            ltCitas.Text = sb.ToString();
        }

        protected void btnEnviarValoracion_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(hfIdCita.Value, out int idCita)) return;

            var clienteCita = new CitaWAClient();
            var cita = clienteCita.cita_obtenerPorId(idCita);

            if (cita == null)
            {
                ltCitas.Text = "<div class='alert alert-danger'>No se encontró la cita para valorar.</div>";
                return;
            }

            var valoracion = new OdontoSysBusiness.ValoracionWS.valoracion
            {
                comentario = txtComentario.Text.Trim(),
                calicicacion = int.Parse(ddlPuntaje.SelectedValue),
                calicicacionSpecified = true,
                fechaCalificacion = DateTime.Today.ToString("yyyy-MM-dd")
            };
            
            try
            {
                var clienteValoracion = new ValoracionWAClient();
                int idV = clienteValoracion.valoracion_insertar(valoracion);
                var valoracionCita = new OdontoSysBusiness.CitaWS.valoracion
                {
                    idValoracion = idV,
                    idValoracionSpecified = true
                };
                clienteCita.cita_actualizarFkValoracion(cita, valoracionCita);
                ltCitas.Text = "<div class='alert alert-success'>Gracias por valorar tu cita.</div>";
                pnlValoracion.CssClass += " d-none";
            }
            catch (Exception)
            {
                ltCitas.Text = "<div class='alert alert-danger'>Error al registrar la valoración. Intenta nuevamente.</div>";
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}
