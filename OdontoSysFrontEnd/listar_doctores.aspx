<%@ Page Title="Listado de Doctores" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="listar_doctores.aspx.cs" Inherits="OdontoSysFrontEnd.listar_doctores" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2>Listado de Doctores</h2>
        
        <div class="row mt-4">
            <div class="col-md-12">
                <asp:GridView ID="dgvDoctores" runat="server" AllowPaging="true" PageSize="10" 
                    AutoGenerateColumns="false" CssClass="table table-hover table-striped" 
                    OnPageIndexChanging="dgvDoctores_PageIndexChanging">
                    <Columns>
                        <asp:BoundField HeaderText="Odontólogo Encargado" DataField="NombreOdontologo" />
                        <asp:BoundField HeaderText="Especialidad" DataField="Especialidad" />
                        <asp:BoundField HeaderText="Puntuacion" DataField="Puntuacion" />
                    </Columns>
                    <PagerStyle CssClass="pagination-ys" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <div class="alert alert-info text-center">
                            No se encontraron doctores.
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