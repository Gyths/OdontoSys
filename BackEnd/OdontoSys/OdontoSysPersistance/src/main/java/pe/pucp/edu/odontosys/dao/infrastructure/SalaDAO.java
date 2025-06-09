package pe.pucp.edu.odontosys.dao.infrastructure;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.infrastructure.model.Sala;

public interface SalaDAO {
    Integer insertar(Sala sala);
    Integer modificar(Sala sala);
    Integer eliminar(Sala sala);
    Sala obtenerPorId(Integer id);
    ArrayList<Sala> listarTodos();
}
