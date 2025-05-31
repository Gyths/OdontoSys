using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel
{
    public class Comprobante
    {
        public int IdComprobante { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime HoraEmision { get; set; }
        public double Total { get; set; }
        public MetodoPago MetodoDePago { get; set; }

        public Comprobante()
        {
            this.MetodoDePago = new MetodoPago();
        }

        public override string ToString()
        {
            return $"Comprobante{{IdComprobante={IdComprobante}, FechaEmision={FechaEmision}, HoraEmision={HoraEmision}, Total={Total}, MetodoDePago={MetodoDePago}}}";
        }
    }
}
