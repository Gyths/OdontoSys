using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;
using OdontoSysBusiness.Xtras;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OdontoSysWebApplication
{
    public partial class crearCuenta : System.Web.UI.Page
    {
        private PacienteBO pacienteBO;
        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }

        public crearCuenta()
        {
            this.PacienteBO = new PacienteBO();
        }
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
            // Validar existencia de usuario y documento
            var bo = new PacienteWAClient();
            if (this.PacienteBO.paciente_verificarExistenciaNombreUsuario(usuario))
                errores.AppendLine("<li>Ese nombre de usuario ya está en uso. Por favor elige otro.</li>");
            if (this.PacienteBO.paciente_verificarExistenciaNumeroDocumento(numeroDocumento))
                errores.AppendLine("<li>Ese número de documento ya está registrado en otra cuenta.</li>");

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
            var regexNombre = new Regex(@"^(?=.{2,60}$)(?=[A-Za-zÁÉÍÓÚÜáéíóúüÑñ]{2,})(?!.*\s{2,})(?![\s'´`’]+$)[A-Za-zÁÉÍÓÚÜáéíóúüÑñ\s'´`’]+$");

            if (string.IsNullOrWhiteSpace(usuario))
            {
                errores.AppendLine("<li>El nombre de usuario es obligatorio.</li>");
            }
            else
            {
                if (usuario.Length < 4)
                    errores.AppendLine("<li>El nombre de usuario debe tener al menos 4 caracteres.</li>");

                if (!Regex.IsMatch(usuario, @"^[A-Za-z][A-Za-z0-9_.]*$"))
                    errores.AppendLine("<li>El nombre de usuario debe empezar con una letra y solo puede contener letras, números, puntos o guiones bajos.</li>");

                int letras = usuario.Count(char.IsLetter);
                if (letras < 3)
                    errores.AppendLine("<li>El nombre de usuario debe contener al menos 3 letras.</li>");

                if (usuario.Length > 30)
                    errores.AppendLine("<li>El nombre de usuario no debe tener más de 30 caracteres.</li>");
            }

            if (string.IsNullOrWhiteSpace(nombres))
                errores.AppendLine("<li>Los nombres son obligatorios.</li>");
            else if (!regexNombre.IsMatch(nombres))
                errores.AppendLine("<li>Nombre(s) inválido(s): mínimo 2 letras juntas, sin símbolos y entre 2 y 60 caracteres.</li>");

            if (string.IsNullOrWhiteSpace(apellidos))
                errores.AppendLine("<li>Los apellidos son obligatorios.</li>");
            else if (!regexNombre.IsMatch(apellidos))
                errores.AppendLine("<li>Apellidos inválidos: mínimo 2 letras juntas, sin símbolos y entre 2 y 60 caracteres.</li>");

            // Teléfono: celular (9xx xxx xxx) o fijo (xxx-xxxx)
            if (!Regex.IsMatch(telefono, @"^(9\d{8}|\d{3}-\d{4})$"))
                errores.AppendLine("<li>El teléfono debe ser un número celular (9xxxxxxxx) o un número fijo (xxx-xxxx).</li>");


            if (!Regex.IsMatch(correo, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errores.AppendLine("<li>Correo electrónico inválido.</li>");

            if (contrasena.Length < 6)
                errores.AppendLine("<li>La contraseña debe tener al menos 6 caracteres.</li>");
            if (!Regex.IsMatch(contrasena, @"^[A-Za-z0-9]+$"))
                errores.AppendLine("<li>La contraseña solo puede contener letras y números.</li>");
            if (contrasena != confirmacion)
                errores.AppendLine("<li>Las contraseñas no coinciden.</li>");

            // Tipo de documento
            if (tipoDoc != "DNI" && tipoDoc != "CE")
                errores.AppendLine("<li>Debes seleccionar un tipo de documento válido.</li>");

            // Número de documento
            if (!Regex.IsMatch(numDoc, @"^\d+$"))
                errores.AppendLine("<li>El número de documento solo puede contener dígitos.</li>");
            else if (tipoDoc == "DNI")
            {
                if (numDoc.Length != 8)
                    errores.AppendLine("<li>El DNI debe tener 8 dígitos.</li>");
                else if (numDoc.StartsWith("0"))
                    errores.AppendLine("<li>El DNI no puede comenzar con 0.</li>");
            }
            else if (tipoDoc == "CE")
            {
                if (numDoc.Length != 12)
                    errores.AppendLine("<li>El Carné de Extranjería debe tener 12 dígitos.</li>");
                else if (numDoc.StartsWith("0"))
                    errores.AppendLine("<li>El Carné de Extranjería no puede comenzar con 0.</li>");
            }

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
                this.PacienteBO.paciente_insertar(nuevoPaciente);

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
