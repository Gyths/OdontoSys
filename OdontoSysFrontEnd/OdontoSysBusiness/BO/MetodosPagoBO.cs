using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.metodospagoWS;

namespace OdontoSysBusiness.BO
{
    public class MetodosPagoBO
    {
        private MetodosPagoClient metodosPagoClienteSOAP;

        public MetodosPagoBO()
        {
            this.metodosPagoClienteSOAP = new MetodosPagoClient();
        }

        public int InsertarMetodoPago(metodoPago metodoPago)
        {
            return this.metodosPagoClienteSOAP.InsertarMetodoPago(metodoPago);
        }

        public int ModificarMetodoPago(metodoPago metodoPago)
        {
            return this.metodosPagoClienteSOAP.ModificarMetodoPago(metodoPago);
        }

        public int EliminarMetodoPago(metodoPago metodoPago)
        {
            return this.metodosPagoClienteSOAP.EliminarMetodoPago(metodoPago);
        }

        public BindingList<metodoPago> ListarMetodoPago()
        {
            metodoPago[] lista = this.metodosPagoClienteSOAP.ListarMetodosPago();
            return new BindingList<metodoPago>(lista);
        }
    }
}
