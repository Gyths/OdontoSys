package pe.pucp.edu.odontosys.dao.services;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Especialidad;

import pe.pucp.edu.odontosys.services.model.Tratamiento;

public interface TratamientoDAO {
    Integer insertar(Tratamiento tratamiento);
    Integer modificar(Tratamiento tratamiento);
    Integer eliminar(Tratamiento tratamiento);
    Tratamiento obtenerPorId(Integer id);
    ArrayList<Tratamiento> listarTodos();
    ArrayList<Tratamiento> listarPorEspecialidad(Especialidad especialidad);
}
