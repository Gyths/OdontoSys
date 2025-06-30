
﻿using OdontoSysBusiness;
using OdontoSysBusiness.CitaWS;
using OdontoSysBusiness.EspecialidadWS;
using OdontoSysBusiness.OdontologoWS;
using OdontoSysBusiness.SalaWS;
using OdontoSysBusiness.ValoracionWS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OdontoSysWebApplication
{
    public partial class gestionCita : System.Web.UI.Page
    {

        private OdontologoBO odontologoBO;
        private EspecialidadBO especialidadBO;
        private CitaBO citaBO;
        private SalaBO salaBO;
        private ValoracionBO valoracionBO;

        public OdontologoBO OdontologoBO { get => odontologoBO; set => odontologoBO = value; }
        public EspecialidadBO EspecialidadBO { get => especialidadBO; set => especialidadBO = value; }
        public CitaBO CitaBO { get => citaBO; set => citaBO = value; }
        public SalaBO SalaBO { get => salaBO; set => salaBO = value; }
        public ValoracionBO ValoracionBO { get => valoracionBO; set => valoracionBO = value; }

        public gestionCita()
        {
            this.OdontologoBO = new OdontologoBO();
            this.EspecialidadBO = new EspecialidadBO();
            this.CitaBO = new CitaBO();
            this.SalaBO = new SalaBO();
            this.ValoracionBO = new ValoracionBO();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idCita))
                {

                    OdontoSysBusiness.CitaWS.cita citaVariable = this.CitaBO.cita_obtenerCompletoPorId(idCita);
                    if (citaVariable != null)

                    {
                        Session["CitaSeleccionada"] = citaVariable;
                        cargarCita();
                    }
                }
            }
        }

        private void cargarCita()
        {
            var cita = Session["CitaSeleccionada"] as OdontoSysBusiness.CitaWS.cita;
            lblFecha.Text = cita.fecha;
            lblHora.Text = cita.horaInicio;
            lblOdontologo.Text = $"{cita.odontologo.nombre} {cita.odontologo.apellidos}";
            var especialidad = this.EspecialidadBO.especialidad_obtenerPorId(cita.odontologo.especialidad.idEspecialidad);
            lblEspecialidad.Text = especialidad.nombre;

            // Badge por estado
            string claseEstado = "bg-secondary";
            string textoEstado = cita.estado.ToString();

            if (textoEstado == "RESERVADA")
                claseEstado = "bg-warning text-dark";
            if (textoEstado == "ATENDIDA")
                claseEstado = "bg-success";
            if (textoEstado == "CANCELADA")
                claseEstado = "bg-danger";

            estadoCita.InnerText = textoEstado;
            estadoCita.Attributes["class"] = $"badge {claseEstado}";


            var sala = this.SalaBO.sala_obtenerPorId(cita.odontologo.consultorio.idSala);
            lblHabitacion.Text = sala.numero;
            lblPiso.Text = sala.piso.ToString();

            btnCancelarCita.Visible = cita.estado == OdontoSysBusiness.CitaWS.estadoCita.RESERVADA;

            if (cita.estado == OdontoSysBusiness.CitaWS.estadoCita.ATENDIDA)
            {
                panelValoracion.Visible = true;

                if (cita.valoracion.idValoracion > 0)
                {
                    var valoracion = this.ValoracionBO.valoracion_obtenerPorId(cita.valoracion.idValoracion);
                    panelResumenValoracion.Visible = true;
                    lblComentario.Text = valoracion.comentario;
                    lblCalificacion.Text = valoracion.calicicacion.ToString();
                }
                else
                {
                    panelFormularioValoracion.Visible = true;
                }
            }
        }

        private string ToTitleCase(string input)
        {
            return System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
        }

        protected void btnCancelarCita_Click(object sender, EventArgs e)
        {
            if (Session["CitaSeleccionada"] != null)
            {
                var cita = Session["CitaSeleccionada"] as OdontoSysBusiness.CitaWS.cita;
                cita.estado = OdontoSysBusiness.CitaWS.estadoCita.CANCELADA;
                this.CitaBO.cita_modificar(cita);

                // Actualizamos sesión y recargamos
                Session["CitaSeleccionada"] = cita;
                Response.Redirect("gestionCita.aspx?id=" + cita.idCita);
            }
        }

        protected void btnEnviarValoracion_Click(object sender, EventArgs e)
        {
            if (Session["CitaSeleccionada"] != null)
            {
                // Ocultar ambos mensajes antes de validar
                lblErrorComentario.Visible = false;
                lblErrorCalificacion.Visible = false;

                var cita = Session["CitaSeleccionada"] as OdontoSysBusiness.CitaWS.cita;
                string comentario = txtComentario.Text?.Trim() ?? "";
                string calificacionSeleccionada = ddlCalificacion.SelectedValue;

                bool esValido = true;

                // Validación de comentario
                if (string.IsNullOrWhiteSpace(comentario) || comentario.Length > 250)
                {
                    lblErrorComentario.Visible = true;
                    esValido = false;
                }

                // Validación de calificación
                if (string.IsNullOrWhiteSpace(calificacionSeleccionada))
                {
                    lblErrorCalificacion.Visible = true;
                    esValido = false;
                }

                if (!esValido)
                    return;

                var nuevaValoracion = new OdontoSysBusiness.ValoracionWS.valoracion
                {
                    comentario = comentario,
                    calicicacion = int.Parse(calificacionSeleccionada),
                    calicicacionSpecified = true,
                    fechaCalificacion = DateTime.Now.ToString("yyyy-MM-dd")
                };

                cita.valoracion.idValoracion = this.ValoracionBO.valoracion_insertar(nuevaValoracion);

                this.CitaBO.cita_modificar(cita);

                Session["CitaSeleccionada"] = cita;
                Response.Redirect("gestionCita.aspx?id=" + cita.idCita);
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("misCitas.aspx");
        }

        protected void lnkCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            Session["Paciente"] = null;
            Response.Redirect("~/inicioSesion.aspx");
        }
    }
}
