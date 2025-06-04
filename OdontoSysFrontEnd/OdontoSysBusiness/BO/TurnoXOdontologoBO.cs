using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.turnoxodontologoWS;

namespace OdontoSysBusiness.BO
{
    public class TurnoXOdontologoBO
    {
        private TurnosXOdontologoClient turnoXOdontologoClienteSOAP;

        public TurnoXOdontologoBO()
        {
            this.turnoXOdontologoClienteSOAP = new TurnosXOdontologoClient();
        }

        public int InsertarTurnoXOdontologo(turnoXOdontologo turnoXOdontologo)
        {
            return this.turnoXOdontologoClienteSOAP.InsertarTurnoXOdontologo(turnoXOdontologo);
        }

        public int EliminarTurnoXOdontologo(turnoXOdontologo turnoXOdontologo)
        {
            return this.turnoXOdontologoClienteSOAP.EliminarTurnoXOdontologo(turnoXOdontologo);
        }

        public BindingList<turnoXOdontologo> TurnoListarPorOdontologo(int idOdontologo)
        {
            turnoXOdontologo[] lista = this.turnoXOdontologoClienteSOAP.TurnoListarPorOdontologo(idOdontologo);
            return new BindingList<turnoXOdontologo>(lista);
        }   
    }
}
