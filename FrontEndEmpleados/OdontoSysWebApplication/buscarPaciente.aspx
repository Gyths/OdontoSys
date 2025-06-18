<%@ Page Title="Buscador de Pacientes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="buscarPaciente.aspx.cs" Inherits="OdontoSysWebApplication.buscarPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
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

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

        <hr />

        <asp:GridView ID="gvPacientes" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="false" OnRowCommand="gvPacientes_RowCommand">
    <Columns>
        <asp:TemplateField HeaderText="Nombre">
            <ItemTemplate>
                <asp:LinkButton 
                    ID="lnkGestionar" 
                    runat="server" 
                    Text='<%# Eval("nombre") %>' 
                    CommandName="Gestionar" 
                    CommandArgument='<%# Eval("idPaciente") %>' 
                    CssClass="btn btn-link p-0 text-decoration-none" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="apellidos" HeaderText="Apellido" />
        <asp:BoundField DataField="NumeroDocumento" HeaderText="Número de Documento" />
        <asp:BoundField DataField="telefono" HeaderText="Número Telefónico" />
        <asp:BoundField DataField="correo" HeaderText="Correo Electrónico" />
    </Columns>
</asp:GridView>
    </div>
</asp:Content>