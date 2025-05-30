package com.odontosys.dao.services;

import com.odontosys.services.model.Especialidad;
import java.util.ArrayList;

public interface EspecialidadDAO {
    Integer insertar(Especialidad especialidad);
    Integer modificar(Especialidad especialidad);
    Integer eliminar(Especialidad especialidad);
    Especialidad obtenerPorId(Integer Id);
    ArrayList<Especialidad> listarTodos();
}
