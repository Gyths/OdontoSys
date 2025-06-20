using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class buscarPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Opcional: inicialización si es necesario
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Ejemplo básico: reemplazar por llamada a tu web service real
            var pacienteBO = new PacienteBO();

            try
            {
                var pacientes = pacienteBO.paciente_listarTodos();
                gvPacientes.DataSource = pacientes;
                gvPacientes.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar pacientes : " + ex.Message);
                gvPacientes.DataSource = null;
                gvPacientes.DataBind();
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