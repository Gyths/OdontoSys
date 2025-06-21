<%@ Page Title="Actualizar Cuenta" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="actualizarCuenta.aspx.cs" Inherits="OdontoSysWebApplication.actualizarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-box {
            background-color: #fff;
            border-radius: 0.5rem;
            box-shadow: 0 0 0.5rem rgba(0,0,0,0.1);
            padding: 2rem;
        }

        input[readonly], select:disabled {
            background-color: #e9ecef !important;
            cursor: not-allowed;
        }

        .list-group-item.active-custom {
            background-color: #0d6efd;
            color: white;
            font-weight: bold;
        }
    </style>

    <script>
        let originalValues = {};

        function storeOriginalValues() {
            originalValues = {
                usuario: document.getElementById('<%= txtUsuario.ClientID %>').value,
                correo: document.getElementById('<%= txtCorreo.ClientID %>').value,
                telefono: document.getElementById('<%= txtTelefono.ClientID %>').value
            };
        }

        function detectChanges() {
            const usuario = document.getElementById('<%= txtUsuario.ClientID %>').value;
            const correo = document.getElementById('<%= txtCorreo.ClientID %>').value;
            const telefono = document.getElementById('<%= txtTelefono.ClientID %>').value;

            const hasChanged = usuario !== originalValues.usuario ||
                               correo !== originalValues.correo ||
                               telefono !== originalValues.telefono;

            document.getElementById('<%= btnGuardar.ClientID %>').disabled = !hasChanged;
            document.getElementById('btnCancelar').disabled = !hasChanged;
        }

        function cancelarCambios() {
            document.getElementById('<%= txtUsuario.ClientID %>').value = originalValues.usuario;
            document.getElementById('<%= txtCorreo.ClientID %>').value = originalValues.correo;
            document.getElementById('<%= txtTelefono.ClientID %>').value = originalValues.telefono;

            document.getElementById('<%= btnGuardar.ClientID %>').disabled = true;
            document.getElementById('btnCancelar').disabled = true;
        }

        window.onload = function () {
            storeOriginalValues();
            document.getElementById('<%= txtUsuario.ClientID %>').addEventListener('input', detectChanges);
            document.getElementById('<%= txtCorreo.ClientID %>').addEventListener('input', detectChanges);
            document.getElementById('<%= txtTelefono.ClientID %>').addEventListener('input', detectChanges);
        };
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="row">
            <!-- Menú lateral -->
            <div class="col-md-3">
                <div class="list-group">
                    <a href="actualizarCuenta.aspx" class="list-group-item list-group-item-action active-custom">
                        <i class="fas fa-user-edit me-2"></i>Actualizar Datos
                    </a>
                    <a href="cambiarContrasena.aspx" class="list-group-item list-group-item-action">
                        <i class="fas fa-key me-2"></i>Cambiar Contraseña
                    </a>
                </div>
            </div>

            <!-- Formulario -->
            <div class="col-md-9">
                <div class="form-box">
                    <h3 class="text-center mb-4"><i class="fas fa-user-edit me-2"></i>Actualizar Datos</h3>
                    <asp:Literal ID="ltMensajes" runat="server" EnableViewState="false" />
                    
                    <div class="mb-3">
                        <label class="form-label">Nombre de Usuario</label>
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" MaxLength="30" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Correo</label>
                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" TextMode="Email" MaxLength="100" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Teléfono</label>
                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" MaxLength="15" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Nombres</label>
                        <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Apellidos</label>
                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Tipo de Documento</label>
                        <asp:DropDownList ID="ddlTipoDoc" runat="server" CssClass="form-select" Enabled="false">
                            <asp:ListItem Text="-- Seleccionar --" Value="" />
                            <asp:ListItem Text="DNI" Value="DNI" />
                            <asp:ListItem Text="Carné de Extranjería" Value="CE" />
                        </asp:DropDownList>
                    </div>
                    <div class="mb-3">
                        <label class="form-label">Número de Documento</label>
                        <asp:TextBox ID="txtNumDoc" runat="server" CssClass="form-control" ReadOnly="true" />
                    </div>
                    
                    <div class="d-flex gap-2 justify-content-end">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success" OnClick="btnGuardarCambios_Click" Enabled="false" />
                        <button type="button" id="btnCancelar" class="btn btn-secondary" onclick="cancelarCambios()" disabled>Cancelar</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

