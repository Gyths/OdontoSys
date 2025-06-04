using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysModel;
using OdontoSysModel.Users;
using OdontoSysBusiness;
using OdontoSysModel.Services;

namespace OdontoSysFrontEnd
{
    public partial class reservar_cita : System.Web.UI.Page
    {
       // private CitaBO citaBO;
        //private EspecialidadBO especialidadBO;
        //private OdontologoBO odontologoBO;
        //private HorarioBO horarioBO;

        public reservar_cita()
        {
          //  this.citaBO = new CitaBO();
            //this.especialidadBO = new EspecialidadBO();
            //this.odontologoBO = new OdontologoBO();
            //this.horarioBO = new HorarioBO();
        }

        //public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        //public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }
        //public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        //public HorarioBO HorarioBO { get => horarioBO; set => horarioBO = value; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.CargarEspecialidades();
                this.CargarDoctores();
                this.CargarHorarios();
            }
        }

        private void CargarEspecialidades()
        {
            try
            {
               // var especialidades = this.EspecialidadBO.ListarTodos();
                //ddlEspecialidad.DataSource = especialidades;
                ddlEspecialidad.DataTextField = "Nombre"; // Ajusta según tu DTO
                ddlEspecialidad.DataValueField = "IdEspecialidad"; // Ajusta según tu DTO
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccione Especialidad --", ""));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al cargar especialidades: {ex.Message}');", true);
            }
        }

        private void CargarDoctores()
        {
            try
            {
               // var doctores = this.OdontologoBO.ListarTodos().Where(d => d.Activo).ToList();
                //ddlDoctor.DataSource = doctores;
                ddlDoctor.DataTextField = "NombreCompleto";
                ddlDoctor.DataValueField = "IdOdontologo";
                ddlDoctor.DataBind();
                ddlDoctor.Items.Insert(0, new ListItem("-- Seleccione Doctor --", ""));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al cargar doctores: {ex.Message}');", true);
            }
        }

        private void CargarHorarios()
        {
            try
            {
                //var horarios = this.HorarioBO.ListarTodos();
                //ddlHorario.DataSource = horarios;
                ddlHorario.DataTextField = "Descripcion"; // Ajusta según tu DTO (ej: "09:00 AM - 09:30 AM")
                ddlHorario.DataValueField = "IdHorario"; // Ajusta según tu DTO
                ddlHorario.DataBind();
                ddlHorario.Items.Insert(0, new ListItem("-- Seleccione Horario --", ""));
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al cargar horarios: {ex.Message}');", true);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se hayan seleccionado todos los campos
                if (string.IsNullOrEmpty(ddlEspecialidad.SelectedValue) ||
                    string.IsNullOrEmpty(ddlDoctor.SelectedValue) ||
                    string.IsNullOrEmpty(ddlHorario.SelectedValue))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert",
                        "alert('Por favor, complete todos los campos.');", true);
                    return;
                }

                // Crear el objeto Cita con los datos seleccionados
                Cita nuevaCita = new Cita
                {
                    //IdEspecialidad = Convert.ToInt32(ddlEspecialidad.SelectedValue),
                    //IdOdontologo = Convert.ToInt32(ddlDoctor.SelectedValue),
                    //IdHorario = Convert.ToInt32(ddlHorario.SelectedValue),
                    //FechaCita = DateTime.Now.Date, // Por defecto hoy, puedes agregar un DatePicker si necesitas
                    //Estado = "Programada", // Estado inicial
                    //FechaRegistro = DateTime.Now
                    // Agrega otros campos según tu DTO de Cita
                };

                // Insertar la cita usando el BO
               // bool resultado = this.CitaBO.Insertar(nuevaCita);

               // if (resultado)
                //{
                  //  ClientScript.RegisterStartupScript(this.GetType(), "alert",
                   //     "alert('Cita reservada exitosamente.'); window.location='Default.aspx';", true);
                //}
                //else
                //{
                 //   ClientScript.RegisterStartupScript(this.GetType(), "alert",
                  //      "alert('Error al reservar la cita. Inténtelo nuevamente.');", true);
                //}
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert",
                    $"alert('Error al reservar la cita: {ex.Message}');", true);
            }
        }
    }
}