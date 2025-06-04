<%@ Page Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="ver_pagos.aspx.cs" Inherits="OdontoSysFrontEnd.ver_pagos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2><i class="fas fa-user-md me-2"></i>Listado de Documentos de Pago</h2>
        
        <div class="container row">
            <asp:GridView ID="dgvPagos" runat="server" AllowPaging="false" AutoGenerateColumns="false" 
                CssClass="table table-hover table-responsive table-striped">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="IdComprobante"/>
                    <asp:BoundField HeaderText="Fecha Emision" DataField="FechaEmision"/>  
                    <asp:BoundField HeaderText="Hora Emision" DataField="HoraEmision"/>
                    <asp:BoundField HeaderText="total" DataField="Total"/>
                    <asp:BoundField HeaderText="Metodo de Pago" DataField="MetodoDePago"/>
                   
                </Columns>
            </asp:GridView>
        </div>
        
        <div class="container row">
            <div class="text-end">
                <asp:Button ID="btnRegresar" CssClass="btn btn-primary" 
                    runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
