using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel
{
    public class Especialidad
    {
        public int IdEspecialidad { get; set; }
        public string Nombre { get; set; }

        public Especialidad()
        {
        }

        public Especialidad(int idEspecialidad, string nombre)
        {
            this.IdEspecialidad = idEspecialidad;
            this.Nombre = nombre;
        }
    }
}
