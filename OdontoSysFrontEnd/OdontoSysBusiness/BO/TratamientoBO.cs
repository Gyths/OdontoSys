using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.tratamientoWS;

namespace OdontoSysBusiness.BO
{
    public class TratamientoBO
    {
        private TratamientosClient tratamientosClienteSOAP;

        public TratamientoBO()
        {
            this.tratamientosClienteSOAP = new TratamientosClient();    
        }

        public int InsertarTratamiento(tratamiento tratamiento)
        {
            return this.tratamientosClienteSOAP.InsertarTratamiento(tratamiento);
        }

        public int ModificarTratamiento(tratamiento tratamiento)
        {
            return this.tratamientosClienteSOAP.ModificarTratamiento(tratamiento);
        }

        public int EliminarTratamiento(tratamiento tratamiento)
        {
            return this.tratamientosClienteSOAP.EliminarTratamiento(tratamiento);
        }

        public BindingList<tratamiento> ListarTratamientos()
        {
            tratamiento[] lista = this.tratamientosClienteSOAP.ListarTratamientos();
            return new BindingList<tratamiento>(lista);
        }
    }
}
