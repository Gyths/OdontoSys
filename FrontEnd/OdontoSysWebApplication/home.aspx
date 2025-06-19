<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Paciente.Master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="OdontoSysWebApplication.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .hero {
            background: url('/Images/home/fondo.png') no-repeat center center;
            background-size: cover;
            height: calc(100vh - 56px);
            display: flex;
            align-items: center;
        }

        .hero-text h1,
        .hero-text p {
            color: #0d6efd;
            text-shadow: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Hero -->
    <div class="hero">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6 hero-text">
                    <h1>Bienvenido <%: NombrePaciente %></h1>
                    <p class="lead">
                        Tu sonrisa, nuestra mayor prioridad. ¡Reserva tu cita en un clic!
                    </p>
                    <a href="reservaCita.aspx" class="btn btn-primary">Agendar Cita</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

