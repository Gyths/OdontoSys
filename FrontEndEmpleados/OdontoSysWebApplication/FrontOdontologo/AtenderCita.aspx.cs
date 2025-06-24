using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.ValoracionWS;
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
            if (!IsPostBack) {
                string idCita = Session["Cita"]?.ToString();
                CargarDatosCita(idCita);
                CargarTratamientos(idCita);
            }
        }

        private void CargarDatosCita(string idCita)
        {
            boCita = new CitaBO();
            boPaciente = new PacienteBO();
            var cita = boCita.cita_obtenerPorId(Int32.Parse(idCita));
            var paciente = boPaciente.paciente_obtenerPorId(cita.paciente.idPaciente);
            txtPaciente.Text = paciente.nombre + " " +paciente.apellidos;
            txtPaciente.Enabled = false;
            txtCorreo.Text = paciente.correo;
            txtCorreo.Enabled = false;
            txtTelefono.Text = paciente.telefono;
            txtTelefono.Enabled = false;
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
            if (e.CommandName == "Editar")
            {
                Session["Tratamiento"] = e.CommandArgument.ToString();
                Response.Redirect($"/FrontOdontologo/EditarTratamiento.aspx");
            }
        }
        protected void btnAgregarTratamiento_Click(object sender, EventArgs e)
        {
            Response.Redirect($"/FrontOdontologo/AgregarTratamiento.aspx");
        }
        protected void btnQuitarTodos_Click(object sender, EventArgs e) 
        {
            string idCitaActual = Session["Cita"].ToString();
            foreach (GridViewRow row in gvTratamientos.Rows)
            {
                
                HiddenField hdnIdTratamiento = (HiddenField)row.FindControl("idTratamiento");
                boDetalleTratamiento = new DetalleTratamientoBO();

                var tratamientoDet = new DetalleTratamientoWS.tratamiento
                {
                    idTratamiento = Int32.Parse(hdnIdTratamiento.Value),
                    idTratamientoSpecified = true
                };
                var detalle = new DetalleTratamientoWS.detalleTratamiento
                {
                    idCita = Int32.Parse(idCitaActual),
                    idCitaSpecified = true,
                    tratamiento = tratamientoDet
                };
                boDetalleTratamiento.detalleTratamiento_eliminar(detalle);
                
            }
            Response.Redirect($"/FrontOdontologo/AtenderCita.aspx");
        }
        protected void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            string idCitaActual = Session["Cita"].ToString();
            foreach(GridViewRow row in gvTratamientos.Rows) 
            {
                CheckBox chkSeleccionar = (CheckBox)row.FindControl("chkSeleccionar");
                HiddenField hdnIdTratamiento = (HiddenField)row.FindControl("idTratamiento");

                if (chkSeleccionar != null && chkSeleccionar.Checked) 
                {
                    boDetalleTratamiento = new DetalleTratamientoBO();

                    var tratamientoDet = new DetalleTratamientoWS.tratamiento {
                        idTratamiento = Int32.Parse(hdnIdTratamiento.Value),
                        idTratamientoSpecified = true
                    };
                    var detalle = new DetalleTratamientoWS.detalleTratamiento
                    {
                        idCita = Int32.Parse(idCitaActual),
                        idCitaSpecified = true,
                        tratamiento = tratamientoDet
                    };
                    boDetalleTratamiento.detalleTratamiento_eliminar(detalle);
                }
            }
            Response.Redirect($"/FrontOdontologo/AtenderCita.aspx");
        }

        protected void btnVolverAgenda_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/FrontOdontologo/CitasPorAtender.aspx");
        }
    }
}