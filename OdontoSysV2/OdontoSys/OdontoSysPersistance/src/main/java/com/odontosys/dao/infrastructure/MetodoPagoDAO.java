package com.odontosys.dao.infrastructure;

import com.odontosys.infrastructure.model.MetodoPago;
import java.util.ArrayList;

public interface MetodoPagoDAO {
    Integer insertar(MetodoPago metodoPago);
    Integer modificar(MetodoPago metodoPago);
    Integer eliminar(MetodoPago metodoPago);
    MetodoPago obtenerPorId(Integer Id);
    ArrayList<MetodoPago> listarTodos();
}
