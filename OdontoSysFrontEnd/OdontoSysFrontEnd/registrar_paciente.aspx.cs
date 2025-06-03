using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysModel.Users;

namespace OdontoSysFrontEnd
{
    public partial class registrar_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            Paciente paciente = new Paciente
            {
                Nombre = txtNombre.Text,
                Apellidos = TxtApellido.Text,
                Correo = txtCorreo.Text,
                Dni = txtDNI.Text,
                Telefono = txtTelefono.Text,
                NombreUsuario = txtUsuario.Text,
                Contrasenha = txtContrasena.Text
            };
            // Crear instancia del BO
            //PacienteBO pacienteBO = new PacienteBO();

            // Llamar al método Insertar del BO
            //pacienteBO.Insertar(paciente);

            // Redirigir o mostrar mensaje de éxito
            //Response.Redirect("index.aspx");
        }
    }
}