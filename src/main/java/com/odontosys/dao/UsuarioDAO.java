
package com.odontosys.dao;

import com.odontosys.users.model.Usuario;
import java.util.ArrayList;

/**
 *
 * @author Gyts
 */
public interface UsuarioDAO{
    Integer insertar(Usuario usuario);
    Integer modificarCorreo(int idUsuario, String nuevoCorreo);
    Integer eliminar(int idUsuario);
    ArrayList<Usuario> listarTodos();
}
