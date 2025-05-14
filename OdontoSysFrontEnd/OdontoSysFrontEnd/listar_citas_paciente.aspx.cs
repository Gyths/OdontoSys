using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysFrontEnd
{
    public partial class listar_citas_paciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarCitas();
            }
        }

        private void CargarCitas()
        {
            //para crear datos de ejemplo
            DataTable dt = CrearTablaCitasEjemplo();
            dgvCitas.DataSource = dt;
            dgvCitas.DataBind();
        }

        private DataTable CrearTablaCitasEjemplo()
        {
            // tabla
            DataTable dt = new DataTable();
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("NombreOdontologo", typeof(string));
            dt.Columns.Add("Estado", typeof(string));
            dt.Columns.Add("Tratamiento", typeof(string));

            // datos de ejemplo
            dt.Rows.Add(DateTime.Now.AddDays(-2), "Dra. Sofía Vargas", "Atendida", "Limpieza dental");
            dt.Rows.Add(DateTime.Now.AddDays(-24), "Dr. Juan Pérez", "Cancelada", "Ortodoncia");
            dt.Rows.Add(DateTime.Now.AddDays(-48), "Dr. Carlos López", "Cancelada", "Revisión general");
            dt.Rows.Add(DateTime.Now.AddDays(-59), "Dra. María González", "Cancelada", "Blanqueamiento");
            dt.Rows.Add(DateTime.Now.AddDays(-72), "Dr. Roberto Silva", "Cancelada", "Extracción molar");
            dt.Rows.Add(DateTime.Now.AddDays(-85), "Dra. Ana Rodríguez", "Cancelada", "Empaste dental");
            dt.Rows.Add(DateTime.Now.AddMonths(-100), "Dr. Juan Pérez", "Cancelada", "Radiografía");

            return dt;
        }

        protected void dgvCitas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvCitas.PageIndex = e.NewPageIndex;
            CargarCitas();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            // página principal
            Response.Redirect("index.aspx");
        }

    }
}