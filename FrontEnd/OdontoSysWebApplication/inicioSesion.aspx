<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="inicioSesion.aspx.cs" Inherits="OdontoSysWebApplication.inicioSesion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        html, body, form {
            height: 100%;
            margin: 0;
        }

        .login-container {
            display: flex;
            height: 100vh;
        }

        .login-form-side {
            flex: 0 0 35%;
            display: flex;
            align-items: center;
            justify-content: center;
        }

        .login-bg-side {
            flex: 0 0 65%;
            background: url('/Images/inicioSesion/fondo.png') no-repeat center center;
            background-size: cover;
        }

        .login-card {
            max-width: 360px;
            width: 75%;
        }

        .login-logo {
            max-width: 200px;
            margin: 0 auto 1.5rem;
            display: block;
        }
    </style>

    <!-- Toggle password -->
    <script>
        $(function () {
            $('#togglePasswordSpan').click(function () {
                var pwd = $('#<%= txtContrasenha.ClientID %>');
          var ico = $('#togglePasswordIcon');
          if (pwd.attr('type') === 'password') {
              pwd.attr('type', 'text'); ico.toggleClass('fa-eye fa-eye-slash');
          } else {
              pwd.attr('type', 'password'); ico.toggleClass('fa-eye-slash fa-eye');
          }
      });
    });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-container">
        <!-- lado formulario -->
        <div class="login-form-side">
            <div class="login-card bg-white p-4 shadow-sm rounded">
                <asp:Image ID="imgLogo" runat="server"
                    CssClass="login-logo"
                    ImageUrl="~/Images/logo/horizontal.png" />

                <h3 class="text-center mb-4">
                    <i class="fas fa-user-lock me-2"></i>Iniciar Sesión
                </h3>

                <asp:Literal ID="ltMensaje" runat="server" EnableViewState="false" />

                <div class="mb-3">
                    <label class="form-label">Usuario</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="fas fa-user"></i></span>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"
                            Placeholder="Nombre de usuario" />
                    </div>
                </div>

                <div class="mb-3">
                    <label class="form-label">Contraseña</label>
                    <div class="input-group">
                        <span class="input-group-text"><i class="fas fa-key"></i></span>
                        <asp:TextBox ID="txtContrasenha" runat="server" CssClass="form-control"
                            TextMode="Password" Placeholder="Contraseña" />
                        <span class="input-group-text" id="togglePasswordSpan" style="cursor: pointer">
                            <i id="togglePasswordIcon" class="fas fa-eye"></i>
                        </span>
                    </div>
                </div>

                <div class="d-grid mb-3">
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Ingresar"
                        OnClick="btnLogin_Click" />
                </div>

                <asp:HyperLink runat="server" NavigateUrl="~/crearCuenta.aspx"
                    CssClass="d-block text-center">
          ¿No tienes cuenta? Crear una ahora
                </asp:HyperLink>
            </div>
        </div>

        <!-- lado fondo -->
        <div class="login-bg-side d-none d-md-block"></div>
    </div>
</asp:Content>
