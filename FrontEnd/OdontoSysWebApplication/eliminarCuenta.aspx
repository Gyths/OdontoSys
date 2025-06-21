<%@ Page Title="Eliminar Cuenta" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="eliminarCuenta.aspx.cs" Inherits="OdontoSysWebApplication.eliminarCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .form-box {
            background-color: #fff;
            border-radius: 0.5rem;
            box-shadow: 0 0 0.5rem rgba(0, 0, 0, 0.1);
            padding: 2rem;
            max-width: 600px;
            margin: auto;
        }

        .list-group-item.active-custom {
            background-color: #0d6efd;
            color: white;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="row">
            <!-- Sidebar -->
            <div class="col-md-3">
                <div class="list-group">
                    <a href="actualizarCuenta.aspx" class="list-group-item list-group-item-action">
                        <i class="fas fa-user-edit me-2"></i>Actualizar Datos
                    </a>
                    <a href="cambiarContrasena.aspx" class="list-group-item list-group-item-action">
                        <i class="fas fa-key me-2"></i>Cambiar Contraseña
                    </a>
                    <a href="eliminarCuenta.aspx" class="list-group-item list-group-item-action active-custom text-danger">
                        <i class="fas fa-user-times me-2"></i>Eliminar Cuenta
                    </a>
                </div>
            </div>

            <!-- Confirmación de eliminación -->
            <div class="col-md-9">
                <asp:Panel runat="server" CssClass="form-box" DefaultButton="btnEliminarCuenta">
                    <h4 class="text-danger text-center mb-3">
                        <i class="fas fa-user-times me-2"></i>¿Estás seguro de eliminar tu cuenta?
                    </h4>

                    <asp:Label runat="server" ID="lblError" CssClass="text-danger mb-3 d-block text-center" Visible="false" />

                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Ingresa tu contraseña" CssClass="form-label" />
                        <asp:TextBox runat="server"
                                     ID="txtPassword"
                                     TextMode="Password"
                                     CssClass="form-control"
                                     Placeholder="Contraseña"
                                     Required="true" />
                    </div>

                    <div class="d-flex justify-content-end gap-2">
                        <a href="miCuenta.aspx" class="btn btn-secondary">Cancelar</a>
                        <asp:Button runat="server"
                                    ID="btnEliminarCuenta"
                                    CssClass="btn btn-danger"
                                    Text="Eliminar cuenta"
                                    OnClick="btnEliminarCuenta_Click" />
                    </div>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>

