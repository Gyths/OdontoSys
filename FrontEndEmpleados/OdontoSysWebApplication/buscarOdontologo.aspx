<%@ Page Title="Buscador de Doctores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="buscarOdontologo.aspx.cs" Inherits="OdontoSysWebApplication.buscarOdontologo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Buscar Odontólogos</h2>
        <div class="row mb-3">
            <div class="col-md-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Apellido" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="N° Documento" />
            </div>
            <div class="col-md-3">
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select">
                    <asp:ListItem Text="-- Especialidad --" Value="" />
                </asp:DropDownList>
            </div>
        </div>

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

        <hr />

        <asp:GridView ID="gvOdontologos" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="false"
            DataKeyNames="idOdontologo" EmptyDataText="No hay doctores registrados." Width="100%" OnRowDataBound="gvOdontologos_RowDataBound" OnRowCommand="gvOdontologo_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Nombre">
    <ItemTemplate>
        <asp:LinkButton 
            ID="lnkGestionar" 
            runat="server" 
            Text='<%# Eval("nombre") %>' 
            CommandName="Gestionar" 
            CommandArgument='<%# Eval("idOdontologo") %>' 
            CssClass="btn btn-link p-0 text-decoration-none" />
    </ItemTemplate>
</asp:TemplateField>
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="numeroDocumento" HeaderText="Número de Documento" />
                <%-- Usamos un TemplateField para acceder a la propiedad anidada 'nombre' de 'especialidad' --%>
                <asp:TemplateField HeaderText="Especialidad">
                    <ItemTemplate>
                        <%# Eval("especialidad.nombre") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="telefono" HeaderText="Número Telefónico" />
                <asp:BoundField DataField="correo" HeaderText="Correo Electrónico" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>