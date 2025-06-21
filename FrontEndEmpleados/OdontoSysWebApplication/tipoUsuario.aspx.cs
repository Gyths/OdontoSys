using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication
{
    public partial class tipoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            string tipo = Request.Form["userType"];
            if (string.IsNullOrEmpty(tipo))
            {
                return;
            }
            Session["TipoUsuario"] = tipo;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}