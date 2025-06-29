using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.ComprobanteWS;

namespace OdontoSysBusiness
{
    public class ComprobanteBO
    {
        private ComprobanteWAClient comprobanteWAClient;

        public ComprobanteBO()
        {
            this.comprobanteWAClient = new ComprobanteWAClient();
        }

        public int comprobante_insertar(comprobante comprobante)
        {
            return this.comprobanteWAClient.comprobante_insertar(comprobante);
        }

        public int comprobante_modificar(comprobante comprobante)
        {
            return this.comprobanteWAClient.comprobante_modifica(comprobante);
        }

        public int comprobante_eliminar(comprobante comprobante)
        {
            return this.comprobanteWAClient.comprobante_eliminar(comprobante);
        }

        public comprobante comprobante_obtenerPorId(int id)
        {
            return this.comprobanteWAClient.comprobante_obtenerPorId(id);
        }

        public BindingList<comprobante> comprobante_listarTodos()
        {
            comprobante[] lista = this.comprobanteWAClient.comprobante_listarTodos();
            return new BindingList<comprobante>(lista ?? Array.Empty<comprobante>());
        }

        public int comprobante_actualizarTotal(int idCita)
        {
            return this.comprobanteWAClient.comprobante_actualizarTotal(idCita);
        }
    }
}
