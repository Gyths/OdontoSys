<%@ Page Title="Inicio" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Home.aspx.cs"
    Inherits="OdontoSysWebApplication.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <style>
    .navbar {
      position: static;
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
      color: #0d6efd;
      text-shadow: none;
    }
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="hero">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6 hero-text">
                    <h1>
                      Bienvenido
                      <%
                        string tipo = Session["TipoCuenta"] as string;
                        if (tipo == "recepcionista") {
                           var rec = Session["Usuario"] as OdontoSysWebApplication.RecepcionistaWS.recepcionista;
                           Response.Write(", " + rec.nombre);
                        } else if (tipo == "odontologo") {
                           var odo = Session["Usuario"] as OdontoSysWebApplication.OdontologoWS.odontologo;
                           Response.Write(", Dr. " + odo.nombre);
                        } else {
                           Response.Write(" a OdontoSys Empleados");
                        }
                        %>
                    </h1>
                    <p class="lead">
                        Plataforma exclusiva para odontólogos y recepcionistas. 
                        <% if (tipo == null) { %>
                            Inicia sesión o crea tu cuenta para comenzar.
                        <% } else { %>
                            Accede a tus funciones administrativas o clínicas.
                        <% } %>
                    </p>
                    <% if (tipo == "recepcionista") { %>
                      <a href="buscarPaciente.aspx" class="btn btn-outline-success me-2 mt-3">Gestionar Pacientes</a>
                      <a href="buscarOdontologo.aspx" class="btn btn-outline-primary mt-3">Gestionar Odontólogos</a>
                    <% } else if (tipo == "odontologo") { %>
                     <a href="/FrontOdontologo/CitasPorAtender.aspx" class="btn btn-outline-success me-2 mt-3">Ver Agenda</a>
                    <a href="historialPacientes.aspx" class="btn btn-outline-primary mt-3">Historial de Pacientes</a>
                    <% } %>
                    <% if (tipo == null) { %>
                        <a href="inicioSesion.aspx" class="btn btn-primary btn-lg mt-3 me-2">Iniciar Sesión</a>
                        <a href="crearCuenta.aspx" class="btn btn-outline-primary btn-lg mt-3">Crear Cuenta</a>
                    <% } %>
                </div>
            </div>
        </div>
    </div>
</asp:Content>