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

        public BindingList<cita> cita_listarPorOdontologoFechas(odontologo odontologo, string fechaInicio, string fechaFin)
        {
            cita[] lista = this.citaWAClient.cita_listarPorOdontologoFechas(odontologo, fechaInicio, fechaFin);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorPacienteFechas(paciente paciente, string fechaInicio, string fechaFin)
        {
            cita[] lista = this.citaWAClient.cita_listarPorPacienteFechas(paciente, fechaInicio, fechaFin);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorOdontologo(odontologo odontologo)
        {
            cita[] lista = this.citaWAClient.cita_listarPorOdontologo(odontologo);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorPaciente(paciente paciente)
        {
            cita[] lista = this.citaWAClient.cita_listarPorPaciente(paciente);
            return new BindingList<cita>(lista ?? Array.Empty<cita>());
        }

        public BindingList<cita> cita_listarPorRecepcionista(recepcionista recepcionista)
        {
            cita[] lista = this.citaWAClient.cita_listarPorRecepcionista(recepcionista);
            return new BindingList<cita>(lista);
        }

        public int cita_actualizarFkValoracion(cita cita, valoracion valoracion)
        {
            return this.citaWAClient.cita_actualizarFkValoracion(cita, valoracion);
        }

        public int cita_actualizarFkComprobante(cita cita, comprobante comprobante)
        {
            return this.citaWAClient.cita_actualizarFkComprobante(cita, comprobante);
        }

        public int cita_actualizarEstado(cita cita)
        {
            return this.citaWAClient.cita_actualizarEstado(cita);
        }

    }
}
