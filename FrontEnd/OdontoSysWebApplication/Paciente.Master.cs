using System;
using System.Linq;
using OdontoSysBusiness.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class Paciente : System.Web.UI.MasterPage
    {
        protected string paginaActiva = "";

        public string InicialPaciente
        {
            get
            {
                var paciente = Session["Paciente"] as paciente;
                return (!string.IsNullOrEmpty(paciente?.nombre)) ? paciente.nombre.Substring(0, 1).ToUpper() : "?";
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
            string[] paginasLibres = { "inicioSesion.aspx", "crearCuenta.aspx" };

            if (!paginasLibres.Contains(PaginaActual, StringComparer.OrdinalIgnoreCase) &&
                Session["Paciente"] == null)
            {
                Response.Redirect("~/inicioSesion.aspx");
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

