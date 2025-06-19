using System;
using System.Text;
using System.Text.RegularExpressions;
using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class modificarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ltMensajes.Text = "";
                // Cargo los datos del paciente desde la sesión
                var pacienteActual = (paciente)Session["paciente"];
                if (pacienteActual == null)
                {
                    Response.Redirect("inicioSesion.aspx");
                    return;
                }
                txtUsuario.Text = pacienteActual.nombreUsuario;
                txtTelefono.Text = pacienteActual.telefono;
                txtCorreo.Text = pacienteActual.correo;
                txtNombres.Text = pacienteActual.nombre;
                txtApellidos.Text = pacienteActual.apellidos;
                txtNumDoc.Text = pacienteActual.numeroDocumento;
                ddlTipoDoc.SelectedValue = pacienteActual.tipoDocumento.idTipoDocumento == 1 ? "DNI" : "CE";
            }
        }

        protected void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            // Recupero inputs
            string usuario = txtUsuario.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string tipoDoc = ddlTipoDoc.SelectedValue;

            // Validación sencilla (amplía con regex si gustas)
            var errores = new StringBuilder();
            if (string.IsNullOrEmpty(usuario)) errores.AppendLine("<li>El usuario es obligatorio.</li>");
            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) errores.AppendLine("<li>Correo inválido.</li>");
            if (!Regex.IsMatch(telefono, @"^\d{7,15}$")) errores.AppendLine("<li>Teléfono inválido.</li>");
            //if (tipoDoc != "DNI" && tipoDoc != "CE") errores.AppendLine("<li>Tipo de documento inválido.</li>");
            // Ya no se valida tipoDoc, porque no se puede modificar


            if (errores.Length > 0)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'><ul>{errores}</ul></div>";
                return;
            }

            // Creo la instancia del BO y traigo el paciente actual
            PacienteWAClient bo = new PacienteWAClient();
            var pacienteActual = (paciente)Session["paciente"];
            
            // Verifico duplicidad (solo si cambió)
            if (usuario != pacienteActual.nombreUsuario)
            {
                bool existe = bo.paciente_verificarExistenciaNombreUsuario(usuario);
                if (existe)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>El nombre de usuario ya está en uso.</div>";
                    return;
                }
            }

            // Preparo el objeto para enviar al BO
            pacienteActual.nombreUsuario = usuario;
            pacienteActual.telefono = telefono;
            pacienteActual.correo = correo;

            try
            {
                // Llamo al método de modificación
                bo.paciente_modificar(pacienteActual);
                Session["paciente"] = pacienteActual;
                ltMensajes.Text = "<div class='alert alert-success'>Cuenta actualizada correctamente.</div>";
            }
            catch (Exception ex)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'>Ocurrió un error: {ex.Message}</div>";
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

    }
}
