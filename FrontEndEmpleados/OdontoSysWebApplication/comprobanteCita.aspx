<%@ Page Title="" Language="C#" MasterPageFile="~/Recepcionista.Master" AutoEventWireup="true" CodeBehind="comprobanteCita.aspx.cs" Inherits="OdontoSysWebApplication.comprobanteCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label { font-weight:bold; }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- mensajes (éxito / error) -->
    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>

    <!-- Panel para generar comprobante -->
    <div class="row mb-3">
    <div class="col-md-6">
        <label class="form-label">MetodoPago</label>
        <asp:DropDownList ID="ddlMetodoPago" runat="server"
            CssClass="form-select"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged"
            AppendDataBoundItems="true">
            <asp:ListItem Text="-- Seleccione un Metodo de Pago --" Value="" />
        </asp:DropDownList>
    </div>
</div>

    <div class="mt-4">
        <asp:Button ID="btnGenerar" runat="server" Text="GenerarComprobante" CssClass="btn btn-warning" OnClick="btnGenerar_Click" />
    </div>
    <!-- Panel para mostrar detalle -->
    <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
        <h4>Datos del comprobante</h4>
        <p><span class="label">Fecha de emisión:</span>
           <asp:Label ID="lblFecha" runat="server" /></p>
        <p><span class="label">Hora de emisión:</span>
           <asp:Label ID="lblHora" runat="server" /></p>
        <p><span class="label">Total:</span>
           <asp:Label ID="lblTotal" runat="server" /></p>
        <p><span class="label">Método de pago:</span>
           <asp:Label ID="lblMetodoPago" runat="server" /></p>
    </asp:Panel>
</asp:Content>
