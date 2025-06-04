using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness;
using OdontoSysBusiness.BO;
using OdontoSysBusiness.odontologoWS;
using OdontoSysBusiness.citaWS;
using System.ComponentModel;

namespace OdontoSysFrontEnd
{
    public partial class reservar_cita : System.Web.UI.Page
    {
        private CitaBO citaBO;
        private EspecialidadBO especialidadBO;
        private OdontologoBO odontologoBO;
        private PacienteBO pacienteBO;

        public reservar_cita()
        {
            this.citaBO = new CitaBO();
            this.especialidadBO = new EspecialidadBO();
            this.odontologoBO = new OdontologoBO();
            this.pacienteBO = new PacienteBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
                LimpiarDoctores();
                LimpiarHorarios();
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
                var especialidades = this.especialidadBO.ListarEspecialidades();
                ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "nombre"; 
                ddlEspecialidad.DataValueField = "idEspecialidad"; 
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", ""));
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar especialidades: {ex.Message}");
            }
        }

        private void CargarDoctoresPorEspecialidad(int especialidadId)
        {
            try
            {
                // Crear objeto especialidad para filtrar
                OdontoSysBusiness.odontologoWS.especialidad especialidad = new OdontoSysBusiness.odontologoWS.especialidad();
                especialidad.idEspecialidad = especialidadId;

                var doctores = this.odontologoBO.listarPorEspecialidad(especialidad);

                ddlDoctor.DataSource = doctores;
                ddlDoctor.DataTextField = "nombreCompleto"; 
                ddlDoctor.DataValueField = "idOdontologo"; 
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, new ListItem("-- Seleccione Doctor --", ""));
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar doctores: {ex.Message}");
            }
        }

        private void CargarHorariosDisponibles()
        {
            try
            {
                if (string.IsNullOrEmpty(ddlDoctor.SelectedValue) || string.IsNullOrEmpty(txtFechaCita.Text))
                {
                    LimpiarHorarios();
                    return;
                }

                int odontologoId = Convert.ToInt32(ddlDoctor.SelectedValue);
                string fechaSeleccionada = txtFechaCita.Text;

                // Crear objeto odontólogo
                OdontoSysBusiness.odontologoWS.odontologo odontologo = this.odontologoBO.obtenerPorId(odontologoId);

                if (odontologo != null)
                {
                    // Obtener citas existentes para el odontólogo en la fecha seleccionada
                    BindingList<OdontoSysBusiness.citaWS.cita> citasExistentes = this.citaBO.ListarPorOdontologo(odontologo, fechaSeleccionada, fechaSeleccionada);
                    
                    var horariosDisponibles = GenerarHorariosDisponibles(citasExistentes, fechaSeleccionada);

                    ddlHorario.DataSource = horariosDisponibles;
                    ddlHorario.DataTextField = "Descripcion";
                    ddlHorario.DataValueField = "Hora";
                    ddlHorario.DataBind();
                    ddlHorario.Items.Insert(0, new ListItem("-- Seleccione Horario --", ""));
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al cargar horarios: {ex.Message}");
            }
        }

        private object GenerarHorariosDisponibles(BindingList<OdontoSysBusiness.citaWS.cita> citasExistentes, string fechaSeleccionada)
        {
            throw new NotImplementedException();
        }

        private List<object> GenerarHorariosDisponibles(List<OdontoSysBusiness.citaWS.cita> citasExistentes, string fecha)
        {
            var horarios = new List<object>();

            for (int hora = 8; hora < 18; hora++)
            {
                for (int minuto = 0; minuto < 60; minuto += 30)
                {
                    var horaString = $"{hora:D2}:{minuto:D2}";
                    var horaDisplay = $"{hora:D2}:{minuto:D2} - {(minuto == 30 ? (hora + 1) : hora):D2}:{(minuto == 30 ? "00" : "30")}";

                   
                        horarios.Add(new { Hora = horaString, Descripcion = horaDisplay });
                    
                }
            }

            return horarios;
        }

        private void LimpiarDoctores()
        {
            ddlDoctor.Items.Clear();
            ddlDoctor.Items.Insert(0, new ListItem("-- Debe seleccionar especialidad --", ""));
            ddlDoctor.Enabled = false;
        }

        private void LimpiarHorarios()
        {
            ddlHorario.Items.Clear();
            ddlHorario.Items.Insert(0, new ListItem("-- Seleccione doctor y fecha --", ""));
            ddlHorario.Enabled = false;
        }

        protected void ddlEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlEspecialidad.SelectedValue))
            {
                int especialidadId = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                CargarDoctoresPorEspecialidad(especialidadId);
                ddlDoctor.Enabled = true;

                LimpiarHorarios();
            }
            else
            {
                LimpiarDoctores();
                LimpiarHorarios();
            }
        }

        protected void ddlDoctor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDoctor.SelectedValue) && !string.IsNullOrEmpty(txtFechaCita.Text))
            {
                CargarHorariosDisponibles();
                ddlHorario.Enabled = true;
            }
            else
            {
                LimpiarHorarios();
            }
        }

        protected void txtFechaCita_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlDoctor.SelectedValue) && !string.IsNullOrEmpty(txtFechaCita.Text))
            {
               
                DateTime fechaSeleccionada;
                if (DateTime.TryParse(txtFechaCita.Text, out fechaSeleccionada))
                {
                    if (fechaSeleccionada < DateTime.Today)
                    {
                        MostrarMensaje("La fecha de la cita no puede ser anterior a hoy.");
                        txtFechaCita.Text = "";
                        LimpiarHorarios();
                        return;
                    }
                }

                CargarHorariosDisponibles();
                ddlHorario.Enabled = true;
            }
            else
            {
                LimpiarHorarios();
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (!ValidarFormulario())
                {
                    return;
                }

                // Obtener datos del formulario
                int especialidadId = Convert.ToInt32(ddlEspecialidad.SelectedValue);
                int odontologoId = Convert.ToInt32(ddlDoctor.SelectedValue);
                DateTime fechaCita = Convert.ToDateTime(txtFechaCita.Text);
                DateTime horaCita = Convert.ToDateTime(ddlHorario.SelectedValue);
                

                // Crear objeto Cita
                OdontoSysBusiness.citaWS.cita nuevaCita = new OdontoSysBusiness.citaWS.cita();

                // Configurar los datos de la cita
                nuevaCita.fecha = fechaCita;
                nuevaCita.horaInicio=horaCita;
                nuevaCita.estado = OdontoSysBusiness.citaWS.estadoCita.RESERVADA; // Estado inicial

                // Obtener el odontólogo
                OdontoSysBusiness.odontologoWS.odontologo odontologo = this.odontologoBO.obtenerPorId(odontologoId);
                nuevaCita.odontologo = odontologo;

               
                OdontoSysBusiness.citaWS.paciente paciente = (OdontoSysBusiness.citaWS.paciente)Session["paciente"];
                nuevaCita.paciente = paciente;

                // Insertar la cita
                int resultado = this.citaBO.InsertCita(nuevaCita);

                if (resultado > 0)
                {
                    MostrarMensajeYRedireccionar("Cita reservada exitosamente.", "Default.aspx");
                }
                else
                {
                    MostrarMensaje("Error al reservar la cita. Inténtelo nuevamente.");
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje($"Error al reservar la cita: {ex.Message}");
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("index.aspx");
        }

        private bool ValidarFormulario()
        {
            List<string> errores = new List<string>();

            if (string.IsNullOrEmpty(ddlEspecialidad.SelectedValue))
                errores.Add("Debe seleccionar una especialidad.");

            if (string.IsNullOrEmpty(ddlDoctor.SelectedValue))
                errores.Add("Debe seleccionar un doctor.");

            if (string.IsNullOrEmpty(txtFechaCita.Text))
                errores.Add("Debe seleccionar una fecha.");

            if (string.IsNullOrEmpty(ddlHorario.SelectedValue))
                errores.Add("Debe seleccionar un horario.");

            // Validar fecha
            DateTime fechaCita;
            if (!string.IsNullOrEmpty(txtFechaCita.Text) && DateTime.TryParse(txtFechaCita.Text, out fechaCita))
            {
                if (fechaCita < DateTime.Today)
                    errores.Add("La fecha de la cita no puede ser anterior a hoy.");
            }

            if (errores.Any())
            {
                string mensaje = "Por favor, corrija los siguientes errores:\\n" + string.Join("\\n", errores);
                MostrarMensaje(mensaje);
                return false;
            }

            return true;
        }

        private void MostrarMensaje(string mensaje)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", $"alert('{mensaje}');", true);
        }

        private void MostrarMensajeYRedireccionar(string mensaje, string url)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert",
                $"alert('{mensaje}'); window.location='{url}';", true);
        }
    }
}