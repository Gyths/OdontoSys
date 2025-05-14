<%@ Page Title="Historial de pacientes" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="pacientes_odontologo.aspx.cs" Inherits="OdontoSysFrontEnd.listar_pacientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2>Pacientes registrados</h2>
        
        <div class="row mt-4">
            <div class="col-md-12">
                <asp:GridView ID="dgvPacientes" runat="server" AllowPaging="true" PageSize="10" 
                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" >
                    
                    <Columns>
                        <asp:BoundField HeaderText="DNI" DataField="DNI" />
                        <asp:BoundField HeaderText="Nombre" DataField="NombreCompleto" />
                        <asp:BoundField HeaderText="Teléfono" DataField="Telefono" />
                        <asp:BoundField HeaderText="Correo" DataField="Correo" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbHistoriaClinica" runat="server" Text="Ver historia" 
                                    CssClass="btn btn-primary btn-sm" 
                                    CommandArgument='<%# Eval("DNI") %>' 
                                    OnClick="lbHistoriaClinica_Click">
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" Text="Ver pagos" 
                                    CssClass="btn btn-primary btn-sm" 
                                    CommandArgument='<%# Eval("DNI") %>' 
                                    OnClick="lbVerPagos_Click">
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <div class="alert alert-info text-center">
                            No se encontraron pacientes en el historial.
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
        
        <div class="row mt-4">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
            </div>
        </div>
    </div>
</asp:Content>