<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="cuentaEliminada.aspx.cs" Inherits="OdontoSysWebApplication.cuentaEliminada" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
  <!-- Redirige automáticamente después de 2s -->
  <meta http-equiv="refresh" content="2;url=inicioSesion.aspx" />
  <style>
    /* Opcional: que el mensaje siempre quede centrado en toda la altura */
    .fullvh { height: 100vh; }
  </style>
</asp:Content>

<asp:Content ID="BodyContent" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="d-flex justify-content-center align-items-center fullvh">
    <div class="card text-center shadow-sm" style="max-width: 500px;">
      <div class="card-body">
        <i class="fas fa-check-circle fa-4x text-success mb-3"></i>
        <h1 class="card-title mb-2">Cuenta eliminada</h1>
        <p class="card-text">
          Tu cuenta ha sido eliminada exitosamente.<br/>
          Serás redirigido en unos segundos...
        </p>
      </div>
    </div>
  </div>
</asp:Content>
