<%@ Page Title="Buscador de Pacientes" Language="C#" MasterPageFile="~/Recepcionista.master" AutoEventWireup="true" CodeBehind="buscarPaciente.aspx.cs" Inherits="OdontoSysWebApplication.buscarPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            window.history.replaceState('', '', window.location.href);
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Buscar Pacientes</h2>
        <div class="row mb-3">
            <div class="col-md-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtDNI" runat="server" CssClass="form-control" placeholder="DNI" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" placeholder="Teléfono" />
            </div>
        </div>
        <div class="row mb-3">
            <asp:Label ID="lblMensaje" runat="server" Visible="false" />
        </div>
        <div class="row mb-3">
            <div class="col-12 text-center">
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary w-100" OnClick="btnBuscar_Click" />
            </div>
        </div>
        <hr />
        <asp:GridView ID="gvPacientes"
                  runat="server"
                  CssClass="table table-striped mt-3"
                  EnableViewState="true"    
                  Visible="false"
                  AutoGenerateColumns="False"
                  OnRowCommand="gvPacientes_RowCommand">
      <Columns>
        <asp:BoundField DataField="Nombre"         HeaderText="Nombre" />
        <asp:BoundField DataField="Apellidos"       HeaderText="Apellido" />
        <asp:BoundField DataField="NumeroDocumento" HeaderText="N° Documento" />
        <asp:BoundField DataField="Telefono"        HeaderText="Teléfono" />
        <asp:BoundField DataField="Correo"          HeaderText="Correo" />
        <asp:TemplateField HeaderText="Acciones">
          <ItemTemplate>
            <asp:Button runat="server"
                        Text="Gestionar"
                        CssClass="btn btn-sm btn-primary"
                        CommandName="Gestionar"
                        CommandArgument='<%# Eval("IdPaciente") %>' />
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
    </div>
</asp:Content>
