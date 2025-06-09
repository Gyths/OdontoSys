package pe.pucp.edu.odontosys.dao.services;

import pe.pucp.edu.odontosys.services.model.Especialidad;
import java.util.ArrayList;

public interface EspecialidadDAO {
    Integer insertar(Especialidad especialidad);
    Integer modificar(Especialidad especialidad);
    Integer eliminar(Especialidad especialidad);
    Especialidad obtenerPorId(Integer id);
    ArrayList<Especialidad> listarTodos();
}
