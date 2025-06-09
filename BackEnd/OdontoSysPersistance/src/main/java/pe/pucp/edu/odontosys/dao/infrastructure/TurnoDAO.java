package pe.pucp.edu.odontosys.dao.infrastructure;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import pe.pucp.edu.odontosys.users.model.Odontologo;

public interface TurnoDAO {
    Integer insertar(Turno turno);
    Integer modificar(Turno turno);
    Integer eliminar(Turno turno);
    Turno obtenerPorId(Integer id);
    ArrayList<Turno> listarTodos();
    ArrayList<Turno> listarPorOdontologo(Odontologo odontologo);
}
