package com.odontosys.bo;
import com.odontosys.dao.OdontologoDAO;
import com.odontosys.daoImp.OdontologoDAOImpl;
import com.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public class OdontologoBO {
    private OdontologoDAO odontologoDAO;
    private PersonaBO personaBO;
    
    public OdontologoBO(){
        this.odontologoDAO = new OdontologoDAOImpl();
        this.personaBO = new PersonaBO();
    }
    
    public Integer insertarOdontologo(Odontologo odontologo){
        return this.odontologoDAO.insertar(odontologo);
    }
    
    public Integer modificarOdontologo(Odontologo odontologo){
       return this.odontologoDAO.modificarOdontologo(odontologo);
    }
    
    public Integer eliminarOdontologo(Odontologo odontologo){
       return this.odontologoDAO.eliminar(odontologo);
    }
    
    public Odontologo obtenerPorID(Integer ondontologoID){
        return this.odontologoDAO.obtenerPorID(odontologoID);
    }
    
    public ArrayList<Odontologo> listarOdontologos(){
        ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
        return lista;
    }
    
    
    
}
