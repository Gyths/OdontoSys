<%@ Page Title="Historial de Citas" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="listar_citas_paciente.aspx.cs" Inherits="OdontoSysFrontEnd.listar_citas_paciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2>Historial de Citas</h2>
        
        <div class="row mt-4">
            <div class="col-md-12">
                <asp:GridView ID="dgvCitas" runat="server" AllowPaging="true" PageSize="10" 
                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" 
                    OnPageIndexChanging="dgvCitas_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Odontólogo Encargado" DataField="NombreOdontologo" />
                        <asp:BoundField HeaderText="Estado" DataField="Estado" />
                        <asp:BoundField HeaderText="Tratamiento" DataField="Tratamiento" />
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <div class="alert alert-info text-center">
                            No se encontraron citas en el historial.
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