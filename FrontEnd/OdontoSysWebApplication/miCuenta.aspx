<%@ Page Title="Mi Cuenta" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="miCuenta.aspx.cs" Inherits="OdontoSysWebApplication.miCuenta" %>

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
        input[readonly], select:disabled {
            background-color: #e9ecef !important;
            pointer-events: none;
            opacity: 1;
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
                    <a href="actualizarCuenta.aspx" class="list-group-item list-group-item-action <% if (Request.Url.AbsolutePath.EndsWith("actualizarCuenta.aspx")) { %>active-custom<% } %>">
                        <i class="fas fa-user-edit me-2"></i>Actualizar Datos
                    </a>
                    <a href="cambiarContrasena.aspx" class="list-group-item list-group-item-action <% if (Request.Url.AbsolutePath.EndsWith("cambiarContrasena.aspx")) { %>active-custom<% } %>">
                        <i class="fas fa-key me-2"></i>Cambiar Contraseña
                    </a>
                </div>
            </div>

            <!-- Bienvenida -->
            <div class="col-md-9">
                <div class="card shadow-sm p-4">
                    <h4><i class="fas fa-user-cog me-2"></i>Mi Cuenta</h4>
                    <p>Desde aquí puedes actualizar tus datos personales o cambiar tu contraseña.</p>
                    <p>Selecciona una opción del menú a la izquierda.</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



