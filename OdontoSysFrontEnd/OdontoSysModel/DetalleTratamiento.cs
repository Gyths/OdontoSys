using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel
{
    public class DetalleTratamiento
    {
        public int IdCita { get; set; }
        public Tratamiento Tratamiento { get; set; }
        public int Cantidad { get; set; }
        public double Subtotal { get; set; }

        public DetalleTratamiento()
        {
            this.Tratamiento = new Tratamiento();
        }

        public override string ToString()
        {
            return $"DetalleTratamiento{{IdCita={IdCita}, Tratamiento={Tratamiento}, Cantidad={Cantidad}, Subtotal={Subtotal}}}";
        }
    }
}
