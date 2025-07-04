﻿using System;
using System.ComponentModel;
using OdontoSysWebApplication.TratamientoWS;

namespace OdontoSysWebApplication.OdontoSysBusiness
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
            return new BindingList<tratamiento>(lista ?? Array.Empty<tratamiento>());
        }

         public BindingList<tratamiento> tratamiento_listarPorEspecilidad(especialidad especialidad)
        {
            tratamiento[] lista = this.tratamientoWAClient.tratamiento_listarPorEspecilidad(especialidad);
            return new BindingList<tratamiento>(lista ?? Array.Empty<tratamiento>());
        }
    }
}