using System;
using System.ComponentModel;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontologoWS;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.TurnoXOdontologoWS;

namespace OdontoSysWebApplication
{
    public partial class agregarTurnoDoctor : System.Web.UI.Page
    {
        private TurnoBO turnoBO = new TurnoBO();
        private TurnoXOdontologoBO turnoXOdontologoBO = new TurnoXOdontologoBO();
        private OdontologoBO odontologoBO = new OdontologoBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                string idDoctorParam = Request.QueryString["Doctor"];
                if (string.IsNullOrEmpty(idDoctorParam))
                {
                    Response.Redirect("ListarDoctores.aspx");
                    return;
                }

                int idDoctor;
                if (!int.TryParse(idDoctorParam, out idDoctor))
                {
                    Response.Redirect("ListarDoctores.aspx");
                    return;
                }

                hdnIdDoctor.Value = idDoctor.ToString();
                CargarNombreDoctor(idDoctor);
                CargarTurnos();
            }
        }

        private void CargarNombreDoctor(int idDoctor)
        {
            try
            {

                var doctores = odontologoBO.odontologo_listarTodos();
                var doctor = doctores.FirstOrDefault(d => d.idOdontologo == idDoctor);

                if (doctor != null)
                {
                    lblNombreDoctor.Text = $"Dr. {doctor.nombre} {doctor.apellidos}";
                }
                else
                {
                    lblNombreDoctor.Text = "Doctor no encontrado";
                }
            }
            catch (Exception ex)
            {
                lblNombreDoctor.Text = "Error al cargar información del doctor";

                System.Diagnostics.Debug.WriteLine($"Error al cargar doctor: {ex.Message}");
            }
        }

        private void CargarTurnos()
        {
            try
            {
                BindingList<TurnoWS.turno> turnos = turnoBO.turno_listarTodos();

                ddlTurnos.DataSource = turnos;
                ddlTurnos.DataBind();

                ddlTurnos.Items.Insert(0, new ListItem("-- Seleccione un turno --", ""));
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar los turnos disponibles.", "alert-danger");
                System.Diagnostics.Debug.WriteLine($"Error al cargar turnos: {ex.Message}");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int idDoctor = int.Parse(hdnIdDoctor.Value);
                    int idTurno = int.Parse(ddlTurnos.SelectedValue);


                    if (VerificarTurnoExistente(idDoctor, idTurno))
                    {
                        MostrarMensaje("Este turno ya está asignado al doctor seleccionado.", "alert-warning");
                        return;
                    }


                    turnoXOdontologo turnoXOdontologo = new turnoXOdontologo
                    {
                        idOdontologo = idDoctor,
                        idTurno = idTurno
                    };

                    // Insertar la relación
                    int resultado = turnoXOdontologoBO.turnoXOdontologo_insertar(turnoXOdontologo);

                    if (resultado > 0)
                    {
                        MostrarMensaje("Turno asignado exitosamente al doctor.", "alert-success");


                        ddlTurnos.ClearSelection();
                        ddlTurnos.Items.Insert(0, new ListItem("-- Seleccione un turno --", ""));


                        ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                            "setTimeout(function(){ window.location.href='ListarDoctores.aspx'; }, 2000);", true);
                    }
                    else
                    {
                        MostrarMensaje("Error al asignar el turno. Inténtelo nuevamente.", "alert-danger");
                    }
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Ocurrió un error al procesar la solicitud.", "alert-danger");
                System.Diagnostics.Debug.WriteLine($"Error al guardar: {ex.Message}");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarDoctores.aspx");
        }

        private bool VerificarTurnoExistente(int idDoctor, int idTurno)
        {
            try
            {
                var relaciones = turnoXOdontologoBO.turnoXOdontologo_listarTodos();
                return relaciones.Any(r => r.idOdontologo == idDoctor && r.idTurno == idTurno);
            }
            catch
            {
                return false;
            }
        }

        private void MostrarMensaje(string mensaje, string tipoAlerta)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = $"alert {tipoAlerta}";
            lblMensaje.Visible = true;
        }
    }
}