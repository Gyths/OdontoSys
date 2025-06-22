<%@ Page Title="Mis Citas" Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="citasOdontologo.aspx.cs" Inherits="OdontoSysWebApplication.citasOdontologo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <div class="card shadow">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0"><i class="fas fa-calendar-alt me-2"></i>Mis Citas</h4>
                    </div>
                    <div class="card-body">
                        <asp:Literal ID="ltMensajes" runat="server" EnableViewState="false" />

                        <div class="table-responsive">
                            <asp:GridView ID="gvCitas" runat="server" CssClass="table table-striped table-hover"
                                AutoGenerateColumns="false" OnRowCommand="gvCitas_RowCommand"
                                EmptyDataText="No se encontraron citas registradas.">
                                <Columns>
                                    <asp:BoundField DataField="idCita" HeaderText="ID" />
                                    <asp:BoundField DataField="fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="horaInicio" HeaderText="Hora" />
                                    <asp:BoundField DataField="paciente.nombre" HeaderText="Paciente" />
                                    <asp:BoundField DataField="paciente.apellidos" HeaderText="Apellidos" />
                                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button ID="btnAgregarTratamiento" runat="server"
                                                CssClass="btn btn-success btn-sm"
                                                Text="Agregar Tratamiento"
                                                CommandName="AgregarTratamiento"
                                                CommandArgument='<%# Eval("idCita") %>'
                                                OnClientClick='<%# "abrirModal(" + Eval("idCita") + "); return false;" %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Modal para Agregar Tratamiento -->
    <div class="modal fade" id="modalTratamiento" tabindex="-1" aria-labelledby="modalTratamientoLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header bg-success text-white">
                    <h5 class="modal-title" id="modalTratamientoLabel">
                        <i class="fas fa-tooth me-2"></i>Agregar Tratamiento
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <asp:UpdatePanel ID="upModalTratamiento" runat="server">
                        <ContentTemplate>
                            <asp:HiddenField ID="hfIdCitaSeleccionada" runat="server" />

                            <div class="row g-3">
                                <div class="col-12">
                                    <label class="form-label">Tratamiento</label>
                                    <asp:DropDownList ID="ddlTratamiento" runat="server" CssClass="form-select"
                                        OnSelectedIndexChanged="ddlTratamiento_SelectedIndexChanged" AutoPostBack="true">
                                    </asp:DropDownList>
                                </div>

                                <div class="col-md-6">
                                    <label class="form-label">Cantidad</label>
                                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control"
                                        TextMode="Number" min="1" value="1" />
                                </div>

                                <div class="col-md-6">
                                    <label class="form-label">Costo Unitario</label>
                                    <asp:TextBox ID="txtCostoUnitario" runat="server" CssClass="form-control"
                                        ReadOnly="true" />
                                </div>

                                <div class="col-12">
                                    <label class="form-label">Descripción del Tratamiento</label>
                                    <asp:TextBox ID="txtDescripcionTratamiento" runat="server" CssClass="form-control"
                                        TextMode="MultiLine" Rows="3" ReadOnly="true" />
                                </div>

                                <div class="col-12">
                                    <label class="form-label">Subtotal</label>
                                    <asp:TextBox ID="txtSubtotal" runat="server" CssClass="form-control"
                                        ReadOnly="true" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cancelar</button>
                    <asp:Button ID="btnGuardarTratamiento" runat="server" CssClass="btn btn-success"
                        Text="Guardar Tratamiento" OnClick="btnGuardarTratamiento_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function abrirModal(idCita) {
            document.getElementById('<%= hfIdCitaSeleccionada.ClientID %>').value = idCita;
            var modal = new bootstrap.Modal(document.getElementById('modalTratamiento'));
            modal.show();
            return false;
        }

        function calcularSubtotal() {
            var cantidad = document.getElementById('<%= txtCantidad.ClientID %>').value;
            var costo = document.getElementById('<%= txtCostoUnitario.ClientID %>').value;

            if (cantidad && costo) {
                var subtotal = parseFloat(cantidad) * parseFloat(costo);
                document.getElementById('<%= txtSubtotal.ClientID %>').value = subtotal.toFixed(2);
            }
        }

        document.addEventListener('DOMContentLoaded', function () {
            var txtCantidad = document.getElementById('<%= txtCantidad.ClientID %>');
            if (txtCantidad) {
                txtCantidad.addEventListener('input', calcularSubtotal);
            }
        });
    </script>

</asp:Content>
