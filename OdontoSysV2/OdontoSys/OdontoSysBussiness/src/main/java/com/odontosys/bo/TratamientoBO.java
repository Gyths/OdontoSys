package com.odontosys.bo;

import com.odontosys.dao.services.TratamientoDAO;
import com.odontosys.daoImp.services.TratamientoDAOImpl;
import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.Tratamiento;
import java.util.ArrayList;


public class TratamientoBO {
    private TratamientoDAO tratamientoDAO;
    
    public TratamientoBO(){
        this.tratamientoDAO = new TratamientoDAOImpl();
    }
    
    public Integer InsertarTratamiento(Tratamiento tratamiento){
        return this.tratamientoDAO.insertar(tratamiento);
    }
   
    public Integer ModificarTratamiento(Tratamiento tratamiento){
        return this.tratamientoDAO.modificar(tratamiento);
    }
    
    public Integer EliminarTratamiento(Tratamiento tratamiento){
        return this.tratamientoDAO.eliminar(tratamiento);
    }
}
