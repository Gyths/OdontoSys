using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness; // <-- EJEMPLO: Cambia esto por tu namespace correcto

namespace OdontoSysWebApplication
{
    public partial class ListarDoctores : System.Web.UI.Page
    {
        
        private OdontologoBO boOdontologo;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Cargar los datos solo en la primera carga de la página, no en postbacks.
            if (!IsPostBack)
            {
                CargarDoctores();
            }
        }

        private void CargarDoctores()
        {
            try
            {
             
                boOdontologo = new OdontologoBO();

                var listaDoctores = boOdontologo.odontologo_listarTodos();

              
                gvDoctores.DataSource = listaDoctores;

                
                gvDoctores.DataBind();
            }
            catch (Exception ex)
            {
                
                // lblError.Text = "Ocurrió un error al cargar los doctores: " + ex.Message;
                // lblError.Visible = true;

                
                System.Diagnostics.Debug.WriteLine("Error al cargar doctores: " + ex.Message);

                // Asignar null para que el GridView muestre el mensaje de "EmptyDataText"
                gvDoctores.DataSource = null;
                gvDoctores.DataBind();
            }
        }


        protected void gvDoctores_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var doctor = (OdontologoWS.odontologo)e.Row.DataItem;

                int columnaTipoEsp = 5; // cambia este número si tu columna está en otra posición

                if (doctor.especialidad.idEspecialidad == 1)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Odontología General";
                }
                else if (doctor.especialidad.idEspecialidad == 2)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Ortodoncia";
                }
                else if (doctor.especialidad.idEspecialidad == 3)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Endodoncia";
                }
                else if (doctor.especialidad.idEspecialidad == 4)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Cirugia";
                }
                else if (doctor.especialidad.idEspecialidad == 5)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Pediatra";
                }
            }
        }
    }
}