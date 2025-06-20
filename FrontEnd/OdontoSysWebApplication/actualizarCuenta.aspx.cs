﻿using OdontoSysBusiness;
using OdontoSysBusiness.PacienteWS;
using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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
                    errores.AppendLine("<li>El nombre de usuario debe contener al menos 3 letras.</li>");

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
                errores.AppendLine("<li>El teléfono debe ser móvil (9xx xxx xxx) o fijo (xxx-xxxx).</li>");
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
                bool existe = bo.paciente_verificarExistenciaNombreUsuario(usuario);
                if (existe)
                {
                    ltMensajes.Text = "<div class='alert alert-danger'>El nombre de usuario ya está en uso.</div>";
                    return;
                }
            }

            // Actualizar datos
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

