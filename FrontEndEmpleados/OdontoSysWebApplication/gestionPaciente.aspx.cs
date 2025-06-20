using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.ComponentModel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
        // Variables para almacenar los datos del paciente y citas
        private PacienteWS.paciente pacienteActual;
        private BindingList<CitaWS.cita> citasActuales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idPacienteSeleccionado"] != null && int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
                {
                    CargarPaciente(idPaciente);
                    CargarCitasPaciente(idPaciente);
                }
                else
                {
                    Response.Redirect("buscarPaciente.aspx");
                }
            }
        }

        private void CargarPaciente(int id)
        {
            var pacienteBO = new PacienteBO();
            pacienteActual = pacienteBO.paciente_obtenerPorId(id);

            if (pacienteActual != null)
            {
                txtNombre.Text = pacienteActual.nombre ?? "";
                txtApellido.Text = pacienteActual.apellidos ?? "";
                txtDocumento.Text = pacienteActual.numeroDocumento ?? "";
                txtCorreo.Text = pacienteActual.correo ?? "";
                txtTelefono.Text = pacienteActual.telefono ?? "";
                txtUsuario.Text = pacienteActual.nombreUsuario ?? "";
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            txtCorreo.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtUsuario.ReadOnly = false;
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] != null && int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                var pacienteBO = new PacienteBO();
                var original = pacienteBO.paciente_obtenerPorId(idPaciente);

                if (original != null)
                {
                    original.correo = txtCorreo.Text;
                    original.telefono = txtTelefono.Text;
                    original.nombreUsuario = txtUsuario.Text;
                    pacienteBO.paciente_modificar(original);

                    // Actualizar datos actuales
                    pacienteActual = original;

                    pnlAlerta.Visible = true;

                    txtCorreo.ReadOnly = true;
                    txtTelefono.ReadOnly = true;
                    txtUsuario.ReadOnly = true;
                    btnGuardar.Visible = false;
                    btnEditar.Visible = true;
                }
            }
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idPacienteSeleccionado"] != null && int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
                {
                    // Recargar datos actuales para el PDF
                    CargarDatosParaPDF(idPaciente);
                    GenerarPDFHistoriaClinica();
                }
            }
            catch (Exception ex)
            {
                // Mostrar mensaje de error al usuario
                Response.Write("<script>alert('Error al generar el PDF. Intente nuevamente.');</script>");
            }
        }

        private void CargarDatosParaPDF(int idPaciente)
        {
            // Cargar datos del paciente
            var pacienteBO = new PacienteBO();
            pacienteActual = pacienteBO.paciente_obtenerPorId(idPaciente);

            // Cargar citas del paciente
            var citaBO = new CitaBO();
            var paciente = new CitaWS.paciente { idPaciente = idPaciente };
            citasActuales = citaBO.cita_listarPorPaciente(paciente);
        }

        private void GenerarPDFHistoriaClinica()
        {
            // Crear documento PDF
            Document documento = new Document(PageSize.A4, 50, 50, 50, 50);

            using (MemoryStream stream = new MemoryStream())
            {
                PdfWriter writer = PdfWriter.GetInstance(documento, stream);
                documento.Open();

                // Configurar fuentes
                BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                Font fontTitulo = new Font(bfTimes, 18, Font.BOLD);
                Font fontSubtitulo = new Font(bfTimes, 14, Font.BOLD);
                Font fontNormal = new Font(bfTimes, 11, Font.NORMAL);
                Font fontNormalBold = new Font(bfTimes, 11, Font.BOLD);

                // Título principal
                Paragraph titulo = new Paragraph("HISTORIA CLÍNICA", fontTitulo);
                titulo.Alignment = Element.ALIGN_CENTER;
                titulo.SpacingAfter = 20f;
                documento.Add(titulo);

                // Información del paciente (cabecera)
                documento.Add(new Paragraph("DATOS DEL PACIENTE", fontSubtitulo));
                documento.Add(new Paragraph(" ", fontNormal)); // Espacio

                if (pacienteActual != null)
                {
                    // Crear tabla para los datos del paciente
                    PdfPTable tablaPaciente = new PdfPTable(2);
                    tablaPaciente.WidthPercentage = 100;
                    tablaPaciente.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchosPaciente = { 1f, 2f };
                    tablaPaciente.SetWidths(anchosPaciente);

                    // Agregar datos del paciente
                    AgregarFilaTabla(tablaPaciente, "Nombre Completo:",
                        $"{pacienteActual.nombre} {pacienteActual.apellidos}", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "DNI:",
                        pacienteActual.numeroDocumento ?? "N/A", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Teléfono:",
                        pacienteActual.telefono ?? "N/A", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Correo:",
                        pacienteActual.correo ?? "N/A", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Usuario:",
                        pacienteActual.nombreUsuario ?? "N/A", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Fecha de Generación:",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormalBold, fontNormal);

                    documento.Add(tablaPaciente);
                }

                // Sección de citas
                documento.Add(new Paragraph("CITAS DEL PACIENTE:", fontSubtitulo));
                documento.Add(new Paragraph(" ", fontNormal)); // Espacio

                if (citasActuales != null && citasActuales.Count > 0)
                {
                    // Crear tabla para las citas
                    PdfPTable tablaCitas = new PdfPTable(4);
                    tablaCitas.WidthPercentage = 100;
                    tablaCitas.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchosCitas = { 1.5f, 1f, 2f, 2f };
                    tablaCitas.SetWidths(anchosCitas);

                    // Encabezados de la tabla
                    AgregarEncabezadoTabla(tablaCitas, "Fecha", fontNormalBold);
                    AgregarEncabezadoTabla(tablaCitas, "Hora", fontNormalBold);
                    AgregarEncabezadoTabla(tablaCitas, "Odontólogo", fontNormalBold);
                    AgregarEncabezadoTabla(tablaCitas, "Especialidad", fontNormalBold);

                    // Agregar datos de las citas
                    foreach (var cita in citasActuales)
                    {
                        AgregarCeldaTabla(tablaCitas, cita.fecha ?? "N/A", fontNormal);
                        AgregarCeldaTabla(tablaCitas, cita.horaInicio ?? "N/A", fontNormal);
                        AgregarCeldaTabla(tablaCitas,
                            cita.odontologo?.nombre ?? "N/A", fontNormal);
                        AgregarCeldaTabla(tablaCitas,
                            cita.odontologo?.especialidad?.nombre ?? "N/A", fontNormal);
                    }

                    documento.Add(tablaCitas);

                    // Resumen de citas
                    documento.Add(new Paragraph($"Total de citas registradas: {citasActuales.Count}", fontNormalBold));
                }
                else
                {
                    documento.Add(new Paragraph("No se encontraron citas registradas para este paciente.", fontNormal));
                }

                // Pie de página
                documento.Add(new Paragraph(" ", fontNormal));
                documento.Add(new Paragraph(" ", fontNormal));
                Paragraph pie = new Paragraph($"Documento generado el {DateTime.Now.ToString("dd/MM/yyyy")} a las {DateTime.Now.ToString("HH:mm")}",
                    new Font(bfTimes, 9, Font.ITALIC));
                pie.Alignment = Element.ALIGN_RIGHT;
                documento.Add(pie);

                documento.Close();

                // Configurar respuesta para descarga
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition",
                    $"attachment; filename=Historia_Clinica_{pacienteActual?.numeroDocumento ?? "Paciente"}_{DateTime.Now.ToString("yyyyMMdd")}.pdf");
                Response.BinaryWrite(stream.ToArray());
                Response.End();
            }
        }

        private void AgregarFilaTabla(PdfPTable tabla, string etiqueta, string valor, Font fontEtiqueta, Font fontValor)
        {
            PdfPCell celdaEtiqueta = new PdfPCell(new Phrase(etiqueta, fontEtiqueta));
            celdaEtiqueta.Border = Rectangle.NO_BORDER;
            celdaEtiqueta.PaddingBottom = 5f;
            tabla.AddCell(celdaEtiqueta);

            PdfPCell celdaValor = new PdfPCell(new Phrase(valor, fontValor));
            celdaValor.Border = Rectangle.NO_BORDER;
            celdaValor.PaddingBottom = 5f;
            tabla.AddCell(celdaValor);
        }

        private void AgregarEncabezadoTabla(PdfPTable tabla, string texto, Font font)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, font));
            celda.BackgroundColor = BaseColor.LIGHT_GRAY;
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 5f;
            tabla.AddCell(celda);
        }

        private void AgregarCeldaTabla(PdfPTable tabla, string texto, Font font)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto, font));
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 5f;
            tabla.AddCell(celda);
        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscarPaciente.aspx");
        }

        private void CargarCitasPaciente(int idPaciente)
        {
            var citaBO = new CitaBO();
            var paciente = new CitaWS.paciente { idPaciente = idPaciente };
            try
            {
                var citas = citaBO.cita_listarPorPaciente(paciente);
                citasActuales = citas; // Guardar para usar en el PDF
                gvCitas.DataSource = citas;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas del paciente : " + ex.Message);
                gvCitas.DataSource = null;
                gvCitas.DataBind();
            }
        }
    }
}