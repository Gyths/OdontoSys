package com.odontosys.dao.users;

import com.odontosys.users.model.Paciente;
import java.util.ArrayList;

public interface PacienteDAO{
    Integer insertar(Paciente paciente);
    Integer eliminar(Paciente paciente);
    Paciente obtenerPorId(Integer Id);
    ArrayList<Paciente> listarTodos();
}

