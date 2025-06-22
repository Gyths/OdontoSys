<%@ Page Title="Ver Comprobante" Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeBehind="VerComprobante.aspx.cs" Inherits="OdontoSysWebApplication.VerComprobante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-receipt"></i> Detalles del Comprobante</h2>
        <a href="javascript:history.back()" class="btn btn-secondary">← Volver</a>
    </div>

    <div class="card">
        <div class="card-header bg-info text-white">
            <h4 class="mb-0">Información del Comprobante</h4>
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>ID Comprobante:</strong></label>
                        <asp:TextBox ID="txtIdComprobante" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Fecha:</strong></label>
                        <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Monto Total:</strong></label>
                        <asp:TextBox ID="txtMontoTotal" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="col-md-6">
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Tipo de Comprobante:</strong></label>
                        <asp:TextBox ID="txtTipoComprobante" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Estado:</strong></label>
                        <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Método de Pago:</strong></label>
                        <asp:TextBox ID="txtMetodoPago" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
            
            <!-- Información adicional si existe -->
            <div class="row mt-3">
                <div class="col-12">
                    <div class="form-group mb-3">
                        <label class="form-label"><strong>Observaciones:</strong></label>
                        <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" 
                            TextMode="MultiLine" Rows="3" ReadOnly="true"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Mensaje de error si no se encuentra el comprobante -->
    <asp:Panel ID="pnlError" runat="server" Visible="false" CssClass="alert alert-danger mt-3">
        <i class="fas fa-exclamation-triangle"></i>
        <strong>Error:</strong> No se pudo cargar la información del comprobante.
    </asp:Panel>
</asp:Content>