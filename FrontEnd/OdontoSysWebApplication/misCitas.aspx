<%@ Page Title="Mis Citas" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="misCitas.aspx.cs" Inherits="OdontoSysWebApplication.misCitas" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
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
            <asp:LinkButton ID="lnkCerrarSesion" runat="server" CssClass="btn btn-outline-primary" OnClick="lnkCerrarSesion_Click">Cerrar Sesión</asp:LinkButton>
          </li>
        </ul>
      </div>
    </div>
  </nav>

  <div class="container mt-5 pt-4">
    <h2 class="mb-4">Mis Citas</h2>

    <!-- Lista de Citas -->
    <asp:Literal ID="ltCitas" runat="server" />

    <!-- Panel de Valoración -->
    <asp:Panel ID="pnlValoracion" runat="server" CssClass="card mt-4 d-none">
      <div class="card-body">
        <h5 class="card-title">Valorar cita</h5>

        <div class="mb-3">
          <label class="form-label">Comentario</label>
          <asp:TextBox ID="txtComentario" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
        </div>

        <div class="mb-3">
          <label class="form-label">Calificación (1 a 5)</label>
          <asp:DropDownList ID="ddlPuntaje" runat="server" CssClass="form-select">
            <asp:ListItem Text="1" Value="1" />
            <asp:ListItem Text="2" Value="2" />
            <asp:ListItem Text="3" Value="3" />
            <asp:ListItem Text="4" Value="4" />
            <asp:ListItem Text="5" Value="5" />
          </asp:DropDownList>
        </div>

        <asp:HiddenField ID="hfIdCita" runat="server" />

        <asp:Button ID="btnEnviarValoracion" runat="server" CssClass="btn btn-primary" Text="Enviar Valoración" OnClick="btnEnviarValoracion_Click" />
      </div>
    </asp:Panel>
  </div>

  <script>
      function valorarCita(event, idCita) {
          event.preventDefault();
          document.getElementById('<%= hfIdCita.ClientID %>').value = idCita;
        document.getElementById('<%= pnlValoracion.ClientID %>').classList.remove('d-none');
      window.scrollTo({ top: document.getElementById('<%= pnlValoracion.ClientID %>').offsetTop, behavior: 'smooth' });
      }
  </script>

  <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</asp:Content>
