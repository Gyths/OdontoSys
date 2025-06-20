﻿using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;
using OdontoSysBusiness.Xtras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication
{
    public partial class eliminarCuenta : System.Web.UI.Page
    {
        private PacienteWAClient bo = new PacienteWAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Paciente"] == null)
                {
                    Response.Redirect("inicioSesion.aspx");
                }
            }
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            string contrasenhaSolicitada = txtPassword.Text.Trim();
            var paciente = Session["Paciente"] as OdontoSysBusiness.PacienteWS.paciente;
            string contrasenhaAcual = paciente.contrasenha;


            if (contrasenhaAcual != PasswordHelper.HashPassword(contrasenhaSolicitada))
            {
                // Mostrar error y reabrir modal
                lblError.Text = "La contraseña es incorrecta.";
                lblError.Visible = true;
                const string script = @"
                  Sys.Application.add_load(function() {
                    var modalEl = document.getElementById('confirmDeleteModal');
                    if (modalEl) {
                      new bootstrap.Modal(modalEl).show();
                    }
                  });
                ";
                ScriptManager.RegisterStartupScript(this, GetType(), "showDeleteModal", script, true);
                return;
            }

            try
            {
                //Por las fk es necesario primero eliminar las citas del paciente y luego eliminarsu cuenta.

                try
                {
                    var clienteCita = new CitaBO();
                    var pacienteCita = new OdontoSysBusiness.CitaWS.paciente
                    {
                        idPaciente = paciente.idPaciente,
                        idPacienteSpecified = true
                    };
                    var citas = clienteCita.cita_listarPorPaciente(pacienteCita);
                    foreach (var cita in citas)
                    {
                        clienteCita.cita_eliminar(cita);
                    }
                }
                catch (Exception ex1)
                {

                }
                var clientePaciente = new PacienteBO();
                clientePaciente.paciente_eliminar(paciente);
                Session.Abandon();
                Response.Redirect("cuentaEliminada.aspx");
                //Response.AddHeader("Refresh", "1;URL=cuentaEliminada.aspx");
            }
            catch (Exception ex)
            {
                // Si algo falla al eliminar:
                lblError.Text = "Ocurrió un error al eliminar tu cuenta. Intenta más tarde.";
                lblError.Visible = true;
                const string script = @"
                  Sys.Application.add_load(function() {
                    var modalEl = document.getElementById('confirmDeleteModal');
                    if (modalEl) {
                      new bootstrap.Modal(modalEl).show();
                    }
                  });
                ";
                ScriptManager.RegisterStartupScript(this, GetType(), "showDeleteModal", script, true);
            }
        }

    }
}