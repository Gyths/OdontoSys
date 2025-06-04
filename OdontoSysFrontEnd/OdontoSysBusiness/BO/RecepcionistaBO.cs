using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.recepcionistaWS;

namespace OdontoSysBusiness.BO
{
    public class RecepcionistaBO
    {
        private RecepcionistasClient recepcionistaClienteSOAP;

        public RecepcionistaBO()
        {
            this.recepcionistaClienteSOAP = new RecepcionistasClient();
        }

        public int insertarRecepcionista(recepcionista recepcionista)
        {
            return this.recepcionistaClienteSOAP.insertarRecepcionista(recepcionista);
        }

        public int modificarRecepcionista(recepcionista recepcionista)
        {
            return this.recepcionistaClienteSOAP.modificarRecepcionista(recepcionista);
        }

        public int eliminarRecepcionista(recepcionista recepcionista)
        {
            return this.recepcionistaClienteSOAP.eliminarRecepcionista(recepcionista);
        }

        public recepcionista obtenerPorId(int recepcionistaId)
        {
            return this.recepcionistaClienteSOAP.obtenerPorID(recepcionistaId);
        }

        public recepcionista buscarPorUsuario(string nombreUsuario)
        {
            return this.recepcionistaClienteSOAP.buscarPorUsuario(nombreUsuario);
        }

        public BindingList<recepcionista> listarRecepcionista()
        {
            recepcionista[] lista = this.recepcionistaClienteSOAP.listarRecepcionista();
            return new BindingList<recepcionista>(lista);
        }
    }
}
