using System;
using System.Web.UI;
using OdontoSysBusiness.BO;
using OdontoSysBusiness.pacienteWS;

namespace OdontoSysFrontEnd
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string usuario = txtUsuario.Text.Trim();
                string contrasenaIngresada = txtContrasena.Text.Trim();

                // Validación básica
                if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasenaIngresada))
                {
                    lblMensaje.Text = "Por favor, complete todos los campos.";
                    return;
                }

                // Instanciar el objeto BO
                PacienteBO pacienteBO = new PacienteBO();
                paciente paciente = pacienteBO.buscarPorUsuario(usuario);

                if (paciente != null)
                {
                    // Validar contraseña
                    if (paciente.contrasenha.Equals(contrasenaIngresada))
                    {
                        // Login exitoso - guardar en sesión
                        Session["paciente"] = paciente;
                        Session["usuarioId"] = paciente.idPaciente;
                        Session["nombreUsuario"] = paciente.nombre;

                        // Redirigir a la página principal
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Contraseña incorrecta.";
                    }
                }
                else
                {
                    lblMensaje.Text = "Usuario no encontrado.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al procesar la solicitud: " + ex.Message;
            }
        }
    }
}