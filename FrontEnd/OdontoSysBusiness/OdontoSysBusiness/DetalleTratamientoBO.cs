using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.DetalleTratamientoWS;

namespace OdontoSysBusiness
{
    public class DetalleTratamientoBO
    {
        private DetalleTratamientoWAClient detalleTratamientoWAClient;

        public DetalleTratamientoBO()
        {
            this.detalleTratamientoWAClient = new DetalleTratamientoWAClient();
        }

        public int detalleTratamiento_insertar(detalleTratamiento detalle)
        {
            return this.detalleTratamientoWAClient.detalleTratamiento_insertar(detalle);
        }

        public int detalleTratamiento_modificar(detalleTratamiento detalle)
        {
            return this.detalleTratamientoWAClient.detalleTratamiento_modificar(detalle);
        }

        public int detalleTratamiento_eliminar(detalleTratamiento detalle)
        {
            return this.detalleTratamientoWAClient.detalleTratamiento_eliminar(detalle);
        }

        public detalleTratamiento detalleTratamiento_obtenerPorId(int id)
        {
            return this.detalleTratamientoWAClient.detalleTratamiento_obtenerPorId(id);
        }

        public BindingList<detalleTratamiento> detalleTratamiento_listarTodos()
        {
            detalleTratamiento[] lista = this.detalleTratamientoWAClient.detalleTratamiento_listarTodos();
            return new BindingList<detalleTratamiento>(lista);
        }

        public BindingList<detalleTratamiento> detalleTratamiento_listarPorCita(cita cita)
        {
            detalleTratamiento[] lista = this.detalleTratamientoWAClient.detalleTratamiento_listarPorCita(cita);
            return new BindingList<detalleTratamiento>(lista);
        }
    }
}