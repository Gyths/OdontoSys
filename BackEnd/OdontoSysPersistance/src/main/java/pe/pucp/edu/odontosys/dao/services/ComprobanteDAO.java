package pe.pucp.edu.odontosys.dao.services;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Cita;

import pe.pucp.edu.odontosys.services.model.Comprobante;

public interface ComprobanteDAO {
    Integer insertar(Comprobante comprobante);
    Integer modificar(Comprobante comprobante);
    Integer eliminar(Comprobante comprobante);
    Comprobante obtenerPorId(Integer id);
    ArrayList<Comprobante> listarTodos();
    Integer actualizarTotal(Cita cita);
}
