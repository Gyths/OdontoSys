<%@ Page Title="" Language="C#" MasterPageFile="~/Recepcionista.Master" AutoEventWireup="true" CodeBehind="comprobanteCita.aspx.cs" Inherits="OdontoSysWebApplication.comprobanteCita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .label { 
            font-weight: bold; 
        }
        .comprobante-container {
            background-color: #f8f9fa;
            padding: 20px;
            border-radius: 8px;
            margin-top: 20px;
            box-shadow: 0 2px 4px rgba(0,0,0,0.1);
        }
        .btn-pdf {
            background-color: #dc3545;
            border-color: #dc3545;
            color: white;
            min-width: 150px;
        }
        .btn-pdf:hover {
            background-color: #c82333;
            border-color: #bd2130;
            color: white;
        }
        .btn-container {
            text-align: right;
            margin-top: 20px;
        }
        .btn-container .btn {
            margin-left: 10px;
            min-width: 120px;
        }
        .mensaje-container {
            margin-bottom: 20px;
        }
        .mensaje-container .alert {
            padding: 12px 20px;
            border-radius: 6px;
            font-size: 14px;
            font-weight: 500;
        }
        .text-success {
            background-color: #d4edda;
            border: 1px solid #c3e6cb;
            color: #155724;
        }
        .text-danger {
            background-color: #f8d7da;
            border: 1px solid #f5c6cb;
            color: #721c24;
        }
        .form-section {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            margin-bottom: 20px;
            box-shadow: 0 1px 3px rgba(0,0,0,0.1);
        }
        .section-title {
            color: #495057;
            font-size: 18px;
            font-weight: 600;
            margin-bottom: 15px;
            border-bottom: 2px solid #007bff;
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Mensajes (éxito / error) -->
    <div class="mensaje-container">
        <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" CssClass="alert"></asp:Label>
    </div>
    
    <!-- Panel para generar comprobante -->
    <asp:Panel ID="pnlGeneracion" runat="server">
        <div class="form-section">
            <h5 class="section-title">Generar Comprobante de Pago</h5>
            <div class="row mb-3">
                <div class="col-md-6">
                    <asp:Label ID="lblhead" runat="server" EnableViewState="false" CssClass="form-label">
                        Método de Pago <span class="text-danger">*</span>
                    </asp:Label>
                    <asp:DropDownList ID="ddlMetodoPago" runat="server"
                        CssClass="form-select"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlMetodoPago_SelectedIndexChanged"
                        AppendDataBoundItems="true">
                        <asp:ListItem Text="-- Seleccione un Método de Pago --" Value="" />
                    </asp:DropDownList>
                </div>
            </div>
            
            <div class="btn-container">
                <asp:Button ID="btnGenerar" runat="server" 
                    Text="Generar Comprobante" 
                    CssClass="btn btn-primary" 
                    OnClick="btnGenerar_Click"
                    Visible="false" />
            </div>
        </div>
    </asp:Panel>
    
    <!-- Panel para mostrar detalle del comprobante existente -->
    <asp:Panel ID="pnlDetalle" runat="server" Visible="false">
        <div class="comprobante-container">
            <h4 class="mb-3 text-primary">
                <i class="fas fa-file-invoice"></i> Comprobante de Pago
            </h4>
            <div class="row">
                <div class="col-md-6">
                    <p><span class="label">Fecha de emisión:</span>
                       <asp:Label ID="lblFecha" runat="server" /></p>
                    <p><span class="label">Hora de emisión:</span>
                       <asp:Label ID="lblHora" runat="server" /></p>
                </div>
                <div class="col-md-6">
                    <p><span class="label">Total:</span>
                       <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold text-primary" /></p>
                    <p><span class="label">Método de pago:</span>
                       <asp:Label ID="lblMetodoPago" runat="server" /></p>
                </div>
            </div>  
            
            <!-- Botón para descargar PDF -->
            <div class="btn-container">
                <asp:Button ID="btnDescargarPDF" runat="server" 
                    Text="📄 Descargar PDF" 
                    CssClass="btn btn-pdf" 
                    OnClick="btnDescargarPDF_Click" />
            </div>
        </div>
    </asp:Panel>
    
    <!-- Botones de navegación -->
    <div class="btn-container">
        <asp:Button ID="btnVolver" runat="server"
            Text="← Volver"
            CssClass="btn btn-secondary"
            OnClick="btnVolver_Click" />
    </div>
</asp:Content>