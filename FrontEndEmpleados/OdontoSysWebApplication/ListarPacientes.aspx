<%@ Page Title="Listado de Pacientes" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ListarPacientes.aspx.cs" Inherits="OdontoSysWebApplication.ListarPacientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-users"></i> Listado de Pacientes</h2>
     
        <a href="RegistrarPaciente.aspx" class="btn btn-primary">Registrar Nuevo Paciente</a>
    </div>

    <asp:GridView ID="gvPacientes" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-hover table-striped"
        DataKeyNames="idPaciente"
        EmptyDataText="No hay pacientes registrados."
        Width="100%"
        OnRowDataBound="gvPacientes_RowDataBound"
        OnRowCommand="gvPacientes_RowCommand">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="correo" HeaderText="Correo Electrónico" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            
           
            <asp:TemplateField HeaderText="Tipo de Documento">
                <ItemTemplate>
                    <%# Eval("tipoDocumento.nombre") %> 
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="NumeroDocumento" HeaderText="N° Documento" />

             <%-- Columna de acciones con boton--%>
            <asp:TemplateField HeaderText="Citas">
                <ItemTemplate>
                    <asp:Button ID="btnVerCitas" runat="server" Text="Ver Citas"
                        CommandName="VerCitas"
                        CommandArgument='<%# Eval("idPaciente") %>'
                        CssClass="btn btn-outline-primary btn-sm" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>