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
        private OdontologoBO odonlogoBO;
        private EspecialidadBO especialidadBO;

        public OdontologoBO OdonlogoBO { get => odonlogoBO; set => odonlogoBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }

        public buscarOdontologo()
        {
            this.OdonlogoBO = new OdontologoBO();
            this.EspecialidadBO = new EspecialidadBO();
        }

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
            ddlEspecialidad.DataSource = EspecialidadBO.especialidad_listarTodos();
            ddlEspecialidad.DataTextField = "nombre";
            ddlEspecialidad.DataValueField = "idEspecialidad";
            ddlEspecialidad.DataBind();
            ddlEspecialidad.Items.Insert(0, new ListItem("-- Seleccionar --", ""));
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
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
                    lista = OdonlogoBO.odontologo_listarPorEspecialidad(idEsp);
                }
                else if (!hayNombre && !hayApellido && !hayDocumento)
                {
                    lista = OdonlogoBO.odontologo_listarTodoCompleto();
                }
                else if (hayNombre && hayApellido && !hayDocumento)
                {
                    lista = OdonlogoBO.odontologo_buscarPorNombreApellido(txtNombre.Text.Trim(), txtApellidos.Text.Trim());
                }
                else if (hayNombre && hayApellido && hayDocumento)
                {
                    lista = OdonlogoBO.odontologo_buscarPorNombreApellidoDocumento(txtNombre.Text.Trim(), txtApellidos.Text.Trim(), txtDocumento.Text.Trim());
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
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger";

                gvOdontologos.DataSource = null;
                gvOdontologos.DataBind();

                System.Diagnostics.Debug.WriteLine("Excepción capturada en btnBuscar_Click: " + ex.ToString());

                throw;
            }
            gvOdontologos.DataSource = lista?.ToList();
            gvOdontologos.DataBind();
            lblMensaje.Text = "";
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