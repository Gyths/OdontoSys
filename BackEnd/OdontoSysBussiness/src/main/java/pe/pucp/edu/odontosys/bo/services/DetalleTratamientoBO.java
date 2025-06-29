package pe.pucp.edu.odontosys.bo.services;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.dao.services.DetalleTratamientoDAO;
import pe.pucp.edu.odontosys.daoImp.services.DetalleTratamientoDAOImpl;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.services.model.DetalleTratamiento;

public class DetalleTratamientoBO {
    private DetalleTratamientoDAO detalleTratamientoDAO;
    
    public DetalleTratamientoBO(){
        this.detalleTratamientoDAO = new DetalleTratamientoDAOImpl();
    }
    
    public Integer insertar(DetalleTratamiento detalle){
        return this.detalleTratamientoDAO.insertar(detalle);
    }
    
    public Integer modificar(DetalleTratamiento detalleTratamiento){
        return this.detalleTratamientoDAO.modificar(detalleTratamiento);
    }
    
    public Integer eliminar(DetalleTratamiento detalleTratamiento){
        return this.detalleTratamientoDAO.eliminar(detalleTratamiento);
    }
    
    public DetalleTratamiento obtenerPorId(Integer id){
        return this.detalleTratamientoDAO.obtenerPorId(id);
    }
    
    public ArrayList<DetalleTratamiento> listarTodos(){
        return this.detalleTratamientoDAO.listarTodos();
    }
    
    public ArrayList<DetalleTratamiento> listarPorCita(Integer idCita){
        Cita cita = new Cita();
        cita.setIdCita(idCita);
        return this.detalleTratamientoDAO.listarPorCita(cita);
    }
    
    public Integer actualizarSubtotal(Integer idCita){
        Cita cita = new Cita();
        cita.setIdCita(idCita);    
        return this.detalleTratamientoDAO.actualizarSubtotal(cita);
    }
}
