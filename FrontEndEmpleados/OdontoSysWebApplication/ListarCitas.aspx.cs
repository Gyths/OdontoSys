using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class ListarCitas : System.Web.UI.Page
    {
        private CitaBO boCita;
        private PacienteBO boPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var paciente = Session["pacienteSeleccionado"] as CitaWS.paciente;

                if (paciente != null)
                {
                    CargarCitas(paciente);
                }
                else
                {
                    Response.Redirect("ListarPacientes.aspx"); // O muestra un mensaje
                }
            }
        }

        private void CargarCitas(CitaWS.paciente paciente)
        {
            try
            {
                var citaService = new CitaWS.cita();
                var citas = boCita.cita_listarPorPaciente(paciente); // Aquí usas el objeto completo
                gvCitas.DataSource = citas;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                // Manejar errores
            }
        }
    }
}