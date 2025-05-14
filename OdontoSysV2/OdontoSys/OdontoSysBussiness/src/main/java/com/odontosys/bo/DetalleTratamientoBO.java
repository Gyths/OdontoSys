package com.odontosys.bo;

import com.odontosys.dao.DetalleTratamientoDAO;
import com.odontosys.daoImp.DetalleTratamientoDAOImpl;
import com.odontosys.services.model.DetalleTratamiento;

public class DetalleTratamientoBO {
    private DetalleTratamientoDAO detalleTratamientoDAO;
    
    public DetalleTratamientoBO(){
        this.detalleTratamientoDAO = new DetalleTratamientoDAOImpl();
    }
    
    public Integer InsertarDetalle(Integer idCita, Integer idTratamiento, Integer cantidad, double subtotal){
        DetalleTratamiento detalle = new DetalleTratamiento();
        detalle.setIdCita(idCita);
        detalle.getTratamiento().setIdTratamiento(idTratamiento);
        detalle.setCantidad(cantidad);
        detalle.setSubtotal(subtotal);
        return this.detalleTratamientoDAO.insertar(detalle);
    }
    
    //Pendiente
    public Integer ModificarDetalle(){
        return -1;
    }
    
    //Pendiente
    public Integer EliminarDetalle(){
        return -1;
    }
}
