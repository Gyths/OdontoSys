using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using OdontoSysBusiness.ValoracionWS;

namespace OdontoSysBusiness
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

        //public BindingList<valoracion> valoracion_listarPorOdontologo(int idOdontologo)
        //{
        //    valoracion[] lista = this.valoracionWAClient.valoracion_listarPorOdontologo(idOdontologo);
        //    return new BindingList<valoracion>(lista ?? Array.Empty<valoracion>());
        //}

        //public BindingList<valoracion> valoracion_listarPorPaciente(int idPaciente)
        //{
        //    valoracion[] lista = this.valoracionWAClient.valoracion_listarPorPaciente(idPaciente);
        //    return new BindingList<valoracion>(lista ?? Array.Empty<valoracion>());
        //}
    }
}
