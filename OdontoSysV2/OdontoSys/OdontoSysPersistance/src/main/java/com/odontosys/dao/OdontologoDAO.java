package com.odontosys.dao;

import com.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public interface OdontologoDAO{
    Integer insertar(Odontologo recepcionista);
    Integer eliminar(Odontologo recepcionista);
    ArrayList<Odontologo> listarTodos();
}
