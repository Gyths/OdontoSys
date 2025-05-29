package com.odontosys.bo;
import com.odontosys.dao.users.OdontologoDAO;
import com.odontosys.daoImp.users.OdontologoDAOImpl;
import com.odontosys.services.model.Especialidad;
import com.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public class OdontologoBO {
    private OdontologoDAO odontologoDAO;
    
    public OdontologoBO(){
        this.odontologoDAO = new OdontologoDAOImpl();
    }
    
    public Integer insertarOdontologo(Odontologo odontologo){
        return this.odontologoDAO.insertar(odontologo);
    }
    
    public Integer modificarOdontologo(Odontologo odontologo){
       return this.odontologoDAO.modificar(odontologo);
    }
    
    public Integer eliminarOdontologo(Odontologo odontologo){
       return this.odontologoDAO.eliminar(odontologo);
    }
    
    public Odontologo obtenerPorID(Integer odontologoID){
        return this.odontologoDAO.obtenerPorId(odontologoID);
    }
    
    public Odontologo buscarPorUsuario(String odontologoUsuario){
        return this.odontologoDAO.buscarPorUsuario(odontologoUsuario);
    }
    
    public ArrayList<Odontologo> listarOdontologos(){
        ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
        return lista;
    }
    
    public ArrayList<Odontologo> listarPorEspecialidad(Especialidad especialidad){
        ArrayList<Odontologo> lista = this.odontologoDAO.listarPorEspecialidad(especialidad);
        return lista;
    }
    
}
