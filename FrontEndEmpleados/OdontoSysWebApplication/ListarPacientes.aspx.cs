using System;
using System.Web.UI;
using System.Web.UI.WebControls;
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


        protected void gvPacientes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var paciente = (PacienteWS.paciente)e.Row.DataItem;

                int columnaTipoDoc = 4; // cambia este número si tu columna está en otra posición

                if (paciente.tipoDocumento.idTipoDocumento == 1)
                {
                    e.Row.Cells[columnaTipoDoc].Text = "DNI";
                }
                else
                {
                    e.Row.Cells[columnaTipoDoc].Text = "Carné de Extranjería";
                }
            }
        }

        protected void gvPacientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "VerCitas")
            {
                try
                {
                    int idPaciente = Convert.ToInt32(e.CommandArgument);
                    boPaciente = new PacienteBO();
                    var paciente = boPaciente.paciente_obtenerPorId(idPaciente);

                    Session["pacienteSeleccionado"] = paciente;
                    Response.Redirect("ListarCitas.aspx");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error en RowCommand: " + ex.Message);
                }
            }
        }
    }
}