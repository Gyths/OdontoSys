using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using OdontoSysWebApplication.ValoracionWS;

namespace OdontoSysWebApplication.OdontoSysBusiness
{
    public class ValoracionBO
    {
        private ValoracionWAClient valoracionWAClient;

        public ValoracionBO()
        {
            this.valoracionWAClient = new ValoracionWAClient();
        }

        public int valoracion_insertar(valoracion valoracion)
        {
            return this.valoracionWAClient.valoracion_insertar(valoracion);
        }

        public int valoracion_modificar(valoracion valoracion)
        {
            return this.valoracionWAClient.valoracion_modificar(valoracion);
        }

        public int valoracion_eliminar(valoracion valoracion)
        {
            return this.valoracionWAClient.valoracion_eliminar(valoracion);
        }

        public valoracion valoracion_obtenerPorId(int id)
        {
            return this.valoracionWAClient.valoracion_obtenerPorId(id);
        }

        public BindingList<valoracion> valoracion_listarTodos()
        {
            valoracion[] lista = this.valoracionWAClient.valoracion_listarTodos();
            return new BindingList<valoracion>(lista ?? Array.Empty<valoracion>());
        }

        public BindingList<valoracion> valoracion_listarPorOdontologo(odontologo odontologo)
        {
            valoracion[] lista = this.valoracionWAClient.valoracion_listarPorOdontologo(odontologo);
            return new BindingList<valoracion>(lista ?? Array.Empty<valoracion>());
        }

        public BindingList<valoracion> valoracion_listarPorPaciente(paciente paciente)
        {
            valoracion[] lista = this.valoracionWAClient.valoracion_listarPorPaciente(paciente);
            return new BindingList<valoracion>(lista ?? Array.Empty<valoracion>());
        }
    }
}
