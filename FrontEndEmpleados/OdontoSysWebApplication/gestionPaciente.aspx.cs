using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebApplication.OdontoSysBusiness;
using OdontoSysWebApplication.CitaWS;
using OdontoSysWebApplication.EspecialidadWS;
using OdontoSysWebApplication.OdontologoWS;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using OdontoSysWebApplication.PacienteWS;

namespace OdontoSysWebApplication
{
    public partial class gestionPaciente : System.Web.UI.Page
    {
        private PacienteWS.paciente pacienteActual;
        Label lblMensaje;
        private PacienteBO pacienteBO ;
        private OdontologoBO odontologoBO ;
        private CitaBO citaBO;
        private SalaBO salaBO;
        private EspecialidadBO especialidadBO;

        public PacienteBO PacienteBO { get => pacienteBO; set => pacienteBO = value; }
        public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public SalaBO SalaBO { get => salaBO; set => salaBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }

        public gestionPaciente()
        {
            this.PacienteBO = new PacienteBO();
            this.OdontologoBO = new OdontologoBO();
            this.CitaBO = new CitaBO();
            this.SalaBO = new SalaBO();
            this.EspecialidadBO = new EspecialidadBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] == null ||
        !       int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                Response.Redirect("buscarPaciente.aspx");
                return;
            }

