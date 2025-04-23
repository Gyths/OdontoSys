package com.odontosys.dao;

import com.odontosys.infraestructure.model.Sala;
import java.util.List;

public interface SalaDAO {
    public Integer insertar(Sala sala);
    
    public Sala obtenerPorId(Integer salaId);
    
//    public List<Turno> listarTodos();
    
    public Integer modificar(Sala sala);
    
    public Integer eliminar(Sala sala);
}
