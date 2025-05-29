package com.odontosys.dao.users;

import com.odontosys.users.model.Recepcionista;
import java.util.ArrayList;

public interface RecepcionistaDAO{
    Integer insertar(Recepcionista recepcionista);
    Integer eliminar(Recepcionista recepcionista);
    Recepcionista obtenerPorId(Integer Id);
    ArrayList<Recepcionista> listarTodos();
}
