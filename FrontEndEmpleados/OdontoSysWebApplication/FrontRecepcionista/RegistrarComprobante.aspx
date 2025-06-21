<%@ Page Title="Registrar Comprobante" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegistrarComprobante.aspx.cs" Inherits="OdontoSysWebApplication.RegistrarComprobante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
  <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.4.0/css/all.min.css" rel="stylesheet" />
  <style>
    html, body, form { height: 100%; margin: 0; }
    .register-container { display: flex; height: 100vh; }
    .register-form-side {
      flex: 0 0 35%;
      display: flex; 
      align-items: center; 
      justify-content: center;
    }
    .register-bg-side {
      flex: 0 0 65%;
      background: url('/Images/crearCuenta/fondo.png') no-repeat center center;
      background-size: cover;
    }
    .form-box {
      width: 100%;
      max-width: 500px;
      background: #fff;
      padding: 2rem;
      border-radius: .5rem;
      box-shadow: 0 0 .5rem rgba(0,0,0,.1);
    }
    .register-logo {
      display: block;
      margin: 0 auto 1.5rem;
      max-width: 200px;
    }
  </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <div class="register-container">
    <div class="register-form-side">
      <div class="form-box" id="pnlFormulario" runat="server">
        <asp:Image ID="imgLogoReg" runat="server"
          ImageUrl="~/Images/logo/horizontal.png"
          AlternateText="Logo" CssClass="register-logo" />

        <h3 class="text-center mb-4"><i class="fas fa-receipt me-2"></i>Registrar Comprobante</h3>
        <asp:Label ID="lblMensaje" runat="server" CssClass="form-text text-success d-block text-center mb-3" EnableViewState="false" />

        <div class="row g-3">
          <!-- Fecha y hora de emisión -->
          <div class="col-md-6">
            <label class="form-label">Fecha Emisión</label>
            <asp:TextBox ID="txtFechaEmision" runat="server" CssClass="form-control" ReadOnly="true" />
          </div>
          <div class="col-md-6">
            <label class="form-label">Hora Emisión</label>
            <asp:TextBox ID="txtHoraEmision" runat="server" CssClass="form-control" ReadOnly="true" />
          </div>

          <!-- Total -->
          <div class="col-md-12">
            <label class="form-label">Total (S/)</label>
            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control" TextMode="Number" required="required" />
          </div>

          <!-- Método de pago -->
          <div class="col-md-12">
            <label class="form-label">Método de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server" CssClass="form-select" required="required">
              <asp:ListItem Text="-- Seleccione --" Value="" />
              <asp:ListItem Text="EFECTIVO" Value="EFECTIVO" />
              <asp:ListItem Text="TARJETA" Value="TARJETA" />
              <asp:ListItem Text="TRANSFERENCIA" Value="TRANSFERENCIA" />
                <asp:ListItem Text="YAPE" Value="YAPE" />
                <asp:ListItem Text="PLIN" Value="PLIN" />
            </asp:DropDownList>
          </div>

          <!-- Botón -->
          <div class="col-12">
            <div class="d-grid">
              <asp:Button ID="btnGuardar" runat="server"
                CssClass="btn btn-primary" Text="Registrar Comprobante"
                OnClick="btnGuardar_Click" />
            </div>
          </div>
        </div>
      </div>
    </div>
    <div class="register-bg-side d-none d-md-block"></div>
  </div>
</asp:Content>
