using System;
using System.IO;
using System.Web.UI;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
        // Variables para almacenar los datos del paciente
        private PacienteWS.paciente pacienteActual;

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
            try
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
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar paciente: " + ex.Message);
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
                    // Recargar datos actuales del paciente para el PDF
                    CargarDatosParaPDF(idPaciente);
                    GenerarPDFHistoriaClinica();
                }
                else
                {
                    Response.Write("<script>alert('No se pudo identificar el paciente.');</script>");
                }
            }
            catch (Exception ex)
            {
                // Log del error específico para debugging
                System.Diagnostics.Debug.WriteLine("Error específico al generar PDF: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack trace: " + ex.StackTrace);

                // Mostrar mensaje de error al usuario
                Response.Write($"<script>alert('Error al generar el PDF: {ex.Message}');</script>");
            }
        }

        private void CargarDatosParaPDF(int idPaciente)
        {
            try
            {
                // Solo cargar datos del paciente
                var pacienteBO = new PacienteBO();
                pacienteActual = pacienteBO.paciente_obtenerPorId(idPaciente);

                if (pacienteActual == null)
                {
                    throw new Exception("No se pudieron cargar los datos del paciente.");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar datos para PDF: " + ex.Message);
                throw; // Re-lanzar la excepción para manejarla en el método llamador
            }
        }

        private void GenerarPDFHistoriaClinica()
        {
            // Verificar que tenemos datos del paciente
            if (pacienteActual == null)
            {
                throw new Exception("No hay datos del paciente para generar el PDF.");
            }

            // Crear documento PDF
            Document documento = new Document(PageSize.A4, 50, 50, 50, 50);

            using (MemoryStream stream = new MemoryStream())
            {
                try
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

                    // Información del paciente
                    documento.Add(new Paragraph("DATOS DEL PACIENTE", fontSubtitulo));
                    documento.Add(new Paragraph(" ", fontNormal)); // Espacio

                    // Crear tabla para los datos del paciente
                    PdfPTable tablaPaciente = new PdfPTable(2);
                    tablaPaciente.WidthPercentage = 100;
                    tablaPaciente.SpacingAfter = 20f;

                    // Configurar anchos de columnas
                    float[] anchosPaciente = { 1f, 2f };
                    tablaPaciente.SetWidths(anchosPaciente);

                    // Agregar datos del paciente con validaciones
                    AgregarFilaTabla(tablaPaciente, "Nombre Completo:",
                        $"{pacienteActual.nombre ?? "N/D"} {pacienteActual.apellidos ?? "N/D"}", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "DNI:",
                        pacienteActual.numeroDocumento ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Teléfono:",
                        pacienteActual.telefono ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Correo:",
                        pacienteActual.correo ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Usuario:",
                        pacienteActual.nombreUsuario ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Fecha de Generación:",
                        DateTime.Now.ToString("dd/MM/yyyy HH:mm"), fontNormalBold, fontNormal);

                    documento.Add(tablaPaciente);

                    // Nota sobre citas (temporal)
                    documento.Add(new Paragraph("CITAS DEL PACIENTE:", fontSubtitulo));
                    documento.Add(new Paragraph("acá van las citas del paciente que no aparecen por alguna razón.", fontNormal));

                    // Pie de página
                    documento.Add(new Paragraph(" ", fontNormal));
                    documento.Add(new Paragraph(" ", fontNormal));
                    Paragraph pie = new Paragraph($"Documento generado el {DateTime.Now.ToString("dd/MM/yyyy")} a las {DateTime.Now.ToString("HH:mm")}",
                        new Font(bfTimes, 9, Font.ITALIC));
                    pie.Alignment = Element.ALIGN_RIGHT;
                    documento.Add(pie);

                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al crear contenido PDF: " + ex.Message);
                    throw;
                }
                finally
                {
                    if (documento.IsOpen())
                    {
                        documento.Close();
                    }
                }

                // Configurar respuesta para descarga
                string nombreArchivo = $"Historia_Clinica_{pacienteActual?.numeroDocumento ?? "Paciente"}_{DateTime.Now.ToString("yyyyMMdd")}.pdf";

                Response.Clear();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", $"attachment; filename={nombreArchivo}");
                Response.BinaryWrite(stream.ToArray());
                Response.Flush();
                Response.End();
            }
        }

        private void AgregarFilaTabla(PdfPTable tabla, string etiqueta, string valor, Font fontEtiqueta, Font fontValor)
        {
            try
            {
                PdfPCell celdaEtiqueta = new PdfPCell(new Phrase(etiqueta ?? "", fontEtiqueta));
                celdaEtiqueta.Border = Rectangle.NO_BORDER;
                celdaEtiqueta.PaddingBottom = 5f;
                tabla.AddCell(celdaEtiqueta);

                PdfPCell celdaValor = new PdfPCell(new Phrase(valor ?? "", fontValor));
                celdaValor.Border = Rectangle.NO_BORDER;
                celdaValor.PaddingBottom = 5f;
                tabla.AddCell(celdaValor);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al agregar fila a tabla: " + ex.Message);
                throw;
            }
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
                gvCitas.DataSource = citas;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas del paciente: " + ex.Message);
                gvCitas.DataSource = null;
                gvCitas.DataBind();
            }
        }
    }
}