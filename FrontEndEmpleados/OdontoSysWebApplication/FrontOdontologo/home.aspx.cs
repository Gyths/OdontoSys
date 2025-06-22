using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.PacienteWS;

namespace OdontoSysWebApplication
{
    
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // … tu lógica actual …
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            // Anular solo la sesión del paciente
            //Session["Paciente"] = null;

            // Si quieres limpiar todo:
            // Session.Clear();
            // Session.Abandon();

            // Redirigir al login
            //Response.Redirect("~/inicioSesion.aspx");
        }
    }
}