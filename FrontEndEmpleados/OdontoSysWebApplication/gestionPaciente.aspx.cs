using System;
using System.IO;
using System.Web.UI;
using System.ComponentModel;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
     
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
               
                System.Diagnostics.Debug.WriteLine("Error específico al generar PDF: " + ex.Message);
                System.Diagnostics.Debug.WriteLine("Stack trace: " + ex.StackTrace);

               
                Response.Write($"<script>alert('Error al generar el PDF: {ex.Message}');</script>");
            }
        }

        private void CargarDatosParaPDF(int idPaciente)
        {
            try
            {
                // Cargar datos del paciente
                var pacienteBO = new PacienteBO();
                pacienteActual = pacienteBO.paciente_obtenerPorId(idPaciente);

                if (pacienteActual == null)
                {
                    throw new Exception("No se pudieron cargar los datos del paciente.");
                }

                //Descomentar cuando se puedan listar las citas
                /*
                // Cargar citas del paciente
                var citaBO = new CitaBO();
                var pacienteWS = new CitaWS.paciente { idPaciente = idPaciente };
                var todasLasCitas = citaBO.cita_listarPorPaciente(pacienteWS);
                
                // Filtrar solo las citas ATENDIDAS
                if (todasLasCitas != null && todasLasCitas.Count > 0)
                {
                    var citasAtendidas = todasLasCitas.Where(c => c != null && 
                        !string.IsNullOrEmpty(c.estado) && 
                        c.estado.Equals("ATENDIDA", StringComparison.OrdinalIgnoreCase)).ToList();
                    
                    citasActuales = new BindingList<CitaWS.cita>(citasAtendidas);
                }
                else
                {
                    citasActuales = new BindingList<CitaWS.cita>();
                }
                
                System.Diagnostics.Debug.WriteLine($"Citas cargadas para PDF: {citasActuales?.Count ?? 0}");
                */
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar datos para PDF: " + ex.Message);
                // citasActuales = new BindingList<CitaWS.cita>(); // Inicializar lista vacía en caso de error
                throw;
            }
        }

        private void GenerarPDFHistoriaClinica()
        {
            
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

                    
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, false);
                    Font fontTitulo = new Font(bfTimes, 18, Font.BOLD);
                    Font fontSubtitulo = new Font(bfTimes, 14, Font.BOLD);
                    Font fontNormal = new Font(bfTimes, 11, Font.NORMAL);
                    Font fontNormalBold = new Font(bfTimes, 11, Font.BOLD);

                   
                    Paragraph titulo = new Paragraph("HISTORIA CLÍNICA", fontTitulo);
                    titulo.Alignment = Element.ALIGN_CENTER;
                    titulo.SpacingAfter = 20f;
                    documento.Add(titulo);

                    Paragraph subtitulo = new Paragraph("Sonrisa Vital SAC", fontTitulo);
                    subtitulo.Alignment = Element.ALIGN_CENTER;
                    subtitulo.SpacingAfter = 20f;
                    documento.Add(subtitulo);

                    documento.Add(new Paragraph("DATOS DEL PACIENTE", fontSubtitulo));
                    documento.Add(new Paragraph(" ", fontNormal)); 

                   
                    PdfPTable tablaPaciente = new PdfPTable(2);
                    tablaPaciente.WidthPercentage = 100;
                    tablaPaciente.SpacingAfter = 20f;

                   
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

                    documento.Add(tablaPaciente);

                    // Descomentar cuando se puedan listar las citas, sino da error
                    /*
                    // Sección de citas atendidas
                    documento.Add(new Paragraph("CITAS ATENDIDAS DEL PACIENTE:", fontSubtitulo));
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
                            if (cita != null)
                            {
                                AgregarCeldaTabla(tablaCitas, cita.fecha ?? "N/D", fontNormal);
                                AgregarCeldaTabla(tablaCitas, cita.horaInicio ?? "N/D", fontNormal);
                                AgregarCeldaTabla(tablaCitas, 
                                    cita.odontologo?.nombre ?? "N/D", fontNormal);
                                AgregarCeldaTabla(tablaCitas, 
                                    cita.odontologo?.especialidad?.nombre ?? "N/D", fontNormal);
                            }
                        }

                        documento.Add(tablaCitas);

                        // Resumen de citas
                        documento.Add(new Paragraph($"Total de citas atendidas: {citasActuales.Count}", fontNormalBold));
                    }
                    else
                    {
                        documento.Add(new Paragraph("No se encontraron citas atendidas para este paciente.", fontNormal));
                    }
                    */

                   
                    documento.Add(new Paragraph("CITAS DEL PACIENTE:", fontSubtitulo));
                    documento.Add(new Paragraph("--------acá irían las citas del paciente--------", fontNormal));

                    
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
            var pacienteWS = new CitaWS.paciente {
                idPaciente = idPaciente,
                idPacienteSpecified = true
            };
            try
            {
                var citas = citaBO.cita_listarPorPaciente(pacienteWS);
                gvCitas.DataSource = citas;
                gvCitas.DataBind();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas del paciente: " + ex.Message + " " + pacienteWS.idPaciente);
                gvCitas.DataSource = null;
                gvCitas.DataBind();
            }
        }
        // TODO
        /*
        private void AgregarEncabezadoTabla(PdfPTable tabla, string texto, Font font)
        {
            try
            {
                PdfPCell celda = new PdfPCell(new Phrase(texto ?? "", font));
                celda.BackgroundColor = BaseColor.LIGHT_GRAY;
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Padding = 5f;
                tabla.AddCell(celda);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al agregar encabezado a tabla: " + ex.Message);
                throw;
            }
        }

        private void AgregarCeldaTabla(PdfPTable tabla, string texto, Font font)
        {
            try
            {
                PdfPCell celda = new PdfPCell(new Phrase(texto ?? "", font));
                celda.HorizontalAlignment = Element.ALIGN_CENTER;
                celda.Padding = 5f;
                tabla.AddCell(celda);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al agregar celda a tabla: " + ex.Message);
                throw;
            }
        }
        */
    }
}