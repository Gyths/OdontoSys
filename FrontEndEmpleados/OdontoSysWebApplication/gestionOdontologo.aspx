<%@ Page Title="Gestión de Odontólogo" Language="C#" MasterPageFile="~/Recepcionista.master" AutoEventWireup="true" CodeBehind="gestionOdontologo.aspx.cs" Inherits="OdontoSysWebApplication.gestionOdontologo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <style>
        /* Container */
        .bscalendar table {
            width: 100%;
            border-collapse: collapse;
        }

        /* Encabezado mes ◀ junio 2025 ▶ */
        .bscalendar .MonthTitle {
            background: #f8f9fa;
            color: #212529;
            padding: .4rem;
            font-weight: 600;
            text-align: center;
            border: 1px solid #dee2e6;
        }

        /* Días header (lun-dom) */
        .bscalendar .DayHeader, .bscalendar .WeekendDayHeader {
            background: #f1f3f5;
            border: 1px solid #dee2e6;
            font-weight: 500;
            padding: .25rem;
        }

        /* Cada celda */
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

        /* Hover */
        .bscalendar td:hover {
            background: #dbeafe;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <div class="mx-auto" style="max-width: 800px;">
            <h2>Datos del Odontólogo</h2>

            <asp:Panel ID="pnlDatos" runat="server" CssClass="row g-3 mt-3">

                <asp:Panel ID="pnlAlerta" runat="server" Visible="false" CssClass="alert alert-success mt-3" role="alert">
                    Cambios guardados exitosamente.
                </asp:Panel>
                <div class="col-md-3">
                    <label class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Apellidos</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Número de documento</label>
                    <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Nombre de Usuario</label>
                    <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Especialidad</label>
                    <asp:TextBox ID="txtEspecialidad" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Correo</label>
                    <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
                <div class="col-md-3">
                    <label class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" ReadOnly="true" />
                </div>
            </asp:Panel>

            <div class="mt-4">
                <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-action" OnClick="btnEditar_Click" />
                <asp:Button ID="btnGuardar" runat="server" Text="Guardar Cambios" CssClass="btn btn-action ms-2" Visible="false" OnClick="btnGuardar_Click" />
                <asp:Button ID="btnVolver" runat="server" Text="Volver" CssClass="btn btn-action ms-2" OnClick="btnVolver_Click" />
            </div>
        </div>
        <h4>Citas del odontólogo</h4>

        <!-- Calendario para elegir el día “centro” -->
        <asp:Calendar ID="calFiltro"
            runat="server"
            CssClass="bscalendar mb-3"
            NextPrevStyle-CssClass="btn btn-link"
            TitleStyle-CssClass="MonthTitle"
            DayHeaderStyle-CssClass="DayHeader"
            TodayDayStyle-CssClass="TodayDay"
            SelectedDayStyle-CssClass="SelectedDay"
            OnSelectionChanged="calFiltro_SelectionChanged" />
        <asp:Label ID="lblMensaje"
            runat="server"
            EnableViewState="false"
            CssClass=""
            Text=""></asp:Label>
        <!-- Aquí pintarás las tarjetas -->
        <asp:Literal ID="ltCitas" runat="server"></asp:Literal>
    </div>
</asp:Content>
