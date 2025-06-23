<%@ Title="AtenderCita" Language="C#" MasterPageFile="Odontologo.Master" AutoEventWireup="true" CodeBehind="AtenderCita.aspx.cs" Inherits="OdontoSysWebApplication.FrontOdontologo.AtenderCita" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Page Title -->
    <asp:Panel CssClass="d-flex justify-content-between align-items-center mb-4" runat="server">
        <asp:Label CssClass="h2" runat="server" Text='<i class="fas fa-user-md"></i> Atención de cita' />
    </asp:Panel>

    <!-- Patient Info -->
    <asp:Panel CssClass="row mb-3" runat="server">
        <asp:Panel CssClass="col-md-4" runat="server">
            <asp:Label ID="lblPaciente" runat="server" CssClass="info-label" AssociatedControlID="txtPaciente" Text="Paciente:" />
            <asp:TextBox ID="txtPaciente" runat="server" ReadOnly="true" CssClass="form-control" />
        </asp:Panel>
        <asp:Panel CssClass="col-md-4" runat="server">
            <asp:Label ID="lblCorreo" runat="server" CssClass="info-label" AssociatedControlID="txtCorreo" Text="Correo:" />
            <asp:TextBox ID="txtCorreo" runat="server" ReadOnly="true" CssClass="form-control" />
        </asp:Panel>
        <asp:Panel CssClass="col-md-4" runat="server">
            <asp:Label ID="lblTelefono" runat="server" CssClass="info-label" AssociatedControlID="txtTelefono" Text="Teléfono:" />
            <asp:TextBox ID="txtTelefono" runat="server" ReadOnly="true" CssClass="form-control" />
        </asp:Panel>
    </asp:Panel>


    <!-- Tratamiento Header with Button -->
    <asp:Panel CssClass="d-flex justify-content-between align-items-center mb-3" runat="server">
       <asp:Panel CssClass="d-flex align-items-center gap-3" runat="server">
            <asp:Label ID="lblTratamiento" runat="server" Text="Tratamiento" CssClass="h4 mb-0" />
            <asp:Button ID="btnAgregarTratamiento" runat="server" Text="Agregar tratamiento"
                CssClass="btn btn-outline-primary"
                OnClick="btnAgregarTratamiento_Click" />
        </asp:Panel>
        <asp:Button ID="btnQuitarTodos" runat="server" Text="Quitar todos"
            CssClass="btn btn-outline-danger"
            OnClick="btnQuitarTodos_Click" />
    </asp:Panel>

   <!-- Tratamientos grid with spacing -->
    <asp:Panel CssClass="mt-3" runat="server">
        <asp:GridView ID="gvTratamientos" runat="server" AutoGenerateColumns="False"
            CssClass="table table-hover table-striped treatment-grid"
            DataKeyNames="subtotal"
            OnRowCommand="gvTratamientos_RowCommand">
            <Columns>
                <asp:BoundField DataField="tratamiento.nombre" HeaderText="Nombre" />
                <asp:BoundField DataField="tratamiento.descripcion" HeaderText="Descripción" />
                <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                <asp:BoundField DataField="tratamiento.costo" HeaderText="Costo Unitario" />

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:Panel CssClass="grid-buttons" runat="server">
                            <asp:Button ID="btnEditar" runat="server" Text="Editar"
                                CommandName="Editar"
                                CommandArgument='<%# Eval("tratamiento.idTratamiento") %>'
                                CssClass="btn btn-primary btn-sm" />
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Seleccionar">
                    <ItemTemplate>
                        <div class="text-center">
                            <asp:CheckBox ID="chkSeleccionar" runat="server" />
                        </div>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center"/>
                </asp:TemplateField>

            </Columns>
            <HeaderStyle CssClass="bg-primary text-white" />
        </asp:GridView>
    </asp:Panel>

    <asp:Panel CssClass="mt-3 text-end" runat="server">
        <asp:Button ID="btnEliminarSeleccion" runat="server" Text="Eliminar selección"
            CssClass="btn btn-outline-danger"
            OnClick="btnEliminarSeleccion_Click" />
    </asp:Panel>

    <asp:Panel CssClass="mt-4" runat="server">
    <asp:Button ID="btnVolverAgenda" runat="server"
        Text="Volver a agenda"
        CssClass="btn btn-secondary"
        OnClick="btnVolverAgenda_Click" />
</asp:Panel>

</asp:Content>
