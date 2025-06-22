using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;


namespace OdontoSysWebApplication
{
    public partial class Recepcionista : System.Web.UI.MasterPage
    {
        protected string paginaActiva = "";

        public string InicialRecepcionista
        {
            get
            {
                var recepcionista = Session["Usuario"] as RecepcionistaWS.recepcionista;
                return (!string.IsNullOrEmpty(recepcionista?.nombre)) ? recepcionista.nombre.Substring(0, 1).ToUpper() : "?";
            }
        }

        public string PaginaActual
        {
            get
            {
                return System.IO.Path.GetFileName(Request.Url.AbsolutePath);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si requiere sesión
            string[] paginasLibres = { "inicioSesion.aspx", "crearCuenta.aspx", "tipoUsuario.aspx" };

            if (!paginasLibres.Contains(PaginaActual, StringComparer.OrdinalIgnoreCase) &&
                Session["Usuario"] == null)
            {
                Response.Redirect("~/tipoUsuario.aspx");
            }
        }
        protected void Page_PreRender(object sender, EventArgs e)
        {
            // Establecer página activa justo antes de que se renderice
            paginaActiva = PaginaActual;
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}