<%@ Page Title="Reservar Cita" Language="C#" MasterPageFile="~/OdontoSys.Master" AutoEventWireup="true" CodeBehind="reservar_cita.aspx.cs" Inherits="OdontoSysFrontEnd.reservar_cita" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphContenido" runat="server">
    <div class="container">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h3 class="card-title mb-0">
                            <i class="fas fa-calendar-plus me-2"></i>Reservar Nueva Cita
                        </h3>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-12">
                                <label for="ddlEspecialidad" class="form-label">
                                    <i class="fas fa-stethoscope me-1"></i>Especialidad:
                                </label>
                                <asp:DropDownList ID="ddlEspecialidad" runat="server" 
                                    CssClass="form-select" AutoPostBack="true" 
                                    OnSelectedIndexChanged="ddlEspecialidad_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvEspecialidad" runat="server"
                                    ControlToValidate="ddlEspecialidad" InitialValue=""
                                    ErrorMessage="Debe seleccionar una especialidad"
                                    CssClass="text-danger" Display="Dynamic" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-12">
                                <label for="ddlDoctor" class="form-label">
                                    <i class="fas fa-user-md me-1"></i>Doctor:
                                </label>
                                <asp:DropDownList ID="ddlDoctor" runat="server" CssClass="form-select"
                                    AutoPostBack="true" OnSelectedIndexChanged="ddlDoctor_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvDoctor" runat="server"
                                    ControlToValidate="ddlDoctor" InitialValue=""
                                    ErrorMessage="Debe seleccionar un doctor"
                                    CssClass="text-danger" Display="Dynamic" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtFechaCita" class="form-label">
                                    <i class="fas fa-calendar me-1"></i>Fecha de Cita:
                                </label>
                                <asp:TextBox ID="txtFechaCita" runat="server" CssClass="form-control" 
                                    TextMode="Date" AutoPostBack="true" 
                                    OnTextChanged="txtFechaCita_TextChanged" />
                                <asp:RequiredFieldValidator ID="rfvFecha" runat="server"
                                    ControlToValidate="txtFechaCita"
                                    ErrorMessage="Debe seleccionar una fecha"
                                    CssClass="text-danger" Display="Dynamic" />
                            </div>
                            <div class="col-md-6">
                                <label for="ddlHorario" class="form-label">
                                    <i class="fas fa-clock me-1"></i>Horario Disponible:
                                </label>
                                <asp:DropDownList ID="ddlHorario" runat="server" CssClass="form-select">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvHorario" runat="server"
                                    ControlToValidate="ddlHorario" InitialValue=""
                                    ErrorMessage="Debe seleccionar un horario"
                                    CssClass="text-danger" Display="Dynamic" />
                            </div>
                        </div>

                        <div class="row mb-3">
                            <div class="col-md-12">
                                <label for="txtObservaciones" class="form-label">
                                    <i class="fas fa-comment me-1"></i>Observaciones (Opcional):
                                </label>
                                <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control" 
                                    TextMode="MultiLine" Rows="3" 
                                    placeholder="Ingrese cualquier observación adicional..."/>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="d-flex justify-content-between">
                                    <asp:Button ID="btnRegresar" runat="server" 
                                        CssClass="btn btn-secondary" 
                                        Text="Regresar" 
                                        OnClick="btnRegresar_Click" 
                                        CausesValidation="false"/>
                                    <asp:Button ID="btnReservar" runat="server" 
                                        CssClass="btn btn-primary" 
                                        Text="Reservar Cita" 
                                        OnClick="btnInsertar_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        window.onload = function() {
            var today = new Date().toISOString().split('T')[0];
            document.getElementById('<%= txtFechaCita.ClientID %>').setAttribute('min', today);
        };
    </script>
</asp:Content>