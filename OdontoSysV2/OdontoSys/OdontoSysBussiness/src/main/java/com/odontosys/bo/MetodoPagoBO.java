package com.odontosys.bo;

import com.odontosys.dao.infrastructure.MetodoPagoDAO;
import com.odontosys.daoImp.infrastructure.MetodoPagoDAOImpl;
import com.odontosys.infrastructure.model.MetodoPago;
import java.util.ArrayList;

public class MetodoPagoBO {
    private MetodoPagoDAO metodoPagoDAO;
    
    public MetodoPagoBO(){
        this.metodoPagoDAO = new MetodoPagoDAOImpl();
    }
    
    public Integer InsertarMetodoPago(MetodoPago metodoPago){
        return this.metodoPagoDAO.insertar(metodoPago);
    }
    
    public Integer ModificarMetodoPago(MetodoPago metodoPago){
        return this.metodoPagoDAO.modificar(metodoPago);
    }
    
    public Integer EliminarMetodoPago(MetodoPago metodoPago){
        return this.metodoPagoDAO.eliminar(metodoPago);
    }
    
    public ArrayList<MetodoPago> ListarMetodosDePago(){
        return this.metodoPagoDAO.listarTodos();
    }
}
