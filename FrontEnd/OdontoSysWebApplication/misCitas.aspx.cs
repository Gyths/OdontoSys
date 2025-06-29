using System;
using System.Text;
using System.Web.UI;
using System.Globalization;
using OdontoSysBusiness.CitaWS;
using OdontoSysBusiness.EspecialidadWS;
using OdontoSysBusiness.OdontologoWS;
using OdontoSysBusiness.PacienteWS;
using System.Web.UI.WebControls;
using OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class misCitas : System.Web.UI.Page
    {
        private CitaBO citaBO;
        private OdontologoBO odontologoBO;
        private EspecialidadBO especialidadBO;

        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }

        public misCitas()
        {
            this.CitaBO = new CitaBO();
            this.OdontologoBO = new OdontologoBO();
            this.EspecialidadBO = new EspecialidadBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarCitasPaciente();
        }

        private void CargarCitasPaciente()
        {
            var paciente = Session["Paciente"] as OdontoSysBusiness.PacienteWS.paciente;
            if (paciente == null) return;

            string estadoSeleccionado = ddlEstado.SelectedValue;

            var citas = this.CitaBO.cita_listarPorPaciente(paciente.idPaciente);

            if (citas == null)
            {
                ltCitas.Text = "<div class='alert alert-warning'>No tienes citas registradas.</div>";
                return;
            }

            var sb = new StringBuilder();
            foreach (var cita in citas)
            {
                if (cita.estado.ToString() != estadoSeleccionado)
                    continue;
                var especialidad = this.EspecialidadBO.especialidad_obtenerPorId(cita.odontologo.especialidad.idEspecialidad);

                string badgeColor = GetBadgeColor(cita.estado.ToString());

                sb.AppendLine("<div class='card mb-3 shadow-sm'>");
                sb.AppendLine("<div class='card-body'>");
                sb.AppendLine($"<h5 class='card-title'>Fecha: {cita.fecha} - Hora: {cita.horaInicio}</h5>");
                sb.AppendLine($"<p class='card-text'><strong>Odontólogo:</strong> {cita.odontologo.nombre} {cita.odontologo.apellidos}</p>");
                sb.AppendLine($"<p class='card-text'><strong>Especialidad:</strong> {especialidad.nombre}</p>");
                sb.AppendLine($"<p class='card-text'><strong>Estado:</strong> <span class='badge bg-{badgeColor}'>{ToTitleCase(cita.estado.ToString())}</span></p>");

                sb.AppendLine("<form method='post'>");
                sb.AppendLine($"<a href='gestionCita.aspx?id={cita.idCita}' class='btn btn-primary btn-sm'>Gestionar</a>");
                sb.AppendLine("</form>");

                sb.AppendLine("</div></div>");
            }

            ltCitas.Text = sb.ToString();
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

        private string ToTitleCase(string input)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarCitasPaciente();
        }

        protected void btnGestionar_Command(object sender, CommandEventArgs e)
        {
            if (int.TryParse(e.CommandArgument.ToString(), out int idCita))
            {
                var cita = this.CitaBO.cita_obtenerPorId(idCita);

                if (cita != null)
                {
                    Session["CitaSeleccionada"] = cita;
                    Response.Redirect("gestionCita.aspx");
                }
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}
