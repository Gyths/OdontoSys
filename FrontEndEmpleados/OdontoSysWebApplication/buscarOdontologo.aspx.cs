﻿using System;
using System.Collections.Generic;
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
            var odontologoBO = new OdontologoBO();
            var resultado = odontologoBO.odontologo_listarTodos();

            gvOdontologos.DataSource = resultado;
            gvOdontologos.DataBind();
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
                    int idOdontologo = Convert.ToInt32(e.CommandArgument);
                    Session["idOdontologoSeleccionado"] = idOdontologo;
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