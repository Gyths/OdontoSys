using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysModel.Infraestructure;
using OdontoSysModel.Services;

namespace OdontoSysModel.Users
{
    public class Odontologo : Persona
    {
        public int IdOdontologo { get; set; }
        public Especialidad Especialidad { get; set; }
        public double PuntuacionPromedio { get; set; }
        public Sala Consultorio { get; set; }
        public List<Cita> Citas { get; set; }
        public List<Turno> Turnos { get; set; }

        public Odontologo()
        {
            this.Consultorio = new Sala();
            this.Especialidad = new Especialidad();
        }

        public override string ToString()
        {
            string herencia = base.ToString() + Environment.NewLine;
            return herencia + $"Odontologo{{Especialidad={Especialidad}, PuntuacionPromedio={PuntuacionPromedio}, Consultorio={Consultorio}, Citas={Citas}, Turnos={Turnos}}}";
        }
    }
}
