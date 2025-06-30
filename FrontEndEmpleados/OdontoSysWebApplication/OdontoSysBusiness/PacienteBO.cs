using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using OdontoSysWebApplication.PacienteWS;

namespace OdontoSysWebApplication.OdontoSysBusiness
{
    public class PacienteBO
    {
        private PacienteWAClient pacienteWAClient;

        public PacienteBO()
        {
            this.pacienteWAClient = new PacienteWAClient();
        }

        public int paciente_insertar(paciente paciente)
        {
            return this.pacienteWAClient.paciente_insertar(paciente);
        }

        public int paciente_modificar(paciente paciente)
        {
            return this.pacienteWAClient.paciente_modificar(paciente);
        }

        public int paciente_eliminar(paciente paciente)
        {
            return this.pacienteWAClient.paciente_eliminar(paciente);
        }

        public paciente paciente_obtenerPorId(int id)
        {
            return this.pacienteWAClient.paciente_obtenerPorId(id);
        }

        public BindingList<paciente> paciente_listarTodos()
        {
            paciente[] lista = this.pacienteWAClient.paciente_listarTodos();
            return new BindingList<paciente>(lista ?? Array.Empty<paciente>());
        }

        public paciente paciente_obtenerPorUsuarioContrasenha(string nombreUsuario, string contrasenha)
        {
            return this.pacienteWAClient.paciente_obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
        }

        public bool paciente_verificarExistenciaNombreUsuario(string nombreUsuario)
        {
            return this.pacienteWAClient.paciente_verificarExistenciaNombreUsuario(nombreUsuario);
        }

        
        public BindingList<paciente> paciente_buscarPorNombreApellido(string nombre, string apellido){
            paciente[] lista = this.pacienteWAClient.paciente_buscarPorNombreApellido(nombre, apellido);
            return new BindingList<paciente>(lista ?? Array.Empty<paciente>());
        }

        public BindingList<paciente> paciente_buscarPorNombreApellidoDocumento(string nombre, string apellido, string documento){
            paciente[] lista = this.pacienteWAClient.paciente_buscarPorNombreApellidoDocumento(nombre, apellido, documento);
            return new BindingList<paciente>(lista ?? Array.Empty<paciente>());
        }

        public BindingList<paciente> paciente_buscarPorNombreApellidoTelefono(string nombre, string apellido, string telefono){
            paciente[] lista = this.pacienteWAClient.paciente_buscarPorNombreApellidoTelefono(nombre, apellido, telefono);
            return new BindingList<paciente>(lista ?? Array.Empty<paciente>());
        }
}
}
