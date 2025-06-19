<%@Title="AtenderCita" Language="C#" AutoEventWireup="true" CodeBehind="AtenderCita.aspx.cs" Inherits="OdontoSysWebApplication.FrontOdontologo.AtenderCita" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cita</title>
    <style>
        .title {
            font-size: 24px;
            font-weight: bold;
            margin-bottom: 20px;
        }

        .info-label {
            display: inline-block;
            width: 80px;
            font-weight: bold;
        }

        .form-section {
            margin-bottom: 15px;
        }

        .grid-buttons input {
            margin-right: 5px;
        }

        .header-section {
            margin-bottom: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 30px">

            <!-- Title -->
            <div class="header-section">
                <span class="title">Cita</span>
            </div>

            <!-- Patient Info -->
            <div class="form-section">
                <span class="info-label">Paciente:</span>
                <asp:TextBox ID="txtPaciente" runat="server" ReadOnly="true" Width="300px" />
            </div>
            <div class="form-section">
                <span class="info-label">Correo:</span>
                <asp:TextBox ID="txtCorreo" runat="server" ReadOnly="true" Width="300px" />
            </div>
            <div class="form-section">
                <span class="info-label">Teléfono:</span>
                <asp:TextBox ID="txtTelefono" runat="server" ReadOnly="true" Width="300px" />
            </div>

            <!-- Treatments Grid -->
            <asp:GridView ID="gvTratamientos" runat="server" AutoGenerateColumns="False"
                          CssClass="treatment-grid" DataKeyNames="idTratamiento" 
                          OnRowCommand="gvTratamientos_RowCommand">
                <Columns>
                    <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="grid-buttons">
                                <asp:Button ID="btnEditar" runat="server" Text="Editar"
                                            CommandName="Editar" CommandArgument='<%# Eval("idTratamiento") %>' CssClass="btn" />
                                <asp:Button ID="btnFinalizar" runat="server" Text="Finalizar"
                                            CommandName="Finalizar" CommandArgument='<%# Eval("idTratamiento") %>' CssClass="btn" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            <!-- Add Treatment Button -->
            <div style="margin-top: 20px;">
                <asp:Button ID="btnAgregarTratamiento" runat="server" Text="Añadir tratamiento"
                            CssClass="btn" OnClick="btnAgregarTratamiento_Click" />
            </div>
        </div>
    </form>
</body>
</html>
