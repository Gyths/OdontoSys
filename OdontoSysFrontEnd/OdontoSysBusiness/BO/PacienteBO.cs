using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.pacienteWS;

namespace OdontoSysBusiness.BO
{
    public class PacienteBO
    {
        private PacientesClient pacientesClienteSOAP;

        public PacienteBO()
        {
            this.pacientesClienteSOAP = new PacientesClient();
        }

        public int insertarPaciente(paciente paciente)
        {
            return this.pacientesClienteSOAP.insertarPaciente(paciente);
        }

        public int modificarPaciente(paciente paciente)
        {
            return this.pacientesClienteSOAP.modificarPaciente(paciente);
        }

        public int eliminarPaciente(paciente paciente)
        {
            return this.pacientesClienteSOAP.eliminarPaciente(paciente);
        }

        public paciente obtenerPorId(int recepcionistaId)
        {
            return this.pacientesClienteSOAP.pa_obtenerPorID(recepcionistaId);
        }

        public paciente buscarPorUsuario(string nombreUsuario)
        {
            return this.pacientesClienteSOAP.pa_buscarPorUsuario(nombreUsuario);
        }

        public BindingList<paciente> listarRecepcionista()
        {
            paciente[] lista = this.pacientesClienteSOAP.listarPacientes();
            return new BindingList<paciente>(lista);
        }
    }
}
