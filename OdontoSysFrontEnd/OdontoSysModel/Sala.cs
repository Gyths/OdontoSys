using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel
{
    public class Sala
    {
        public int IdSala { get; set; }
        public string Numero { get; set; }
        public int Piso { get; set; }

        public Sala()
        {
        }

        public override string ToString()
        {
            return $"Sala{{IdSala={IdSala}, Numero={Numero}, Piso={Piso}}}";
        }
    }
}
