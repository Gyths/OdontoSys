package pe.pucp.edu.odontosys.bo.services;

import pe.pucp.edu.odontosys.dao.services.EspecialidadDAO;
import pe.pucp.edu.odontosys.daoImp.services.EspecialidadDAOImpl;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import java.util.ArrayList;


public class EspecialidadBO {
    private EspecialidadDAO especialidadDAO;
    
    public EspecialidadBO(){
        this.especialidadDAO = new EspecialidadDAOImpl();
    }
    
    public Integer insertar(Especialidad especialidad){
        return this.especialidadDAO.insertar(especialidad);
    }
    
    public Integer modificar(Especialidad especialidad){
        return this.especialidadDAO.modificar(especialidad);
    }
    
    public Integer eliminar(Especialidad especialidad){
        return this.especialidadDAO.eliminar(especialidad);
    }
    
    public Especialidad obtenerPorId(Integer id){
        return this.especialidadDAO.obtenerPorId(id);
    }
    public ArrayList<Especialidad> listarTodos(){
        return this.especialidadDAO.listarTodos();
    }
}
