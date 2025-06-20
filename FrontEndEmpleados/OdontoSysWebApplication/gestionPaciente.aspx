<%@ Page Title="Gestión de Paciente" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="gestionPaciente.aspx.cs" Inherits="OdontoSysWebApplication.gestionPaciente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h2>Datos del Paciente</h2>
        <asp:Panel ID="pnlDatos" runat="server" CssClass="row g-3 mt-3">
            <div class="col-md-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Apellidos</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">DNI</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </asp:Panel>
        <div class="mt-4">
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success ms-2" Visible="false" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnDescargarPDF" runat="server" Text="Descargar Historia Clínica" CssClass="btn btn-info ms-2" OnClick="btnDescargarPDF_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver a búsqueda" CssClass="btn btn-secondary ms-2" PostBackUrl="~/buscarPaciente.aspx" />
        </div>
        <asp:Panel ID="pnlAlerta" runat="server" CssClass="alert alert-success mt-3" Visible="false">
            Cambios guardados exitosamente.
        </asp:Panel>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            var alerta = $("#<%= pnlAlerta.ClientID %>");
            if (alerta.is(":visible")) {
                setTimeout(function () {
                    alerta.fadeOut("slow");
                }, 3000);
            }
        });
    </script>
    <hr class="my-4" />
        <h3 class="mt-4">Citas del Paciente</h3>
        <asp:GridView ID="gvCitas" runat="server" CssClass="table table-bordered table-hover mt-3"
            AutoGenerateColumns="false" EmptyDataText="Este paciente no tiene citas registradas." Width="100%">
            <Columns>
                <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField DataField="horaInicio" HeaderText="Hora" />
                <asp:BoundField DataField="odontologo.nombre" HeaderText="Odontólogo" />
                <asp:BoundField DataField="odontologo.especialidad.nombre" HeaderText="Especialidad" />
                <asp:BoundField DataField="estado" HeaderText="Estado" />
            </Columns>
        </asp:GridView>
</asp:Content>