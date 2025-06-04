<%@ Page Title="Iniciar Sesión" Language="C#" MasterPageFile="~/OdontoSys.master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="OdontoSysFrontEnd.login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="row justify-content-center mt-5">
        <div class="col-md-6">
            <div class="card shadow">
                <div class="card-header bg-primary text-white text-center">
                    <h4><i class="fas fa-sign-in-alt"></i> Iniciar Sesión</h4>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:Label ID="lblUsuario" runat="server" Text="Usuario" CssClass="form-label" />
                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label ID="lblContrasena" runat="server" Text="Contraseña" CssClass="form-label" />
                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control" TextMode="Password" />
                    </div>
                    <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Ingresar" OnClick="btnLogin_Click" />
                    <asp:Label ID="lblMensaje" runat="server" ForeColor="Red" CssClass="text-center d-block mt-3" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

