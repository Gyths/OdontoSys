package pe.pucp.edu.odontosys.bo.services;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.dao.services.ValoracionDAO;
import pe.pucp.edu.odontosys.daoImp.services.ValoracionDAOImpl;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.users.model.Paciente;

public class ValoracionBO {
    
    private ValoracionDAO valoracionDAO;
    
    public ValoracionBO(){
        this.valoracionDAO = new ValoracionDAOImpl();
    }
    
    public Integer insertar(Valoracion valoracion){
        return this.valoracionDAO.insertar(valoracion);
    }

    public Integer modificar(Valoracion valoracion){
        return this.valoracionDAO.modificar(valoracion);
    }
    
    public Integer eliminar(Valoracion valoracion){
        return this.valoracionDAO.eliminar(valoracion);
    }
    
    public Valoracion obtenerPorId(Integer id){
        return this.valoracionDAO.obtenerPorId(id);
    }
    
    public ArrayList<Valoracion> listarTodos(){
        return this.valoracionDAO.listarTodos();
    }
    
}
