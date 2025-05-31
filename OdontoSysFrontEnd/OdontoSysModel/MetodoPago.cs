using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel
{
    public class MetodoPago
    {
        public int IdMetodoPago { get; set; }
        public string Nombre { get; set; }

        public MetodoPago()
        {
        }

        public MetodoPago(int idMetodoPago, string nombre)
        {
            this.IdMetodoPago = idMetodoPago;
            this.Nombre = nombre;
        }
    }
}
