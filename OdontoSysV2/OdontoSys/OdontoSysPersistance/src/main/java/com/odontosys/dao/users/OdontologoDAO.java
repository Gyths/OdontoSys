package com.odontosys.dao.users;

import com.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public interface OdontologoDAO{
    Integer insertar(Odontologo recepcionista);
    Integer eliminar(Odontologo recepcionista);
    Odontologo obtenerPorId(Integer Id);
    ArrayList<Odontologo> listarTodos();
}
