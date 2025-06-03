using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel.Users
{
    public class Persona
    {
        private string contrasenha;
        private string nombreUsuario;
        private string correo;
        private string telefono;
        private string nombre;
        private string apellidos;
        private string dni;
        private TipoUsuario tipoUsuario;

        public Persona()
        {
        }

        public string Contrasenha { get => contrasenha; set => contrasenha = value; }
        public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellidos { get => apellidos; set => apellidos = value; }
        public string Dni { get => dni; set => dni = value; }
        public TipoUsuario TipoUsuario { get => tipoUsuario; set => tipoUsuario = value; }

        public override string ToString()
        {
            return $"Persona{{Contrasenha={Contrasenha}, NombreUsuario={NombreUsuario}, Correo={Correo}, Telefono={Telefono}, Nombre={Nombre}, Apellidos={Apellidos}, DNI={Dni}, TipoUsuario={TipoUsuario}}}";
        }
    }
}
