using OdontoSysWebApplication.OdontoSysBusiness;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication.FrontOdontologo
{
    public partial class EditarTratamiento : System.Web.UI.Page
    {
        private EspecialidadBO boEspecialidad;
        private TratamientoBO boTratamiento;
        private DetalleTratamientoBO boDetalle;
        private OdontologoWS.odontologo odontologoSes;
        protected void Page_Load(object sender, EventArgs e)
        {
            odontologoSes = Session["Usuario"] as OdontologoWS.odontologo;
            if (!IsPostBack)
            {
                string idTratamiento = Session["Tratamiento"].ToString();
                CargarEspecialidad();
                CargarTratamientos();
            }
        }

        private EspecialidadWS.especialidad ObtenerEspecialidad()
        {
            int idEspecialidad = odontologoSes.especialidad.idEspecialidad;
            boEspecialidad = new EspecialidadBO();
            EspecialidadWS.especialidad espOdontologo = boEspecialidad.especialidad_obtenerPorId(idEspecialidad);
            return espOdontologo;
        }
        private void CargarEspecialidad()
        {
            var especialidad = ObtenerEspecialidad();
            ddlEspecialidad.Items.Add(new ListItem(especialidad.nombre));
            ddlEspecialidad.SelectedIndex = 1;
            ddlEspecialidad.Enabled = false;
        }
        private void CargarTratamientos()
        {
            string idTratamiento = Session["Tratamiento"].ToString();
            boTratamiento = new TratamientoBO();
            var tratamiento = boTratamiento.tratamiento_obtenerPorId(Int32.Parse(idTratamiento));
            ddlTratamiento.Items.Add(new ListItem(tratamiento.nombre,tratamiento.idTratamiento.ToString()));
            ddlTratamiento.SelectedIndex = 1;
            ddlTratamiento.Enabled = false;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string idCitaAct = Session["Cita"]?.ToString();
            boTratamiento = new TratamientoBO();
            try { 
                var tratamientoSelec = boTratamiento.tratamiento_obtenerPorId(int.Parse(ddlTratamiento.SelectedValue));

                var tratamientoAux = new DetalleTratamientoWS.tratamiento
                {
                    idTratamiento = tratamientoSelec.idTratamiento,
                    idTratamientoSpecified = true,
                    costo = tratamientoSelec.costo
                };

                boDetalle = new DetalleTratamientoBO();
                int cant = Int32.Parse(txtCantidad.Text);
                var detalle = new DetalleTratamientoWS.detalleTratamiento
                {
                    idCita = Int32.Parse(idCitaAct),
                    idCitaSpecified = true,
                    tratamiento = tratamientoAux,
                    cantidad = cant,
                    cantidadSpecified = true,
                    subtotal = (cant * tratamientoAux.costo)
                };

                if (cant > 5) throw new Exception("La cantidad no puede ser mayor a 5");

                boDetalle.detalleTratamiento_modificar(detalle);
                Response.Redirect($"/FrontOdontologo/AtenderCita.aspx");

            } catch(Exception ex){
                System.Diagnostics.Debug.WriteLine("Error al agregar tratamiento: " + ex.Message);
                Label lblMensaje = new Label();
                lblMensaje.Text = "Error al agregar el tratamiento. " + ex.Message;
                lblMensaje.CssClass = "text-danger";
                pnlError.Controls.Add(new LiteralControl(lblMensaje.Text));
                pnlError.Visible = true;
            }
        }
    }
}