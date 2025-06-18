<%@ Page Title="Citas del Paciente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ListarCitas.aspx.cs" Inherits="OdontoSysWebApplication.ListarCitas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-calendar-alt"></i> Citas del Paciente</h2>
        <a href="ListarPacientes.aspx" class="btn btn-secondary">← Volver a Pacientes</a>
    </div>

   <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="false"
    CssClass="table table-striped"
    EmptyDataText="No hay citas registradas para este paciente."
    OnRowCommand="gvCitas_RowCommand"
       OnRowDataBound="gvCitas_RowDataBound">
    
    <Columns>
        <asp:BoundField DataField="fecha" HeaderText="Fecha" />
<asp:BoundField DataField="horaInicio" HeaderText="Hora de Inicio" />

<asp:BoundField DataField="odontologoNombre" HeaderText="Odontólogo" />
<asp:BoundField DataField="calificacion" HeaderText="Calificación" />
<asp:BoundField DataField="estado" HeaderText="Estado" />

<asp:TemplateField HeaderText="Comprobante">
    <ItemTemplate>
        <%# (bool)Eval("tieneComprobante") ? "Comprobante generado" : "Sin comprobante" %>
    </ItemTemplate>
</asp:TemplateField>

<asp:TemplateField HeaderText="Acción">
    <ItemTemplate>
        <asp:Button ID="btnVer" runat="server" Text="Ver Detalles"
            CommandName="VerComprobante" CommandArgument='<%# Eval("idCita") %>'
            CssClass="btn btn-sm btn-outline-primary" Visible="false" />

        <asp:Button ID="btnAdd" runat="server" Text="Añadir Comprobante"
            CommandName="AñadirComprobante" CommandArgument='<%# Eval("idCita") %>'
            CssClass="btn btn-sm btn-outline-primary" Visible="false" />
    </ItemTemplate>
</asp:TemplateField>
    </Columns>

    <HeaderStyle CssClass="bg-primary text-white" />
</asp:GridView>
    </script>
</asp:Content>