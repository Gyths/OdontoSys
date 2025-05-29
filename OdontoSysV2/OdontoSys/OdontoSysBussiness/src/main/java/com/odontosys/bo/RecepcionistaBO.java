package com.odontosys.bo;
import com.odontosys.users.model.Recepcionista;
import com.odontosys.dao.RecepcionistaDAO;
import com.odontosys.daoImp.RecepcionistaDAOImpl;
import java.util.ArrayList;

public class RecepcionistaBO {
    private RecepcionistaDAO recepcionistaDAO;
    
    public RecepcionistaBO(){
        this.recepcionistaDAO = new RecepcionistaDAOImpl();
    }
    
    public Integer insertarRecepcionista(Recepcionista recepcionista){
        return this.recepcionistaDAO.insertar(recepcionista);
    }
    
    public Integer modificarRecepcionista(Recepcionista recepcionista){
       return this.recepcionistaDAO.modificarRecepcionista(recepcionista);
    }
    
    public Integer eliminarRecepcionista(Recepcionista recepcionista){
       return this.recepcionistaDAO.eliminar(recepcionista);
    }
    
    public Recepcionista obtenerPorID(Integer recepcionistaID){
        return this.recepcionistaDAO.obtenerPorID(recepcionistaID);
    }
    
    public ArrayList<Recepcionista> listarOdontologos(){
        ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
        return lista;
    }
    
}
