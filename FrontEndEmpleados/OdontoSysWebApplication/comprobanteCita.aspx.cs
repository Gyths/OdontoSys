using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OdontoSysWebAppliation.OdontoSysBusiness;
using OdontoSysWebApplication.OdontoSysBusiness;

namespace OdontoSysWebApplication
{
    public partial class comprobanteCita : System.Web.UI.Page
    {
        private int idCita => int.Parse(Request.QueryString["idCita"]);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComprobanteOCrearWizard();
            }
        }

        protected void CargarComprobanteOCrearWizard()
        {
            var clienteCita = new CitaBO();
            var cita = clienteCita.cita_obtenerPorId(idCita);
            if (cita == null)
            {
                lblMensaje.Text = "No se encontró la cita.";
                lblMensaje.CssClass = "text-danger";
                return;
            }
            if (cita.estado == CitaWS.estadoCita.ATENDIDA)
            {
                var clienteComprobante = new ComprobanteBO();
                var comp = clienteComprobante.comprobante_obtenerPorId(cita.comprobante.idComprobante);
                lblFecha.Text = comp.fechaEmision.ToString();
                lblHora.Text = comp.horaEmision.ToString();
                lblTotal.Text = comp.total.ToString("C");
                var clienteMetodoPago = new MetodoPagoBO();
                var metodoPago = clienteMetodoPago.metodoPago_obtenerPorId(comp.metodoDePago.idMetodoPago);
                lblMetodoPago.Text = metodoPago.nombre.ToString();
                pnlDetalle.Visible = true;
                btnGenerar.Visible = false;
            }
            else
            {
                CargarMetodosPago();
                btnGenerar.Visible = false;
                pnlDetalle.Visible = false;
            }
        }

        private void CargarMetodosPago()
        {
            try
            {
                var cliMP = new MetodoPagoBO();
                var metodos = cliMP.metodoPago_listarTodos();

                ddlMetodoPago.DataSource = metodos;
                ddlMetodoPago.DataTextField = "nombre";
                ddlMetodoPago.DataValueField = "idMetodoPago";
                ddlMetodoPago.DataBind();
            }
            catch (Exception ex)
            {
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

                var clienteComprobante = new ComprobanteBO();
                int idComprobante = clienteComprobante.comprobante_insertar(comprobante);   // devuelve PK

                var clienteCita = new CitaBO();
                var cita = clienteCita.cita_obtenerPorId(idCita);
                cita.comprobante = new CitaWS.comprobante 
                { 
                    idComprobante = idComprobante, 
                    idComprobanteSpecified = true
                };
                cita.estado = CitaWS.estadoCita.ATENDIDA;
                clienteCita.cita_actualizarEstado(cita);
                clienteCita.cita_actualizarFkComprobante(cita, cita.comprobante);
                var citaComprobante = new ComprobanteWS.cita
                {
                    idCita = cita.idCita,
                    idCitaSpecified = true
                };
                clienteComprobante.comprobante_actualizarTotal(citaComprobante);
                lblMensaje.Text = "Comprobante generado correctamente.";
                lblMensaje.CssClass = "text-success";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "No se pudo generar el comprobante.";
                lblMensaje.CssClass = "text-danger";
                // log(ex);
            }

            CargarComprobanteOCrearWizard();
        }
    }



}