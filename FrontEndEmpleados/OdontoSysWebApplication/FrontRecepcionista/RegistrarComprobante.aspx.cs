using System;
using System.Globalization;
using System.Web.UI;
using OdontoSysWebApplication.CitaWS;

namespace OdontoSysWebApplication
{
    public partial class RegistrarComprobante : System.Web.UI.Page
    {
        private CitaWAClient clienteCita = new CitaWAClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["idCita"] == null)
                {
                    Response.Redirect("ListarCitas.aspx");
                    return;
                }

                DateTime ahora = DateTime.Now;
                txtFechaEmision.Text = ahora.ToString("yyyy-MM-dd");
                txtHoraEmision.Text = ahora.ToString("HH:mm:ss");
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;

            try
            {
                int idCita = (int)Session["idCita"];

                double total = double.Parse(txtTotal.Text.Trim(), CultureInfo.InvariantCulture);
                string metodoPago = ddlMetodoPago.SelectedValue;

                if (string.IsNullOrWhiteSpace(metodoPago))
                {
                    lblMensaje.Text = "❌ Seleccione un método de pago.";
                    lblMensaje.CssClass = "text-danger";
                    return;
                }

                DateTime fechaEmision = DateTime.Now;

                var comprobante = new ComprobanteWS.comprobante();

                comprobante.total = total;

                var metPago = new ComprobanteWS.metodoPago();
                if(metodoPago == "EFECTIVO")
                {
                    metPago.idMetodoPago = 1;
                } else if (metodoPago == "TARJETA"){
                    metPago.idMetodoPago = 2;
                }
                else if(metodoPago == "EFECTIVO"){
                    metPago.idMetodoPago = 3;
                }
                else if (metodoPago == "YAPE")
                {
                    metPago.idMetodoPago = 4;
                }
                else if (metodoPago == "PLIN")
                {
                    metPago.idMetodoPago = 5;
                }
                comprobante.metodoDePago = metPago;

                var clienteComprobante = new ComprobanteWS.ComprobanteWAClient();
                clienteComprobante.comprobante_insertar(comprobante);

                lblMensaje.Text = "✅ Comprobante registrado correctamente.";
                lblMensaje.CssClass = "text-success";
                pnlFormulario.Disabled = true;

                // Redirigir después de 3 segundos (opcional)
                 Response.AddHeader("REFRESH", "3;URL=ListarCitas.aspx");
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error: " + ex.Message;
                lblMensaje.CssClass = "text-danger";
            }
        }
    }
}
