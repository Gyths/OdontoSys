package com.odontosys.dao;

import com.odontosys.infraestructure.model.Turno;
import java.util.List;

public interface TurnoDAO {
    public Integer insertar(Turno turno);
    
    public Turno obtenerPorId(Integer turnoId);
    
//    public List<Turno> listarTodos();
    
    public Integer modificar(Turno turno);
    
    public Integer eliminar(Turno turno);
}
