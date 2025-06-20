<%@ Page Title="Mi Cuenta" Language="C#" MasterPageFile="~/Paciente.Master" AutoEventWireup="true" CodeBehind="miCuenta.aspx.cs" Inherits="OdontoSysWebApplication.miCuenta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <style>
        .form-box {
            max-width: 600px;
            margin: auto;
            padding: 2rem;
            background-color: #fff;
            border-radius: 0.5rem;
            box-shadow: 0 0 0.5rem rgba(0,0,0,0.1);
        }
        input[readonly], select:disabled {
            background-color: #e9ecef !important;
            pointer-events: none;
            opacity: 1;
        }
        .list-group-item.active-custom {
            background-color: #0d6efd;
            color: white;
            font-weight: bold;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <div class="row">
            <!-- Sidebar -->
            <div class="col-md-3">
                <div class="list-group">
                    <a href="actualizarCuenta.aspx" class="list-group-item list-group-item-action <% if (Request.Url.AbsolutePath.EndsWith("actualizarCuenta.aspx")) { %>active-custom<% } %>">
                        <i class="fas fa-user-edit me-2"></i>Actualizar Datos
                    </a>
                    <a href="cambiarContrasena.aspx" class="list-group-item list-group-item-action <% if (Request.Url.AbsolutePath.EndsWith("cambiarContrasena.aspx")) { %>active-custom<% } %>">
                        <i class="fas fa-key me-2"></i>Cambiar Contraseña
                    </a>
                    <button type="button"
                            class="list-group-item list-group-item-action text-danger"
                            data-bs-toggle="modal"
                            data-bs-target="#confirmDeleteModal">
                      <i class="fas fa-user-times me-2"></i>Eliminar Cuenta
                    </button>
                </div>
            </div>
            <!-- Modal de confirmación -->
            <div class="modal fade" id="confirmDeleteModal" tabindex="-1" aria-labelledby="confirmDeleteLabel" aria-hidden="true">
              <div class="modal-dialog modal-dialog-centered">
                <div class="modal-content">
                  <div class="modal-header">
                    <h5 class="modal-title text-danger" id="confirmDeleteLabel">
                      ¿Estás seguro de eliminar tu cuenta?
                    </h5>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Cerrar"></button>
                  </div>
                  <asp:Panel runat="server" DefaultButton="btnEliminarCuenta">
                    <div class="modal-body">
                      <asp:Label runat="server" ID="lblError" CssClass="text-danger mb-2" Visible="false" />
                      <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtPassword" Text="Ingresa tu contraseña" CssClass="form-label" />
                        <asp:TextBox runat="server"
                                     ID="txtPassword"
                                     TextMode="Password"
                                     CssClass="form-control"
                                     Placeholder="Contraseña"
                                     Required="true" />
                      </div>
                    </div>
                    <div class="modal-footer">
                      <button type="button"
                              class="btn btn-secondary"
                              data-bs-dismiss="modal">
                        Cancelar
                      </button>
                      <asp:Button runat="server"
                                  ID="btnEliminarCuenta"
                                  CssClass="btn btn-danger"
                                  Text="Eliminar cuenta"
                                  OnClick="btnEliminarCuenta_Click" />
                    </div>
                  </asp:Panel>
                </div>
              </div>
            </div>
            <!-- Bienvenida -->
            <div class="col-md-9">
                <div class="card shadow-sm p-4">
                    <h4><i class="fas fa-user-cog me-2"></i>Mi Cuenta</h4>
                    <p>Desde aquí puedes actualizar tus datos personales o cambiar tu contraseña.</p>
                    <p>Selecciona una opción del menú a la izquierda.</p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>



