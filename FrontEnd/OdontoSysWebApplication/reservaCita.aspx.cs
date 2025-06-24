using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Mail;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness;
using OdontoSysBusiness.CitaWS;

namespace OdontoSysWebApplication
{
    public partial class reservaCita : System.Web.UI.Page
    {
        private OdontologoBO odontologoBO = new OdontologoBO();
        private EspecialidadBO especialidadBO = new EspecialidadBO();
        private SalaBO salaBO = new SalaBO();   
        private TurnoBO turnoBO = new TurnoBO();    
        private CitaBO citaBO = new CitaBO();   
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
                var especialidades = especialidadBO.especialidad_listarTodos();

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


            var odontologos = odontologoBO.odontologo_listarPorEspecialidad(especialidad);

            ddlOdontologos.Items.Add(new ListItem("-- Seleccione un odontólogo --", ""));
            foreach (var o in odontologos)
            {
                string nombreCompleto = $"{o.nombre} {o.apellidos}".PadRight(27);
                string display = $"{nombreCompleto} {o.puntuacionPromedio.ToString()} ⭐";
                ddlOdontologos.Items.Add(new ListItem(display, o.idOdontologo.ToString()));
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

            var turnos = turnoBO.turno_listarPorOdontologo(odontologoTurno);

            var odontologoCita = new OdontoSysBusiness.CitaWS.odontologo
            {
                idOdontologo = idOdontologo,
                idOdontologoSpecified = true
            };

            var citas = citaBO.cita_listarPorOdontologoFechas(odontologoCita, fechaInicioStr, fechaFinStr);

            var disponibilidad = CalcularHorasDisponibles(turnos, citas, fechaInicio);

            ltSlots.Text = GenerarHTMLDisponibilidad(disponibilidad);
            pnlSlots.Visible = true;
        }

        private Dictionary<DateTime, List<TimeSpan>> CalcularHorasDisponibles(
            BindingList<OdontoSysBusiness.TurnoWS.turno> turnos,
            BindingList<OdontoSysBusiness.CitaWS.cita> citas,
            DateTime fechaInicio)
        {


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
                if (cita.estado.ToString() == "CANCELADA") continue;
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
            var paciente = Session["Paciente"] as OdontoSysBusiness.PacienteWS.paciente;

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
                paciente = new OdontoSysBusiness.CitaWS.paciente
                {
                    idPaciente = paciente.idPaciente,
                    idPacienteSpecified = true
                },
            };

            try
            {
                citaBO.cita_insertar(cita);
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

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }


    }
}