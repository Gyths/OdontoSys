using System;
using System.Text;
using System.Text.RegularExpressions;
using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class actualizarCuenta : System.Web.UI.Page
    {
        private PacienteWAClient bo = new PacienteWAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var paciente = Session["Paciente"] as paciente;
                if (paciente == null)
                {
                    Response.Redirect("inicioSesion.aspx");
                    return;
                }

                txtUsuario.Text = paciente.nombreUsuario;
                txtTelefono.Text = paciente.telefono;
                txtCorreo.Text = paciente.correo;
                txtNombres.Text = paciente.nombre;
                txtApellidos.Text = paciente.apellidos;
                txtNumDoc.Text = paciente.numeroDocumento;
                ddlTipoDoc.SelectedValue = paciente.tipoDocumento.idTipoDocumento == 1 ? "DNI" : "CE";
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();

            var errores = new StringBuilder();
            if (string.IsNullOrEmpty(usuario)) errores.AppendLine("<li>El usuario es obligatorio.</li>");
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) errores.AppendLine("<li>Correo inválido.</li>");
            if (!Regex.IsMatch(telefono, @"^\d{7,15}$")) errores.AppendLine("<li>Teléfono inválido.</li>");

            if (errores.Length > 0)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'><ul>{errores}</ul></div>";
                return;
            }

            var paciente = Session["Paciente"] as paciente;
            if (paciente == null)
            {
                Response.Redirect("inicioSesion.aspx");
                return;
            }

            if (usuario != paciente.nombreUsuario)
            {
                bool existe = bo.paciente_verificarExistenciaNombreUsuario(usuario);
                if (existe)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>El nombre de usuario ya está en uso.</div>";
                    return;
                }
            }

            paciente.nombreUsuario = usuario;
            paciente.telefono = telefono;
            paciente.correo = correo;

            try
            {
                bo.paciente_modificar(paciente);
                Session["Paciente"] = paciente;
                ltMensajes.Text = "<div class='alert alert-success'>Datos actualizados correctamente.</div>";
            }
            catch (Exception ex)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'>Error al actualizar: {ex.Message}</div>";
            }
        }
    }
}
