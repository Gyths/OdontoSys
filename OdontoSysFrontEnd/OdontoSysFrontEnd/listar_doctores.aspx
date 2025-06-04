<%@ Page Title="" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="listar_doctores.aspx.cs" Inherits="OdontoSysWA.listar_doctores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2><i class="fas fa-user-md me-2"></i>Listado de Doctores</h2>
        
        <div class="container row">
            <asp:GridView ID="dgvDoctores" runat="server" AllowPaging="false" AutoGenerateColumns="false" 
                CssClass="table table-hover table-responsive table-striped">
                <Columns>
                    <asp:BoundField HeaderText="ID" DataField="IdOdontologo"/>
                    <asp:BoundField HeaderText="Nombre Completo" DataField="NombreCompleto"/>  
                    <asp:BoundField HeaderText="DNI" DataField="Dni"/>
                    <asp:BoundField HeaderText="Teléfono" DataField="Telefono"/>
                    <asp:BoundField HeaderText="Email" DataField="Email"/>
                    <asp:BoundField HeaderText="Especialidad" DataField="Especialidad"/>
                   
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