<%@ Page Title="Contáctanos" Language="C#" AutoEventWireup="true" CodeBehind="contacto.aspx.cs" Inherits="OdontoSysWebApplication.contacto" MasterPageFile="~/Paciente.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            padding-top: 80px;
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
</asp:Content>

