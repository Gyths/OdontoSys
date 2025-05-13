package com.odontosys.dao;

import com.odontosys.users.model.Paciente;
import java.util.ArrayList;

public interface PacienteDAO{
    Integer insertar(Paciente paciente);
    Integer eliminar(Paciente paciente);
    ArrayList<Paciente> listarTodos();
}

