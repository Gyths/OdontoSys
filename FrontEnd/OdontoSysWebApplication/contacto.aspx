<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="OdontoSysWebApplication.contacto" MasterPageFile="~/Paciente.Master" %>

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
  <!-- Navbar (repetido en cada página según tu decisión) -->
  <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm">
    <div class="container">
      <a class="navbar-brand" href="Home.aspx">
        <asp:Image runat="server"
                   CssClass="d-inline-block align-text-top"
                   ImageUrl="~/Images/logo/horizontal.png"
                   AlternateText="Logo Sonrisa Vital"
                   Width="150" />
      </a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#mainNav">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="mainNav">
        <ul class="navbar-nav ms-auto">
          <li class="nav-item">
            <a class="nav-link" href="Home.aspx">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="MisCitas.aspx">Mis Citas</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="ReservaCita.aspx">Agendar Cita</a>
          </li>
          <li class="nav-item">
            <a class="nav-link active" href="Contacto.aspx">Contáctanos</a>
          </li>
          <li class="nav-item ms-3">
            <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="btn btn-outline-primary" OnClick="lnkCerrarSesion_Click">
              Cerrar Sesión
            </asp:LinkButton>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <!-- Contenido principal -->
  <div class="container mt-4">
    <h2 class="mb-4">Contáctanos</h2>

    <div class="card p-4 shadow-sm">
      <p><strong>📞 Teléfono:</strong> (01) 234-5678</p>
      <p><strong>📧 Correo electrónico:</strong> contacto@odontosys.com</p>
      <p><strong>🏥 Dirección:</strong> Av. Los Dientes 123, Lima, Perú</p>
      <p><strong>⏰ Horario de atención:</strong> Lunes a Viernes, 8:00 am – 6:00 pm</p>
    </div>

    <div class="mt-4">
      <h5>¿Tienes alguna duda o sugerencia?</h5>
      <p>Escríbenos y te responderemos lo antes posible.</p>
    </div>
  </div>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

