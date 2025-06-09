package pe.pucp.edu.odontosys.dao.services;

import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.time.LocalDate;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.users.model.Paciente;

public interface ValoracionDAO{
    Integer insertar(Valoracion valoracion);
    Integer modificar(Valoracion valoracion);
    Integer eliminar(Valoracion valoracion);
    Valoracion obtenerPorId(Integer id);
    ArrayList<Valoracion> listarTodos();
    ArrayList<Valoracion> listarPorOdontologo(Odontologo odontologo);
    ArrayList<Valoracion> listarPorPaciente(Paciente paciente);
}