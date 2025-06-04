using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.odontologoWS;

namespace OdontoSysBusiness.BO
{
    public class OdontologoBO
    {
        private OdontologosClient odontologosClienteSOAP;

        public OdontologoBO()
        {
            this.odontologosClienteSOAP = new OdontologosClient();
        }

        public int insertarOdontologo(odontologo odontologo)
        {
            return this.odontologosClienteSOAP.insertarOdontologo(odontologo);
        }

        public int modificarOdontologo(odontologo odontologo)
        {
            return this.odontologosClienteSOAP.modificarOdontologo(odontologo);
        }

        public int eliminarOdontologo(odontologo odontologo)
        {
            return this.odontologosClienteSOAP.eliminarOdontologo(odontologo);
        }

        public odontologo obtenerPorId(int odontologoId)
        {
            return this.odontologosClienteSOAP.od_obtenerPorID(odontologoId);
        }

        public odontologo buscarPorUsuario(string odontologoUsuario)
        {
            return this.odontologosClienteSOAP.od_buscarPorUsuario(odontologoUsuario);
        }

        public BindingList<odontologo> listarPorEspecialidad(especialidad especialidad)
        {
            odontologo[] lista = this.odontologosClienteSOAP.listarPorEspecialidad(especialidad);
            return new BindingList<odontologo>(lista);
        }

        public BindingList<odontologo> listarOdontologos()
        {
            odontologo[] lista = this.odontologosClienteSOAP.od_listarOdontologos();
            return new BindingList<odontologo>(lista);
        }
    }
}
