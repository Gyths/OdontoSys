using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication.FrontOdontologo
{
    public partial class CitasPorAtender : System.Web.UI.Page
    {
        private CitaBO boCita;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCitas();
            }
        }
        private void CargarCitas() 
        {
            try
            {
                boCita = new CitaBO();
                var odontologoSes = Session["Usuario"] as OdontologoWS.odontologo;
                var odontologo = new CitaWS.odontologo
                {
                    idOdontologo = odontologoSes.idOdontologo,
                    idOdontologoSpecified = true
                };
                var listaCitas = boCita.cita_listarPorOdontologo(odontologo);
                gvCitas.DataSource = listaCitas;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas: " + ex.Message);
                // Asignar null para que el GridView muestre el mensaje de "EmptyDataText"
                gvCitas.DataSource = null;
                gvCitas.DataBind();
            }
        }

        protected void gvCitas_RowDataBound()
        {

        }
    }
}