<%@ Page Title="Reservar Cita" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="registrar_paciente.aspx.cs" Inherits="OdontoSysFrontEnd.registrar_paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<div class="container">
   
     <div class="card">
        <div class="card-header">
            <h2> Crear cuenta</h2>
        </div>
        <div class="card-body">
            <div class="mb-3 row">
                <asp:Label ID="lblNombre" runat="server" Text="Nombres: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="lblApellido" runat="server" Text="Apellidos: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtApellido"  runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="lblCorreo" runat="server" Text="Correo: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="mb-3 row">
                 <asp:Label ID="LblDNI" runat="server" Text="DNI: " CssClass="col-sm-4 col-form-label"></asp:Label>
                 <div class="col-sm-4">
                     <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>
             <div class="mb-3 row">
                 <asp:Label ID="LblTelefono" runat="server" Text="Teléfono: " CssClass="col-sm-4 col-form-label"></asp:Label>
                 <div class="col-sm-4">
                     <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>
            <div class="mb-3 row">
                <asp:Label ID="LblNombreUsuario" runat="server" Text="Nombre de usuario: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="LblContrasena" runat="server" Text="Contraseña: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
        </div>
       
    </div>

    <div class="container row">
        <div class="text-end">
            <asp:Button ID="btnRegresar" CssClass="float-start btn btn-primary me-2" runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
            <asp:Button ID="btnInsertar" CssClass="float-start btn btn-secondary" runat="server" Text="Registrarse" OnClick="btnInsertar_Click"/>                
        </div>
    </div>
</div>
</asp:Content>
