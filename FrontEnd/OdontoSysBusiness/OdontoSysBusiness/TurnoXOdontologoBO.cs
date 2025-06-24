using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.TurnoXOdontologoWS;

namespace OdontoSysBusiness
{
    public class TurnoXOdontologoBO
    {
        private TurnoXOdontologoWAClient turnoXOdontologoWAClient;

        public TurnoXOdontologoBO()
        {
            this.turnoXOdontologoWAClient = new TurnoXOdontologoWAClient();
        }

        public int turnoXOdontologo_insertar(turnoXOdontologo turnoXOdontologo)
        {
            return this.turnoXOdontologoWAClient.turnoXOdontologo_insertar(turnoXOdontologo);
        }

        public int turnoXOdontologo_modificar(turnoXOdontologo turnoXOdontologo)
        {
            return this.turnoXOdontologoWAClient.turnoXOdontologo_modificar(turnoXOdontologo);
        }

        public int turnoXOdontologo_eliminar(turnoXOdontologo turnoXOdontologo)
        {
            return this.turnoXOdontologoWAClient.turnoXOdontologo_eliminar(turnoXOdontologo);
        }

        public BindingList<turnoXOdontologo> turnoXOdontologo_listarTodos()
        {
            turnoXOdontologo[] lista = this.turnoXOdontologoWAClient.turnoXOdontologo_listarTodos();
            return new BindingList<turnoXOdontologo>(lista ?? Array.Empty<turnoXOdontologo>());
        }

    }
}
