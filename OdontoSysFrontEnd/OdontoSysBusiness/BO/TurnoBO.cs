using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.turnoWS;

namespace OdontoSysBusiness.BO
{
    public class TurnoBO
    {
        private TurnosClient turnosClienteSOAP;

        public TurnoBO()
        {
            this.turnosClienteSOAP = new TurnosClient();    
        }

        public int InsertarTurno(turno turno)
        {
            return this.turnosClienteSOAP.InsertarTurno(turno);
        }

        public int ModificarTurno(turno turno)
        {
            return this.turnosClienteSOAP.ModificarTurno(turno);
        }

        public int eliminarRecepcionista(turno turno)
        {
            return this.turnosClienteSOAP.EliminarTurno(turno);
        }

        public turno obtenerPorId(int turnoId)
        {
            return this.turnosClienteSOAP.obtenerPorId(turnoId);
        }
    }
}
