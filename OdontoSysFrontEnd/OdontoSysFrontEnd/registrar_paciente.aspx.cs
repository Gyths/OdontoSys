using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness.pacienteWS;

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
            paciente paciente = new paciente
            {
                nombre = txtNombre.Text,
                apellidos = txtApellido.Text,
                correo = txtCorreo.Text,
                numeroDocumento = txtNumeroDocumento.Text,
                telefono = txtTelefono.Text,
                nombreUsuario = txtNombreUsuario.Text,
                contrasenha = txtContrasena.Text
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