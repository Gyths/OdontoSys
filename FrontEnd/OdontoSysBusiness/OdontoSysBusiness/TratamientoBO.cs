using System.ComponentModel;
using OdontoSysBusiness.TratamientoWS;

namespace OdontoSysBusiness
{
    public class TratamientoBO
    {
        private TratamientoWAClient tratamientoWAClient;

        public TratamientoBO()
        {
            this.tratamientoWAClient = new TratamientoWAClient();
        }

        public int tratamiento_insertar(tratamiento tratamiento)
        {
            return this.tratamientoWAClient.tratamiento_insertar(tratamiento);
        }

        public int tratamiento_modificar(tratamiento tratamiento)
        {
            return this.tratamientoWAClient.tratamiento_modificar(tratamiento);
        }

        public int tratamiento_eliminar(tratamiento tratamiento)
        {
            return this.tratamientoWAClient.tratamiento_eliminar(tratamiento);
        }

        public tratamiento tratamiento_obtenerPorId(int id)
        {
            return this.tratamientoWAClient.tratamiento_obtenerPorId(id);
        }

        public BindingList<tratamiento> tratamiento_listarTodos()
        {
            tratamiento[] lista = this.tratamientoWAClient.tratamiento_listarTodos();
            return new BindingList<tratamiento>(lista);
        }

         public BindingList<tratamiento> tratamiento_listarPorEspecilidad(especialidad especialidad)
        {
            tratamiento[] lista = this.tratamientoWAClient.tratamiento_listarPorEspecilidad(especialidad);
            return new BindingList<tratamiento>(lista);
        }
    }
}