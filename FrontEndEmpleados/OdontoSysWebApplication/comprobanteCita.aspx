<%@ Page Title="" Language="C#" MasterPageFile="~/Recepcionista.Master" AutoEventWireup="true" CodeBehind="comprobanteCita.aspx.cs" Inherits="OdontoSysWebApplication.comprobanteCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label { font-weight:bold; }
        .comprobante-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
            margin-top: 20px;
        }
        .btn-pdf {
            background-color: #dc3545;
            border-color: #dc3545;
            color: white;
        }
        .btn-pdf:hover {
            background-color: #c82333;
            border-color: #bd2130;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- mensajes (éxito / error) -->
    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false"></asp:Label>
    
    <!-- Panel para generar comprobante -->
    <div class="row mb-3">
        <div class="col-md-6">
            <label class="form-label">Método de Pago</label>
            <asp:DropDownList ID="ddlMetodoPago" runat="server"
                CssClass="form-select"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="-- Seleccione un Método de Pago --" Value="" />
            </asp:DropDownList>
        </div>
    </div>
    
    <div class="mt-4">
        <asp:Button ID="btnGenerar" runat="server" Text="Generar Comprobante" CssClass="btn btn-warning" OnClick="btnGenerar_Click" />
    </div>
    
    <!-- Panel para mostrar detalle -->
    <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
        <div class="comprobante-container">
            <h4 class="mb-3">Datos del Comprobante</h4>
            <div class="row">
                <div class="col-md-6">
                    <p><span class="label">Fecha de emisión:</span>
                       <asp:Label ID="lblFecha" runat="server" /></p>
                    <p><span class="label">Hora de emisión:</span>
                       <asp:Label ID="lblHora" runat="server" /></p>
                </div>
                <div class="col-md-6">
                    <p><span class="label">Total:</span>
                       <asp:Label ID="lblTotal" runat="server" /></p>
                    <p><span class="label">Método de pago:</span>
                       <asp:Label ID="lblMetodoPago" runat="server" /></p>
                </div>
            </div>
            
            <!-- Botón para descargar PDF -->
            <div class="mt-4 text-center">
                <asp:Button ID="btnDescargarPDF" runat="server" 
                    Text="Descargar PDF" 
                    CssClass="btn btn-pdf" 
                    OnClick="btnDescargarPDF_Click" 
                    Visible="false" />
            </div>
        </div>
    </asp:Panel>
</asp:Content>