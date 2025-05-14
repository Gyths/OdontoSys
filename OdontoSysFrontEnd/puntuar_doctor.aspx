<%@ Page Title="Puntuacion de Doctor" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="puntuar_doctor.aspx.cs" Inherits="OdontoSysFrontEnd.puntuar_doctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <h2>Puntuacion de Doctor</h2>
        
        <div class="card-body">
            <div class="col-md-4">
                <label for="ddlFechaCita" class="form-label">Fecha de la Cita:</label>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione Fecha --" Value="" />
                <asp:ListItem Text="11/05/2025" Value="1" />
                <asp:ListItem Text="19/04/2025" Value="2" />
                <asp:ListItem Text="26/03/2025" Value="3" />
                <asp:ListItem Text="15/03/2025" Value="4" />
                <asp:ListItem Text="02/03/2025" Value="5" />
                <asp:ListItem Text="17/02/2025" Value="1" />
                </asp:DropDownList>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre del Doctor: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="txtNombre" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3 row">
                <asp:Label ID="Label1" runat="server" Text="Especialidad del Doctor: " CssClass="col-sm-4 col-form-label"></asp:Label>
                <div class="col-sm-4">
                    <asp:TextBox ID="TxtEspecialidad" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-4">
                <label for="ddlPuntaje" class="form-label">Puntaje:</label>
                <asp:DropDownList ID="ddlPuntaje" runat="server" CssClass="form-select">
                <asp:ListItem Text="-- Seleccione Puntaje --" Value="" />
                <asp:ListItem Text="1" Value="1" />
                <asp:ListItem Text="2" Value="2" />
                <asp:ListItem Text="3" Value="3" />
                <asp:ListItem Text="4" Value="4" />
                <asp:ListItem Text="5" Value="5" />
                <asp:ListItem Text="6" Value="1" />
                <asp:ListItem Text="7" Value="2" />
                <asp:ListItem Text="8" Value="3" />
                <asp:ListItem Text="9" Value="4" />
                <asp:ListItem Text="10" Value="5" />
                </asp:DropDownList>
            </div>
        </div>
        
        <div class="row mt-4">
            <div class="col-md-12 text-center">
                <asp:Button ID="btnRegresar" runat="server" Text="Regresar" CssClass="btn btn-secondary" OnClick="btnRegresar_Click" />
                <asp:Button ID="btnGuardar" CssClass="float-end btn btn-secondary" runat="server" Text="Guardar" OnClick="btnGuardar_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
