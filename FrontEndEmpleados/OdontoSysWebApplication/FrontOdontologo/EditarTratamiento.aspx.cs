using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication.FrontOdontologo
{
    public partial class EditarTratamiento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idTratamiento = Session["Tratamiento"].ToString();
                CargarEspecialidades();
                CargarTratamientos();
            }
        }

        private void CargarEspecialidades()
        {
            
        }
        private void CargarTratamientos()
        {
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}