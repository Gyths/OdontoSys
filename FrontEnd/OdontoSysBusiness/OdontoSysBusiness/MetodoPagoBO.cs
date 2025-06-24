using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.MetodoPagoWS;

namespace OdontoSysBusiness
{
    public class MetodoPagoBO
    {
        private MetodoPagoWAClient metodosPagoWAClient;

        public MetodoPagoBO()
        {
            this.metodosPagoWAClient = new MetodoPagoWAClient();
        }

        public int metodoPago_insertar(metodoPago metodo)
        {
            return this.metodosPagoWAClient.metodoPago_insertar(metodo);
        }

        public int metodoPago_modificar(metodoPago metodo)
        {
            return this.metodosPagoWAClient.metodoPago_modificar(metodo);
        }

        public int metodoPago_eliminar(metodoPago metodo)
        {
            return this.metodosPagoWAClient.metodoPago_eliminar(metodo);
        }

        public metodoPago metodoPago_obtenerPorId(int id)
        {
            return this.metodosPagoWAClient.metodoPago_obtenerPorId(id);
        }

        public BindingList<metodoPago> metodoPago_listarTodos()
        {
            metodoPago[] lista = this.metodosPagoWAClient.metodoPago_listarTodos();
            return new BindingList<metodoPago>(lista ?? Array.Empty<metodoPago>());
        }
    }
}