            if (!IsPostBack)
            {
                CargarPaciente(idPaciente);
                calFiltro.SelectedDate = DateTime.Today;
                CargarCitas(idPaciente, DateTime.Today);
            }
        }

        private void CargarPaciente(int id)
        {
            try
            {
                pacienteActual = PacienteBO.paciente_obtenerPorId(id);

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

        protected void gvCitas_RowCommand(object sender, GridViewCommandEventArgs e) 
        {
            if (e.CommandName == "Gestionar") 
            {
                string idCita = e.CommandArgument.ToString();
                Response.Redirect($"comprobanteCita.aspx?idCita={idCita}");
            }
            
        }

        protected void gvCitas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow) return;

            var estado = DataBinder.Eval(e.Row.DataItem, "estado")?.ToString();
            bool mostrarBtn = estado == "ATENDIDA" || estado == "RESERVADA"; 
            bool mostrarChk = estado == "RESERVADA";

            var btn = (Button)e.Row.FindControl("btnGestionarComprobante");
            var chk = (CheckBox)e.Row.FindControl("chkSeleccionar");

            if (btn != null) btn.Visible = mostrarBtn;
            if (chk != null) chk.Visible = mostrarChk;
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
                    var original = PacienteBO.paciente_obtenerPorId(idPaciente);

                    if (original != null)
                    {
                        if (Regex.IsMatch(txtTelefono.Text, @"^(9\d{8}|\d{3}-\d{4})$") &&
                            Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                        {
                            original.correo = txtCorreo.Text;
                            original.telefono = txtTelefono.Text;
                            original.nombreUsuario = txtUsuario.Text;
                            PacienteBO.paciente_modificar(original);
                        }
                        else
                        {
                            
                            throw new Exception("El numero de telefono o correo son incorrectos");
                        }

                        pacienteActual = original;

                        pnlAlerta.Visible = true;
                        pnlError.Visible = false;
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
                    Label lblMensaje = new Label();
                    lblMensaje.Text = "Error al guardar los cambios. "+ ex.Message;
                    lblMensaje.CssClass = "text-danger";
                    pnlError.Controls.Add(new LiteralControl(lblMensaje.Text));
                    pnlAlerta.Visible = false;
                    pnlError.Visible = true;
                }
            }
        }
        
        private void CargarCitas(int id, DateTime baseDate) 
        {
            DateTime desde = baseDate;
            DateTime hasta = baseDate;

            pacienteActual = PacienteBO.paciente_obtenerPorId(id);

            var listaCitas = CitaBO.cita_listarPorPacienteFechas(pacienteActual.idPaciente,desde.ToString("yyyy-MM-dd"),hasta.ToString("yyyy-MM-dd"));
            foreach (var cita in listaCitas)
            {
                var odontologo = OdontologoBO.odontologo_obtenerPorId(cita.odontologo.idOdontologo);
                var consultorioOd = SalaBO.sala_obtenerPorId(odontologo.consultorio.idSala);
                var consultorio = new CitaWS.sala
                {
                    idSala = odontologo.consultorio.idSala,
                    idSalaSpecified = true,
                    numero = consultorioOd.numero,
                };
                var od = new CitaWS.odontologo
                {
                    idOdontologo = odontologo.idOdontologo,
                    idOdontologoSpecified = true,
                    nombre = odontologo.nombre,
                    apellidos = odontologo.apellidos,
                    consultorio = consultorio
                };
                cita.odontologo = od;
                cita.odontologo.nombre += (" " + cita.odontologo.apellidos);
            }
            gvCitas.DataSource = listaCitas;
            gvCitas.DataBind();
        }

        protected void btnEliminarSeleccion_Click(object sender, EventArgs e)
        {
            List<int> idsCitasCancelar = new List<int>();
            foreach (GridViewRow fila in gvCitas.Rows)
            {
                if (fila.RowType != DataControlRowType.DataRow) continue;
                var chk = (CheckBox)fila.FindControl("chkSeleccionar");
                if (chk != null && chk.Checked)
                {
                    int idCita = (int)gvCitas.DataKeys[fila.RowIndex].Value;
                    idsCitasCancelar.Add(idCita);
                }
            }
            if (idsCitasCancelar.Count == 0)
            {
                pnlError.Controls.Clear();
                pnlError.Controls.Add(new Literal
                {
                    Text = "Seleccione al menos una cita en estado <strong>Reservada</strong>."
                });
                pnlError.Visible = true;
                return;
            }

            foreach (int idCita in idsCitasCancelar)
            {

                var cita = CitaBO.cita_obtenerPorId(idCita);
                cita.estado = CitaWS.estadoCita.CANCELADA;
                CitaBO.cita_modificar(cita);
            }
            if (int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPa))
            {
                DateTime fechaBase = calFiltro.SelectedDate == DateTime.MinValue
                                        ? DateTime.Today
                                        : calFiltro.SelectedDate;

                CargarCitas(idPa, fechaBase);
            }
        }
        

        protected void calFiltro_SelectionChanged(object sender, EventArgs e)
        {
            if (Session["idPacienteSeleccionado"] != null &&
                int.TryParse(Session["idPacienteSeleccionado"].ToString(), out int idPaciente))
            {
                DateTime baseDate = calFiltro.SelectedDate;
                CargarCitas(idPaciente, baseDate);
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
            Response.Redirect("reservaCitaPorRecepcionista.aspx", false);  // ← false evita ThreadAbortException
            Context.ApplicationInstance.CompleteRequest();
        }

        private void CargarDatosParaPDF(int idPaciente)
        {
            try
            {
                pacienteActual = PacienteBO.paciente_obtenerPorId(idPaciente);

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

                    
                    documento.Add(new Paragraph("CITAS ATENDIDAS", fontSubtitulo));
                    documento.Add(new Paragraph(" ", fontNormal));

                  
                    var citasAtendidas = CargarCitasAtendidasPaciente(pacienteActual.idPaciente);

                    if (citasAtendidas != null && citasAtendidas.Count > 0)
                    {
                        PdfPTable tablaCitas = new PdfPTable(4);
                        tablaCitas.WidthPercentage = 100;
                        tablaCitas.SpacingAfter = 20f;

                        float[] anchosCitas = { 1.5f, 1f, 2f, 1.5f };
                        tablaCitas.SetWidths(anchosCitas);

                        AgregarCeldaEncabezado(tablaCitas, "Fecha", fontNormalBold);
                        AgregarCeldaEncabezado(tablaCitas, "Hora", fontNormalBold);
                        AgregarCeldaEncabezado(tablaCitas, "Odontólogo", fontNormalBold);
                        AgregarCeldaEncabezado(tablaCitas, "Especialidad", fontNormalBold);

                        foreach (var cita in citasAtendidas)
                        {
                            try
                            {
                                var odonto = OdontologoBO.odontologo_obtenerPorId(cita.odontologo.idOdontologo);
                                var especialidad = EspecialidadBO.especialidad_obtenerPorId(odonto.especialidad.idEspecialidad);

                                string fechaTexto = cita.fecha;
                                string horaTexto = cita.horaInicio;
                                string odontologoTexto = $"{odonto.nombre} {odonto.apellidos}";
                                string especialidadTexto = especialidad.nombre;

                                AgregarCeldaCita(tablaCitas, fechaTexto, fontNormal);
                                AgregarCeldaCita(tablaCitas, horaTexto, fontNormal);
                                AgregarCeldaCita(tablaCitas, odontologoTexto, fontNormal);
                                AgregarCeldaCita(tablaCitas, especialidadTexto, fontNormal);
                            }
                            catch (Exception ex)
                            {
                                System.Diagnostics.Debug.WriteLine($"Error al procesar cita {cita.idCita}: " + ex.Message);
                                
                                AgregarCeldaCita(tablaCitas, cita.fecha, fontNormal);
                                AgregarCeldaCita(tablaCitas, cita.horaInicio, fontNormal);
                                AgregarCeldaCita(tablaCitas, "N/D", fontNormal);
                                AgregarCeldaCita(tablaCitas, "N/D", fontNormal);
                            }
                        }

                        documento.Add(tablaCitas);
                    }
                    else
                    {
                        documento.Add(new Paragraph("No hay citas reservadas para este paciente.", fontNormal));
                        documento.Add(new Paragraph(" ", fontNormal));
                    }

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

        private BindingList<CitaWS.cita> CargarCitasAtendidasPaciente(int idPaciente)
        {
            try
            {
                var todasLasCitas = CitaBO.cita_listarPorPaciente(idPaciente);

                if (todasLasCitas == null)
                {
                    return new BindingList<CitaWS.cita>();
                }

                // filtrar solo citas atendidas
                var citasReservadas = new BindingList<CitaWS.cita>();
                foreach (var cita in todasLasCitas)
                {
                    if (cita.estado == CitaWS.estadoCita.ATENDIDA)
                    {
                        citasReservadas.Add(cita);
                    }
                }

                return citasReservadas;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("Error al cargar citas reservadas: " + ex.Message);
                return new BindingList<CitaWS.cita>();
            }
        }

       
        private void AgregarCeldaEncabezado(PdfPTable tabla, string texto, Font font)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto ?? "", font));
            celda.BackgroundColor = BaseColor.LIGHT_GRAY;
            celda.HorizontalAlignment = Element.ALIGN_CENTER;
            celda.Padding = 5f;
            celda.Border = Rectangle.BOX;
            tabla.AddCell(celda);
        }

        
        private void AgregarCeldaCita(PdfPTable tabla, string texto, Font font)
        {
            PdfPCell celda = new PdfPCell(new Phrase(texto ?? "", font));
            celda.HorizontalAlignment = Element.ALIGN_LEFT;
            celda.Padding = 5f;
            celda.Border = Rectangle.BOX;
            tabla.AddCell(celda);
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