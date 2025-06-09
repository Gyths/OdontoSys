package pe.pucp.edu.odontosys.dao.infrastructure;

import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import java.util.ArrayList;

public interface MetodoPagoDAO {
    Integer insertar(MetodoPago metodoPago);
    Integer modificar(MetodoPago metodoPago);
    Integer eliminar(MetodoPago metodoPago);
    MetodoPago obtenerPorId(Integer id);
    ArrayList<MetodoPago> listarTodos();
}
