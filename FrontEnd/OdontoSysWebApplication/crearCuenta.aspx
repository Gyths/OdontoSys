<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="crearCuenta.aspx.cs" Inherits="OdontoSysWebApplication.crearCuenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <!-- Bootstrap + FontAwesome + jQuery -->
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />

  <style>
    html, body, form { height: 100%; margin: 0; }
    .register-container { display: flex; height: 100vh; }
    .register-form-side {
      flex: 0 0 35%;
      display: flex; 
      align-items: center; 
      justify-content: center;
    }
    .register-bg-side {
      flex: 0 0 65%;
      background: url('/Images/crearCuenta/fondo.png') no-repeat center center;
      background-size: cover;
    }
    .form-box {
      width: 100%;
      max-width: 500px;
      background: #fff;
      padding: 2rem;
      border-radius: .5rem;
      box-shadow: 0 0 .5rem rgba(0,0,0,.1);
    }
    .register-logo {
      display: block;
      margin: 0 auto 1.5rem;
      max-width: 200px;
    }
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="register-container">
    <!-- IZQUIERDA: Formulario -->
    <div class="register-form-side">
      <div class="form-box">
        <!-- Logo arriba -->
        <asp:Image ID="imgLogoReg" runat="server"
          ImageUrl="~/Images/logo/horizontal.png"
          AlternateText="Logo" CssClass="register-logo" />

        <h3 class="text-center mb-4"><i class="fas fa-user-plus me-2"></i>Crear Cuenta</h3>
        <asp:Literal ID="ltMensajes" runat="server" EnableViewState="false" />

        <div class="row g-3">
          <!-- Usuario y Teléfono -->
          <div class="col-md-6">
            <label class="form-label">Usuario</label>
            <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
          </div>
          <div class="col-md-6">
            <label class="form-label">Teléfono</label>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" />
          </div>

          <!-- Nombres y Apellidos -->
          <div class="col-md-6">
            <label class="form-label">Nombres</label>
            <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" />
          </div>
          <div class="col-md-6">
            <label class="form-label">Apellidos</label>
            <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" />
          </div>

          <!-- Correo -->
          <div class="col-12">
            <label class="form-label">Correo</label>
            <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" />
          </div>

          <!-- Contraseña y Repetir -->
          <div class="col-md-6">
            <label class="form-label">Contraseña</label>
            <asp:TextBox ID="txtContrasenha" runat="server" CssClass="form-control" TextMode="Password" />
          </div>
          <div class="col-md-6">
            <label class="form-label">Repetir Contraseña</label>
            <asp:TextBox ID="txtContrasenha2" runat="server" CssClass="form-control" TextMode="Password" />
          </div>

          <!-- Tipo y Número de Documento -->
          <div class="col-md-6">
            <label class="form-label">Tipo de Documento</label>
            <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-select">
              <asp:ListItem Text="-- Seleccionar --" Value="" />
              <asp:ListItem Text="DNI" Value="DNI" />
              <asp:ListItem Text="Carné de Extranjería" Value="CE" />
            </asp:DropDownList>
          </div>
          <div class="col-md-6">
            <label class="form-label">Número de Documento</label>
            <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" />
          </div>

          <!-- Botón Registrar -->
          <div class="col-12">
            <div class="d-grid">
              <asp:Button ID="btnRegistrar" runat="server"
                CssClass="btn btn-primary" Text="Registrar"
                OnClick="btnRegistrar_Click" />
            </div>
          </div>
        </div>
      </div>
    </div>

    <!-- DERECHA: Fondo -->
    <div class="register-bg-side d-none d-md-block"></div>
  </div>
</asp:Content>