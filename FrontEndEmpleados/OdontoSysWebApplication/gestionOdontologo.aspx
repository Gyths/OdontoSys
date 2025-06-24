<%@ Page Title="Gestión de Odontólogo" Language="C#" MasterPageFile="~/Recepcionista.master" AutoEventWireup="true" CodeBehind="gestionOdontologo.aspx.cs" Inherits="OdontoSysWebApplication.gestionOdontologo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- Referencias a Bootstrap y Font Awesome para estilos e iconos --%>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.0.0/css/all.min.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {
            window.history.replaceState('', '', window.location.href);
        });
    </script>
    <style>
        .locked {
            background-color: #f0f0f0 !important;
            cursor: not-allowed;
        }


        .calendar-dropdown {
            position: relative;
            display: inline-block;
            width: 100%;
            max-width: 320px;
        }


        .calendar-toggle {
            background-color: #0d6efd;
            border: none;
            border-radius: 8px;
            color: white;
            padding: 8px 16px;
            cursor: pointer;
            width: 100%;
            text-align: left;
            display: flex;
            justify-content: space-between;
            align-items: center;
            font-size: 16px;
            font-weight: 500;
            transition: all 0.3s ease;
        }

            .calendar-toggle:hover {
                background-color: #0b5ed7;
            }

            .calendar-toggle:focus {
                outline: none;
                box-shadow: 0 0 0 3px rgba(13, 110, 253, 0.3);
            }

            .calendar-toggle .icon {
                transition: transform 0.3s ease;
            }

            .calendar-toggle.active .icon {
                transform: rotate(180deg);
            }

        .calendar-container {
            position: absolute;
            top: 100%;
            left: 0;
            right: 0;
            background: white;
            border-radius: 12px;
            box-shadow: 0 10px 40px rgba(0, 0, 0, 0.1);
            z-index: 1000;
            opacity: 0;
            visibility: hidden;
            transform: translateY(-10px);
            transition: all 0.3s ease;
            margin-top: 8px;
            border: 1px solid #e9ecef;
        }

            .calendar-container.show {
                opacity: 1;
                visibility: visible;
                transform: translateY(0);
            }


        .bscalendar table {
            width: 100%;
            border-collapse: collapse;
        }

        .bscalendar .MonthTitle {
            background: #f8f9fa;
            color: #343a40;
            padding: .5rem;
            font-weight: 600;
            text-align: center;
        }

        .bscalendar .DayHeader, .bscalendar .WeekendDayHeader {
            background: #f8f9fa;
            border: 1px solid #dee2e6;
            font-weight: 600;
            padding: .5rem .25rem;
            text-align: center;
            font-size: 0.8em;
        }

        .bscalendar .Day, .bscalendar .WeekendDay, .bscalendar .OtherMonthDay {
            border: 1px solid #dee2e6;
            padding: .5rem;
            cursor: pointer;
            text-align: center;
            transition: all 0.2s ease;
        }

        .bscalendar td:hover {
            background-color: #e9ecef;
            transform: scale(1.05);
        }

        .bscalendar .TodayDay {
            background-color: #ffc107;
            font-weight: 700;
            color: #212529;
            border: 1px solid #ff9800;
        }

        .bscalendar .SelectedDay {
            background-color: #0d6efd !important;
            color: white !important;
            font-weight: 700;
            transform: scale(1.1);
            box-shadow: 0 4px 15px rgba(13, 110, 253, 0.4);
        }

        .bscalendar .OtherMonthDay {
            color: #adb5bd;
            background-color: #f8f9fa;
        }


        .action-buttons {
            display: flex;
            flex-wrap: wrap;
            gap: 0.75rem;
            align-items: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid mt-4">
        <h2>Datos del Odontólogo</h2>
        <asp:Panel ID="pnlDatos" runat="server" CssClass="row g-3 mt-3">
            <div class="col-md-4">
                <label class="form-label">Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Apellidos</label>
                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Número de documento</label>
                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Especialidad</label>
                <asp:TextBox ID="txtEspecialidad" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Nombre de Usuario</label>
                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Correo</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
            <div class="col-md-4">
                <label class="form-label">Teléfono</label>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control locked" ReadOnly="true" />
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlAlerta" runat="server" Visible="false" CssClass="alert alert-success mt-3" role="alert">
            Cambios guardados exitosamente.
        </asp:Panel>
    <asp:Label ID="lblMensaje" runat="server"
       CssClass="alert" Visible="false" />

        <div class="mt-4 action-buttons">
            <asp:LinkButton ID="btnEditar" runat="server" Text="<i class='fas fa-pencil-alt me-1'></i> Editar" CssClass="btn btn-warning" OnClick="btnEditar_Click" />
            <asp:LinkButton ID="btnGuardar" runat="server" Text="<i class='fas fa-save me-1'></i> Guardar Cambios" CssClass="btn btn-success" Visible="false" OnClick="btnGuardar_Click" />
            <asp:LinkButton ID="btnVolver" runat="server" Text="<i class='fas fa-arrow-left me-1'></i> Volver" CssClass="btn btn-secondary ms-auto" OnClick="btnVolver_Click" />
        </div>

        

        <%-- Sección de Citas --%>
        <div class="mt-5">
            <h4 class="mb-3"><i class="fas fa-calendar-alt me-2 text-primary"></i>Citas del Odontólogo</h4>


            <div class="row align-items-start mb-4">
                <div class="col-auto">
                    <div class="calendar-dropdown">
                        <button type="button" class="calendar-toggle">
                            <span class="selected-date">Filtrar por Fecha</span>
                            <i class="fas fa-chevron-down icon"></i>
                        </button>

                        <div class="calendar-container">
                            <asp:Calendar ID="calFiltro" runat="server" CssClass="bscalendar"
                                TitleStyle-CssClass="MonthTitle"
                                DayHeaderStyle-CssClass="DayHeader"
                                TodayDayStyle-CssClass="TodayDay"
                                SelectedDayStyle-CssClass="SelectedDay"
                                OnSelectionChanged="calFiltro_SelectionChanged" />
                        </div>
                    </div>
                </div>
            </div>

            <asp:Panel CssClass="mt-3" runat="server">
                <asp:GridView ID="gvCitas" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-striped treatment-grid"
                    DataKeyNames="idCita"
                    OnRowDataBound="gvCitas_RowDataBound">

                    <Columns>
                        <asp:BoundField DataField="paciente.nombre" HeaderText="Paciente" />
                        <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField DataField="horaInicio" HeaderText="Hora" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />

                        <asp:TemplateField HeaderText="Cancelar Citas">
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:CheckBox ID="chkSeleccionar" runat="server" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <HeaderStyle CssClass="bg-primary text-white" />
                </asp:GridView>
            </asp:Panel>

            <asp:Panel ID="pnlError" runat="server"
                CssClass="alert alert-danger mt-3"
                Visible="false">
                <asp:Label ID="lblError" runat="server" />
            </asp:Panel>

            <asp:Panel CssClass="mt-3 text-end" runat="server">
                <asp:Button ID="btnEliminarSeleccion" runat="server" Text="Cancelar citas seleccionadas"
                    CssClass="btn btn-outline-danger"
                    OnClick="btnEliminarSeleccion_Click" />
            </asp:Panel>

            <div class="mt-5">
                <h4 class="mb-3"><i class="fas fa-calendar-alt me-2 text-primary"></i>Turnos del Odontólogo</h4>
            </div>

            <asp:Panel CssClass="mt-3" runat="server">
                <asp:GridView ID="gvTurnos" runat="server" AutoGenerateColumns="False"
                    CssClass="table table-hover table-striped treatment-grid"
                    DataKeyNames="idTurno"
                    OnRowCommand="gvTurnos_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="diaSemana" HeaderText="Dia" />
                        <asp:BoundField DataField="horaInicio" HeaderText="Hora Inicio" />
                        <asp:BoundField DataField="horaFin" HeaderText="Hora Fin" />

                        <%-- %><asp:TemplateField HeaderText="Cancelar Turnos">
                            <ItemTemplate>
                                <div class="text-center">
                                    <asp:CheckBox ID="chkSeleccionar1" runat="server" />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField> --%>

                    </Columns>
                    <HeaderStyle CssClass="bg-primary text-white" />
                </asp:GridView>
            </asp:Panel>

            <%-- <asp:Panel CssClass="mt-3 text-end" runat="server">
                <asp:Button ID="Button1" runat="server" Text="Cancelar Turnos Seleccionados"
                    CssClass="btn btn-outline-danger"
                    OnClick="btnEliminarTurnoSelec_Click" />
            </asp:Panel> --%>

        </div>
    </div>

    <script type="text/javascript">
        $(document).ready(function () {

            $('.calendar-toggle').click(function (e) {
                e.stopPropagation();
                const container = $(this).siblings('.calendar-container');
                container.toggleClass('show');
                $(this).toggleClass('active');
            });


            $(document).click(function (e) {
                if (!$(e.target).closest('.calendar-dropdown').length) {
                    $('.calendar-container').removeClass('show');
                    $('.calendar-toggle').removeClass('active');
                }
            });


            $('.bscalendar td').click(function () {
                setTimeout(function () {
                    $('.calendar-container').removeClass('show');
                    $('.calendar-toggle').removeClass('active');
                }, 150);
            });


            var alerta = $("#<%= pnlAlerta.ClientID %>");
            if (alerta.is(":visible")) {
                setTimeout(function () {
                    alerta.fadeOut("slow");
                }, 3000);
            }
        });
    </script>
</asp:Content>
