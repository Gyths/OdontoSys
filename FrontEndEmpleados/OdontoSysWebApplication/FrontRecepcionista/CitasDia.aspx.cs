using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;

// Ya no necesitamos los 'using' para los namespaces de los servicios
// porque seremos explícitos en el código.

namespace OdontoSysWebApplication
{
    public partial class CitasDia : System.Web.UI.Page
    {
        private CitaBO boCita;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                var odontologoDeSesion = Session["Doctor"] as OdontoSysWebApplication.OdontologoWS.odontologo;

              
                if (odontologoDeSesion != null)
                {                    var odontologoParaCitas = new OdontoSysWebApplication.CitaWS.odontologo();
                    odontologoParaCitas.idOdontologo = odontologoDeSesion.idOdontologo;

                    
                    CargarCitas(odontologoParaCitas);
                }
            }
        }

       
        private void CargarCitas(OdontoSysWebApplication.CitaWS.odontologo odontologo)
        {
            try
            {
                boCita = new CitaBO();
                string fechaHoy = DateTime.Now.ToString("yyyy-MM-dd");

                h2Titulo.InnerText = $"Citas para Hoy ({DateTime.Now.ToShortDateString()})";

                var listaCitas = boCita.cita_listarPorOdontologoFechas(odontologo, fechaHoy, fechaHoy);

                gvCitasDia.DataSource = listaCitas;
                gvCitasDia.DataBind();
            }
            catch (Exception ex)
            {
                lblError.Visible = true;
                lblError.Text = "Error al cargar las citas: " + ex.Message;
                System.Diagnostics.Debug.WriteLine("Error en CargarCitas: " + ex.ToString());
            }
        }

        protected void gvCitasDia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Atender")
            {
                string idCita = e.CommandArgument.ToString();
                Response.Redirect($"RegistrarAtencion.aspx?idCita={idCita}");
            }
        }
    }
}