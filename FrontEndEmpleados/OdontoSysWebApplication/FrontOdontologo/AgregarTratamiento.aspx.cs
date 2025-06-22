using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.TurnoXOdontologoWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication.FrontOdontologo
{
    public partial class AgregarTratamiento : System.Web.UI.Page
    {
        private EspecialidadBO boEspecialidad;
        private TratamientoBO boTratamiento;
        private DetalleTratamientoBO boDetalle;
        OdontologoWS.odontologo odontologoSes;
        protected void Page_Load(object sender, EventArgs e)
        {
            odontologoSes = Session["Usuario"] as OdontologoWS.odontologo;
            if (!IsPostBack)
            {
                CargarEspecialidad();
                CargarTratamientosDisponibles();
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
        private void CargarTratamientosDisponibles()
        {
            var especialidad = ObtenerEspecialidad();
            var esp = new TratamientoWS.especialidad
            {
                idEspecialidad = especialidad.idEspecialidad,
                idEspecialidadSpecified = true
            };
            boTratamiento = new TratamientoBO();
            var tratEspececialidad = boTratamiento.tratamiento_listarPorEspecilidad(esp);

            ddlTratamiento.AppendDataBoundItems = true;
            ddlTratamiento.DataSource = tratEspececialidad;
            ddlTratamiento.DataTextField = "nombre";
            ddlTratamiento.DataValueField = "idTratamiento";
            ddlTratamiento.DataBind();
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            //TO-DO agregar buscar por nombre en back o alguna manera de sacar el id del ddl
            string idCitaAct = Session["Cita"]?.ToString();
            boTratamiento = new TratamientoBO();
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
            boDetalle.detalleTratamiento_insertar(detalle);
            Response.Redirect($"/FrontOdontologo/AtenderCita.aspx");
        }
    }
}