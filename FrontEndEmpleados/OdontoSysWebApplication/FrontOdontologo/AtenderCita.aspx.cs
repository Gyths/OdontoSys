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
    public partial class AtenderCita : System.Web.UI.Page
    {
        private CitaBO boCita;
        private PacienteBO boPaciente;
        private DetalleTratamientoBO boDetalleTratamiento;
        private TratamientoBO boTratamiento;
        protected void Page_Load(object sender, EventArgs e)
        {
            string idCita = Request.QueryString["idCita"];
            System.Diagnostics.Debug.WriteLine("ID Cita: " + idCita);
            CargarDatosCita(idCita);
            CargarTratamientos(idCita);

        }

        private void CargarDatosCita(string idCita)
        {
            boCita = new CitaBO();
            boPaciente = new PacienteBO();
            var cita = boCita.cita_obtenerPorId(Int32.Parse(idCita));
            var paciente = boPaciente.paciente_obtenerPorId(cita.paciente.idPaciente);
            txtPaciente.Text = paciente.nombre + paciente.apellidos;
            txtCorreo.Text = paciente.correo;
            txtTelefono.Text = paciente.telefono;
        }

        private void CargarTratamientos(string idCita)
        {
            boDetalleTratamiento = new DetalleTratamientoBO();
            boTratamiento = new TratamientoBO();
            DetalleTratamientoWS.cita cita = new DetalleTratamientoWS.cita
            {
                idCita = Int32.Parse(idCita),
                idCitaSpecified = true
            };
            try
            {
                var listaDetalle = boDetalleTratamiento.detalleTratamiento_listarPorCita(cita);
                foreach (var detalle in listaDetalle)
                {
                    var tratamiento = boTratamiento.tratamiento_obtenerPorId(detalle.tratamiento.idTratamiento);
                    detalle.tratamiento.nombre = tratamiento.nombre;
                    detalle.tratamiento.descripcion = tratamiento.descripcion;
                    detalle.tratamiento.costo = tratamiento.costo;
                }
                gvTratamientos.DataSource = listaDetalle;
                gvTratamientos.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas: " + ex.Message);
                // Asignar null para que el GridView muestre el mensaje de "EmptyDataText"
                gvTratamientos.DataSource = null;
                gvTratamientos.DataBind();
            }
            
        }
        protected void gvTratamientos_RowCommand(object sender, GridViewCommandEventArgs e){
            
        }
        protected void btnAgregarTratamiento_Click(object sender, EventArgs e) { 
        
        }
    }
}