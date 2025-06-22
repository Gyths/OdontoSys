<%@ Page Title="Gestión de Paciente" Language="C#" MasterPageFile="~/Recepcionista.master" AutoEventWireup="true" CodeBehind="gestionPaciente.aspx.cs" Inherits="OdontoSysWebApplication.gestionPaciente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    
    <style>
        .locked {
            background-color: #f0f0f0 !important;
            cursor: not-allowed;
        }

        .bscalendar table {
            width: 100%;
            border-collapse: collapse;
        }

        .bscalendar .MonthTitle {
            background: #f8f9fa;
            color: #212529;
            padding: .4rem;
            font-weight: 600;
            text-align: center;
            border: 1px solid #dee2e6;
        }

        .bscalendar .DayHeader, .bscalendar .WeekendDayHeader {
            background: #f1f3f5;
            border: 1px solid #dee2e6;
            font-weight: 500;
            padding: .25rem;
        }

        .bscalendar .Day, .bscalendar .WeekendDay, .bscalendar .OtherMonthDay {
            border: 1px solid #dee2e6;
            padding: .35rem .25rem;
            cursor: pointer;
        }

        .bscalendar .TodayDay {
            background: #eaf4ff;
            font-weight: 600;
        }

        .bscalendar .SelectedDay {
            background: #0d6efd;
            color: #fff;
        }

        .bscalendar td:hover {
            background: #dbeafe;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfPostbackOrigin" runat="server" />
    
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%= hfPostbackOrigin.ClientID %>').val('');
            $('#<%= calFiltro.ClientID %>').on('change', function () {
                $('#<%= hfPostbackOrigin.ClientID %>').val('calendar');
            });
        });

        function cancelCita(idCita) {
            if (confirm('¿Está seguro de que desea cancelar esta cita?')) {
                __doPostBack('CancelCita', idCita);
            }
        }
    </script>

    <div class="container-fluid mt-4">
        <h2>Datos del Paciente</h2>
        <asp:Panel ID="pnlDatos" runat="server" CssClass="row g-3 mt-3">
            <div class="col-md-3">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Apellidos</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">DNI</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-3">
                <label class="form-label">Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" ReadOnly="true" />
            </div>
        </asp:Panel>
        <div class="mt-4">
            <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-success ms-2" Visible="false" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnDescargarPDF" runat="server" Text="Descargar Historia Clínica" CssClass="btn btn-primary" OnClick="btnDescargarPDF_Click" />
            <asp:Button ID="btnVolver" runat="server" Text="Volver a búsqueda" CssClass="btn btn-secondary ms-2" PostBackUrl="~/buscarPaciente.aspx" />
            <asp:Button ID="btnCita" runat="server" Text="Agendar Cita" CssClass="btn btn-success" PostBackUrl="~/reservaCitaPorRecepcionista.aspx" />
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
    <h4>Citas del paciente</h4>

    <asp:Label ID="lblMensaje" runat="server" EnableViewState="false" CssClass="" Text=""></asp:Label>

    <div class="row align-items-center mb-3">
        <div class="col-auto">
            <asp:Calendar ID="calFiltro" runat="server" CssClass="bscalendar mb-3"
                TitleStyle-CssClass="MonthTitle"
                DayHeaderStyle-CssClass="DayHeader"
                TodayDayStyle-CssClass="TodayDay"
                SelectedDayStyle-CssClass="SelectedDay"
                OnSelectionChanged="calFiltro_SelectionChanged" />
        </div>
    </div>

    <asp:Literal ID="ltCitas" runat="server"></asp:Literal>
</asp:Content>