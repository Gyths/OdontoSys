using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysModel.Users;

namespace OdontoSysModel.Services
{
    public class Cita
    {
        public int IdCita { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime HoraInicio { get; set; }
        public double Puntuacion { get; set; }
        public EstadoCita Estado { get; set; }
        public Odontologo Odontologo { get; set; }
        public Paciente Paciente { get; set; }
        public Comprobante Comprobante { get; set; }
        public List<DetalleTratamiento> Tratamientos { get; set; }

        public Cita()
        {
            this.Odontologo = new Odontologo();
            this.Paciente = new Paciente();
            this.Comprobante = new Comprobante();
        }

        public override string ToString()
        {
            return $"Cita{{IdCita={IdCita}, Fecha={Fecha}, HoraInicio={HoraInicio}, Puntuacion={Puntuacion}, Estado={Estado}, Odontologo={Odontologo}, Comprobante={Comprobante}, Tratamientos={Tratamientos}}}";
        }

    }
}
