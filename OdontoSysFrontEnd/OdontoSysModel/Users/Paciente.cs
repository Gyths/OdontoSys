using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysModel.Services;

namespace OdontoSysModel.Users
{
    public class Paciente : Persona
    {
        public int IdPaciente { get; set; }
        public List<Cita> Citas { get; set; }

        public Paciente()
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
