using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using OdontoSysBusiness.TipoDocumentoWS;

namespace OdontoSysBusiness
{
    public class TipoDocumentoBO
    {
        private TipoDocumentoWAClient tipoDocumentoWAClient;

        public TipoDocumentoBO()
        {
            this.tipoDocumentoWAClient = new TipoDocumentoWAClient();
        }

        public int tipoDocumento_insertar(tipoDocumento tipoDocumento)
        {
            return this.tipoDocumentoWAClient.tipoDocumento_insertar(tipoDocumento);
        }

        public int tipoDocumento_modificar(tipoDocumento tipoDocumento)
        {
            return this.tipoDocumentoWAClient.tipoDocumento_modificar(tipoDocumento);
        }

        public int tipoDocumento_eliminar(tipoDocumento tipoDocumento)
        {
            return this.tipoDocumentoWAClient.tipoDocumento_eliminar(tipoDocumento);
        }

        public tipoDocumento tipoDocumento_obtenerPorId(int id)
        {
            return this.tipoDocumentoWAClient.tipoDocumento_obtenerPorId(id);
        }

        public BindingList<tipoDocumento> tipoDocumento_listarTodos()
        {
            tipoDocumento[] lista = this.tipoDocumentoWAClient.tipoDocumento_listarTodos();
            return new BindingList<tipoDocumento>(lista);
        }

    }
}