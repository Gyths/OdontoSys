package com.odontosys.dao.services;

import java.util.ArrayList;

import com.odontosys.services.model.DetalleTratamiento;

public interface DetalleTratamientoDAO {
    Integer insertar(DetalleTratamiento detalleTratamiento);
    Integer modificar(DetalleTratamiento detalleTratamiento);
    Integer eliminar(DetalleTratamiento detalleTratamiento);
    DetalleTratamiento obtenerPorId(Integer Id);
    ArrayList<DetalleTratamiento> listarTodos();
}
