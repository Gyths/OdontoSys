using System;
using OdontoSysBusiness.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                VerificarSesionPaciente();
        }

        private void VerificarSesionPaciente()
        {
            var paciente = Session["Paciente"] as paciente;
            if (paciente == null)
            {
                // Redirigir si no hay sesión activa
                Response.Redirect("~/inicioSesion.aspx");
            }
            else
            {
                // Aquí podrías mostrar información del paciente si lo deseas
                // ej: lblNombrePaciente.Text = paciente.nombre + " " + paciente.apellidos;
            }
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}
