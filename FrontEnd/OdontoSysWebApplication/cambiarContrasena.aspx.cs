using System;
using System.Text.RegularExpressions;
using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;
using OdontoSysBusiness.Xtras;

namespace OdontoSysWebApplication
{
    public partial class cambiarContrasena : System.Web.UI.Page
    {
        private PacienteBO pacienteBO = new PacienteBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Paciente"] == null)
                {
                    Response.Redirect("inicioSesion.aspx");
                }
            }
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            var paciente = Session["Paciente"] as paciente;
            if (paciente == null) return;

            string actual = txtContrasenaActual.Text.Trim();
            string nueva = txtNuevaContrasena.Text.Trim();
            string confirmar = txtConfirmarContrasena.Text.Trim();

            lblMensajeContrasena.CssClass = "d-block mt-2 text-danger";
            lblMensajeContrasena.Text = "";

            if (string.IsNullOrEmpty(actual) || string.IsNullOrEmpty(nueva) || string.IsNullOrEmpty(confirmar))
            {
                lblMensajeContrasena.Text = "Completa todos los campos.";
                return;
            }

            if (nueva.Length < 6 || !Regex.IsMatch(nueva, @"^[A-Za-z0-9]+$"))
            {
                lblMensajeContrasena.Text = "La nueva contraseña debe tener al menos 6 caracteres y solo contener letras y números.";
                return;
            }

            if (nueva != confirmar)
            {
                lblMensajeContrasena.Text = "La nueva contraseña no coincide con la confirmación.";
                return;
            }

            string actualHash = PasswordHelper.HashPassword(actual);
            if (actualHash != paciente.contrasenha)
            {
                lblMensajeContrasena.Text = "La contraseña actual es incorrecta.";
                return;
            }

            try
            {
                paciente.contrasenha = PasswordHelper.HashPassword(nueva);
                pacienteBO.paciente_modificar(paciente);
                Session["Paciente"] = paciente;

                lblMensajeContrasena.CssClass = "d-block mt-2 text-success";
                lblMensajeContrasena.Text = "Contraseña actualizada correctamente.";
            }
            catch (Exception ex)
            {
                lblMensajeContrasena.Text = $"Error al cambiar contraseña: {ex.Message}";
            }
        }
    }
}
