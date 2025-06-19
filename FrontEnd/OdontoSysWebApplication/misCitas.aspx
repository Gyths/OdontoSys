<%@ Page Title="Mis Citas" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="misCitas.aspx.cs" Inherits="OdontoSysWebApplication.misCitas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            padding-top: 80px;
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenido de Mis Citas -->
    <div class="container mt-5 pt-3">
        <h2 class="mb-4">Mis Citas</h2>

        <!-- Filtro de estado -->
        <div class="mb-3">
            <label class="form-label">Filtrar por estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true"
                CssClass="form-select w-auto d-inline-block"
                OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                <asp:ListItem Text="RESERVADA" Value="RESERVADA" />
                <asp:ListItem Text="ATENDIDA" Value="ATENDIDA" />
                <asp:ListItem Text="CANCELADA" Value="CANCELADA" />
            </asp:DropDownList>
        </div>

        <!-- Resultados -->
        <asp:Literal ID="ltCitas" runat="server" />
    </div>
</asp:Content>
