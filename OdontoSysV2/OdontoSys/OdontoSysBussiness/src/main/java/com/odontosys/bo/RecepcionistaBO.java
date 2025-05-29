package com.odontosys.bo;
import com.odontosys.users.model.Recepcionista;
import com.odontosys.dao.users.RecepcionistaDAO;
import com.odontosys.daoImp.users.RecepcionistaDAOImpl;
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
       return this.recepcionistaDAO.modificar(recepcionista);
    }
    
    public Integer eliminarRecepcionista(Recepcionista recepcionista){
       return this.recepcionistaDAO.eliminar(recepcionista);
    }
    
    public Recepcionista obtenerPorID(Integer recepcionistaID){
        return this.recepcionistaDAO.obtenerPorId(recepcionistaID);
    }
    
    public Recepcionista buscarPorUsuario(String nombreUsuario){
        return this.recepcionistaDAO.buscarPorUsuario(nombreUsuario);
    }
    
    public ArrayList<Recepcionista> listarRecepcionista(){
        ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
        return lista;
    }
    
}
