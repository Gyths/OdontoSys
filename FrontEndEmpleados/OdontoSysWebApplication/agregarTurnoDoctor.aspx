<%@ Page Title="Agregar Turno" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="agregarTurnoDoctor.aspx.cs" Inherits="OdontoSysWebApplication.agregarTurnoDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row justify-content-center">
        <div class="col-md-8 col-lg-6">
            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h4 class="mb-0">
                        <i class="fas fa-clock me-2"></i>Agregar Turno al Doctor
                    </h4>
                </div>
                <div class="card-body">
                    <div class="mb-4">
                        <label class="form-label fw-bold">Doctor seleccionado:</label>
                        <asp:Label ID="lblNombreDoctor" runat="server" CssClass="form-control-plaintext text-primary fw-bold" />
                        <asp:HiddenField ID="hdnIdDoctor" runat="server" />
                    </div>

                    <div class="mb-4">
                        <label for="ddlTurnos" class="form-label fw-bold">Seleccionar Turno:</label>
                        <asp:DropDownList ID="ddlTurnos" runat="server" CssClass="form-select" 
                                          DataTextField="descripcion" DataValueField="idTurno">
                            <asp:ListItem Text="-- Seleccione un turno --" Value="" />
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvTurno" runat="server" 
                                                    ControlToValidate="ddlTurnos" 
                                                    ErrorMessage="Por favor seleccione un turno" 
                                                    CssClass="text-danger small" 
                                                    Display="Dynamic" />
                    </div>

                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" 
                                   CssClass="btn btn-outline-secondary me-md-2" 
                                   OnClick="btnCancelar_Click" CausesValidation="false" />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar Turno" 
                                   CssClass="btn btn-primary" 
                                   OnClick="btnGuardar_Click" />
                    </div>

                    <div class="mt-3">
                        <asp:Label ID="lblMensaje" runat="server" CssClass="alert" Visible="false" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
