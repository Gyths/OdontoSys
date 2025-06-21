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
    public partial class VerComprobante : System.Web.UI.Page
    {
        private ComprobanteBO boComprobante;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string idComprobanteStr = Request.QueryString["idComprobante"];

                if (!string.IsNullOrEmpty(idComprobanteStr) && int.TryParse(idComprobanteStr, out int idComprobante))
                {
                    CargarComprobante(idComprobante);
                }
                else
                {
                    MostrarError();
                }
            }
        }

        private void CargarComprobante(int idComprobante)
        {
            try
            {
                boComprobante = new ComprobanteBO();
                var comprobante = boComprobante.comprobante_obtenerPorId(idComprobante);

                if (comprobante != null)
                {
                    MostrarDatosComprobante(comprobante);
                }
                else
                {
                    MostrarError();
                }
            }
            catch (Exception ex)
            {
                // Log del error 
                MostrarError();
            }
        }

        private void MostrarDatosComprobante(dynamic comprobante)
        {
            try
            {
              
                txtIdComprobante.Text = comprobante.idComprobante?.ToString() ?? "";

                
                if (comprobante.fecha != null)
                {
                    if (DateTime.TryParse(comprobante.fecha.ToString(), out DateTime fecha))
                    {
                        txtFecha.Text = fecha.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        txtFecha.Text = comprobante.fecha.ToString();
                    }
                }

                // Formatear monto total
                if (comprobante.montoTotal != null)
                {
                    if (decimal.TryParse(comprobante.montoTotal.ToString(), out decimal monto))
                    {
                        txtMontoTotal.Text = monto.ToString("S");
                    }
                    else
                    {
                        txtMontoTotal.Text = comprobante.montoTotal.ToString();
                    }
                }

               
                txtTipoComprobante.Text = comprobante.tipoComprobante?.ToString() ?? "";
                txtEstado.Text = comprobante.estado?.ToString() ?? "";
                txtMetodoPago.Text = comprobante.metodoPago?.ToString() ?? "";
                txtObservaciones.Text = comprobante.observaciones?.ToString() ?? "";

               
            }
            catch (Exception ex)
            {
                MostrarError();
            }
        }

        private void MostrarError()
        {
            pnlError.Visible = true;
        }
    }
}