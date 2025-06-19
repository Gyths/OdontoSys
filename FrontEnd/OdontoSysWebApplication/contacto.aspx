<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="OdontoSysWebApplication.contacto" MasterPageFile="~/Paciente.Master" %>

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
            color: #0d6efd;
            text-shadow: none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Navbar (repetido en cada página según tu decisión) -->
    <nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm fixed-top">
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
    <div class="container mt-5">
        <h2 class="mb-4">Contáctanos</h2>

        <div class="row">
            <!-- Columna izquierda: contenido original -->
            <div class="col-md-6">
                <p>Si tienes preguntas, sugerencias o necesitas más información, no dudes en escribirnos o visitarnos.</p>
                <p>También puedes encontrarnos en nuestras redes sociales o llamarnos directamente a nuestro número de atención al cliente.</p>
                <p class="mb-0"><strong>Teléfono:</strong> +51 987 654 321</p>
                <p class="mb-0"><strong>Email:</strong> sonrisavital@gmail.com</p>
                <p><strong>Horario de atención:</strong> Lunes a Sábado, 9:00 a.m. – 9:00 p.m.</p>
            </div>

            <!-- Columna derecha: texto + mapa -->
            <div class="col-md-6">
                <p class="fw-semibold mb-2">Te esperamos para atenderte en:</p>
                <div class="ratio ratio-4x3">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d15606.18877115118!2d-77.08987355232236!3d-12.07464504198076!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x9105c9104ad3bfe1%3A0xa638264856d65e9e!2sDENTOMAS%20ESPECIALIDADES%20ODONTOL%C3%93GICAS!5e0!3m2!1ses-419!2spe!4v1750290600346!5m2!1ses-419!2spe"
                        width="400" height="300" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>

