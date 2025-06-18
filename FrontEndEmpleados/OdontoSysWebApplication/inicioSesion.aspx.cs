using System;
using System.Text.RegularExpressions;  // <<< Asegúrate de importar esto
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.PacienteWS;
using OdontoSysWebApplication.Xtras;
namespace OdontoSysWebApplication
{
    public partial class inicioSesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltMensaje.Text = "";
                // Si quisieras validación instantánea:
                // txtContrasenha.AutoPostBack = true;
                // txtContrasenha.TextChanged += TxtContrasenha_TextChanged;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtContrasenha.Text.Trim();

           
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                ShowError("Por favor, ingresa usuario y contraseña.");
                return;
            }

          
            if (!Regex.IsMatch(contrasena, @"^[A-Za-z0-9]+$"))
            {
                ShowError("La contraseña sólo puede contener letras y números (no caracteres especiales).");
                return;
            }

            try
            {
                
                // Intentar con Recepcionista
                var recepcionistaBO = new RecepcionistaBO();
                var recepcionista = recepcionistaBO.recepcionista_obtenerPorUsuarioContrasenha(usuario, PasswordHelper.HashPassword(contrasena));
                if (recepcionista != null && recepcionista.idRecepcionista > 0)
                {
                    Session["TipoCuenta"] = "recepcionista";
                    Session["Usuario"] = recepcionista;
                    Response.Redirect("~/home.aspx");
                    return;
                }

                // Intentar con Odontólogo
                var odontologoBO = new OdontologoBO();
                var odontologo = odontologoBO.odontologo_obtenerPorUsuarioContrasenha(usuario, PasswordHelper.HashPassword(contrasena));
                if (odontologo != null && odontologo.idOdontologo > 0)
                {
                    Session["TipoCuenta"] = "odontologo";
                    Session["Usuario"] = odontologo;
                    Response.Redirect("~/home.aspx");
                    return;
                }

                ShowError("Usuario o contraseña inválidos.");
            }
            catch (Exception)
            {
                ShowError("Ocurrió un error al conectarse con el sistema. Intenta más tarde.");
            }
        }

       
        /*
        private void TxtContrasenha_TextChanged(object sender, EventArgs e)
        {
            string pwd = txtContrasenha.Text;
            if (!Regex.IsMatch(pwd, @"^[A-Za-z0-9]+$"))
                ShowError("Sólo se permiten letras y números en la contraseña.");
            else
                ltMensaje.Text = "";
        }
        */

        private void ShowError(string mensaje)
        {
            ltMensaje.Text = $"<div class='alert alert-danger'>{mensaje}</div>";
        }
    }
}