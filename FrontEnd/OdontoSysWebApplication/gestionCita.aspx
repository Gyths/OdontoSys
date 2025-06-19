<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="gestionCita.aspx.cs" Inherits="OdontoSysWebApplication.gestionCita" %>

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
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                        <a class="nav-link active" href="MisCitas.aspx">Mis Citas</a>
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

    <div class="container mt-5">
        <h2 class="mb-4">Detalle de Cita</h2>

        <div class="card shadow-sm p-4 mb-3">
            <p><strong>Fecha:</strong>
                <asp:Label ID="lblFecha" runat="server" /></p>
            <p><strong>Hora:</strong>
                <asp:Label ID="lblHora" runat="server" /></p>
            <p><strong>Odontólogo:</strong>
                <asp:Label ID="lblOdontologo" runat="server" /></p>
            <p><strong>Especialidad:</strong>
                <asp:Label ID="lblEspecialidad" runat="server" /></p>
            <p>
                <strong>Estado:</strong>
                <span id="estadoCita" runat="server" class="badge"></span>
            </p>
            <p><strong>Habitación:</strong>
                <asp:Label ID="lblHabitacion" runat="server" /></p>
            <p><strong>Piso:</strong>
                <asp:Label ID="lblPiso" runat="server" /></p>
        </div>

        <asp:Panel ID="panelValoracion" runat="server" CssClass="card shadow-sm p-4 mt-4" Visible="false">
            <h5>Valoración de la atención</h5>

            <asp:Panel ID="panelFormularioValoracion" runat="server" Visible="false">
                <div class="mb-3">
                    <label for="txtComentario" class="form-label">Comentario (máx. 250 caracteres):</label>
                    <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine" MaxLength="250" Rows="4"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ddlCalificacion" class="form-label">Calificación:</label>
                    <asp:DropDownList ID="ddlCalificacion" runat="server" CssClass="form-select">
                        <asp:ListItem Text="Seleccione una opción" Value="" />
                        <asp:ListItem Text="1" Value="1" />
                        <asp:ListItem Text="2" Value="2" />
                        <asp:ListItem Text="3" Value="3" />
                        <asp:ListItem Text="4" Value="4" />
                        <asp:ListItem Text="5" Value="5" />
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnEnviarValoracion" runat="server" Text="Enviar Valoración"
                    CssClass="btn btn-success"
                    OnClick="btnEnviarValoracion_Click" />
            </asp:Panel>

            <asp:Panel ID="panelResumenValoracion" runat="server" Visible="false">
                <p><strong>Comentario:</strong></p>
                <asp:Label ID="lblComentario" runat="server" CssClass="form-control" />
                <p class="mt-3">
                    <strong>Calificación:</strong>
                    <asp:Label ID="lblCalificacion" runat="server" CssClass="badge bg-primary" />
                </p>
            </asp:Panel>
        </asp:Panel>

        <asp:Button ID="btnCancelarCita" runat="server"
            Text="Cancelar Cita"
            CssClass="btn btn-danger"
            OnClick="btnCancelarCita_Click"
            OnClientClick="return confirm('¿Estás seguro de cancelar esta cita?');"
            Visible="false" />
        <asp:Button ID="btnRegresar" runat="server"
            Text="Regresar"
            CssClass="btn btn-secondary mt-3"
            OnClick="btnRegresar_Click" />
    </div>
</asp:Content>

