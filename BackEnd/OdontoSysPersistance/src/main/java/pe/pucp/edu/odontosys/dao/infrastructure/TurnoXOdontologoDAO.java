package pe.pucp.edu.odontosys.dao.infrastructure;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.infrastructure.model.TurnoXOdontologo;

public interface TurnoXOdontologoDAO {
    Integer insertar(TurnoXOdontologo turnoXOdontologo);
    Integer modificar(TurnoXOdontologo turnoXOdontologo);
    Integer eliminar(TurnoXOdontologo turnoXOdontologo);
    TurnoXOdontologo obtenerPorId(Integer id);
    ArrayList<TurnoXOdontologo> listarTodos();
}
