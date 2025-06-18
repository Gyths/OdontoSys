using System;
using System.Text;
using System.Text.RegularExpressions;
using OdontoSysBusiness;
using OdontoSysBusiness.Xtras;

namespace OdontoSysWebApplication
{
    public partial class crearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ltMensajes.Text = "";
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string contrasena = txtContrasenha.Text;
            string contrasenaConfirmacion = txtContrasenha2.Text;
            string tipoDocumento = ddlTipoDoc.SelectedValue;
            string numeroDocumento = txtNumDoc.Text.Trim();

            var errores = ValidarFormulario(usuario, nombres, apellidos, telefono, correo, contrasena, contrasenaConfirmacion, tipoDocumento, numeroDocumento);

            if (errores.Length > 0)
            {
                MostrarErrores(errores);
                return;
            }

            RegistrarPaciente(usuario, nombres, apellidos, telefono, correo, contrasena, tipoDocumento, numeroDocumento);
        }

        private StringBuilder ValidarFormulario(string usuario, string nombres, string apellidos, string telefono,
                                                 string correo, string contrasena, string confirmacion, string tipoDoc, string numDoc)
        {
            var errores = new StringBuilder();
            var regexNombre = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$");

            if (string.IsNullOrEmpty(usuario))
                errores.AppendLine("<li>El usuario es obligatorio.</li>");

            if (!regexNombre.IsMatch(nombres))
                errores.AppendLine("<li>Los nombres solo pueden contener letras y espacios.</li>");
            if (!regexNombre.IsMatch(apellidos))
                errores.AppendLine("<li>Los apellidos solo pueden contener letras y espacios.</li>");

            if (!Regex.IsMatch(telefono, @"^\d{7,15}$"))
                errores.AppendLine("<li>El teléfono debe tener entre 7 y 15 dígitos.</li>");

            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errores.AppendLine("<li>Correo electrónico inválido.</li>");

            if (contrasena.Length < 6)
                errores.AppendLine("<li>La contraseña debe tener al menos 6 caracteres.</li>");
            if (!Regex.IsMatch(contrasena, @"^[A-Za-z0-9]+$"))
                errores.AppendLine("<li>La contraseña solo puede contener letras y números.</li>");
            if (contrasena != confirmacion)
                errores.AppendLine("<li>Las contraseñas no coinciden.</li>");

            if (tipoDoc != "DNI" && tipoDoc != "CE")
                errores.AppendLine("<li>Debes seleccionar un tipo de documento válido.</li>");

            if (!Regex.IsMatch(numDoc, @"^\d+$"))
                errores.AppendLine("<li>El número de documento solo puede contener dígitos.</li>");
            else if ((tipoDoc == "DNI" && numDoc.Length != 8) || (tipoDoc == "CE" && numDoc.Length != 12))
                errores.AppendLine($"<li>El {(tipoDoc == "DNI" ? "DNI" : "Carné de Extranjería")} debe tener {(tipoDoc == "DNI" ? "8" : "12")} dígitos.</li>");

            return errores;
        }

        private void MostrarErrores(StringBuilder errores)
        {
            ltMensajes.Text = $"<div class='alert alert-danger'><ul>{errores}</ul></div>";
        }

        private void RegistrarPaciente(string usuario, string nombres, string apellidos, string telefono, string correo,
                                       string contrasena, string tipoDoc, string numDoc)
        {
            var nuevoPaciente = new OdontoSysBusiness.PacienteWS.paciente
            {
                nombreUsuario = usuario,
                nombre = nombres,
                apellidos = apellidos,
                telefono = telefono,
                correo = correo,
                contrasenha = PasswordHelper.HashPassword(contrasena),
                tipoDocumento = new OdontoSysBusiness.PacienteWS.tipoDocumento
                {
                    idTipoDocumento = (tipoDoc == "DNI") ? 1 : 2,
                    idTipoDocumentoSpecified = true
                },
                numeroDocumento = numDoc
            };
            try
            {
                var bo = new OdontoSysBusiness.PacienteBO();
                bo.paciente_insertar(nuevoPaciente);

                ltMensajes.Text = "<div class='alert alert-success'>Cuenta creada correctamente. " +
                                  "Puedes <a href='inicioSesion.aspx'>iniciar sesión</a> ahora.</div>";
            }
            catch (Exception)
            {
                ltMensajes.Text = "<div class='alert alert-danger'>Ocurrió un error al crear la cuenta. Intenta nuevamente más tarde.</div>";
            }
        }
    }
}
