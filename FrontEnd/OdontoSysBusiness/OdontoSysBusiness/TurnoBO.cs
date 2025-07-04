﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdontoSysBusiness.TurnoWS;

namespace OdontoSysBusiness
{
    public class TurnoBO
    {
        private TurnoWAClient turnoWAClient;

        public TurnoBO()
        {
            this.turnoWAClient = new TurnoWAClient();
        }

        public int turno_insertar(turno turno)
        {
            return this.turnoWAClient.turno_insertar(turno);
        }

        public int turno_modificar(turno turno)
        {
            return this.turnoWAClient.turno_modificar(turno);
        }

        public int turno_eliminar(turno turno)
        {
            return this.turnoWAClient.turno_eliminar(turno);
        }

        public turno turno_obtenerPorId(int id)
        {
            return this.turnoWAClient.turno_obtenerPorId(id);
        }

        public BindingList<turno> turno_listarTodos()
        {
            turno[] lista = this.turnoWAClient.turno_listarTodos();
            return new BindingList<turno>(lista ?? Array.Empty<turno>());
        }

        public BindingList<turno> turno_listarPorOdontologo(odontologo odontologo)
        {
            turno[] lista = this.turnoWAClient.turno_listarPorOdontologo(odontologo);
            return new BindingList<turno>(lista ?? Array.Empty<turno>());
        }
    }
}

