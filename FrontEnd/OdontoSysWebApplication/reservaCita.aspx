<%@ Page Title="" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="reservaCita.aspx.cs" Inherits="OdontoSysWebApplication.reservaCita" %>

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

        .semana-btn {
            margin-right: 0.5rem;
            margin-bottom: 0.5rem;
        }

            .semana-btn.active {
                background-color: #0d6efd;
                color: white;
                border-color: #0d6efd;
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
                    <li class="nav-item"><a class="nav-link" href="misCitas.aspx">Mis Citas</a></li>
                    <li class="nav-item"><a class="nav-link active" href="reservaCita.aspx">Agendar Cita</a></li>
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

    <div class="container mt-5 pt-4">
        <h2 class="mb-4">Agendar Nueva Cita</h2>

        <div class="row mb-3">
            <div class="col-md-6">
                <label class="form-label">Especialidad</label>
                <asp:DropDownList ID="ddlEspecialidades" runat="server"
                    CssClass="form-select"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Text="-- Seleccione una especialidad --" Value="" />
                </asp:DropDownList>
            </div>
        </div>

        <asp:Panel ID="pnlOdontologos" runat="server" Visible="false">
            <div class="row mb-3">
                <div class="col-md-6">
                    <label class="form-label">Odontólogo</label>
                    <asp:DropDownList ID="ddlOdontologos" runat="server"
                        CssClass="form-select"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlOdontologos_SelectedIndexChanged"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="-- Seleccione un odontólogo --" Value="" />
                    </asp:DropDownList>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlSemana" runat="server" Visible="false" CssClass="mb-3">
            <label class="form-label d-block">Selecciona el rango</label>
            <asp:LinkButton ID="btnEstaSemana" runat="server"
                CssClass="btn btn-outline-primary semana-btn"
                OnClick="BtnSemana_Click" CommandArgument="0">
        Esta semana
            </asp:LinkButton>
            <asp:LinkButton ID="btnSiguienteSemana" runat="server"
                CssClass="btn btn-outline-primary semana-btn"
                OnClick="BtnSemana_Click" CommandArgument="1">
        Siguiente semana
            </asp:LinkButton>
            <asp:LinkButton ID="btnDosSemanas" runat="server"
                CssClass="btn btn-outline-primary semana-btn"
                OnClick="BtnSemana_Click" CommandArgument="2">
        Dentro de 2 semanas
            </asp:LinkButton>
        </asp:Panel>

        <asp:Panel ID="pnlSlots" runat="server" Visible="false" CssClass="mb-4">
            <asp:Literal ID="ltSlots" runat="server" />
        </asp:Panel>

        <asp:Button ID="btnConfirmarCita" runat="server"
            CssClass="btn btn-primary mb-3"
            Text="Registrar Cita"
            OnClick="btnConfirmarCita_Click"
            Visible="false" />

        <asp:HiddenField ID="hfFechaSeleccionada" runat="server" />
        <asp:HiddenField ID="hfHoraSeleccionada" runat="server" />
        <asp:Literal ID="ltDisponibilidad" runat="server" />
    </div>

    <script>
        function seleccionarSlot(fecha, hora) {
            document.getElementById('<%= hfFechaSeleccionada.ClientID %>').value = fecha;
          document.getElementById('<%= hfHoraSeleccionada.ClientID %>').value = hora;
            __doPostBack('SeleccionarSlot', '');
        }
    </script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
