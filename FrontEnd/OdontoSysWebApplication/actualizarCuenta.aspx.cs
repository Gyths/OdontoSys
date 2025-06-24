using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OdontoSysWebApplication
{
    public partial class actualizarCuenta : System.Web.UI.Page
    {
        private PacienteBO pacienteBO;
        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }

        public actualizarCuenta()
        {
            this.PacienteBO = new PacienteBO();
        }

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

            // Validación de nombre de usuario
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
                    errores.AppendLine("<li>El nombre de usuario debe tener al menos 3 letras.</li>");

                if (usuario.Length > 30)
                    errores.AppendLine("<li>El nombre de usuario no debe tener más de 30 caracteres.</li>");
            }


            // Validación de correo
            if (string.IsNullOrWhiteSpace(correo))
            {
                errores.AppendLine("<li>El correo es obligatorio.</li>");
            }
            else if (!Regex.IsMatch(correo, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errores.AppendLine("<li>El correo ingresado no es válido.</li>");
            }

            // Validación de teléfono
            if (string.IsNullOrWhiteSpace(telefono))
            {
                errores.AppendLine("<li>El teléfono es obligatorio.</li>");
            }
            else if (
                !Regex.IsMatch(telefono, @"^9\d{2} ?\d{3} ?\d{3}$") &&  // móvil
                !Regex.IsMatch(telefono, @"^\d{3}-\d{4}$")              // fijo
            )
            {
                errores.AppendLine("<li>Formato de teléfono inválido. Usa 9 dígitos (celular) o xxx-xxxx (fijo)</li>");
            }

            // Mostrar errores si existen
            if (errores.Length > 0)
            {
                ltMensajes.Text = $"<div class='alert alert-danger'><ul>{errores}</ul></div>";
                return;
            }

            // Verificar usuario repetido
            var paciente = Session["Paciente"] as paciente;
            if (paciente == null)
            {
                Response.Redirect("inicioSesion.aspx");
                return;
            }

            if (usuario != paciente.nombreUsuario)
            {
                bool existe = this.PacienteBO.paciente_verificarExistenciaNombreUsuario(usuario);
                if (existe)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>El nombre de usuario ingresado ya está en uso.</div>";
                    return;
                }
            }

            // Actualizar datos
            paciente.nombreUsuario = usuario;
            paciente.telefono = telefono;
            paciente.correo = correo;

            try
            {
                this.PacienteBO.paciente_modificar(paciente);
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

