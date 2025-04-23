package com.odontosys.dao;

import com.odontosys.infraestructure.model.Sala;
import java.util.ArrayList;

public interface SalaDAO {
    Integer insertar(Sala sala);
    ArrayList<Sala> listarTodos();
    Integer modificar(Sala sala);
    Integer eliminar(Sala sala);
}
