<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Paciente.Master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="OdontoSysWebApplication.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <style>
        body {
            padding-top: 80px;
        }

        .navbar {
            background: #fff;
            z-index: 1000;
        }

        .hero {
            background: url('/Images/home/fondo.png') no-repeat center center;
            background-size: cover;
            height: calc(100vh - 56px);
            display: flex;
            align-items: center;
        }

        .hero-text h1,
        .hero-text p {
            color: #0d6efd; /* Azul contrastante */
            text-shadow: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Navbar -->
    <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm fixed-top">
        <div class="container">
            <a class="navbar-brand" href="Home.aspx">
                <asp:Image runat="server"
                    CssClass="d-inline-block align-text-top"
                    ImageUrl="~/Images/logo/horizontal.png"
                    AlternateText="Logo Sonrisa Vital"
                    Width="150" />
            </a>
            <button class="navbar-toggler" type="button"
                data-bs-toggle="collapse"
                data-bs-target="#mainNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="mainNav">
                <ul class="navbar-nav ms-auto">
                    <li class="nav-item">
                        <a class="nav-link active" href="Home.aspx">Home</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="MisCitas.aspx">Mis Citas</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="ReservaCita.aspx">Agendar Cita</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Contacto.aspx">Contáctanos</a>
                    </li>
                    <li class="nav-item ms-3">
                        <asp:LinkButton ID="lnkCerrarSesion"
                            runat="server"
                            CssClass="btn btn-outline-primary"
                            OnClick="lnkCerrarSesion_Click">
              Cerrar Sesión
                        </asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
    </nav>

    <!-- Hero -->
    <div class="hero">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6 hero-text">
                    <h1>Bienvenido <%= NombrePaciente %>
                    </h1>
                    <p class="lead">
                        Tu sonrisa, nuestra mayor prioridad. ¡Reserva tu cita en un clic!
                    </p>
                    <a href="reservaCita.aspx"
                        class="btn btn-primary">Agendar Cita
                    </a>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
