using System;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;
using OdontoSysBusiness;
using OdontoSysBusiness.Xtras;

namespace OdontoSysWebApplication
{
    public partial class miCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // verificar si hay sesión activa
        }

        protected void btnIrADatos_Click(object sender, EventArgs e)
        {
            Response.Redirect("ActualizarDatos.aspx");
        }

        protected void btnIrAContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("CambiarContrasena.aspx");
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
                } catch (Exception ex1)
                {

                }
                var clientePaciente = new PacienteBO();
                clientePaciente.paciente_eliminar(paciente);
                Session.Abandon();
                Response.AddHeader("Refresh", "1;URL=cuentaEliminada.aspx");
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

