using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel.Services
{
    public class Tratamiento
    {
        public int IdTratamiento { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Costo { get; set; }
        public Especialidad Especialidad { get; set; }

        public Tratamiento()
        {
            this.Especialidad = new Especialidad();
        }

        public override string ToString()
        {
            return $"Tratamiento{{IdTratamiento={IdTratamiento}, Nombre={Nombre}, Descripcion={Descripcion}, Costo={Costo}, Especialidad={Especialidad}}}";
        }
    }
}
