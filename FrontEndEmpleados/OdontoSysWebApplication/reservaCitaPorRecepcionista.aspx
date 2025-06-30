<%@ Page Title="" Language="C#" MasterPageFile="~/Recepcionista.Master" AutoEventWireup="true" CodeBehind="reservaCitaPorRecepcionista.aspx.cs" Inherits="OdontoSysWebApplication.reservaCitaPorRecepcionista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    body {
        padding-top: 80px;
    }

    .semana-btn {
        margin-right: 0.5rem;
        margin-bottom: 0.5rem;
    }

    .semana-btn.active {
        background-color: #0d6efd;
        color: white;
        border-color: #0d6efd;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 pt-4">
    <h2 class="mb-4">Agendar Nueva Cita</h2>

    <div class="row mb-3">
        <div class="col-md-6">
            <label class="form-label">Especialidad</label>
            <asp:DropDownList ID="ddlEspecialidades" runat="server"
                CssClass="form-select"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlEspecialidades_SelectedIndexChanged"
                AppendDataBoundItems="true">
                <asp:ListItem Text="-- Seleccione una especialidad --" Value="" />
            </asp:DropDownList>
        </div>
    </div>

    <asp:Panel ID="pnlOdontologos" runat="server" Visible="false">
        <div class="row mb-3">
            <div class="col-md-6">
                <label class="form-label">Odontólogo</label>
                <asp:DropDownList ID="ddlOdontologos" runat="server"
                    CssClass="form-select"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlOdontologos_SelectedIndexChanged"
                    AppendDataBoundItems="true">
                    <asp:ListItem Text="-- Seleccione un odontólogo --" Value="" />
                </asp:DropDownList>
            </div>
        </div>
    </asp:Panel>

    <asp:Button ID="btnConfirmarCita" runat="server"
        CssClass="btn btn-primary mb-3"
        Text="Registrar Cita"
        OnClick="btnConfirmarCita_Click"
        Visible="false" />

    <asp:HiddenField ID="hfFechaSeleccionada" runat="server" />
    <asp:HiddenField ID="hfHoraSeleccionada" runat="server" />
    <asp:Literal ID="ltDisponibilidad" runat="server" />

    <asp:Panel ID="pnlSemana" runat="server" Visible="false" CssClass="mb-3">
        <label class="form-label d-block">Selecciona el rango</label>
        <asp:LinkButton ID="btnEstaSemana" runat="server"
            CssClass="btn btn-outline-primary semana-btn"
            OnClick="BtnSemana_Click" CommandArgument="0">
            Esta semana
        </asp:LinkButton>
        <asp:LinkButton ID="btnSiguienteSemana" runat="server"
            CssClass="btn btn-outline-primary semana-btn"
            OnClick="BtnSemana_Click" CommandArgument="1">
            Siguiente semana
        </asp:LinkButton>
        <asp:LinkButton ID="btnDosSemanas" runat="server"
            CssClass="btn btn-outline-primary semana-btn"
            OnClick="BtnSemana_Click" CommandArgument="2">
            Dentro de 2 semanas
        </asp:LinkButton>
    </asp:Panel>

    <asp:Panel ID="pnlSlots" runat="server" Visible="false" CssClass="mb-4">
        <asp:Literal ID="ltSlots" runat="server" />
    </asp:Panel>
    
</div>

<script>
    function seleccionarSlot(fecha, hora) {
        document.getElementById('<%= hfFechaSeleccionada.ClientID %>').value = fecha;
        document.getElementById('<%= hfHoraSeleccionada.ClientID %>').value = hora;
        __doPostBack('SeleccionarSlot', '');
    }
</script>
</asp:Content>

