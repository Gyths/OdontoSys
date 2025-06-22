using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontologoWS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;
using System.Globalization;
using System.ComponentModel;

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

            if (!IsPostBack)
            {
                CargarPaciente(idPaciente);
                calFiltro.SelectedDate = DateTime.Today;
                CargarCitasPaciente(idPaciente, DateTime.Today);
            }
            else if (Request.Form["__EVENTTARGET"] == "CancelCita" &&
                     !string.IsNullOrEmpty(Request.Form["__EVENTARGUMENT"]))
            {
                // Handle cancellation postback
                if (int.TryParse(Request.Form["__EVENTARGUMENT"], out int idCita))
                {
                    CancelarCita(idCita, idPaciente);
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
                BloquearTodos();
                btnGuardar.Visible = false;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar paciente: " + ex.Message);
                lblMensaje.Text = "Error al cargar datos del paciente.";
                lblMensaje.CssClass = "text-danger";
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
            if (Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                try
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
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error al guardar paciente: " + ex.Message);
                    lblMensaje.Text = "Error al guardar los cambios.";
                    lblMensaje.CssClass = "text-danger";
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
                if (citas == null || !citas.Any())
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

                    if (c.estado == CitaWS.estadoCita.RESERVADA)
                    {
                        sb.AppendLine($"<button type='button' class='btn btn-danger btn-sm' " +
                                      $"onclick=\"cancelCita('{c.idCita}');\">Cancelar cita</button>");
                    }

                    if (c.estado != CitaWS.estadoCita.CANCELADA)
                    {
                        sb.AppendLine($"<a href='comprobanteCita.aspx?idCita={c.idCita}' " +
                                      $"class='btn btn-primary btn-sm'>Ver comprobante</a>");
                    }

                    sb.AppendLine("  </div>");
                    sb.AppendLine("</div>");
                }

                ltCitas.Text = sb.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas: " + ex.Message);
                ltCitas.Text = "<div class='alert alert-danger'>Error al cargar las citas.</div>";
            }
        }

        private void CancelarCita(int idCita, int idPaciente)
        {
            try
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
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cancelar cita: " + ex.Message);
                lblMensaje.Text = "Error al cancelar la cita.";
                lblMensaje.CssClass = "text-danger";
            }

            DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue ? DateTime.Today : calFiltro.SelectedDate;
            CargarCitasPaciente(idPaciente, fechaBase);
        }

        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitasPaciente(idPaciente, baseDate);
            }
        }

        protected void btnDescargarPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idPacienteSeleccionado"] != null &&
                    int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
                {
                    CargarDatosParaPDF(idPaciente);
                    GenerarPDFHistoriaClinica();
                }
                else
                {
                    lblMensaje.Text = "No se pudo identificar el paciente.";
                    lblMensaje.CssClass = "text-danger";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al generar PDF: " + ex.Message);
                lblMensaje.Text = $"Error al generar el PDF: {ex.Message}";
                lblMensaje.CssClass = "text-danger";
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
                System.Diagnostics.Debug.WriteLine("Error al redirigir a reserva cita: " + ex.Message);
                lblMensaje.Text = "Error al redirigir a la página de reserva.";
                lblMensaje.CssClass = "text-danger";
            }
        }

        private void CargarDatosParaPDF(int idPaciente)
        {
            try
            {
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
                throw;
            }
        }

        private void GenerarPDFHistoriaClinica()
        {
            if (pacienteActual == null)
            {
                throw new Exception("No hay datos del paciente para generar el PDF.");
            }

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

                    AgregarFilaTabla(tablaPaciente, "Nombre Completo:",
                        $"{pacienteActual.nombre ?? "N/D"} {pacienteActual.apellidos ?? "N/D"}", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "DNI:",
                        pacienteActual.numeroDocumento ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Teléfono:",
                        pacienteActual.telefono ?? "N/D", fontNormalBold, fontNormal);
                    AgregarFilaTabla(tablaPaciente, "Correo:",
                        pacienteActual.correo ?? "N/D", fontNormalBold, fontNormal);

                    documento.Add(tablaPaciente);

                    documento.Add(new Paragraph("CITAS DEL PACIENTE:", fontSubtitulo));
                    documento.Add(new Paragraph("--------acá irían las citas del paciente--------", fontNormal));

                    documento.Add(new Paragraph(" ", fontNormal));
                    documento.Add(new Paragraph(" ", fontNormal));
                    Paragraph pie = new Paragraph($"Documento generado el {DateTime.Now:dd/MM/yyyy} a las {DateTime.Now:HH:mm}",
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

                string nombreArchivo = $"Historia_Clinica_{pacienteActual?.numeroDocumento ?? "Paciente"}_{DateTime.Now:yyyyMMdd}.pdf";
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
    }
}