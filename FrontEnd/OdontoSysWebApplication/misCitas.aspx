<%@ Page Title="Mis Citas" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="misCitas.aspx.cs" Inherits="OdontoSysWebApplication.misCitas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            padding-top: 80px;
        }

        .navbar {
            background: #fff;
            z-index: 1000;
        }
    </style>

</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm fixed-top">
        <div class="container">
            <a class="navbar-brand" href="home.aspx">
                <asp:Image runat="server" CssClass="d-inline-block align-text-top" ImageUrl="~/Images/logo/horizontal.png" AlternateText="Logo Sonrisa Vital" Width="150" />
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#mainNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="mainNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item"><a class="nav-link" href="home.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link active" href="misCitas.aspx">Mis Citas</a></li>
                    <li class="nav-item"><a class="nav-link" href="reservaCita.aspx">Agendar Cita</a></li>
                    <li class="nav-item"><a class="nav-link" href="contacto.aspx">Contáctanos</a></li>
                    <li class="nav-item ms-3">
                        <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="btn btn-outline-primary" OnClick="lnkCerrarSesion_Click">
              Cerrar Sesión
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Filtro de estado -->
    <div class="container mt-5 pt-3">
        <h2 class="mb-4">Mis Citas</h2>
        <div class="mb-3">
            <label class="form-label">Filtrar por estado:</label>
            <asp:DropDownList ID="ddlEstado" runat="server" AutoPostBack="true" CssClass="form-select w-auto d-inline-block" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged">
                <asp:ListItem Text="RESERVADA" Value="RESERVADA" />
                <asp:ListItem Text="ATENDIDA" Value="ATENDIDA" />
                <asp:ListItem Text="CANCELADA" Value="CANCELADA" />
            </asp:DropDownList>
        </div>

        <!-- Resultados -->
        <asp:Literal ID="ltCitas" runat="server" />
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
