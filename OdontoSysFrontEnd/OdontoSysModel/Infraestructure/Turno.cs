using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel.Infraestructure
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraFin { get; set; }
        public DiaSemana DiaSemana { get; set; }

        public Turno()
        {
        }

        public override string ToString()
        {
            return $"Turno{{IdTurno={IdTurno}, HoraInicio={HoraInicio}, HoraFin={HoraFin}, DiaSemana={DiaSemana}}}";
        }
    }
}
