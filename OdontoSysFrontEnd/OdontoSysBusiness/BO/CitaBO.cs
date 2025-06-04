using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.citaWS;

namespace OdontoSysBusiness.BO
{
    public class CitaBO
    {
        private CitasClient citasClienteSOAP;

        public CitaBO() 
        {
            this.citasClienteSOAP = new CitasClient();
        }

        public int InsertCita(cita cita)
        {
            return this.citasClienteSOAP.insertCita(cita);
        }

        public int ModificarCita(cita cita)
        {
            return this.citasClienteSOAP.modificarCita(cita);
        }

        public int EliminarCita(cita cita)
        {
            return this.citasClienteSOAP.eliminarCita(cita);
        }

        public BindingList<cita>ListarPorOdontologo(odontologo odontologo, string fechaInicio, string fechaFin)
        {
            cita[] lista = citasClienteSOAP.od_listarPorOdontologo(odontologo, fechaInicio, fechaFin);
            return new BindingList<cita>(lista);

        }

        public booleanArray[] CalcularDisponibilidad(cita[] citas, turno[] turnos, string fechaInicio)
        { 
            return this.citasClienteSOAP.calcularDisponibilidad(citas, turnos, fechaInicio);
        }
    }
}
