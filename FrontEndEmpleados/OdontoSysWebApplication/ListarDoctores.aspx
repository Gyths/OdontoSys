<%@ Page Title="Listado de Doctores" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ListarDoctores.aspx.cs" Inherits="OdontoSysWebApplication.ListarDoctores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-user-md"></i> Listado de Doctores</h2>
        <%-- Opcional: Un botón para llevar a la página de registro de un nuevo doctor --%>
        <a href="RegistrarDoctor.aspx" class="btn btn-primary">Registrar Nuevo Doctor</a>
    </div>

    <asp:GridView ID="gvDoctores" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-hover table-striped"
        DataKeyNames="idOdontologo"
        EmptyDataText="No hay doctores registrados."
        Width="100%">
        <Columns>
            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
            <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
            <asp:BoundField DataField="correo" HeaderText="Correo Electrónico" />
            <asp:BoundField DataField="telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="NumeroDocumento" HeaderText="N° Documento" />
            
            <%-- Usamos un TemplateField para acceder a la propiedad anidada 'nombre' de 'especialidad' --%>
            <asp:TemplateField HeaderText="Especialidad">
                <ItemTemplate>
                    <%# Eval("especialidad.nombre") %>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="puntuacionPromedio" HeaderText="Puntuación" DataFormatString="{0:N2}" />
        </Columns>
        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>
