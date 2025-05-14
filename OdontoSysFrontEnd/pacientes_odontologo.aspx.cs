using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysFrontEnd
{
    public partial class listar_pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarPacientes();
            }
        }
        private void CargarPacientes()
        {
            // En un entorno real, aquí se cargarían los datos desde una base de datos
            // Para este ejemplo, creamos un DataTable con datos de ejemplo
            DataTable dt = new DataTable();
            dt.Columns.Add("DNI", typeof(string));
            dt.Columns.Add("NombreCompleto", typeof(string));
            dt.Columns.Add("Telefono", typeof(string));
            dt.Columns.Add("Correo", typeof(string));

            // Agregamos algunos registros de ejemplo
            dt.Rows.Add("45678912", "Juan Pérez", "999999999", "juan.perez@correo.com");
            dt.Rows.Add("12345678", "María González", "999999999", "maria.gonzalez@correo.com");
            dt.Rows.Add("87654321", "Carlos Rodríguez", "999999999", "carlos.rodriguez@correo.com");
            dt.Rows.Add("23456789", "Ana López", "999999999", "ana.lopez@correo.com");
            dt.Rows.Add("34567891", "Pedro Martínez", "999999999", "pedro.martinez@correo.com");

            dgvPacientes.DataSource = dt;
            dgvPacientes.DataBind();
        }

        protected void dgvCitas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPacientes.PageIndex = e.NewPageIndex;
            CargarPacientes();
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        protected void lbHistoriaClinica_Click(object sender, EventArgs e)
        {

            //LinkButton btn = (LinkButton)sender;
            //string dni = btn.CommandArgument;
            //Session["PacienteDNI"] = dni;
            Response.Redirect("index.aspx");
        }
        protected void lbVerPagos_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }
    }
}