using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class buscarPaciente : System.Web.UI.Page
    {
        private PacienteBO pacienteBO = new PacienteBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTodosLosPacientes();
            }
        }


        private void CargarTodosLosPacientes()
        {
            try
            {
                lblMensaje.Visible = false;
                BindingList<PacienteWS.paciente> resultado = pacienteBO.paciente_listarTodos();

                gvPacientes.DataSource = resultado;
                gvPacientes.DataBind();

                bool hayDatos = resultado != null && resultado.Count > 0;
                gvPacientes.Visible = hayDatos;

                if (!hayDatos)
                {
                    lblMensaje.Text = "No hay pacientes registrados.";
                    lblMensaje.CssClass = "text-info mb-3";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar todos los pacientes: " + ex.Message);
                lblMensaje.Text = "Ocurrió un error al cargar la lista de pacientes.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                gvPacientes.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string documento = txtDNI.Text.Trim();


            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido) && string.IsNullOrEmpty(telefono) && string.IsNullOrEmpty(documento))
            {
                CargarTodosLosPacientes();
                return;
            }

            try
            {
                BindingList<PacienteWS.paciente> resultado;


                if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
                {
                    lblMensaje.Text = "Por favor ingresa nombre y apellido como mínimo para una búsqueda específica.";
                    lblMensaje.CssClass = "text-danger";
                    lblMensaje.Visible = true;
                    gvPacientes.Visible = false;
                    return;
                }


                if (!string.IsNullOrEmpty(telefono))
                {
                    resultado = pacienteBO.paciente_buscarPorNombreApellidoTelefono(nombre, apellido, telefono);
                }
                else
                {

                    resultado = pacienteBO.paciente_buscarPorNombreApellido(nombre, apellido);
                }

                gvPacientes.DataSource = resultado;
                gvPacientes.DataBind();
                lblMensaje.Visible = false;

                bool hayDatos = resultado != null && resultado.Count > 0;
                gvPacientes.Visible = hayDatos;

                if (!hayDatos)
                {
                    lblMensaje.Text = "No se encontraron pacientes con los criterios especificados.";
                    lblMensaje.CssClass = "text-warning mb-3";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al buscar pacientes: " + ex.Message);
                lblMensaje.Text = "Ocurrió un error al realizar la búsqueda.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                gvPacientes.DataSource = null;
                gvPacientes.DataBind();
                gvPacientes.Visible = false;
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Gestionar")
            {
                try
                {
                    int idPaciente = Convert.ToInt32(e.CommandArgument);
                    Session["idPacienteSeleccionado"] = idPaciente;
                    Response.Redirect("gestionPaciente.aspx");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error en RowCommand: " + ex.Message);
                }
            }
        }
    }
}