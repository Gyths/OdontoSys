using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class gestionOdontologo : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] == null || !int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                Response.Redirect("buscarOdontologo.aspx");
                return;
            }
            if (IsPostBack && Request.Form["accion"] == "cancelar")
            {
                if (int.TryParse(Request.Form["idCita"], out int idCita))
                    CancelarCita(idCita, idOdo);
            }
            if (!IsPostBack)
            {
                CargarOdontologo(idOdo);
                calFiltro.SelectedDate = DateTime.Today;
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasOdontologo(idOdo, fechaBase);
        }

        private void CancelarCita(int idCita, int idOdo)
        {
            var cliCita = new CitaBO();
            var cita = cliCita.cita_obtenerPorId(idCita);
            if (cita != null && cita.estado == CitaWS.estadoCita.RESERVADA)
            {
                cita.estado = CitaWS.estadoCita.CANCELADA;
                cliCita.cita_actualizarEstado(cita);

                lblMensaje.Text = "La cita fue cancelada correctamente.";
                lblMensaje.CssClass = "text-success";
            }
            else
            {
                lblMensaje.Text = "No se pudo cancelar la cita.";
                lblMensaje.CssClass = "text-danger";
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasOdontologo(idOdo, fechaBase);
        }

        private void CargarOdontologo(int id)
        {
           
            var odontologoBO = new OdontologoBO(); 
            var boEspecialidad = new EspecialidadBO();
            OdontologoWS.odontologo odontologo = odontologoBO.odontologo_obtenerPorId(id);

           
            txtNombre.Text = odontologo.nombre;
            txtApellido.Text = odontologo.apellidos;
            txtDocumento.Text = odontologo.numeroDocumento;
            var especialidadOd = boEspecialidad.especialidad_obtenerPorId(odontologo.especialidad.idEspecialidad);
            txtEspecialidad.Text = especialidadOd.nombre;
            txtCorreo.Text = odontologo.correo;
            txtTelefono.Text = odontologo.telefono;
            txtUsuario.Text = odontologo.nombreUsuario;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtUsuario.ReadOnly = false;

            btnGuardar.Visible = true;
            btnEditar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null && int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int id))
            {
                var odontologoBO = new OdontologoBO();

                var original = odontologoBO.odontologo_obtenerPorId(id); // obtener objeto completo

                original.correo = txtCorreo.Text;
                original.telefono = txtTelefono.Text;
                original.nombreUsuario = txtUsuario.Text;

                odontologoBO.odontologo_modificar(original);

                // Volver a modo solo lectura
                txtCorreo.ReadOnly = true;
                txtTelefono.ReadOnly = true;
                txtUsuario.ReadOnly = true;

                btnGuardar.Visible = false;
                btnEditar.Visible = true;
            }
        }

        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["idOdontologoSeleccionado"] != null &&
                int.TryParse(Session["idOdontologoSeleccionado"].ToString(), out int idOdo))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitasOdontologo(idOdo, baseDate);
            }
        }

        private void CargarCitasOdontologo(int idOdo, DateTime baseDate)
        {

            DateTime desde = baseDate.AddDays(-1).Date;
            DateTime hasta = baseDate.AddDays(1).Date;

            var boOdontologo = new OdontologoBO();
            var odontologoActual = boOdontologo.odontologo_obtenerPorId(idOdo);
            var odontologo = new CitaWS.odontologo
            {
                idOdontologo = odontologoActual.idOdontologo,
                idOdontologoSpecified = true
            };

            var boCitas = new CitaBO();
            var listaCitas = boCitas.cita_listarPorOdontologoFechas(odontologo, desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
            foreach (var cita in listaCitas)
            {
                var boPaciente = new PacienteBO();
                var paciente = boPaciente.paciente_obtenerPorId(cita.paciente.idPaciente);
                
                var pac = new CitaWS.paciente
                {
                    idPaciente = paciente.idPaciente,
                    idPacienteSpecified = true,
                    nombre = paciente.nombre,
                    apellidos = paciente.apellidos,
                };
                cita.paciente = pac;
                cita.paciente.nombre += (" " + cita.paciente.apellidos);
            }
            gvCitas.DataSource = listaCitas;
            gvCitas.DataBind();

        }
        private void CargarTurnos(int idOdo)
        {
            var boTurnoOdontologo = new TurnoXOdontologoBO();
            var listaTurnos = boTurnoOdontologo.turnoXOdontologo_listarTodos();
            foreach (var turno in listaTurnos)
            {
                if (turno.idOdontologo == idOdo) 
                {
                    var boTurno = new TurnoBO();
                    var turnoActual = boTurno.turno_obtenerPorId(turno.idTurno);
                    //Agregar el turno al grid 
                }
            }
        }
        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarOdontologo.aspx");
        }
        protected void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
        
        }
        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
        
        }
    }
}