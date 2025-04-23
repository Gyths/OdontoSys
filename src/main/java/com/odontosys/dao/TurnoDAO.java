package com.odontosys.dao;

import com.odontosys.infraestructure.model.Turno;
import java.util.ArrayList;

public interface TurnoDAO {
    Integer insertar(Turno turno);
    Integer modificar(Turno turno);
    Integer eliminar(Turno turno);
    ArrayList<Turno> listarTodos();
}

