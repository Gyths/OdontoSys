package com.odontosys.dao;

import java.util.ArrayList;

import com.odontosys.services.model.Tratamiento;

public interface TratamientoDAO {
    Integer insertar(Tratamiento tratamiento);
    Integer modificar(Tratamiento tratamiento);
    Integer eliminar(Tratamiento tratamiento);
    Tratamiento obtenerPorId(Integer Id);
    ArrayList<Tratamiento> listarTodos();
}
