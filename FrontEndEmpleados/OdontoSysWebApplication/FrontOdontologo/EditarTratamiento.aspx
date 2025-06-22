<%@ Page Title="EditarTratamiento" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="EditarTratamiento.aspx.cs" Inherits="OdontoSysWebApplication.FrontOdontologo.EditarTratamiento" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Title -->
    <asp:Panel runat="server" CssClass="mb-4">
        <asp:Label runat="server" CssClass="h2 d-block" Text="Editar Tratamiento" />
        <div class="border-bottom border-primary mt-1" style="height: 3px;"></div>
    </asp:Panel>

    <!-- Especialidad Dropdown -->
    <asp:Panel runat="server" CssClass="mb-3">
        <asp:Label runat="server" AssociatedControlID="ddlEspecialidad" Text="Especialidad:" CssClass="form-label" />
        <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-control">
            <asp:ListItem Text="Selecciona especialidad" Value="" />
        </asp:DropDownList>
    </asp:Panel>

    <!-- Tratamiento Dropdown -->
    <asp:Panel runat="server" CssClass="mb-3">
        <asp:Label runat="server" AssociatedControlID="ddlTratamiento" Text="Tratamiento:" CssClass="form-label" />
        <asp:DropDownList ID="ddlTratamiento" runat="server" CssClass="form-control">
            <asp:ListItem Text="Selecciona tratamiento" Value="" />
        </asp:DropDownList>
    </asp:Panel>

    <!-- Cantidad Input -->
    <asp:Panel runat="server" CssClass="mb-3">
        <asp:Label runat="server" AssociatedControlID="txtCantidad" Text="Cantidad:" CssClass="form-label" />
        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" />
    </asp:Panel>

    <!-- Agregar Button -->
    <asp:Panel runat="server" CssClass="text-end">
        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
    </asp:Panel>

</asp:Content>