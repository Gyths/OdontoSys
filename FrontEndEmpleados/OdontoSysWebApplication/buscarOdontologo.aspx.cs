using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class buscarOdontologo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEspecialidades();
            }
        }

        private void CargarEspecialidades()
        {
            // Llenar combo de Especialidad
            var especialidadBO = new EspecialidadBO();
            ddlEspecialidad.DataSource = especialidadBO.especialidad_listarTodos();
            ddlEspecialidad.DataTextField = "nombre";
            ddlEspecialidad.DataValueField = "idEspecialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            var oBO = new OdontologoBO();
            BindingList<OdontologoWS.odontologo> lista = null;

            bool hayEspecialidad = !string.IsNullOrEmpty(ddlEspecialidad.SelectedValue);
            bool hayNombre = !string.IsNullOrWhiteSpace(txtNombre.Text);
            bool hayApellido = !string.IsNullOrWhiteSpace(txtApellidos.Text);
            bool hayDocumento = !string.IsNullOrWhiteSpace(txtDocumento.Text);

            try
            {
                if (hayEspecialidad)
                {
                    int idEsp = int.Parse(ddlEspecialidad.SelectedValue);
                    var especialidadOdontologo = new OdontologoWS.especialidad
                    {
                        idEspecialidad = idEsp,
                        idEspecialidadSpecified = true
                    };
                    lista = oBO.odontologo_listarPorEspecialidad(especialidadOdontologo);
                }
                else if (!hayNombre && !hayApellido && !hayDocumento)
                {
                    lista = oBO.odontologo_listarTodos();
                }
                else if (hayNombre && hayApellido && !hayDocumento)
                {
                    lista = oBO.odontologo_buscarPorNombreApellido(txtNombre.Text.Trim(), txtApellidos.Text.Trim());
                }
                else if (hayNombre && hayApellido && hayDocumento)
                {
                    lista = oBO.odontologo_buscarPorNombreApellidoDocumento(txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtDocumento.Text.Trim());
                }
                else
                {
                    lblMensaje.Text = "Completa nombre y apellidos antes de usar documento, o selecciona una especialidad.";
                    lblMensaje.CssClass = "text-warning";
                    gvOdontologos.DataSource = null;
                    gvOdontologos.DataBind();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            gvOdontologos.DataSource = lista?.ToList();
            gvOdontologos.DataBind();
            lblMensaje.Text = "";
        }

        protected void gvOdontologos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var doctor = (OdontologoWS.odontologo)e.Row.DataItem;

                int columnaTipoEsp = 3; // cambia este número si tu columna está en otra posición

                if (doctor.especialidad.idEspecialidad == 1)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Odontología General";
                }
                else if (doctor.especialidad.idEspecialidad == 2)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Ortodoncia";
                }
                else if (doctor.especialidad.idEspecialidad == 3)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Endodoncia";
                }
                else if (doctor.especialidad.idEspecialidad == 4)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Cirugia";
                }
                else if (doctor.especialidad.idEspecialidad == 5)
                {
                    e.Row.Cells[columnaTipoEsp].Text = "Pediatra";
                }
            }
        }

        protected void gvOdontologo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Gestionar")
            {
                try
                {
                    int idOdo  = Convert.ToInt32(e.CommandArgument);
                    Session["idOdontologoSeleccionado"] = idOdo;
                    Response.Redirect("gestionOdontologo.aspx");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error en RowCommand: " + ex.Message);
                }
            }
        }
    }
}