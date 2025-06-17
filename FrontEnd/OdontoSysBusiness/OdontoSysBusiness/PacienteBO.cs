using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            return new BindingList<paciente>(lista);
        }

        public paciente paciente_obtenerPorUsuarioContrasenha(string nombreUsuario, string contrasenha)
        {
            return this.pacienteWAClient.paciente_obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
        }
    }
}
