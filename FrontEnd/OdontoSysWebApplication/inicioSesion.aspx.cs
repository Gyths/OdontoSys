using System;
using System.Text.RegularExpressions;
using OdontoSysBusiness;
using OdontoSysBusiness.Xtras;

namespace OdontoSysWebApplication
{
    public partial class inicioSesion : System.Web.UI.Page
    {
        private PacienteBO pacienteBO;

        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }

        public inicioSesion()
        {
            this.PacienteBO = new PacienteBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ltMensaje.Text = "";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuarioIngresado = txtUsuario.Text.Trim();
            string contrasenaIngresada = txtContrasenha.Text.Trim();

            if (!EsEntradaValida(usuarioIngresado, contrasenaIngresada))
                return;

            AutenticarPaciente(usuarioIngresado, contrasenaIngresada);
        }

        private bool EsEntradaValida(string usuario, string contrasena)
        {
            if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(contrasena))
            {
                MostrarMensajeError("Por favor, ingresa usuario y contraseña.");
                return false;
            }

            if (!Regex.IsMatch(contrasena, @"^[A-Za-z0-9]+$"))
            {
                MostrarMensajeError("La contraseña solo puede contener letras y números.");
                return false;
            }

            return true;
        }

        private void AutenticarPaciente(string usuario, string contrasena)
        {
            try
            {
                string contrasenaHasheada = PasswordHelper.HashPassword(contrasena);
                var paciente = this.PacienteBO.paciente_obtenerPorUsuarioContrasenha(usuario, contrasenaHasheada);

                if (paciente != null && paciente.idPaciente > 0)
                {
                    Session["Paciente"] = paciente;
                    Response.Redirect("~/home.aspx");
                }
                else
                {
                    MostrarMensajeError("Usuario o contraseña inválidos.");
                }
            }
            catch
            {
                MostrarMensajeError("Ocurrió un error al conectarse con el servicio. Intenta más tarde.");
            }
        }

        private void MostrarMensajeError(string mensaje)
        {
            ltMensaje.Text = $"<div class='alert alert-danger'>{mensaje}</div>";
        }
    }
}
