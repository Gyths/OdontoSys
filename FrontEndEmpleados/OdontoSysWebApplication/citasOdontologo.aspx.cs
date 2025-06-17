using System;
using System.ComponentModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.TratamientoWS;
using OdontoSysWebApplication.DetalleTratamientoWS;
using OdontoSysWebApplication.OdontologoWS;
using OdontoSysWebAppliation.OdontoSysBusiness;
using tratamiento = OdontoSysWebApplication.TratamientoWS.tratamiento;

namespace OdontoSysWebApplication
{
    public partial class citasOdontologo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Verificar que el usuario esté logueado y sea odontólogo
                if (Session["Usuario"] == null || Session["TipoUsuario"]?.ToString() != "odontologo")
                {
                    Response.Redirect("inicioSesion.aspx");
                    return;
                }

                CargarCitas();
                CargarTratamientos();
            }
        }

        private void CargarCitas()
        {
            try
            {
                // Obtener el odontólogo de la sesión
                var odontologoSesion = Session["Usuario"] as CitaWS.odontologo;
                if (odontologoSesion == null)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>No se pudo obtener la información del odontólogo.</div>";
                    return;
                }

                var citaBO = new CitaBO();
                var citas = citaBO.cita_listarPorOdontologo(odontologoSesion);

                if (citas != null && citas.Count > 0)
                {
                    gvCitas.DataSource = citas;
                    gvCitas.DataBind();
                }
                else
                {
                    gvCitas.DataSource = null;
                    gvCitas.DataBind();
                }
            }
            catch (Exception ex)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'>Error al cargar las citas: {ex.Message}</div>";
            }
        }

        private void CargarTratamientos()
        {
            try
            {
                // Obtener el odontólogo de la sesión para filtrar por especialidad
                var odontologoSesion = Session["Usuario"] as CitaWS.odontologo;
                if (odontologoSesion == null) return;

                var tratamientoBO = new TratamientoBO();
                BindingList<tratamiento> tratamientos;

                
                    tratamientos = tratamientoBO.tratamiento_listarTodos();
                

                ddlTratamiento.DataSource = tratamientos;
                ddlTratamiento.DataTextField = "nombre";
                ddlTratamiento.DataValueField = "idTratamiento";
                ddlTratamiento.DataBind();
                ddlTratamiento.Items.Insert(0, new ListItem("-- Seleccionar Tratamiento --", ""));
            }
            catch (Exception ex)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'>Error al cargar los tratamientos: {ex.Message}</div>";
            }
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "AgregarTratamiento")
            {
                // El JavaScript ya maneja la apertura del modal
                // Este método se mantiene por si se necesita lógica adicional
            }
        }

        protected void ddlTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlTratamiento.SelectedValue))
            {
                try
                {
                    var tratamientoBO = new TratamientoBO();
                    int idTratamiento = int.Parse(ddlTratamiento.SelectedValue);
                    var tratamiento = tratamientoBO.tratamiento_obtenerPorId(idTratamiento);

                    if (tratamiento != null)
                    {
                        txtCostoUnitario.Text = tratamiento.costo.ToString("F2");
                        txtDescripcionTratamiento.Text = tratamiento.descripcion;

                        // Calcular subtotal automáticamente
                        if (!string.IsNullOrEmpty(txtCantidad.Text))
                        {
                            int cantidad = int.Parse(txtCantidad.Text);
                            double subtotal = cantidad * tratamiento.costo;
                            txtSubtotal.Text = subtotal.ToString("F2");
                        }
                    }
                }
                catch (Exception ex)
                {
                    ltMensajes.Text = $"<div class='alert alert-danger'>Error al obtener el tratamiento: {ex.Message}</div>";
                }
            }
            else
            {
                // Limpiar campos si no hay selección
                txtCostoUnitario.Text = "";
                txtDescripcionTratamiento.Text = "";
                txtSubtotal.Text = "";
            }
        }

        protected void btnGuardarTratamiento_Click(object sender, EventArgs e)
        {
            try
            {
                // Validaciones
                if (string.IsNullOrEmpty(hfIdCitaSeleccionada.Value))
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>No se ha seleccionado una cita.</div>";
                    return;
                }

                if (string.IsNullOrEmpty(ddlTratamiento.SelectedValue))
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>Debe seleccionar un tratamiento.</div>";
                    return;
                }

                if (string.IsNullOrEmpty(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>La cantidad debe ser un número mayor a 0.</div>";
                    return;
                }

                // Crear el objeto DetalleTratamiento
                var detalleTratamiento = new DetalleTratamientoWS.detalleTratamiento();

                // Asignar ID de la cita
                detalleTratamiento.idCita = int.Parse(hfIdCitaSeleccionada.Value);
                detalleTratamiento.idCitaSpecified = true;

                // Crear y asignar el tratamiento
                var tratamientoSeleccionado = new DetalleTratamientoWS.tratamiento();
                tratamientoSeleccionado.idTratamiento = int.Parse(ddlTratamiento.SelectedValue);
                tratamientoSeleccionado.idTratamientoSpecified = true;
                detalleTratamiento.tratamiento = tratamientoSeleccionado;

                // Asignar cantidad
                detalleTratamiento.cantidad = cantidad;
                detalleTratamiento.cantidadSpecified = true;

                // Calcular y asignar subtotal
                double costoUnitario = double.Parse(txtCostoUnitario.Text);
                double subtotal = cantidad * costoUnitario;
                detalleTratamiento.subtotal = subtotal;

                // Insertar el detalle de tratamiento
                var detalleTratamientoBO = new DetalleTratamientoBO();
                int resultado = detalleTratamientoBO.detalleTratamiento_insertar(detalleTratamiento);

                if (resultado > 0)
                {
                    ltMensajes.Text = "<div class='alert alert-success'>Tratamiento agregado correctamente a la cita.</div>";

                    // Limpiar el formulario
                    LimpiarFormularioTratamiento();

                    // Recargar las citas para mostrar cambios
                    CargarCitas();

                    // Cerrar el modal usando JavaScript
                    ScriptManager.RegisterStartupScript(this, GetType(), "cerrarModal",
                        "bootstrap.Modal.getInstance(document.getElementById('modalTratamiento')).hide();", true);
                }
                else
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>No se pudo agregar el tratamiento. Intente nuevamente.</div>";
                }
            }
            catch (Exception ex)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'>Error al guardar el tratamiento: {ex.Message}</div>";
            }
        }

        private void LimpiarFormularioTratamiento()
        {
            hfIdCitaSeleccionada.Value = "";
            ddlTratamiento.SelectedIndex = 0;
            txtCantidad.Text = "1";
            txtCostoUnitario.Text = "";
            txtDescripcionTratamiento.Text = "";
            txtSubtotal.Text = "";
        }
    }
}