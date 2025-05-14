<%@ Page Title="Reservar Cita" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="reservar_cita.aspx.cs" Inherits="OdontoSysFrontEnd.reservar_cita" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
<div class="container">
    <h2>Reservar cita</h2>
    
    <div class="container row mb-3">
        <div class="col-md-4">
            <label for="ddlEspecialidad" class="form-label">Especialidad:</label>
            <asp:DropDownList ID="ddlEspecialidad" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione Especialidad --" Value="" />
                <asp:ListItem Text="Ortodoncia general" Value="1" />
                <asp:ListItem Text="Ortodoncia" Value="2" />
                <asp:ListItem Text="Pediatría" Value="3" />
                <asp:ListItem Text="Endodoncia" Value="4" />
                <asp:ListItem Text="Cirugía" Value="5" />
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label for="ddlDoctor" class="form-label">Doctor:</label>
            <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione Doctor --" Value="" />
                <asp:ListItem Text="Dr. Juan Pérez" Value="101" />
                <asp:ListItem Text="Dra. María Gómez" Value="102" />
                <asp:ListItem Text="Dr. Carlos López" Value="201" />
                <asp:ListItem Text="Dra. Laura Martínez" Value="202" />
                <asp:ListItem Text="Dr. Roberto Sánchez" Value="301" />
            </asp:DropDownList>
        </div>
        <div class="col-md-4">
            <label for="ddlHorario" class="form-label">Horario disponible:</label>
            <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione Horario --" Value="" />
                <asp:ListItem Text="09:00 AM - 09:30 AM" Value="1" />
                <asp:ListItem Text="09:30 AM - 10:00 AM" Value="2" />
                <asp:ListItem Text="10:00 AM - 10:30 AM" Value="3" />
                <asp:ListItem Text="10:30 AM - 11:00 AM" Value="4" />
                <asp:ListItem Text="11:00 AM - 11:30 AM" Value="5" />
            </asp:DropDownList>
        </div>
    </div>

    <div class="container row">
        <div class="text-end">
            <asp:Button ID="btnRegresar" CssClass="float-start btn btn-primary me-2" runat="server" Text="Regresar" OnClick="btnRegresar_Click"/>
            <asp:Button ID="btnInsertar" CssClass="float-start btn btn-secondary" runat="server" Text="Reservar" OnClick="btnInsertar_Click"/>                
        </div>
    </div>
</div>
</asp:Content>