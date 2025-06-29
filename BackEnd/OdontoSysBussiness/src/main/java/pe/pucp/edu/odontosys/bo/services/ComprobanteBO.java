package pe.pucp.edu.odontosys.bo.services;

import pe.pucp.edu.odontosys.dao.services.ComprobanteDAO;
import pe.pucp.edu.odontosys.daoImp.services.ComprobanteDAOImpl;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Cita;

public class ComprobanteBO {
    private ComprobanteDAO comprobanteDAO;
    
    public ComprobanteBO(){
        this.comprobanteDAO = new ComprobanteDAOImpl();
    }
    
    public Integer insertar (Comprobante comprobante){
        return this.comprobanteDAO.insertar(comprobante);
    }
    
    public Integer modificar(Comprobante comprobante){
        return this.comprobanteDAO.modificar(comprobante);
    }
    
    public Integer eliminar(Comprobante comprobante){
        return this.comprobanteDAO.eliminar(comprobante);
    }
    
    public Comprobante obtenerPorId(Integer id){
        return this.comprobanteDAO.obtenerPorId(id);
    }
    
    public ArrayList<Comprobante> listarTodos(){
        return this.comprobanteDAO.listarTodos();
    }
    
    public Integer actualizarTotal(Integer idCita){
        Cita cita = new Cita();
        cita.setIdCita(idCita);
        return this.comprobanteDAO.actualizarTotal(cita);
    }
}
