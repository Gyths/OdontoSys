<%@ Page Title="" Language="C#" MasterPageFile="~/Public.Master" AutoEventWireup="true" CodeBehind="tipoUsuario.aspx.cs" Inherits="OdontoSysWebApplication.tipoUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    .fullvh { height: 100vh; }
    .logo-selector{
        max-width: 400px;
        margin: 0 auto 1.5rem;
        display: block;
        width: 100%;
        height: auto;
    }
  </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-center align-items-center fullvh">
    <div class="card p-4" style="max-width: 400px; width:100%;">
      
      <asp:Image runat="server"
                 ID="imgLogo"
                 ImageUrl="~/Images/Logo/horizontal.png"
                 CssClass="img-fluid logo-selector"
                 AlternateText="Logo de la clínica" />  
      <h4 class="mb-4 text-center">¿Qué tipo de usuario eres?</h4>
      
      <!-- Selector de tipo de usuario -->
      <div class="btn-group d-flex" role="group" aria-label="Tipo de usuario">
        <input type="radio" class="btn-check" name="userType" id="optOdontologo" autocomplete="off" value="odontologo">
        <label class="btn btn-outline-primary w-50" for="optOdontologo">
          <i class="fas fa-tooth me-2"></i>Odontólogo
        </label>

        <input type="radio" class="btn-check" name="userType" id="optRecepcionista" autocomplete="off" value="recepcionista">
        <label class="btn btn-outline-primary w-50" for="optRecepcionista">
          <i class="fas fa-user-nurse me-2"></i>Recepcionista
        </label>
      </div>

      <!-- Botón Siguiente -->
      <div class="d-grid mt-4">
        <asp:Button runat="server"
                    ID="btnSiguiente"
                    CssClass="btn btn-primary"
                    Text="Siguiente"
                    OnClick="btnSiguiente_Click"
                    Enabled="false" />
      </div>
    </div>
  </div>

  <!-- Script para habilitar el botón -->
  <script>
    document.addEventListener("DOMContentLoaded", function() {
      const radios = document.querySelectorAll('input[name="userType"]');
      const btn = document.getElementById('<%= btnSiguiente.ClientID %>');
      radios.forEach(r => {
        r.addEventListener('change', () => {
          btn.disabled = false;
        });
      });
    });
  </script>
  </script>
</asp:Content>
