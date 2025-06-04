using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.especialidadWS;

namespace OdontoSysBusiness.BO
{
    public class EspecialidadBO
    {
        private EspecialidadesClient especialidadesClienteSOAP;

        public EspecialidadBO()
        {
            this.especialidadesClienteSOAP = new EspecialidadesClient();
        }

        public int InsertarEspecialidad(especialidad especialidad)
        {
            return this.especialidadesClienteSOAP.InsertarEspecialidad(especialidad);
        }

        public int ModificarEspecialidad(especialidad especialidad)
        {
            return this.especialidadesClienteSOAP.ModificarEspecialidad(especialidad);
        }

        public int EliminarEspecialidad(especialidad especialidad)
        {
            return this.especialidadesClienteSOAP.EliminarEspecialidad(especialidad);
        }

        public BindingList<especialidad> ListarEspecialidades()
        {
            especialidad[] lista = this.especialidadesClienteSOAP.ListarEspecialidades();
            return new BindingList<especialidad>(lista);
        }
    }
}
