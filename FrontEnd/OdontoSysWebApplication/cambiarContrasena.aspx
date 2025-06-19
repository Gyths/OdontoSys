<%@ Page Title="Cambiar Contrasena" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="cambiarContrasena.aspx.cs" Inherits="OdontoSysWebApplication.cambiarContrasena" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-box {
            max-width: 600px;
            margin: auto;
            padding: 2rem;
            background-color: #fff;
            border-radius: 0.5rem;
            box-shadow: 0 0 0.5rem rgba(0,0,0,0.1);
        }

        .list-group-item.active-custom {
            background-color: #0d6efd;
            color: white;
            font-weight: bold;
        }
    </style>

    <script>
        function limpiarCampos() {
            document.getElementById('<%= txtContrasenaActual.ClientID %>').value = '';
            document.getElementById('<%= txtNuevaContrasena.ClientID %>').value = '';
            document.getElementById('<%= txtConfirmarContrasena.ClientID %>').value = '';
            actualizarEstadoBotones();
        }

        function actualizarEstadoBotones() {
            const actual = document.getElementById('<%= txtContrasenaActual.ClientID %>').value.trim();
            const nueva = document.getElementById('<%= txtNuevaContrasena.ClientID %>').value.trim();
            const confirmar = document.getElementById('<%= txtConfirmarContrasena.ClientID %>').value.trim();

            const btnGuardar = document.getElementById('<%= btnCambiarContrasena.ClientID %>');
            const btnCancelar = document.getElementById('btnCancelar');

            const habilitar = actual !== "" && nueva !== "" && confirmar !== "";

            btnGuardar.disabled = !habilitar;
            btnCancelar.disabled = !habilitar;
        }

        document.addEventListener("DOMContentLoaded", function () {
            const campos = [
                document.getElementById('<%= txtContrasenaActual.ClientID %>'),
                document.getElementById('<%= txtNuevaContrasena.ClientID %>'),
                document.getElementById('<%= txtConfirmarContrasena.ClientID %>')
            ];

            campos.forEach(input => {
                input.addEventListener('input', actualizarEstadoBotones);
            });

            actualizarEstadoBotones(); // Inicial
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="container py-5">
    <div class="row">
      <!-- Menú lateral -->
      <div class="col-md-3">
        <div class="list-group">
          <a href="actualizarCuenta.aspx" class="list-group-item list-group-item-action">
            <i class="fas fa-user-edit me-2"></i>Actualizar Datos
          </a>
          <a href="cambiarContrasena.aspx" class="list-group-item list-group-item-action active-custom">
            <i class="fas fa-key me-2"></i>Cambiar Contraseña
          </a>
        </div>
      </div>

      <!-- Formulario -->
      <div class="col-md-9">
        <div class="form-box">
          <h3 class="text-center mb-4"><i class="fas fa-key me-2"></i>Cambiar Contraseña</h3>

          <div class="mb-3">
              <label class="form-label">Contraseña Actual</label>
              <asp:TextBox ID="txtContrasenaActual" runat="server" CssClass="form-control" TextMode="Password" MaxLength="50" />
          </div>
          <div class="mb-3">
              <label class="form-label">Nueva Contraseña</label>
              <asp:TextBox ID="txtNuevaContrasena" runat="server" CssClass="form-control" TextMode="Password" MaxLength="50" />
          </div>
          <div class="mb-3">
              <label class="form-label">Confirmar Nueva Contraseña</label>
              <asp:TextBox ID="txtConfirmarContrasena" runat="server" CssClass="form-control" TextMode="Password" MaxLength="50" />
          </div>

          <div class="d-flex gap-2 justify-content-end">
              <asp:Button ID="btnCambiarContrasena" runat="server" Text="Cambiar Contraseña" CssClass="btn btn-warning" OnClick="btnCambiarContrasena_Click" />
              <button type="button" id="btnCancelar" class="btn btn-secondary" onclick="limpiarCampos()">Cancelar</button>
          </div>

          <asp:Label ID="lblMensajeContrasena" runat="server" CssClass="d-block mt-3 text-center" />
        </div>
      </div>
    </div>
  </div>
</asp:Content>

