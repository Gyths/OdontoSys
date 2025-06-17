using System;
using System.Web.UI;
using OdontoSysWebApplication.OdontoSysBusiness; 

namespace OdontoSysWebApplication
{
    public partial class ListarPacientes : System.Web.UI.Page
    {
        
        private PacienteBO boPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }

        private void CargarPacientes()
        {
            try
            {
      
                boPaciente = new PacienteBO();
                var listaPacientes = boPaciente.paciente_listarTodos();
                gvPacientes.DataSource = listaPacientes;
                gvPacientes.DataBind();
            }
            catch (Exception ex)
            {
              
                System.Diagnostics.Debug.WriteLine("Error al cargar pacientes: " + ex.Message);
                gvPacientes.DataSource = null;
                gvPacientes.DataBind();
            }
        }
    }
}