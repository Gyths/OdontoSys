<%@ Page Title="Inicio" Language="C#" MasterPageFile="Odontologo.Master"
    AutoEventWireup="true" CodeBehind="homeOdontologo.aspx.cs"
    Inherits="OdontoSysWebApplication.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
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
    <div class="hero">
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md-6 hero-text">
                    <h1>
                      Bienvenido
                      <%
                        var odo = Session["Usuario"] as OdontoSysWebApplication.OdontologoWS.odontologo;
                        Response.Write(", Dr. " + odo.nombre);
                      %>
                    </h1>
                    <a href="CitasPorAtender.aspx" class="btn btn-outline-success me-2 mt-3">Ver Agenda</a>
                    <!-- <a href="historialPacientes.aspx" class="btn btn-outline-primary mt-3">Historial de Pacientes</a>-->
                   
                </div>
            </div>
        </div>
    </div>
</asp:Content>