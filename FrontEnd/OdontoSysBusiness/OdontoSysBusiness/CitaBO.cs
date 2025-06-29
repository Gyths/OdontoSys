using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.CitaWS;

namespace OdontoSysBusiness
{
    public class CitaBO
    {
        private CitaWAClient citaWAClient;

        public CitaBO()
        {
            this.citaWAClient = new CitaWAClient();
        }

        public int cita_insertar(cita cita)
        {
            return this.citaWAClient.cita_insertar(cita);
        }

        public int cita_modificar(cita cita)
        {
            return this.citaWAClient.cita_modificar(cita);
        }

        public int cita_eliminar(cita cita)
        {
            return this.citaWAClient.cita_eliminar(cita);
        }

        public cita cita_obtenerPorId(int id)
        {
            return this.citaWAClient.cita_obtenerPorId(id);
        }

        public BindingList<cita> cita_listarTodos()
        {
            cita[] lista = this.citaWAClient.cita_listarTodos();
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorOdontologoFechas(int idOdontologo, string fechaInicio, string fechaFin)
        {
            cita[] lista = this.citaWAClient.cita_listarPorOdontologoFechas(idOdontologo, fechaInicio, fechaFin);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorPacienteFechas(int idPaciente, string fechaInicio, string fechaFin)
        {
            cita[] lista = this.citaWAClient.cita_listarPorPacienteFechas(idPaciente, fechaInicio, fechaFin);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorOdontologo(int idOdontologo)
        {
            cita[] lista = this.citaWAClient.cita_listarPorOdontologo(idOdontologo);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorPaciente(int idPaciente)
        {
            cita[] lista = this.citaWAClient.cita_listarPorPaciente(idPaciente);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

//        public BindingList<cita> cita_listarPorRecepcionista(recepcionista recepcionista)
//        {
//            cita[] lista = this.citaWAClient.cita_listarPorRecepcionista(recepcionista);
//            return new BindingList<cita>(lista);
//        }

//       public int cita_actualizarFkValoracion(cita cita, valoracion valoracion)
//        {
//            return this.citaWAClient.cita_actualizarFkValoracion(cita, valoracion);
//        }

//        public int cita_actualizarFkComprobante(cita cita, comprobante comprobante)
//        {
//            return this.citaWAClient.cita_actualizarFkComprobante(cita, comprobante);
//        }

//        public int cita_actualizarEstado(cita cita)
//        {
//            return this.citaWAClient.cita_actualizarEstado(cita);
//        }

    }
}
