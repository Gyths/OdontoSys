package com.odontosys.dao;

import java.util.ArrayList;

import com.odontosys.infrastructure.model.TurnoXOdontologo;

public interface TurnoXOdontologoDAO {
    Integer insertar(TurnoXOdontologo turnoXOdontologo);
    Integer modificar(TurnoXOdontologo turnoXOdontologo);
    Integer eliminar(TurnoXOdontologo turnoXOdontologo);
    TurnoXOdontologo obtenerPorId(Integer Id);
    ArrayList<TurnoXOdontologo> listarTodos();
}
