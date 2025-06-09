package pe.pucp.edu.odontosys.dao.services;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Cita;

import pe.pucp.edu.odontosys.services.model.DetalleTratamiento;

public interface DetalleTratamientoDAO {
    Integer insertar(DetalleTratamiento detalleTratamiento);
    Integer modificar(DetalleTratamiento detalleTratamiento);
    Integer eliminar(DetalleTratamiento detalleTratamiento);
    DetalleTratamiento obtenerPorId(Integer id);
    ArrayList<DetalleTratamiento> listarTodos();
    ArrayList<DetalleTratamiento> listarPorCita(Cita cita);
    Integer actualizarSubtotal(Cita cita);
}
