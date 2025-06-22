<%@ Page Title= "Citas por atender" Language="C#"  MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="CitasPorAtender.aspx.cs" Inherits="OdontoSysWebApplication.FrontOdontologo.CitasPorAtender" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="d-flex justify-content-between align-items-center mb-4">
        <h2><i class="fas fa-user-md"></i>Citas por atender</h2>
    </div>
    
    <asp:GridView ID="gvCitas" runat="server"
        AutoGenerateColumns="false"
        CssClass="table table-hover table-striped"
        DataKeyNames="idCita"
        EmptyDataText="No hay citas por atender."
        Width="100%"
        OnRowCommand="gvCitas_RowCommand">
        <Columns>
            <asp:TemplateField HeaderText="Paciente">
                <ItemTemplate>
                    <%# Eval("paciente.nombre") %>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="horaInicio" HeaderText="Hora" />

            <asp:BoundField DataField="estado" HeaderText="Estado" />
            
            <asp:TemplateField HeaderText="Acciones">
                <ItemTemplate>
                    <asp:Panel CssClass="grid-buttons" runat="server">
                        <asp:Button ID="btnAtender" runat="server" Text="Atender"
                            CommandName="Atender"
                            CommandArgument='<%# Eval("idCita") %>'
                            CssClass="btn btn-primary btn-sm" />
                    </asp:Panel>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>

