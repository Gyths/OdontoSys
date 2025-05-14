
package com.odontosys.bo;

import com.odontosys.dao.ComprobanteDAO;
import com.odontosys.daoImp.ComprobanteDAOImpl;
import com.odontosys.infrastructure.model.MetodoPago;
import com.odontosys.services.model.Comprobante;
import java.time.LocalDate;
import java.time.LocalTime;

public class ComprobanteBO {
    private ComprobanteDAO comprobanteDAO;
    
    public ComprobanteBO(){
        this.comprobanteDAO = new ComprobanteDAOImpl();
    }
    
    public Integer InsertComprobante (LocalDate fechaEmision,LocalTime horaEmision,double total, MetodoPago metodoPago){
        Comprobante comprobante = new Comprobante();
        comprobante.setFechaEmision(fechaEmision);
        comprobante.setHoraEmision(horaEmision);
        comprobante.setTotal(total);
        comprobante.setMetodoDePago(metodoPago);
        return this.comprobanteDAO.insertar(comprobante);
    }
    
    public Integer EliminarComprobante(Comprobante comprobante){
        return this.comprobanteDAO.eliminar(comprobante);
    }
    
}
