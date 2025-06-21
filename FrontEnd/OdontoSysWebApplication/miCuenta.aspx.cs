using System;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using OdontoSysBusiness;
using OdontoSysBusiness.Xtras;

namespace OdontoSysWebApplication
{
    public partial class miCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verificar si hay sesión activa
        }

        protected void btnIrADatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizarDatos.aspx");
        }

        protected void btnIrAContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContrasena.aspx");
        }
        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("EliminarCuenta.aspx");
        }
    }
}

