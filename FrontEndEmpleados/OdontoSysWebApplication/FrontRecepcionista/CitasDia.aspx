<%@ Page Title="Citas del Día" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="CitasDia.aspx.cs" Inherits="OdontoSysWebApplication.CitasDia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h2 runat="server" id="h2Titulo" class="mb-4">Citas del Día</h2>

    <asp:Label ID="lblError" runat="server" CssClass="text-danger" Visible="false"></asp:Label>

    <asp:GridView ID="gvCitasDia" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-hover align-middle"
        DataKeyNames="idCita"
        EmptyDataText="No tiene citas programadas para el día de hoy."
        OnRowCommand="gvCitasDia_RowCommand"
        Width="100%">
        <Columns>
            <asp:BoundField DataField="horaInicio" HeaderText="Hora" SortExpression="horaInicio" />
            
            <asp:TemplateField HeaderText="Paciente">
                <ItemTemplate>
                    <%# Eval("paciente.nombre") %> <%# Eval("paciente.apellidos") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Estado">
                <ItemTemplate>
                     <%-- Asumimos que el objeto estado tiene una propiedad 'nombre' --%>
                    <span class="badge bg-primary"><%# Eval("estado.nombre") %></span>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:LinkButton ID="btnAtender" runat="server"
                        CommandName="Atender"
                        CommandArgument='<%# Eval("idCita") %>'
                        CssClass="btn btn-sm btn-success">
                        <i class="fas fa-play me-2"></i>Registrar Atención
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>
        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>