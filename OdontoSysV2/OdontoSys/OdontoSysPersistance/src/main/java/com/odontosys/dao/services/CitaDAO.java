package com.odontosys.dao.services;

import com.odontosys.services.model.Cita;
import com.odontosys.users.model.Odontologo;
import java.time.LocalDate;
import java.util.ArrayList;

public interface CitaDAO{
    Integer insertar(Cita cita);
    Integer modificar(Cita cita);
    Integer eliminar(Cita cita);
    Cita obtenerPorId(Integer Id);
    ArrayList<Cita> listarTodos();
    ArrayList<Cita>listarPorOdontologo(Odontologo odontologo,LocalDate fechaInicio,LocalDate fechaFin);
}