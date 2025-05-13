package com.odontosys.dao;

import java.util.ArrayList;

import com.odontosys.services.model.Comprobante;

public interface ComprobanteDAO {
    Integer insertar(Comprobante comprobante);
    Integer modificar(Comprobante comprobante);
    Integer eliminar(Comprobante comprobante);
    Comprobante obtenerPorId(Integer Id);
    ArrayList<Comprobante> listarTodos();
}
