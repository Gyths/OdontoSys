<%@ Page Title="Reservar Cita" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="recepcionista_cita.aspx.cs" Inherits="OdontoSysFrontEnd.recepcionista_cita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<div class="container">
   
     <div class="card">
        <div class="card-header">
            <h2> Registrar cita</h2>
        </div>
        <div class="card-body">
            <div class="mb-3 row">
                <asp:Label ID="lblNombre" runat="server" Text="DNI del paciente: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtIdAlmacen" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
           <div class="mb-3 row">
                <asp:Label ID="Label1" runat="server" Text="Doctor encargado: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                   <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-select">
                         <asp:ListItem Text="-- Seleccione Doctor --" Value="" />
                         <asp:ListItem Text="Dr. Juan Pérez" Value="101" />
                         <asp:ListItem Text="Dra. María Gómez" Value="102" />
                         <asp:ListItem Text="Dr. Carlos López" Value="201" />
                         <asp:ListItem Text="Dra. Laura Martínez" Value="202" />
                         <asp:ListItem Text="Dr. Roberto Sánchez" Value="301" />
                   </asp:DropDownList>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="lblCorreo" runat="server" Text="Fecha: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
             <div class="mb-3 row">
                 <asp:Label ID="LblDNI" runat="server" Text="Hora de inicio: " CssClass="col-sm-4 col-form-label"></asp:Label>
                 <div class="col-sm-4">
                     <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
             </div>
             <div class="mb-3 row">
                 <asp:Label ID="LblTelefono" runat="server" Text="Teléfono: " CssClass="col-sm-4 col-form-label"></asp:Label>
                 <div class="col-sm-4">
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
                        <asp:ListItem Text="--Seleccione estado--" Value="" />
                        <asp:ListItem Text="Cancelada" Value="1" />
                        <asp:ListItem Text="Por cancelar" Value="2" />
                    </asp:DropDownList>
                 </div>
             </div>
            
        </div>
       
    </div>

    <div class="container row">
        <div class="text-end">
            <asp:Button ID="btnRegresar" CssClass="float-start btn btn-primary me-2" runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
            <asp:Button ID="btnInsertar" CssClass="float-start btn btn-secondary" runat="server" Text="Registrar" OnClick="btnInsertar_Click"/>                
        </div>
    </div>
</div>
</asp:Content>
