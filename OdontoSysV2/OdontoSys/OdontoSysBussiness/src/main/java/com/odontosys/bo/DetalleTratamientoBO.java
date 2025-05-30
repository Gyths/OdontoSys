package com.odontosys.bo;

import com.odontosys.dao.services.DetalleTratamientoDAO;
import com.odontosys.daoImp.services.DetalleTratamientoDAOImpl;
import com.odontosys.services.model.DetalleTratamiento;

public class DetalleTratamientoBO {
    private DetalleTratamientoDAO detalleTratamientoDAO;
    
    public DetalleTratamientoBO(){
        this.detalleTratamientoDAO = new DetalleTratamientoDAOImpl();
    }
    
    public Integer InsertarDetalle(DetalleTratamiento detalle){
        return this.detalleTratamientoDAO.insertar(detalle);
    }
    
    public Integer ModificarDetalle(DetalleTratamiento detalleTratamiento){
        return this.detalleTratamientoDAO.modificar(detalleTratamiento);
    }
    
    public Integer EliminarDetalle(DetalleTratamiento detalleTratamiento){
        return this.detalleTratamientoDAO.eliminar(detalleTratamiento);
    }
}
