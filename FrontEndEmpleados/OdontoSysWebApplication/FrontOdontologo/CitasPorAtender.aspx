<%@ Page Title= "Citas por atender" Language="C#" AutoEventWireup="true" CodeBehind="CitasPorAtender.aspx.cs" Inherits="OdontoSysWebApplication.FrontOdontologo.CitasPorAtender" %>

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
        OnRowDataBound="gvCitas_RowDataBound">
        <Columns>
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
            <asp:BoundField DataField="fecha" HeaderText="fecha" />
            <asp:BoundField DataField="hora" HeaderText="hora" />
            <asp:BoundField DataField="estado" HeaderText="estado" />
            
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnAtender" runat="server" CommandName="Atender" CommandArgument='<%# Container.DataItemIndex %>' Text ="Atender"/>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:BoundField DataField="puntuacionPromedio" HeaderText="Puntuación" DataFormatString="{0:N2}" />
        </Columns>
        <HeaderStyle CssClass="bg-primary text-white" />
    </asp:GridView>

</asp:Content>

