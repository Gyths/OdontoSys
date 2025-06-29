using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.OdontologoWS;

namespace OdontoSysBusiness
{
    public class OdontologoBO
    {
        private OdontologoWAClient odontologoWAClient;

        public OdontologoBO()
        {
            this.odontologoWAClient = new OdontologoWAClient();
        }

        public int odontologo_insertar(odontologo odontologo)
        {
            return this.odontologoWAClient.odontologo_insertar(odontologo);
        }

        public int odontologo_modificar(odontologo odontologo)
        {
            return this.odontologoWAClient.odontologo_modificar(odontologo);
        }

        public int odontologo_eliminar(odontologo odontologo)
        {
            return this.odontologoWAClient.odontologo_eliminar(odontologo);
        }

        public odontologo odontologo_obtenerPorId(int id)
        {
            return this.odontologoWAClient.odontologo_obtenerPorId(id);
        }

        public BindingList<odontologo> odontologo_listarTodos()
        {
            odontologo[] lista = this.odontologoWAClient.odontologo_listarTodos();
            return new BindingList<odontologo>(lista ?? Array.Empty<odontologo>());
        }

        public BindingList<odontologo> odontologo_listarPorEspecialidad(int idEspecialidad)
        {
            odontologo[] lista = this.odontologoWAClient.odontologo_listarPorEspecialidad(idEspecialidad);
            return new BindingList<odontologo>(lista ?? Array.Empty<odontologo>());
        }

        public odontologo odontologo_obtenerPorUsuarioContrasenha(string nombreUsuario, string contrasenha)
        {
            return this.odontologoWAClient.odontologo_obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
        }

        public BindingList<odontologo> odontologo_buscarPorNombreApellido(string nombre, string apellido)
        {
            odontologo[] lista = this.odontologoWAClient.odontologo_buscarPorNombreApellido(nombre, apellido);
            return new BindingList<odontologo>(lista ?? Array.Empty<odontologo>());
        }

        public BindingList<odontologo> odontologo_buscarPorNombreApellidoDocumento(string nombre, string apellido, string documento)
        {
            odontologo[] lista = this.odontologoWAClient.odontologo_buscarPorNombreApellidoDocumento(nombre, apellido, documento);
            return new BindingList<odontologo>(lista ?? Array.Empty<odontologo>());
        }

        public odontologo odontologo_obtenerCompletoPorId(int id)
        {
            return this.odontologoWAClient.odontologo_obtenerCompletoPorId(id);
        }

    }
}
