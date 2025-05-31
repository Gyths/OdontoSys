package com.odontosys.bo;

import com.odontosys.dao.services.ComprobanteDAO;
import com.odontosys.daoImp.services.ComprobanteDAOImpl;
import com.odontosys.services.model.Comprobante;
import java.util.ArrayList;

public class ComprobanteBO {
    private ComprobanteDAO comprobanteDAO;
    
    public ComprobanteBO(){
        this.comprobanteDAO = new ComprobanteDAOImpl();
    }
    
    public Integer InsertComprobante (Comprobante comprobante){
        return this.comprobanteDAO.insertar(comprobante);
    }
    
    public Integer EliminarComprobante(Comprobante comprobante){
        return this.comprobanteDAO.eliminar(comprobante);
    }
    
    public ArrayList<Comprobante>ListarTodos(){
        return this.comprobanteDAO.listarTodos();
    }
}
