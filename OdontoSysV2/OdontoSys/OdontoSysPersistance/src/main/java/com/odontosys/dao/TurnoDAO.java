package com.odontosys.dao;

import java.util.ArrayList;

import com.odontosys.infrastructure.model.Turno;

public interface TurnoDAO {
    Integer insertar(Turno turno);
    Integer modificar(Turno turno);
    Integer eliminar(Turno turno);
    Turno obtenerPorId(Integer Id);
    ArrayList<Turno> listarTodos();
}
