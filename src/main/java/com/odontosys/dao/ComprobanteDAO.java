package com.odontosys.dao;

import com.odontosys.services.model.Comprobante;
import java.util.ArrayList;
import java.util.List;

public interface ComprobanteDAO {
    public Integer insertar(Comprobante comprobante);
    
    public Comprobante obtenerPorId(Integer comprobanteId);
    
    public ArrayList<Comprobante> listarTodos();
    
    public Integer modificar(Comprobante comprobante);
    
    public Integer eliminar(Comprobante comprobante);
}
