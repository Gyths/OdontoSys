using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace OdontoSysWebApplication
{
    public partial class comprobanteCita : System.Web.UI.Page
    {
        private int idCita => int.Parse(Request.QueryString["idCita"]);
        private CitaBO citaBO;
        private ComprobanteBO comprobanteBO;
        private MetodoPagoBO metodoPagoBO;
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public ComprobanteBO ComprobanteBO { get => comprobanteBO; set => comprobanteBO = value; }
        public MetodoPagoBO MetodoPagoBO { get => metodoPagoBO; set => metodoPagoBO = value; }

        public comprobanteCita()
        {
            this.CitaBO = new CitaBO();
            this.ComprobanteBO = new ComprobanteBO();
            this.MetodoPagoBO = new MetodoPagoBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Request.QueryString["idCita"] == null || !int.TryParse(Request.QueryString["idCita"], out int idValidCita))
                {
                    MostrarMensaje("ID de cita inválido o no proporcionado.", "text-danger");
                    DeshabilitarControles();
                    return;
                }

                CargarComprobanteOCrearWizard();
            }
        }

        protected void CargarComprobanteOCrearWizard()
        {
            try
            {
                var cita = CitaBO.cita_obtenerPorId(idCita);
                if (cita == null)
                {
                    MostrarMensaje("No se encontró la cita especificada.", "text-danger");
                    DeshabilitarControles();
                    return;
                }

                if (cita.estado == CitaWS.estadoCita.ATENDIDA)
                {
                    CargarComprobanteExistente(cita);
                }
                else
                {
                    CargarFormularioGeneracion();
                }
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar la información de la cita.", "text-danger");
                DeshabilitarControles();
                // Log del error (descomenta si tienes sistema de logging)
                // LogError(ex);
            }
        }

        private void CargarComprobanteExistente(CitaWS.cita cita)
        {
            try
            {
                if (cita.comprobante == null)
                {
                    MostrarMensaje("La cita no tiene un comprobante asociado.", "text-danger");
                    CargarFormularioGeneracion();
                    return;
                }

                var comp = ComprobanteBO.comprobante_obtenerPorId(cita.comprobante.idComprobante);
                if (comp == null)
                {
                    MostrarMensaje("No se pudo cargar el comprobante asociado.", "text-danger");
                    CargarFormularioGeneracion();
                    return;
                }

                // Cargar datos del comprobante
                lblFecha.Text = DateTime.Parse(comp.fechaEmision).ToString("dd/MM/yyyy");
                lblHora.Text = comp.horaEmision;
                lblTotal.Text = comp.total.ToString("C");

                var metodoPago = MetodoPagoBO.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);
                lblMetodoPago.Text = metodoPago?.nombre ?? "Método no encontrado";

                // Configurar visibilidad de controles - SIN mensaje de éxito
                pnlDetalle.Visible = true;
                pnlGeneracion.Visible = false;

                // Limpiar cualquier mensaje previo al mostrar comprobante existente
                lblMensaje.Visible = false;
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar el comprobante existente.", "text-danger");
                CargarFormularioGeneracion();
                // LogError(ex);
            }
        }

        private void CargarFormularioGeneracion()
        {
            CargarMetodosPago();
            pnlGeneracion.Visible = true;
            pnlDetalle.Visible = false;
            btnGenerar.Visible = false;
        }

        private void CargarMetodosPago()
        {
            try
            {
                var metodos = MetodoPagoBO.metodoPago_listarTodos();
                if (metodos == null || metodos.Count == 0)
                {
                    MostrarMensaje("No hay métodos de pago disponibles.", "text-danger");
                    return;
                }

                ddlMetodoPago.DataSource = metodos;
                ddlMetodoPago.DataTextField = "nombre";
                ddlMetodoPago.DataValueField = "idMetodoPago";
                ddlMetodoPago.DataBind();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al cargar los métodos de pago.", "text-danger");
                // LogError(ex);
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
            {
                btnGenerar.Visible = true;
            }
            else
            {
                btnGenerar.Visible = false;
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlMetodoPago.SelectedValue))
                {
                    MostrarMensaje("Debe seleccionar un método de pago.", "text-danger");
                    return;
                }

                if (!int.TryParse(ddlMetodoPago.SelectedValue, out int idMetodo))
                {
                    MostrarMensaje("Método de pago seleccionado no válido.", "text-danger");
                    return;
                }

                // Crear el comprobante
                var comprobante = new ComprobanteWS.comprobante
                {
                    fechaEmision = DateTime.Now.ToString("yyyy-MM-dd"),
                    horaEmision = DateTime.Now.ToString("HH:mm:ss"),
                    metodoDePago = new ComprobanteWS.metodoPago
                    {
                        idMetodoPago = idMetodo,
                        idMetodoPagoSpecified = true
                    },
                    total = 0.0
                };

                int idComprobante = ComprobanteBO.comprobante_insertar(comprobante);

                if (idComprobante <= 0)
                {
                    MostrarMensaje("Error al generar el comprobante.", "text-danger");
                    return;
                }

                // Actualizar la cita
                var cita = CitaBO.cita_obtenerPorId(idCita);
                if (cita == null)
                {
                    MostrarMensaje("Error: no se encontró la cita para actualizar.", "text-danger");
                    return;
                }
                cita.comprobante.idComprobante = idComprobante;
                cita.comprobante.idComprobanteSpecified = true;
                cita.estado = CitaWS.estadoCita.ATENDIDA;
                CitaBO.cita_modificar(cita);

                // Actualizar el total del comprobante
                ComprobanteBO.comprobante_actualizarTotal(cita.idCita);

                MostrarMensaje("Comprobante generado correctamente.", "text-success");
                CargarComprobanteOCrearWizard();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al generar el comprobante: " + ex.Message, "text-danger");
                // LogError(ex);
            }
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/gestionPaciente.aspx");
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                var cita = CitaBO.cita_obtenerPorId(idCita);
                if (cita?.comprobante == null)
                {
                    MostrarMensaje("No se encontró el comprobante para descargar.", "text-danger");
                    return;
                }

                // Usar el método del ComprobanteBO para generar el PDF
                byte[] pdfBytes = ComprobanteBO.reporteComprobante(cita.comprobante.idComprobante);

                if (pdfBytes == null || pdfBytes.Length == 0)
                {
                    MostrarMensaje("Error al generar el reporte PDF.", "text-danger");
                    return;
                }

                // Enviar el PDF al cliente
                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", $"attachment; filename=Comprobante_{cita.comprobante.idComprobante.ToString().PadLeft(8, '0')}.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(pdfBytes);
                Response.End();
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al generar el PDF: " + ex.Message, "text-danger");
                // LogError(ex);
            }
        }

        private void MostrarMensaje(string mensaje, string cssClass)
        {
            lblMensaje.Text = mensaje;
            lblMensaje.CssClass = cssClass + " alert";
            lblMensaje.Visible = !string.IsNullOrEmpty(mensaje);
        }

        private void DeshabilitarControles()
        {
            ddlMetodoPago.Enabled = false;
            btnGenerar.Visible = false;
            btnDescargarPDF.Visible = false;
            pnlDetalle.Visible = false;
            pnlGeneracion.Visible = false;
        }
    }
}