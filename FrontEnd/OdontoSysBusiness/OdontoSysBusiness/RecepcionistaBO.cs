using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.RecepcionistaWS;

namespace OdontoSysBusiness
{
    public class RecepcionistaBO
    {
        private RecepcionistaWAClient recepcionistaWAClient;

        public RecepcionistaBO()
        {
            this.recepcionistaWAClient = new RecepcionistaWAClient();
        }

        public int recepcionista_insertar(recepcionista recepcionista)
        {
            return this.recepcionistaWAClient.recepcionista_insertar(recepcionista);
        }

        public int recepcionista_modificar(recepcionista recepcionista)
        {
            return this.recepcionistaWAClient.recepcionista_modificar(recepcionista);
        }

        public int recepcionista_eliminar(recepcionista recepcionista)
        {
            return this.recepcionistaWAClient.recepcionista_eliminar(recepcionista);
        }

        public recepcionista recepcionista_obtenerPorId(int id)
        {
            return this.recepcionistaWAClient.recepcionista_obtenerPorId(id);
        }

        public BindingList<recepcionista> recepcionista_listarTodos()
        {
            recepcionista[] lista = this.recepcionistaWAClient.recepcionista_listarTodos();
            return new BindingList<recepcionista>(lista);
        }

        public recepcionista recepcionista_obtenerPorUsuarioContrasenha(string nombreUsuario, string contrasenha)
        {
            return this.recepcionistaWAClient.recepcionista_obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
        }
    }
}