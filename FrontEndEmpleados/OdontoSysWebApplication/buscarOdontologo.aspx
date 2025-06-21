<%@ Page Title="Buscador de Doctores" Language="C#" MasterPageFile="~/Recepcionista.master" AutoEventWireup="true" CodeBehind="buscarOdontologo.aspx.cs" Inherits="OdontoSysWebApplication.buscarOdontologo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h2>Buscar Odontólogos</h2>
        <div class="row g-2 mb-3">
            <div class="col-md-3">
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Nombre" />
            </div>
            <div class="col-md-4">
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" placeholder="Apellidos" />
            </div>
            <div class="col-md-3">
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" placeholder="Documento" />
            </div>
        </div>
        <div class="row mb-3">

            <div class="col-md-3">
                <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select">
                    <asp:ListItem Text="-- Especialidad --" Value="" />
                </asp:DropDownList>
            </div>
        </div>

        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-primary" OnClick="btnBuscar_Click" />

        <hr />
        <asp:Label ID="lblMensaje"
           runat="server"
           EnableViewState="false"
           CssClass=""
           Text=""></asp:Label>
        <asp:GridView ID="gvOdontologos" runat="server" CssClass="table table-striped mt-3" AutoGenerateColumns="false"
            DataKeyNames="idOdontologo" EmptyDataText="No hay doctores registrados." Width="100%" OnRowDataBound="gvOdontologos_RowDataBound" OnRowCommand="gvOdontologo_RowCommand">
            <Columns>
                <asp:BoundField DataField="nombre" HeaderText="Nombres" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="numeroDocumento" HeaderText="Número de Documento" />
                <asp:TemplateField HeaderText="Especialidad">
                    <ItemTemplate>
                        <%# Eval("especialidad.nombre") %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="telefono" HeaderText="Número Telefónico" />
                <asp:BoundField DataField="correo" HeaderText="Correo Electrónico" />
                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Button runat="server"
                            Text="Ver Citas"
                            CssClass="btn btn-sm btn-primary"
                            CommandName="Gestionar"
                            CommandArgument='<%# Eval("IdOdontologo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
