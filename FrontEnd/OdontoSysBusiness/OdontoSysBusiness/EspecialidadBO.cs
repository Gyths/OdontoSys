using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.EspecialidadWS;

namespace OdontoSysBusiness
{
    public class EspecialidadBO
    {
        private EspecialidadWAClient especialidadWAClient;

        public EspecialidadBO()
        {
            this.especialidadWAClient = new EspecialidadWAClient();
        }

        public int especialidad_insertar(especialidad especialidad)
        {
            return this.especialidadWAClient.especialidad_insertar(especialidad);
        }

        public int especialidad_modificar(especialidad especialidad)
        {
            return this.especialidadWAClient.especialidad_modificar(especialidad);
        }

        public int especialidad_eliminar(especialidad especialidad)
        {
            return this.especialidadWAClient.especialidad_eliminar(especialidad);
        }

        public especialidad especialidad_obtenerPorId(int id)
        {
            return this.especialidadWAClient.especialidad_obtenerPorId(id);
        }

        public BindingList<especialidad> especialidad_listarTodos()
        {
            especialidad[] lista = this.especialidadWAClient.especialidad_listarTodos();
            return new BindingList<especialidad>(lista ?? Array.Empty<especialidad>());
        }
    }
}
