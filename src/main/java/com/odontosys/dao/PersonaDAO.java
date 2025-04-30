package com.odontosys.dao;

import com.odontosys.users.model.Persona;
import java.util.ArrayList;

/**
 *
 * @author Gyts
 */
public interface PersonaDAO extends UsuarioDAO{
    Integer insertar(Persona persna);
    Integer modificarCorreo(int idUsuario, String nuevoCorreo);
    Integer eliminar(int idUsuario);
    ArrayList<Persona> listarTodos();
}