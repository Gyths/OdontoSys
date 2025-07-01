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
        private CitaBO citaBO = new CitaBO();
        private ComprobanteBO comprobanteBO = new ComprobanteBO();
        private MetodoPagoBO metodoPagoBO = new MetodoPagoBO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Validar que el parámetro idCita esté presente y sea válido
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
                var cita = citaBO.cita_obtenerPorId(idCita);
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

                var comp = comprobanteBO.comprobante_obtenerPorId(cita.comprobante.idComprobante);
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

                var metodoPago = metodoPagoBO.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);
                lblMetodoPago.Text = metodoPago?.nombre ?? "Método no encontrado";

                // Configurar visibilidad de controles
                pnlDetalle.Visible = true;
                btnGenerar.Visible = false;
                btnDescargarPDF.Visible = true;
                ddlMetodoPago.Visible = false;
                lblhead.Visible = false;

                MostrarMensaje("Comprobante cargado correctamente.", "text-success");
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
            btnGenerar.Visible = false;
            pnlDetalle.Visible = false;
            btnDescargarPDF.Visible = false;
            ddlMetodoPago.Visible = true;
            lblhead.Visible = true;
        }

        private void CargarMetodosPago()
        {
            try
            {
                var metodos = metodoPagoBO.metodoPago_listarTodos();
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
                    total = 0.0,
                };

                int idComprobante = comprobanteBO.comprobante_insertar(comprobante);

                if (idComprobante <= 0)
                {
                    MostrarMensaje("Error al generar el comprobante.", "text-danger");
                    return;
                }

                // Actualizar la cita
                var cita = citaBO.cita_obtenerPorId(idCita);
                if (cita == null)
                {
                    MostrarMensaje("Error: no se encontró la cita para actualizar.", "text-danger");
                    return;
                }

                cita.estado = CitaWS.estadoCita.ATENDIDA;
                citaBO.cita_modificar(cita);

                // Actualizar el total del comprobante
                comprobanteBO.comprobante_actualizarTotal(cita.idCita);

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
                var cita = citaBO.cita_obtenerPorId(idCita);
                if (cita?.comprobante == null)
                {
                    MostrarMensaje("No se encontró el comprobante para descargar.", "text-danger");
                    return;
                }

                var comp = comprobanteBO.comprobante_obtenerPorId(cita.comprobante.idComprobante);
                if (comp == null)
                {
                    MostrarMensaje("Error al obtener los datos del comprobante.", "text-danger");
                    return;
                }

                var metodoPago = metodoPagoBO.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);
                if (metodoPago == null)
                {
                    MostrarMensaje("Error al obtener el método de pago.", "text-danger");
                    return;
                }

                GenerarPDF(comp, metodoPago, cita);
            }
            catch (Exception ex)
            {
                MostrarMensaje("Error al generar el PDF: " + ex.Message, "text-danger");
                // LogError(ex);
            }
        }

        private void GenerarPDF(ComprobanteWS.comprobante comprobante, MetodoPagoWS.metodoPago metodoPago, CitaWS.cita cita)
        {
            Document document = null;
            MemoryStream ms = null;

            try
            {
                document = new Document(PageSize.A4, 50, 50, 50, 50);
                ms = new MemoryStream();
                PdfWriter writer = PdfWriter.GetInstance(document, ms);

                document.Open();

                // Fuentes
                Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
                Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                // Encabezado de la empresa
                Paragraph title = new Paragraph("SONRISA VITAL S.A.C.", titleFont);
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);

                Paragraph ruc = new Paragraph("RUC: 12345678910", normalFont);
                ruc.Alignment = Element.ALIGN_CENTER;
                document.Add(ruc);

                Paragraph direccion = new Paragraph("Av. Endodoncia 123, Lima - Perú", normalFont);
                direccion.Alignment = Element.ALIGN_CENTER;
                document.Add(direccion);

                Paragraph telefono = new Paragraph("Teléfono: (01) 123-4567", normalFont);
                telefono.Alignment = Element.ALIGN_CENTER;
                document.Add(telefono);

                // Espacio
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                // Título del comprobante
                Paragraph comprobanteTitle = new Paragraph("COMPROBANTE DE PAGO", headerFont);
                comprobanteTitle.Alignment = Element.ALIGN_CENTER;
                document.Add(comprobanteTitle);

                document.Add(new Paragraph(" "));

                // Tabla de información
                PdfPTable table = new PdfPTable(2);
                table.WidthPercentage = 100;
                table.SetWidths(new float[] { 1f, 2f });

                table.AddCell(new PdfPCell(new Phrase("Comprobante N°:", boldFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(comprobante.idComprobante.ToString().PadLeft(8, '0'), normalFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Fecha de Emisión:", boldFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(DateTime.Parse(comprobante.fechaEmision).ToString("dd/MM/yyyy"), normalFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Hora de Emisión:", boldFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(comprobante.horaEmision, normalFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Cita N°:", boldFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(cita.idCita.ToString(), normalFont)) { Border = Rectangle.NO_BORDER });

                table.AddCell(new PdfPCell(new Phrase("Método de Pago:", boldFont)) { Border = Rectangle.NO_BORDER });
                table.AddCell(new PdfPCell(new Phrase(metodoPago.nombre, normalFont)) { Border = Rectangle.NO_BORDER });

                document.Add(table);

                // Espacio
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                // Tabla del total
                PdfPTable totalTable = new PdfPTable(2);
                totalTable.WidthPercentage = 100;
                totalTable.SetWidths(new float[] { 3f, 1f });

                PdfPCell totalLabelCell = new PdfPCell(new Phrase("TOTAL A PAGAR:", titleFont));
                totalLabelCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                totalLabelCell.Border = Rectangle.TOP_BORDER;
                totalTable.AddCell(totalLabelCell);

                PdfPCell totalValueCell = new PdfPCell(new Phrase(comprobante.total.ToString("C"), titleFont));
                totalValueCell.HorizontalAlignment = Element.ALIGN_RIGHT;
                totalValueCell.Border = Rectangle.TOP_BORDER;
                totalTable.AddCell(totalValueCell);

                document.Add(totalTable);

                // Espacio
                document.Add(new Paragraph(" "));
                document.Add(new Paragraph(" "));

                // Pie de página
                Paragraph footer = new Paragraph("Gracias por confiar en Sonrisa Vital S.A.C.", normalFont);
                footer.Alignment = Element.ALIGN_CENTER;
                document.Add(footer);

                Paragraph fechaImpresion = new Paragraph("Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), normalFont);
                fechaImpresion.Alignment = Element.ALIGN_CENTER;
                document.Add(fechaImpresion);

                document.Close();

                // Enviar el PDF
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", $"attachment; filename=Comprobante_{comprobante.idComprobante.ToString().PadLeft(8, '0')}.pdf");
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite(ms.ToArray());
                Response.End();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al generar el archivo PDF: " + ex.Message, ex);
            }
            finally
            {
                document?.Close();
                ms?.Dispose();
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
        }

        
    }
}