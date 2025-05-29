package com.odontosys.dao.users;

import com.odontosys.services.model.Especialidad;
import com.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public interface OdontologoDAO{
    Integer insertar(Odontologo odontologo);
    Integer modificar(Odontologo odontologo);
    Integer eliminar(Odontologo odontologo);
    Odontologo obtenerPorId(Integer Id);
    ArrayList<Odontologo> listarTodos();
    Odontologo buscarPorUsuario(String nombreUsuario);
    ArrayList<Odontologo> listarPorEspecialidad(Especialidad especialidad);
}
