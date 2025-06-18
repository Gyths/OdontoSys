using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.OdontologoWS;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class ListarCitas : System.Web.UI.Page
    {
        private CitaBO boCita;
        private PacienteBO boPaciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] == null)
            {
                System.Diagnostics.Debug.WriteLine(" No hay paciente seleccionado en sesión.");
                Response.Redirect("ListarPacientes.aspx");
                return;
            }
            if (!IsPostBack)
            {
                CargarCitas();
            }
        }

        private void CargarCitas()
        {
            int idPaciente = (int)Session["idPacienteSeleccionado"];

            var pacienteCita = new CitaWS.paciente
            {
                idPaciente = idPaciente,
                idPacienteSpecified = true
            };

            var clienteCita = new CitaWAClient();
            var citas = clienteCita.cita_listarPorPaciente(pacienteCita);

            // Convertir a lista enriquecida para mostrar en GridView
            var citasProcesadas = citas.Select(c => new {
                c.idCita,
                c.horaInicio,
                c.fecha,
                c.estado,
                odontologoNombre = c.odontologo?.nombre ?? "Sin odontólogo",
                calificacion = c.valoracion?.calicicacion.ToString() ?? "Sin calificación",
                tieneComprobante = c.comprobante != null && c.comprobante.idComprobante > 0,
                c.comprobante
            }).ToList();

            gvCitas.DataSource = citasProcesadas;
            gvCitas.DataBind();
        }

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idCita = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "AñadirComprobante")
            {
                Session["idCita"] = idCita;
                Response.Redirect("RegistrarComprobante.aspx"); // Asegúrate de tener esta página
            }
            else if (e.CommandName == "VerComprobante")
            {
                Session["idCita"] = idCita;
                Response.Redirect("VerComprobante.aspx"); // Asegúrate de tener esta página
            }
        }

        protected void gvCitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                var btnVer = (Button)e.Row.FindControl("btnVer");
                var btnAdd = (Button)e.Row.FindControl("btnAdd");

                string estado = DataBinder.Eval(e.Row.DataItem, "estado").ToString();
                bool tieneComprobante = (bool)DataBinder.Eval(e.Row.DataItem, "tieneComprobante");

                if (estado != "CANCELADA")
                {
                    if (tieneComprobante)
                    {
                        btnVer.Visible = true;
                    }
                    else
                    {
                        btnAdd.Visible = true;
                    }
                }
            }
        }

        /*protected void btnActualizarEstado_Click(object sender, EventArgs e)
        {
            int idCita = int.Parse(hfIdCitaEditar.Value);
            string nuevoEstado = ddlNuevoEstado.SelectedValue;

            var estado = (estado)Enum.Parse(typeof(estado), nuevoEstado);

            var clienteCita = new CitaWAClient();
            clienteCita.actualizarEstadoCita(idCita, estado);

            // Refrescar la lista
            cargarCitas();
        }*/
    }
}