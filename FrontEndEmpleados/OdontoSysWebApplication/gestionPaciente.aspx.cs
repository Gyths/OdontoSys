using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPacienteSeleccionado"] != null && int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
                {
                    CargarPaciente(idPaciente);
                    CargarCitasPaciente(idPaciente);
                }
                else
                {
                    // Manejo alternativo si no se encuentra el ID
                    Response.Redirect("buscarPaciente.aspx");
                }
            }
        }

        private void CargarPaciente(int id)
        {
            var pacienteBO = new PacienteBO(); // Asumiendo existencia de esta clase de negocio
            var paciente = pacienteBO.paciente_obtenerPorId(id); // Llama al WS

            if (paciente != null)
            {
                txtNombre.Text = paciente.nombre;
                txtApellido.Text = paciente.apellidos;
                txtDocumento.Text = paciente.numeroDocumento;
                txtCorreo.Text = paciente.correo;
                txtTelefono.Text = paciente.telefono;
                txtUsuario.Text = paciente.nombreUsuario;
            }
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
            if (Session["idPacienteSeleccionado"] != null && int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                var pacienteBO = new PacienteBO();

                var original = pacienteBO.paciente_obtenerPorId(idPaciente);

                original.correo = txtCorreo.Text;
                original.telefono = txtTelefono.Text;
                original.nombreUsuario = txtUsuario.Text;

                pacienteBO.paciente_modificar(original);

                

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
            Response.Redirect("buscarPaciente.aspx");
        }

        private void CargarCitasPaciente(int idPaciente)
        {
            var citaBO = new CitaBO();

            var paciente = new CitaWS.paciente { idPaciente = idPaciente };

            try
            {
                var citas = citaBO.cita_listarPorPaciente(paciente);
                gvCitas.DataSource = citas;
                gvCitas.DataBind();
            }
            catch (Exception ex) 
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas del paciente : " + ex.Message);
                gvCitas.DataSource = null;
                gvCitas.DataBind();

            }
        }
    }
}