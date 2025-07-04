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
        private OdontologoBO odonlogoBO ;
        private EspecialidadBO especialidadBO ;

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
                // Carga todos los odontólogos la primera vez que se carga la página
                CargarTodosLosOdontologos();
            }
        }

        /// <summary>
        /// Llena el DropDownList de especialidades.
        /// </summary>
        private void CargarEspecialidades()
        {
            try
            {
                ddlEspecialidad.DataSource = EspecialidadBO.especialidad_listarTodos();
                ddlEspecialidad.DataTextField = "nombre";
                ddlEspecialidad.DataValueField = "idEspecialidad";
                ddlEspecialidad.DataBind();
                ddlEspecialidad.Items.Insert(0, new ListItem("-- Todas las Especialidades --", ""));
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar especialidades.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                System.Diagnostics.Debug.WriteLine("Error al cargar especialidades: " + ex.Message);
            }
        }

 
        private void CargarTodosLosOdontologos()
        {
            try
            {
                lblMensaje.Visible = false;
                BindingList<OdontologoWS.odontologo> lista = OdonlogoBO.odontologo_listarTodoCompleto();

                gvOdontologos.DataSource = lista;
                gvOdontologos.DataBind();

                bool hayDatos = lista != null && lista.Count > 0;
                gvOdontologos.Visible = hayDatos;

                if (!hayDatos)
                {
                    lblMensaje.Text = "No hay odontólogos registrados.";
                    lblMensaje.CssClass = "text-info mb-3";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar todos los odontólogos: " + ex.Message);
                lblMensaje.Text = "Ocurrió un error al cargar la lista de odontólogos.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                gvOdontologos.Visible = false;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string documento = txtDocumento.Text.Trim();
            string idEspecialidad = ddlEspecialidad.SelectedValue;

            
            if (string.IsNullOrEmpty(nombre) && string.IsNullOrEmpty(apellidos) && string.IsNullOrEmpty(documento) && string.IsNullOrEmpty(idEspecialidad))
            {
                CargarTodosLosOdontologos();
                return;
            }

            try
            {
                BindingList<OdontologoWS.odontologo> lista = null;

               
                if (!string.IsNullOrEmpty(idEspecialidad))
                {
                    int idEsp = int.Parse(idEspecialidad);
                    lista = OdonlogoBO.odontologo_listarPorEspecialidad(idEsp);
                }
                else 
                {
                   
                    if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellidos))
                    {
                        lblMensaje.Text = "Por favor, ingrese nombre y apellidos para una búsqueda específica.";
                        lblMensaje.CssClass = "text-danger";
                        lblMensaje.Visible = true;
                        gvOdontologos.DataSource = null;
                        gvOdontologos.DataBind();
                        gvOdontologos.Visible = false;
                        return;
                    }

                    if (!string.IsNullOrEmpty(documento))
                    {
                        lista = OdonlogoBO.odontologo_buscarPorNombreApellidoDocumento(nombre, apellidos, documento);
                    }
                    else
                    {
                        lista = OdonlogoBO.odontologo_buscarPorNombreApellido(nombre, apellidos);
                    }
                }

                gvOdontologos.DataSource = lista;
                gvOdontologos.DataBind();
                lblMensaje.Visible = false;

                bool hayDatos = lista != null && lista.Count > 0;
                gvOdontologos.Visible = hayDatos;

                if (!hayDatos)
                {
                    lblMensaje.Text = "No se encontraron odontólogos con los criterios especificados.";
                    lblMensaje.CssClass = "text-warning mb-3";
                    lblMensaje.Visible = true;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al buscar odontólogos: " + ex.Message);
                lblMensaje.Text = "Ocurrió un error al realizar la búsqueda.";
                lblMensaje.CssClass = "text-danger";
                lblMensaje.Visible = true;
                gvOdontologos.DataSource = null;
                gvOdontologos.DataBind();
                gvOdontologos.Visible = false;
            }
        }

        protected void gvOdontologo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Gestionar")
            {
                try
                {
                    int idOdo = Convert.ToInt32(e.CommandArgument);
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