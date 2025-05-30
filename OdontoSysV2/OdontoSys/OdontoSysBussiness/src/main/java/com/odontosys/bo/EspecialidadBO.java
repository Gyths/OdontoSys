package com.odontosys.bo;

import com.odontosys.dao.services.EspecialidadDAO;
import com.odontosys.daoImp.services.EspecialidadDAOImpl;
import com.odontosys.services.model.Especialidad;
import java.util.ArrayList;


public class EspecialidadBO {
    private EspecialidadDAO especialidadDAO;
    
    public EspecialidadBO(){
        this.especialidadDAO = new EspecialidadDAOImpl();
    }
    
    public Integer InsertarEspecialidad(Especialidad especialidad){
        return this.especialidadDAO.insertar(especialidad);
    }
    
    public Integer ModificarEspecialidad(Especialidad especialidad){
        return this.especialidadDAO.modificar(especialidad);
    }
    
    public Integer EliminarEspecialidad(Especialidad especialidad){
        return this.especialidadDAO.eliminar(especialidad);
    }
    
    public ArrayList<Especialidad> ListarEspecialidades(){
        return this.especialidadDAO.listarTodos();
    }
}
