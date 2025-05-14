
package com.odontosys.bo;

import com.odontosys.dao.ComprobanteDAO;
import com.odontosys.daoImp.ComprobanteDAOImpl;
import com.odontosys.infrastructure.model.MetodoPago;
import com.odontosys.services.model.Comprobante;
import java.time.LocalDate;

public class ComprobanteBO {
    private ComprobanteDAO comprobanteDAO;
    
    public ComprobanteBO(){
        this.comprobanteDAO = new ComprobanteDAOImpl();
    }
    
    public Integer InsertComprobante (LocalDate fechaEmision,double total, MetodoPago metodoPago){
        Comprobante comprobante = new Comprobante();
        comprobante.setFechaEmision(fechaEmision);
        comprobante.setTotal(total);
        comprobante.setMetodoDePago(metodoPago);
        return this.comprobanteDAO.insertar(comprobante);
    }
    
    //Pendiente
    public Integer ModificarComprobante(){
        return -1;
    }
    
    //Pendiente
    public Integer EliminarComprobante(){
        return -1;
    }
}
