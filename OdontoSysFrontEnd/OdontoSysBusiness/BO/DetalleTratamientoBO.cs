using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.detallestratamientosWS;

namespace OdontoSysBusiness.BO
{
    public class DetalleTratamientoBO
    {
        private DetallesTratamientosClient detallesTratamientosClienteSOAP;

        public DetalleTratamientoBO()
        {
            this.detallesTratamientosClienteSOAP = new DetallesTratamientosClient();
        }

        public int InsertarDetalle(detalleTratamiento detalleTratamiento)
        {
            return this.detallesTratamientosClienteSOAP.InsertarDetalle(detalleTratamiento);
        }

        public int ModificarDetalle(detalleTratamiento detalleTratamiento)
        {
            return this.detallesTratamientosClienteSOAP.ModificarDetalle(detalleTratamiento);
        }

        public int EliminarDetalle(detalleTratamiento detalleTratamiento)
        {
            return this.detallesTratamientosClienteSOAP.EliminarDetalle(detalleTratamiento);
        }
    }
}
