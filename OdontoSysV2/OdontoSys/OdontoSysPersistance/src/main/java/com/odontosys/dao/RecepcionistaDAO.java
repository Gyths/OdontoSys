package com.odontosys.dao;

import com.odontosys.users.model.Recepcionista;
import java.util.ArrayList;

public interface RecepcionistaDAO{
    Integer insertar(Recepcionista recepcionista);
    Integer eliminar(Recepcionista recepcionista);
    ArrayList<Recepcionista> listarTodos();
}
