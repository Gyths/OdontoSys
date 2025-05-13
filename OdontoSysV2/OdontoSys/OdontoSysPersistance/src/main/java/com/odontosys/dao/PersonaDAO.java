package com.odontosys.dao;

import java.util.ArrayList;

import com.odontosys.users.model.Persona;

public interface PersonaDAO {
    Integer insertar(Persona persona);
    Integer modificar(Persona persona);
    Integer eliminar(Persona persona);
    Persona obtenerPorId(Integer Id);
    ArrayList<Persona> listarTodos();
}
