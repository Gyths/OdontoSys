using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class gestionOdontologo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idOdontologoSeleccionado"] != null && int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int id))
                {
                    CargarOdontologo(id);
                }
                else
                {
                    Response.Redirect("buscarOdontologo.aspx"); // redirigir si no hay sesión
                }
            }
        }

        private void CargarOdontologo(int id)
        {
            // Simulación. Reemplazar con la llamada real al servicio web.
            var odontologoBO = new OdontologoBO(); // Método ficticio

            OdontologoWS.odontologo odontologo = odontologoBO.odontologo_obtenerPorId(id);

            // Llenar campos
            txtNombre.Text = odontologo.nombre;
            txtApellido.Text = odontologo.apellidos;
            txtDocumento.Text = odontologo.numeroDocumento;
            txtEspecialidad.Text = odontologo.especialidad.nombre;
            txtCorreo.Text = odontologo.correo;
            txtTelefono.Text = odontologo.telefono;
            txtUsuario.Text = odontologo.nombreUsuario;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtUsuario.ReadOnly = false;

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null && int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int id))
            {
                var odontologoBO = new OdontologoBO();

                var original = odontologoBO.odontologo_obtenerPorId(id); // obtener objeto completo

                original.correo = txtCorreo.Text;
                original.telefono = txtTelefono.Text;
                original.nombreUsuario = txtUsuario.Text;

                odontologoBO.odontologo_modificar(original);

                // Volver a modo solo lectura
                txtCorreo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtUsuario.ReadOnly = true;

                btnGuardar.Visible = false;
                btnEditar.Visible = true;
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarOdontologo.aspx");
        }
    }
}