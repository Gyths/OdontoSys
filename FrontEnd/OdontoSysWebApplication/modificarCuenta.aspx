<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="modificarCuenta.aspx.cs" Inherits="OdontoSysWebApplication.modificarCuenta" %>
<asp:Content ID="Content3" ContentPlaceHolderID="head" runat="server">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <style>
    html, body, form { height: 100%; margin: 0; }
    .form-container { display: flex; justify-content: center; align-items: center; min-height: 100vh; }
    .form-box {
      width: 100%; max-width: 600px; padding: 2rem;
      background: #fff; border-radius: .5rem;
      box-shadow: 0 0 .5rem rgba(0,0,0,.1);
    }
  </style>
</asp:Content>

<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="form-container">
    <div class="form-box">
      <h3 class="text-center mb-4"><i class="fas fa-user-edit me-2"></i>Modificar Cuenta</h3>
      <asp:Literal ID="ltMensajes" runat="server" EnableViewState="false" />

      <div class="row g-3">
        <!-- Usuario -->
        <div class="col-md-6">
          <label class="form-label">Usuario</label>
          <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
        </div>

        <!-- Teléfono -->
        <div class="col-md-6">
          <label class="form-label">Teléfono</label>
          <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
        </div>

        <!-- Correo -->
        <div class="col-md-12">
          <label class="form-label">Correo</label>
          <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
        </div>

        <!-- Nombres (solo lectura) -->
        <div class="col-md-6">
          <label class="form-label">Nombres</label>
          <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <!-- Apellidos (solo lectura) -->
        <div class="col-md-6">
          <label class="form-label">Apellidos</label>
          <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <!-- Tipo de documento -->
        <div class="col-md-6">
          <label class="form-label">Tipo de Documento</label>
          <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-select">
            <asp:ListItem Text="-- Seleccionar --" Value="" />
            <asp:ListItem Text="DNI" Value="DNI" />
            <asp:ListItem Text="Carné de Extranjería" Value="CE" />
          </asp:DropDownList>
        </div>

        <!-- Número de documento (solo lectura) -->
        <div class="col-md-6">
          <label class="form-label">Número de Documento</label>
          <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" ReadOnly="true" />
        </div>

        <!-- Botón Guardar -->
        <div class="col-12">
          <div class="d-grid">
            <asp:Button ID="btnGuardarCambios" runat="server"
              CssClass="btn btn-success" Text="Guardar Cambios"
              OnClick="btnGuardarCambios_Click" />
          </div>
        </div>
      </div>
    </div>
  </div>
</asp:Content>
