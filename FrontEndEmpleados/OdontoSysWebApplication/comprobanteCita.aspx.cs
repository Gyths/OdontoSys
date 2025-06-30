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
                CargarComprobanteOCrearWizard();
            }
        }

        protected void CargarComprobanteOCrearWizard()
        {
            var cita = CitaBO.cita_obtenerPorId(idCita);
            if (cita == null)
            {
                lblMensaje.Text = "No se encontró la cita.";
                lblMensaje.CssClass = "text-danger";
                return;
            }
            if (cita.estado == CitaWS.estadoCita.ATENDIDA)
            {
                var comp = ComprobanteBO.comprobante_obtenerPorId(cita.comprobante.idComprobante);
                lblFecha.Text = comp.fechaEmision.ToString();
                lblHora.Text = comp.horaEmision.ToString();
                lblTotal.Text = comp.total.ToString("C");
                var metodoPago = MetodoPagoBO.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);
                lblMetodoPago.Text = metodoPago.nombre.ToString();
                pnlDetalle.Visible = true;
                btnGenerar.Visible = false;
                btnDescargarPDF.Visible = true;
                ddlMetodoPago.Visible = false;
                lblhead.Visible = false;
            }
            else
            {
                CargarMetodosPago();
                btnGenerar.Visible = false;
                pnlDetalle.Visible = false;
                btnDescargarPDF.Visible = false;
            }
        }

        private void CargarMetodosPago()
        {
            try
            {
                var metodos = MetodoPagoBO.metodoPago_listarTodos();

                ddlMetodoPago.DataSource = metodos;
                ddlMetodoPago.DataTextField = "nombre";
                ddlMetodoPago.DataValueField = "idMetodoPago";
                ddlMetodoPago.DataBind();
            }
            catch (Exception ex)
            {
                ddlMetodoPago.DataSource = null;
                ddlMetodoPago.DataBind();

                System.Diagnostics.Debug.WriteLine("Error en CargarMetodosPago: " + ex.ToString());
                throw;
            }
        }

        protected void ddlMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnGenerar.Visible = true;
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                int idMetodo = int.Parse(ddlMetodoPago.SelectedValue);

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

                int idComprobante = ComprobanteBO.comprobante_insertar(comprobante);   // devuelve PK

                var cita = CitaBO.cita_obtenerPorId(idCita);
                cita.estado = CitaWS.estadoCita.ATENDIDA;
                CitaBO.cita_modificar(cita);
           
                ComprobanteBO.comprobante_actualizarTotal(cita.idCita);
                lblMensaje.Text = "Comprobante generado correctamente.";
                lblMensaje.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se pudo generar el comprobante. Intenta nuevamente.";
                lblMensaje.CssClass = "text-danger";

                System.Diagnostics.Debug.WriteLine("Error al generar comprobante: " + ex.ToString());
            }

            CargarComprobanteOCrearWizard();
        }
        protected void btnVolver_Click(object sender, EventArgs e) 
        {
            Response.Redirect("~/gestionPaciente.aspx");
        }
        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener datos del comprobante
                var cita = CitaBO.cita_obtenerPorId(idCita);

                var comp = ComprobanteBO.comprobante_obtenerPorId(cita.comprobante.idComprobante);

                var metodoPago = MetodoPagoBO.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);

                // Crear el PDF
                GenerarPDF(comp, metodoPago, cita);
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al generar el PDF: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }

        private void GenerarPDF(ComprobanteWS.comprobante comprobante, MetodoPagoWS.metodoPago metodoPago, CitaWS.cita cita)
        {
          
            Document document = new Document(PageSize.A4, 50, 50, 50, 50);
            MemoryStream ms = new MemoryStream();
            PdfWriter writer = PdfWriter.GetInstance(document, ms);

            document.Open();

           
            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
            Font headerFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
            Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 10);
            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

            
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

            
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

           
            Paragraph comprobanteTitle = new Paragraph("COMPROBANTE DE PAGO", headerFont);
            comprobanteTitle.Alignment = Element.ALIGN_CENTER;
            document.Add(comprobanteTitle);

            
            document.Add(new Paragraph(" "));

           
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

           
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            
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

            
            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

           
            Paragraph footer = new Paragraph("Gracias por confiar en Sonrisa Vital S.A.C.", normalFont);
            footer.Alignment = Element.ALIGN_CENTER;
            document.Add(footer);

            Paragraph fechaImpresion = new Paragraph("Fecha de impresión: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), normalFont);
            fechaImpresion.Alignment = Element.ALIGN_CENTER;
            document.Add(fechaImpresion);

            document.Close();

            
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", $"attachment; filename=Comprobante_{comprobante.idComprobante.ToString().PadLeft(8, '0')}.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(ms.ToArray());
            Response.End();
        }
    }
}