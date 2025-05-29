package com.odontosys.dao.infrastructure;

import java.util.ArrayList;

import com.odontosys.infrastructure.model.Sala;

public interface SalaDAO {
    Integer insertar(Sala sala);
    Integer modificar(Sala sala);
    Integer eliminar(Sala sala);
    Sala obtenerPorId(Integer Id);
    ArrayList<Sala> listarTodos();
}
