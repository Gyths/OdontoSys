using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class reservaCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
            else
            {
                if (!string.IsNullOrEmpty(hfFechaSeleccionada.Value) &&
                    !string.IsNullOrEmpty(hfHoraSeleccionada.Value))
                {
                    btnConfirmarCita.Visible = true;
                    ltDisponibilidad.Text = $"<div class='alert alert-info'>Cita seleccionada para el <strong>{hfFechaSeleccionada.Value}</strong> a las <strong>{hfHoraSeleccionada.Value}</strong>.</div>";
                }
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                var clienteEspecialidad = new OdontoSysBusiness.EspecialidadWS.EspecialidadWAClient();
                var especialidades = clienteEspecialidad.especialidad_listarTodos();

                ddlEspecialidades.DataSource = especialidades;
                ddlEspecialidades.DataValueField = "idEspecialidad";
                ddlEspecialidades.DataTextField = "nombre";
                ddlEspecialidades.DataBind();
            }
            catch
            {
                throw;
            }
        }

        protected void ddlEspecialidades_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlOdontologos.Visible = false;
            pnlSemana.Visible = false;
            pnlSlots.Visible = false;
            ltDisponibilidad.Text = "";
            btnConfirmarCita.Visible = false;

            ddlOdontologos.Items.Clear();

            if (string.IsNullOrEmpty(ddlEspecialidades.SelectedValue))
                return;

            int idEspecialidad = int.Parse(ddlEspecialidades.SelectedValue);
            var especialidad = new OdontoSysBusiness.OdontologoWS.especialidad
            {
                idEspecialidad = idEspecialidad,
                idEspecialidadSpecified = true
            };

            var clienteOdontologo = new OdontoSysBusiness.OdontologoWS.OdontologoWAClient();
            var odontologos = clienteOdontologo.odontologo_listarPorEspecialidad(especialidad);

            ddlOdontologos.Items.Add(new ListItem("-- Seleccione un odontólogo --", ""));
            foreach (var o in odontologos)
            {
                string nombreCompleto = $"{o.nombre} {o.apellidos}";
                ddlOdontologos.Items.Add(new ListItem(nombreCompleto, o.idOdontologo.ToString()));
            }

            pnlOdontologos.Visible = true;
        }

        protected void ddlOdontologos_SelectedIndexChanged(object sender, EventArgs e)
        {
            pnlSemana.Visible = false;
            pnlSlots.Visible = false;
            ltDisponibilidad.Text = "";
            btnConfirmarCita.Visible = false;

            if (!string.IsNullOrEmpty(ddlOdontologos.SelectedValue))
                pnlSemana.Visible = true;
        }

        protected void BtnSemana_Click(object sender, EventArgs e)
        {
            int semanas = int.Parse((sender as LinkButton).CommandArgument);
            DateTime fechaInicio = DateTime.Today.AddDays(1 + semanas * 7);
            DateTime fechaFin = fechaInicio.AddDays(7);

            string fechaInicioStr = fechaInicio.ToString("yyyy-MM-dd");
            string fechaFinStr = fechaFin.ToString("yyyy-MM-dd");

            int idOdontologo = int.Parse(ddlOdontologos.SelectedValue);

            var odontologoTurno = new OdontoSysBusiness.TurnoWS.odontologo
            {
                idOdontologo = idOdontologo,
                idOdontologoSpecified = true
            };

            var clienteTurno = new OdontoSysBusiness.TurnoWS.TurnoWAClient();
            var turnos = clienteTurno.turno_listarPorOdontologo(odontologoTurno);

            var odontologoCita = new OdontoSysBusiness.CitaWS.odontologo
            {
                idOdontologo = idOdontologo,
                idOdontologoSpecified = true
            };

            var clienteCita = new OdontoSysBusiness.CitaWS.CitaWAClient();
            var citas = clienteCita.cita_listarPorOdontologoFechas(odontologoCita, fechaInicioStr, fechaFinStr);

            var disponibilidad = CalcularHorasDisponibles(turnos, citas, fechaInicio);

            ltSlots.Text = GenerarHTMLDisponibilidad(disponibilidad);
            pnlSlots.Visible = true;
        }

        private Dictionary<DateTime, List<TimeSpan>> CalcularHorasDisponibles(
            OdontoSysBusiness.TurnoWS.turno[] turnos,
            OdontoSysBusiness.CitaWS.cita[] citas,
            DateTime fechaInicio)
        {
            if (turnos == null)
                turnos = new OdontoSysBusiness.TurnoWS.turno[0];
            if (citas == null)
                citas = new OdontoSysBusiness.CitaWS.cita[0];

            bool[,] disponibilidad = new bool[7, 48];

            foreach (var turno in turnos)
            {
                if (!Enum.TryParse(turno.diaSemana.ToString(), true, out DayOfWeek diaTurno)) continue;
                if (!TimeSpan.TryParse(turno.horaInicio, out var horaInicio)) continue;
                if (!TimeSpan.TryParse(turno.horaFin, out var horaFin)) continue;

                for (int d = 0; d < 7; d++)
                {
                    var fecha = fechaInicio.AddDays(d);
                    if (fecha.DayOfWeek != diaTurno) continue;

                    int idxInicio = horaInicio.Hours * 2 + (horaInicio.Minutes >= 30 ? 1 : 0);
                    int idxFin = horaFin.Hours * 2 + (horaFin.Minutes > 0 ? 1 : 0);

                    for (int i = idxInicio; i < idxFin && i < 48; i++)
                        disponibilidad[d, i] = true;
                }
            }

            foreach (var cita in citas)
            {
                if (cita == null) continue;
                if (!DateTime.TryParse(cita.fecha, out var fechaCita)) continue;
                if (!TimeSpan.TryParse(cita.horaInicio, out var horaCita)) continue;

                int diaRelativo = (int)(fechaCita.Date - fechaInicio.Date).Days;
                if (diaRelativo < 0 || diaRelativo >= 7) continue;

                int idx = horaCita.Hours * 2 + (horaCita.Minutes == 30 ? 1 : 0);
                if (idx >= 0 && idx < 48)
                    disponibilidad[diaRelativo, idx] = false;
            }

            var resultado = new Dictionary<DateTime, List<TimeSpan>>();
            for (int d = 0; d < 7; d++)
            {
                var fecha = fechaInicio.AddDays(d);
                var horasLibres = new List<TimeSpan>();

                for (int s = 0; s < 48; s++)
                {
                    if (disponibilidad[d, s])
                        horasLibres.Add(TimeSpan.FromMinutes(s * 30));
                }

                resultado[fecha] = horasLibres;
            }

            return resultado;
        }

        private string GenerarHTMLDisponibilidad(Dictionary<DateTime, List<TimeSpan>> disponibilidad)
        {
            var sb = new StringBuilder();

            foreach (var dia in disponibilidad)
            {
                sb.AppendLine($"<h5>{dia.Key:dddd dd/MM}</h5>");
                sb.AppendLine("<div class='d-flex flex-wrap gap-1 mb-3'>");

                foreach (var hora in dia.Value)
                {
                    string horaTexto = hora.ToString(@"hh\:mm");
                    sb.AppendLine($@"
                <button type='button' 
                        class='btn btn-outline-success btn-sm'
                        onclick=""seleccionarSlot('{dia.Key:yyyy-MM-dd}','{horaTexto}')"">
                    {horaTexto}
                </button>");
                }

                sb.AppendLine("</div>");
            }

            return sb.ToString();
        }

        protected void btnConfirmarCita_Click(object sender, EventArgs e)
        {
            var paciente = (OdontoSysBusiness.PacienteWS.paciente)Session["Paciente"];

            if (string.IsNullOrEmpty(ddlOdontologos.SelectedValue) ||
                string.IsNullOrEmpty(hfFechaSeleccionada.Value) ||
                string.IsNullOrEmpty(hfHoraSeleccionada.Value))
            {
                ltDisponibilidad.Text = "<div class='alert alert-danger'>Debes seleccionar odontólogo, fecha y hora.</div>";
                return;
            }

            var cita = new OdontoSysBusiness.CitaWS.cita
            {
                fecha = hfFechaSeleccionada.Value,
                horaInicio = hfHoraSeleccionada.Value,
                estado = OdontoSysBusiness.CitaWS.estadoCita.RESERVADA,
                estadoSpecified = true,
                odontologo = new OdontoSysBusiness.CitaWS.odontologo
                {
                    idOdontologo = int.Parse(ddlOdontologos.SelectedValue),
                    idOdontologoSpecified = true
                },
                recepcionista = new OdontoSysBusiness.CitaWS.recepcionista
                {
                    idRecepcionista = 1,
                    idRecepcionistaSpecified = true
                },
                paciente = new OdontoSysBusiness.CitaWS.paciente
                {
                    idPaciente = paciente.idPaciente,
                    idPacienteSpecified = true
                },
            };

            try
            {
                var clienteCita = new OdontoSysBusiness.CitaWS.CitaWAClient();
                clienteCita.cita_insertar(cita);
                //EnviarCorreoConfirmacion(cita, paciente);
                Response.AddHeader("Refresh", "1;URL=home.aspx");
                ltDisponibilidad.Text = "<div class='alert alert-success'>¡Cita registrada correctamente!</div>";

                btnConfirmarCita.Visible = false;
                pnlSemana.Visible = false;
                pnlSlots.Visible = false;
            }
            catch
            {
                ltDisponibilidad.Text = "<div class='alert alert-danger'>Ocurrió un error al registrar la cita. Intenta nuevamente.</div>";
            }
        }

        private void EnviarCorreoConfirmacion(OdontoSysBusiness.CitaWS.cita cita, OdontoSysBusiness.PacienteWS.paciente paciente)
        {
            // Obtener odontólogo y especialidad
            var clienteOdontologo = new OdontoSysBusiness.OdontologoWS.OdontologoWAClient();
            var odontologo = clienteOdontologo.odontologo_obtenerPorId(cita.odontologo.idOdontologo);

            var clienteEspecialidad = new OdontoSysBusiness.EspecialidadWS.EspecialidadWAClient();
            var especialidad = clienteEspecialidad.especialidad_obtenerPorId(odontologo.especialidad.idEspecialidad);

            // Obtener sala
            var clienteSala = new OdontoSysBusiness.SalaWS.SalaWAClient();
            var sala = clienteSala.sala_obtenerPorId(odontologo.consultorio.idSala);

            // Composición del cuerpo del mensaje
            var sb = new StringBuilder();
            sb.AppendLine($"Estimado(a) {paciente.nombre},");
            sb.AppendLine();
            sb.AppendLine("Su cita ha sido registrada correctamente con los siguientes detalles:");
            sb.AppendLine();
            sb.AppendLine($"📅 Fecha: {cita.fecha}");
            sb.AppendLine($"⏰ Hora: {cita.horaInicio}");
            sb.AppendLine($"🦷 Odontólogo: {odontologo.nombre} {odontologo.apellidos}");
            sb.AppendLine($"📚 Especialidad: {System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(especialidad.nombre.Replace('_', ' ').ToLower())}");
            sb.AppendLine($"🏥 Sala: {sala.numero} - Piso {sala.piso}");
            sb.AppendLine();
            sb.AppendLine("Gracias por confiar en Sonrisa Vital.");

            var mensaje = new MailMessage();
            mensaje.From = new MailAddress("odontosys123@gmail.com", "OdontoSys");
            mensaje.To.Add(paciente.correo);
            mensaje.Subject = "Confirmación de Cita - Sonrisa Vital";
            mensaje.Body = sb.ToString();

            var smtp = new SmtpClient("smtp.gmail.com", 587); // Cambia host y puerto
            smtp.Credentials = new System.Net.NetworkCredential("odontosys123@gmail.com", "_odontoSys321");
            smtp.EnableSsl = true;
            smtp.Send(mensaje);
        }


        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }


    }
}