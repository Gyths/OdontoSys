using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.comprobanteWS;

namespace OdontoSysBusiness.BO
{
    public class ComprobanteBO
    {
        private ComprobantesClient comprobantesClienteSOAP;

        public ComprobanteBO()
        {
            this.comprobantesClienteSOAP = new ComprobantesClient();
        }

        public int InsertComprobante(comprobante comprobante)
        {
            return this.comprobantesClienteSOAP.InsertComprobante(comprobante);
        }

        public int EliminarComprobante(comprobante comprobante)
        {
            return this.comprobantesClienteSOAP.EliminarComprobante(comprobante);
        }

        public BindingList<comprobante> ListarComprobante()
        {
            comprobante[] lista = this.comprobantesClienteSOAP.ListarComprobantes();
            return new BindingList<comprobante>(lista);
        }
    }
}
