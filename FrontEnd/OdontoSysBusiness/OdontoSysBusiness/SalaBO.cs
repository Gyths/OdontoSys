using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.SalaWS;

namespace OdontoSysBusiness
{
    public class SalaBO
    {
        private SalaWAClient salaWAClient;

        public SalaBO()
        {
            this.salaWAClient = new SalaWAClient();
        }

        public int sala_insertar(sala sala)
        {
            return this.salaWAClient.sala_insertar(sala);
        }

        public int sala_modificar(sala sala)
        {
            return this.salaWAClient.sala_modificar(sala);
        }

        public int sala_eliminar(sala sala)
        {
            return this.salaWAClient.sala_eliminar(sala);
        }

        public sala sala_obtenerPorId(int id)
        {
            return this.salaWAClient.sala_obtenerPorId(id);
        }

        public BindingList<sala> sala_listarTodos()
        {
            sala[] lista = this.salaWAClient.sala_listarTodos();
            return new BindingList<sala>(lista);
        }
    }
}