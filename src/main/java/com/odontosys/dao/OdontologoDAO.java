package com.odontosys.dao;

import com.odontosys.users.model.Odontologo;
import java.util.List;

public interface OdontologoDAO {
    public Integer insertar(Odontologo odontologo);
    
    public Odontologo obtenerPorId(Integer odontologoId);
    
//    public List<Odontologo> listarTodos();
    
    public Integer modificar(Odontologo odontologo);
    
    public Integer eliminar(Odontologo odontologo);
    
}
