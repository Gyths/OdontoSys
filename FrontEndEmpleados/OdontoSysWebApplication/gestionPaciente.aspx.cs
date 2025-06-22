using System;
using System.IO;
using System.Web.UI;
using System.ComponentModel;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;
using System.Web.UI.WebControls;
using System.Globalization;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontologoWS;
using System.Text;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
     
        private PacienteWS.paciente pacienteActual;
        private BindingList<CitaWS.cita> citasActuales;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] == null ||
                !int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                Response.Redirect("buscarPaciente.aspx");
                return;
            }
            if (IsPostBack && Request.Form["accion"] == "cancelar")
            {
                if (int.TryParse(Request.Form["idCita"], out int idCita))
                    cancelarCita(idCita, idPaciente);
            }
            if (!IsPostBack)
            {
                CargarPaciente(idPaciente);          
                calFiltro.SelectedDate = DateTime.Today;
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasPaciente(idPaciente, fechaBase);

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
                BloquearTodos();
                btnGuardar.Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar paciente: " + ex.Message);
            }
        }

        private void SetReadOnly(TextBox txt, bool readOnly)
        {
            txt.ReadOnly = readOnly;
            txt.CssClass = readOnly ? "form-control locked" : "form-control";
        }
        private void BloquearTodos()
        {
            SetReadOnly(txtNombre, true);
            SetReadOnly(txtApellido, true);
            SetReadOnly(txtDocumento, true);
            SetReadOnly(txtCorreo, true);
            SetReadOnly(txtTelefono, true);
            SetReadOnly(txtUsuario, true);
        }
        protected void btnEditar_Click(object sender, EventArgs e)
        {
            SetReadOnly(txtCorreo, false);
            SetReadOnly(txtTelefono, false);
            SetReadOnly(txtUsuario, false);
            btnGuardar.Visible = true;
            btnEditar.Visible = false;
            btnCita.Visible = false;
            btnVolver.Visible = false;
            btnDescargarPDF.Visible = false;
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

                    BloquearTodos();          
                    btnGuardar.Visible = false;
                    btnEditar.Visible = true;
                    btnCita.Visible = true;
                    btnVolver.Visible = true;
                    btnDescargarPDF.Visible = true;
                }
            }
        }

        private string GetBadgeColor(string estado)
        {
            switch (estado.ToUpper())
            {
                case "RESERVADA": return "warning";
                case "ATENDIDA": return "success";
                case "CANCELADA": return "danger";
                default: return "secondary";
            }
        }

        private string ToTitleCase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        private void CargarCitasPaciente(int idPaciente, DateTime baseDate)
        {
            DateTime desde = baseDate.AddDays(-1).Date;     
            DateTime hasta = baseDate.AddDays(1).Date;


            var clienteCita = new CitaWAClient();
            var clienteOdontologo = new OdontologoWAClient();
            var clienteEspecialidad = new EspecialidadWAClient();

            var pacienteCita = new CitaWS.paciente
            {
                idPaciente = idPaciente,
                idPacienteSpecified = true
            };
            try
            {
                var citas = clienteCita.cita_listarPorPacienteFechas(pacienteCita, desde.ToString("yyyy-MM-dd"), hasta.ToString("yyyy-MM-dd"));
                if (citas == null)
                {
                    ltCitas.Text = "<div class='alert alert-warning'>No hay citas en el rango seleccionado.</div>";
                    return;
                }
                var sb = new StringBuilder();
                foreach (var c in citas)
                {
                    var odonto = clienteOdontologo.odontologo_obtenerPorId(c.odontologo.idOdontologo);
                    var especialidad = clienteEspecialidad.especialidad_obtenerPorId(odonto.especialidad.idEspecialidad);

                    sb.AppendLine("<div class='card mb-3 shadow-sm'>");
                    sb.AppendLine("  <div class='card-body'>");
                    sb.AppendLine($"   <h5 class='card-title'>Fecha: {c.fecha:d} – Hora: {c.horaInicio:hh\\:mm}</h5>");
                    sb.AppendLine($"   <p class='card-text'><strong>Odontólogo:</strong> {odonto.nombre} {odonto.apellidos}</p>");
                    sb.AppendLine($"   <p class='card-text'><strong>Especialidad:</strong> {especialidad.nombre}</p>");
                    sb.AppendLine($"   <p class='card-text'><strong>Estado:</strong> " +
                                    $"<span class='badge bg-{GetBadgeColor(c.estado.ToString())}'>" +
                                    $"{ToTitleCase(c.estado.ToString())}</span></p>");

                    //----- botón Cancelar solo cuando el estado es RESERVADA -----
                    if (c.estado == CitaWS.estadoCita.RESERVADA)
                    {
                        sb.AppendLine("<form method='post' class='d-inline'>");
                        sb.AppendLine("   <input type='hidden' name='accion' value='cancelar' />");
                        sb.AppendLine($"  <input type='hidden' name='idCita' value='{c.idCita}' />");
                        sb.AppendLine("   <button type='submit' class='btn btn-danger btn-sm'>");
                        sb.AppendLine("       Cancelar cita");
                        sb.AppendLine("   </button>");
                        sb.AppendLine("</form>");

                    }
                    if (c.estado != CitaWS.estadoCita.CANCELADA)
                    {
                        sb.AppendLine(
                            $"<a href='comprobanteCita.aspx?idCita={c.idCita}' " +
                            $"class='btn btn-primary btn-sm'>Ver comprobante</a>");
                    }
                    sb.AppendLine("  </div>");
                    sb.AppendLine("</div>");
                }

                ltCitas.Text = sb.ToString();

            }
            catch (Exception ex)
            {
                throw;
            }
        }
        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if(Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitasPaciente(idPaciente, baseDate);
            }
        }
        protected void cancelarCita(int idCita, int idPaciente)
        {
            var clienteCita = new CitaBO();
            var cita = clienteCita.cita_obtenerPorId(idCita);
            if (cita != null && cita.estado == CitaWS.estadoCita.RESERVADA)
            {
                cita.estado = CitaWS.estadoCita.CANCELADA;
                clienteCita.cita_actualizarEstado(cita);
                lblMensaje.Text = "La cita fue cancelada correctamente.";
                lblMensaje.CssClass = "text-success";
            }
            else
            {
                lblMensaje.Text = "No se pudo cancelar la cita.";
                lblMensaje.CssClass = "text-danger";
            }
            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasPaciente(idPaciente, fechaBase);
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

        protected void btnCita_Click(object sender, EventArgs e)
        {
            try
            {
                Response.Redirect("reservaCitaPorRecepcionista.aspx");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error en RowCommand: " + ex.Message);
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