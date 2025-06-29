package pe.pucp.edu.odontosys.bo.services;

import pe.pucp.edu.odontosys.dao.services.TratamientoDAO;
import pe.pucp.edu.odontosys.daoImp.services.TratamientoDAOImpl;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.services.model.Tratamiento;
import java.util.ArrayList;


public class TratamientoBO {
    private TratamientoDAO tratamientoDAO;
    
    public TratamientoBO(){
        this.tratamientoDAO = new TratamientoDAOImpl();
    }
    
    public Integer insertar(Tratamiento tratamiento){
        return this.tratamientoDAO.insertar(tratamiento);
    }
   
    public Integer modificar(Tratamiento tratamiento){
        return this.tratamientoDAO.modificar(tratamiento);
    }
    
    public Integer eliminar(Tratamiento tratamiento){
        return this.tratamientoDAO.eliminar(tratamiento);
    }
    
    public ArrayList<Tratamiento> listarTodos(){
        return this.tratamientoDAO.listarTodos();
    }
    
    public Tratamiento obtenerPorId(Integer id){
        return this.tratamientoDAO.obtenerPorId(id);
    }
    
    public ArrayList<Tratamiento> listarPorEspecialidad(Integer idEspecialidad){
        Especialidad especialidad = new Especialidad();
        especialidad.setIdEspecialidad(idEspecialidad);
        return this.tratamientoDAO.listarPorEspecialidad(especialidad);
    }
}
