using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication.FrontOdontologo
{
    public partial class CitasPorAtender : System.Web.UI.Page
    {
        private CitaBO boCita;
        private PacienteBO boPaciente;
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
                foreach ( var cita in listaCitas )
                {
                    boPaciente = new PacienteBO();
                    var paciente = new PacienteWS.paciente();
                    paciente = boPaciente.paciente_obtenerPorId(cita.paciente.idPaciente);
                    var pacienteCita = new CitaWS.paciente
                    {
                        nombre = paciente.nombre
                    };
                    cita.paciente.nombre = pacienteCita.nombre;
                }
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

        protected void gvCitas_RowDataBound(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Atender")
            {
                string idCita = e.CommandArgument.ToString();
                Response.Redirect($"/FrontOdontologo/AtenderCita.aspx?idCita={idCita}");
            }
        }
    }
}