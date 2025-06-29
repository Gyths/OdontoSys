using OdontoSysBusiness;
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
        private PacienteBO pacienteBO;
        private CitaBO citaBO = new CitaBO();
        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }

        public eliminarCuenta()
        {
            this.PacienteBO = new PacienteBO();
            this.CitaBO = new CitaBO();
        }
           

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Paciente"] == null)
                {
                    this.Response.Redirect("inicioSesion.aspx");
                }
            }
        }

        protected void btnEliminarCuenta_Click(object sender, EventArgs e)
        {
            string contrasenhaSolicitada = this.txtPassword.Text.Trim();
            paciente paciente = Session["Paciente"] as paciente;
            string contrasenhaAcual = paciente.contrasenha;


            if (contrasenhaAcual != PasswordHelper.HashPassword(contrasenhaSolicitada))
            {
                // Mostrar error y reabrir modal
                this.lblError.Text = "La contraseña es incorrecta.";
                this.lblError.Visible = true;
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
                    
                    var pacienteCita = new OdontoSysBusiness.CitaWS.paciente
                    {
                        idPaciente = paciente.idPaciente,
                        idPacienteSpecified = true
                    };
                    var citas = this.CitaBO.cita_listarPorPaciente(pacienteCita.idPaciente);
                    foreach (var cita in citas)
                    {
                        this.CitaBO.cita_eliminar(cita);
                    }
                }
                catch (Exception ex1)
                {
                    System.Diagnostics.Trace.WriteLine("Error al eliminar citas del paciente: " + ex1.Message);
                }
                this.PacienteBO.paciente_eliminar(paciente);
                this.Session.Abandon();
                this.Response.Redirect("cuentaEliminada.aspx");
                //Response.AddHeader("Refresh", "1;URL=cuentaEliminada.aspx");
            }
            catch (Exception ex)
            {
                // Si algo falla al eliminar:
                this.lblError.Text = "Ocurrió un error al eliminar tu cuenta. Intenta más tarde.";
                this.lblError.Visible = true;
                const string script = @"
                  Sys.Application.add_load(function() {
                    var modalEl = document.getElementById('confirmDeleteModal');
                    if (modalEl) {
                      new bootstrap.Modal(modalEl).show();
                    }
                  });
                ";
                ScriptManager.RegisterStartupScript(this, GetType(), "showDeleteModal", script, true);
                System.Diagnostics.Trace.WriteLine("Error al eliminar cuenta del paciente: " + ex.Message);
            }
        }

    }
}