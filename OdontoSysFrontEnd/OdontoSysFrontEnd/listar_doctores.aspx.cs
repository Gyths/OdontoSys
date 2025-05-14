using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysFrontEnd
{
    public partial class listar_doctores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarDoctores();
            }
        }

        private void CargarDoctores()
        {
            //para crear datos de ejemplo
            DataTable dt = CrearTablaDoctores();

            dgvDoctores.DataSource = dt;
            dgvDoctores.DataBind();
        }

        private DataTable CrearTablaDoctores()
        {

            // tabla
            DataTable dt = new DataTable();
            dt.Columns.Add("NombreOdontologo", typeof(string));
            dt.Columns.Add("Especialidad", typeof(string));
            dt.Columns.Add("Puntuacion", typeof(double));

            // datos de ejemplo
            dt.Rows.Add("Dra. Sofía Vargas", "Odontologo General", 8.77);
            dt.Rows.Add("Dr. Juan Pérez", "Ortodoncista", 9.11);
            dt.Rows.Add("Dr. Carlos López", "Odontologo General", 8.56);
            dt.Rows.Add("Dra. María González", "Prostodoncista", 7.94);
            dt.Rows.Add("Dr. Roberto Silva", "Periodoncista", 8.69);
            dt.Rows.Add("Dra. Ana Rodríguez", "Periodoncista", 9.02);
            dt.Rows.Add("Dr. Juan Pérez", "Radiologo", 9.55);

            return dt;
        }

        protected void dgvDoctores_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvDoctores.PageIndex = e.NewPageIndex;
            CargarDoctores();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            // página principal
            Response.Redirect("index.aspx");
        }
    }
}