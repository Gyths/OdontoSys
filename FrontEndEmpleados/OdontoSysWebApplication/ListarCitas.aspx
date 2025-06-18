<%@ Page Title="Citas del Paciente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ListarCitas.aspx.cs" Inherits="OdontoSysWebApplication.ListarCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-calendar-alt"></i> Citas del Paciente</h2>
        <a href="ListarPacientes.aspx" class="btn btn-secondary">← Volver a Pacientes</a>
    </div>

    <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="false"
        CssClass="table table-striped"
        EmptyDataText="No hay citas registradas para este paciente.">

        <Columns>
            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="horaInicio" HeaderText="Hora de Inicio" />
            <asp:BoundField DataField="idRecepcionista" HeaderText="ID Recepcionista" />
            <asp:BoundField DataField="idOdontologo" HeaderText="ID Odontólogo" />
            <asp:BoundField DataField="idComprobante" HeaderText="ID Comprobante" />
            <asp:BoundField DataField="idValoracion" HeaderText="ID Valoración" />
            <asp:BoundField DataField="estado" HeaderText="Estado" />
        </Columns>

        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>