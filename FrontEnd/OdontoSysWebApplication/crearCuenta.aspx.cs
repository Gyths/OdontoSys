using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.Xtras;

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
            // Recoger valores
            string usuario = txtUsuario.Text.Trim();
            string nombres = txtNombres.Text.Trim();
            string apellidos = txtApellidos.Text.Trim();
            string telefono = txtTelefono.Text.Trim();
            string correo = txtCorreo.Text.Trim();
            string pwd1 = txtContrasenha.Text;
            string pwd2 = txtContrasenha2.Text;
            string tipoDoc = ddlTipoDoc.SelectedValue;
            string numDoc = txtNumDoc.Text.Trim();

            // Acumular errores
            var errores = new System.Text.StringBuilder();

            // 1. Usuario
            if (string.IsNullOrEmpty(usuario))
                errores.AppendLine("<li>El usuario es obligatorio.</li>");

            // 2. Nombres / Apellidos: sólo letras y espacios
            var nameRx = new Regex(@"^[A-Za-zÁÉÍÓÚáéíóúÑñ ]+$");
            if (!nameRx.IsMatch(nombres))
                errores.AppendLine("<li>Los nombres sólo pueden contener letras y espacios.</li>");
            if (!nameRx.IsMatch(apellidos))
                errores.AppendLine("<li>Los apellidos sólo pueden contener letras y espacios.</li>");

            // 3. Teléfono: dígitos 7–15
            if (!Regex.IsMatch(telefono, @"^\d{7,15}$"))
                errores.AppendLine("<li>El teléfono debe tener sólo dígitos (7 a 15 caracteres).</li>");

            // 4. Correo
            if (!Regex.IsMatch(correo,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                errores.AppendLine("<li>Correo electrónico inválido.</li>");

            // 5. Contraseña
            if (pwd1.Length < 6)
                errores.AppendLine("<li>La contraseña debe tener al menos 6 caracteres.</li>");
            if (!Regex.IsMatch(pwd1, @"^[A-Za-z0-9]+$"))
                errores.AppendLine("<li>La contraseña sólo puede contener letras y números.</li>");
            if (pwd1 != pwd2)
                errores.AppendLine("<li>Las contraseñas no coinciden.</li>");

            // 6. Tipo de documento
            if (tipoDoc != "DNI" && tipoDoc != "CE")
                errores.AppendLine("<li>Debes seleccionar un tipo de documento.</li>");

            // 7. Número de documento
            if (!Regex.IsMatch(numDoc, @"^\d+$"))
                errores.AppendLine("<li>El número de documento sólo puede contener dígitos.</li>");
            else
            {
                int len = numDoc.Length;
                if (tipoDoc == "DNI" && len != 8)
                    errores.AppendLine("<li>El DNI debe tener exactamente 8 dígitos.</li>");
                if (tipoDoc == "CE" && len != 12)
                    errores.AppendLine("<li>El Carné de Extranjería debe tener exactamente 12 dígitos.</li>");
            }

            // Si hay errores, mostrarlos y salir
            if (errores.Length > 0)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'><ul>{errores}</ul></div>";
                return;
            }

            var paciente = new PacienteWS.paciente();

            // 2) Asignamos las propiedades simples
            paciente.nombreUsuario = usuario;
            paciente.nombre = nombres;
            paciente.apellidos = apellidos;
            paciente.telefono = telefono;
            paciente.correo = correo;
            paciente.contrasenha = PasswordHelper.HashPassword(pwd1);

            // 3) Crear el objeto TipoDocumento del proxy correcto
            var tdoc = new PacienteWS.tipoDocumento();

            // 4) Asignar el valor
            tdoc.idTipoDocumento = (tipoDoc == "DNI") ? 1 : 2;

            // 5) ¡Marcarlo como “specified”!
            tdoc.idTipoDocumentoSpecified = true; //MUY IMPORTANTE

            // 6) Asignar al paciente
            paciente.tipoDocumento = tdoc;

            // 7) Finalmente el número de documento
            paciente.numeroDocumento = numDoc;

            try
            {
                var bo = new PacienteBO();
                bo.paciente_insertar(paciente);

                ltMensajes.Text =
                  "<div class='alert alert-success'>Cuenta creada correctamente. " +
                  "Puedes <a href='inicioSesion.aspx'>iniciar sesión</a> ahora.</div>";
            }
            catch (Exception ex)
            {
                // Log interno de ser necesario...
                ltMensajes.Text =
                  "<div class='alert alert-danger'>Ocurrió un error al crear la cuenta. " +
                  "Intenta nuevamente más tarde.</div>";
            }
        }
    }
}