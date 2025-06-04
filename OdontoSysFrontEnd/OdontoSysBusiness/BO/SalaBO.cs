using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.salaWS;

namespace OdontoSysBusiness.BO
{
    public class SalaBO
    {
        private SalasClient salasClienteSOAP;

        public SalaBO()
        {
            this.salasClienteSOAP = new SalasClient();
        }

        public int InsertarSala(sala sala)
        {
            return this.salasClienteSOAP.InsertarSala(sala);
        }

        public int EliminarSala(sala sala)
        {
            return this.salasClienteSOAP.EliminarSala(sala);
        }
    }
}
