using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdontoSysModel.Users
{
    public class Persona
    {
        protected string Contrasenha { get; set; }
        protected string NombreUsuario { get; set; }
        protected string Correo { get; set; }
        protected string Telefono { get; set; }
        protected string Nombre { get; set; }
        protected string Apellidos { get; set; }
        protected string DNI { get; set; }
        protected TipoUsuario TipoUsuario { get; set; }

        public Persona()
        {
        }

        public string GetContrasenha() => Contrasenha;
        public void SetContrasenha(string contrasenha) => Contrasenha = contrasenha;

        public string GetNombreUsuario() => NombreUsuario;
        public void SetNombreUsuario(string nombreUsuario) => NombreUsuario = nombreUsuario;

        public string GetCorreo() => Correo;
        public void SetCorreo(string correo) => Correo = correo;

        public string GetTelefono() => Telefono;
        public void SetTelefono(string telefono) => Telefono = telefono;

        public string GetNombre() => Nombre;
        public void SetNombre(string nombre) => Nombre = nombre;

        public string GetApellidos() => Apellidos;
        public void SetApellidos(string apellidos) => Apellidos = apellidos;

        public string GetDNI() => DNI;
        public void SetDNI(string dni) => DNI = dni;

        public TipoUsuario GetTipoUsuario() => TipoUsuario;
        public void SetTipoUsuario(TipoUsuario tipoUsuario) => TipoUsuario = tipoUsuario;

        public override string ToString()
        {
            return $"Persona{{Contrasenha={Contrasenha}, NombreUsuario={NombreUsuario}, Correo={Correo}, Telefono={Telefono}, Nombre={Nombre}, Apellidos={Apellidos}, DNI={DNI}, TipoUsuario={TipoUsuario}}}";
        }
    }
}
