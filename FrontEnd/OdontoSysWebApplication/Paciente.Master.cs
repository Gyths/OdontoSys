using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Página actual
            string paginaActual = System.IO.Path.GetFileName(Request.Url.AbsolutePath);

            // Páginas públicas
            string[] paginasLibres = { "inicioSesion.aspx", "crearCuenta.aspx" };

            // Si es página protegida y no hay sesión, redirige
            bool requiereSesion = !paginasLibres.Contains(paginaActual, StringComparer.OrdinalIgnoreCase);
            bool sesionInvalida = Session["Paciente"] == null;

            if (requiereSesion && sesionInvalida)
                Response.Redirect("~/inicioSesion.aspx");
        }
    }
}