package com.odontosys.dao;

import com.odontosys.services.model.Cita;
import java.util.ArrayList;

public interface CitaDAO{
    Integer insertar(Cita cita);
    Integer modificar(Cita cita);
    Integer eliminar(Cita cita);
    ArrayList<Cita> listarTodos();
}