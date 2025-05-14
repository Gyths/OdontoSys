package com.odontosys.bo;

import com.odontosys.dao.TratamientoDAO;
import com.odontosys.daoImp.TratamientoDAOImpl;
import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.Tratamiento;
import java.util.ArrayList;


public class TratamientoBO {
    private TratamientoDAO tratamientoDAO;
    
    public TratamientoBO(){
        this.tratamientoDAO = new TratamientoDAOImpl();
    }
    
    public Integer InsertarTratamiento(String nombre, String descripcion, double costo, Especialidad especialidad){
        Tratamiento tratamiento = new Tratamiento();
        tratamiento.setNombre(nombre);
        tratamiento.setDescripcion(descripcion);
        tratamiento.setCosto(costo);
        tratamiento.setEspecialidad(especialidad);
        
        return this.tratamientoDAO.insertar(tratamiento);
    }
    
    //Pendiente
    public Integer ModificarTratamiento(String nombre){
        return -1;
    }
    
    public Integer EliminarTratamiento(String nombre){
        ArrayList<Tratamiento> list = this.tratamientoDAO.listarTodos();
        for(Tratamiento t : list){
            if(t.getNombre().matches(nombre))
                return this.tratamientoDAO.eliminar(t);
        }
        return -1;
    }
}
