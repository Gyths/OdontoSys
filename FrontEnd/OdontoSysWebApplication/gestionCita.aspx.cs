using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysBusiness.CitaWS;
using OdontoSysBusiness.EspecialidadWS;
using OdontoSysBusiness.OdontologoWS;
using OdontoSysBusiness.SalaWS;
using OdontoSysBusiness.ValoracionWS;

namespace OdontoSysWebApplication
{
    public partial class gestionCita : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int idCita))
                {
                    var clienteCita = new CitaWAClient();
                    var cita = clienteCita.cita_obtenerPorId(idCita);
                    if (cita != null)
                    {
                        Session["CitaSeleccionada"] = cita;
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

            var clienteOdontologo = new OdontologoWAClient();
            var odontologo = clienteOdontologo.odontologo_obtenerPorId(cita.odontologo.idOdontologo);
            lblOdontologo.Text = $"{odontologo.nombre} {odontologo.apellidos}";
            var clienteEspecialidad = new EspecialidadWAClient();
            var especialidad = clienteEspecialidad.especialidad_obtenerPorId(odontologo.especialidad.idEspecialidad);
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

            // Obtener sala
            var clienteSala = new SalaWAClient();
            var sala = clienteSala.sala_obtenerPorId(odontologo.consultorio.idSala);
            lblHabitacion.Text = sala.numero;
            lblPiso.Text = sala.piso.ToString();

            btnCancelarCita.Visible = cita.estado == OdontoSysBusiness.CitaWS.estadoCita.RESERVADA;

            if (cita.estado == OdontoSysBusiness.CitaWS.estadoCita.ATENDIDA)
            {
                panelValoracion.Visible = true;

                if (cita.valoracion.idValoracion > 0)
                {
                    var clienteValoracion = new ValoracionWAClient();
                    var valoracion = clienteValoracion.valoracion_obtenerPorId(cita.valoracion.idValoracion);
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

                var clienteCita = new CitaWAClient();
                clienteCita.cita_modificar(cita);

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

                var clienteValoracion = new ValoracionWAClient();
                int idGenerado = clienteValoracion.valoracion_insertar(nuevaValoracion);

                var valoracionInsertada = new OdontoSysBusiness.CitaWS.valoracion
                {
                    idValoracion = idGenerado,
                    idValoracionSpecified = true
                };

                var clienteCita = new CitaWAClient();
                clienteCita.cita_actualizarFkValoracion(cita, valoracionInsertada);

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
