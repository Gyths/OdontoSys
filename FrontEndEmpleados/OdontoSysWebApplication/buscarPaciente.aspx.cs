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
                gvPacientes.Visible = false;
                lblMensaje.Visible = false;
            }
                
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellido = txtApellido.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string documento = txtDNI.Text.Trim();

            try
            {
                BindingList<PacienteWS.paciente> resultado;
                 resultado = pacienteBO.paciente_listarTodos();
                if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellido) && string.IsNullOrEmpty(telefono) && string.IsNullOrEmpty(documento))
                {
                    resultado = pacienteBO.paciente_listarTodos();
                }
                else
                {
                    if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
                    {
                        lblMensaje.Text = "Por favor ingresa nombre y apellido como minimo para una busqueda especifica";
                        lblMensaje.CssClass = "text-danger";
                        lblMensaje.Visible = true;
                        return;
                    }

                    if (!string.IsNullOrEmpty(telefono))
                    {
                        //resultado = pacienteBO.paciente_buscarPorNombreApellidoTelefono(nombre, apellido, telefono);
                    }
                    else if (!string.IsNullOrEmpty(documento))
                    {
                        //resultado = pacienteBO.paciente_buscarPorNombreApellido(nombre, apellido);
                    }
                    else
                    {
                        //resultado = pacienteBO.paciente_buscarPorNombreApellido(nombre, apellido);
                    }
                }
                gvPacientes.DataSource = resultado;
                gvPacientes.DataBind();
                lblMensaje.Visible = false;
                bool hayDatos = resultado != null && resultado.Count > 0;
                gvPacientes.Visible = hayDatos;

                if (!hayDatos)
                {
                    lblMensaje.Text = "No se encontraron pacientes.";
                    lblMensaje.CssClass = "text-warning mb-3";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al buscar pacientes: " + ex.Message);
                lblMensaje.Text = "Ocurrió un error al buscar pacientes.";
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