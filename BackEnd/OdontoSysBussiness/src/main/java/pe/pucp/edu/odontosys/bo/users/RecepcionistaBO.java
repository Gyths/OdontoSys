package pe.pucp.edu.odontosys.bo.users;
import pe.pucp.edu.odontosys.users.model.Recepcionista;
import pe.pucp.edu.odontosys.dao.users.RecepcionistaDAO;
import pe.pucp.edu.odontosys.daoImp.users.RecepcionistaDAOImpl;
import java.util.ArrayList;

public class RecepcionistaBO {
    private RecepcionistaDAO recepcionistaDAO;
    
    public RecepcionistaBO(){
        this.recepcionistaDAO = new RecepcionistaDAOImpl();
    }
    
    public Integer insertar(Recepcionista recepcionista){
        return this.recepcionistaDAO.insertar(recepcionista);
    }
    
    public Integer modificar(Recepcionista recepcionista){
       return this.recepcionistaDAO.modificar(recepcionista);
    }
    
    public Integer eliminar(Recepcionista recepcionista){
       return this.recepcionistaDAO.eliminar(recepcionista);
    }
    
    public Recepcionista obtenerPorId(Integer id){
        return this.recepcionistaDAO.obtenerPorId(id);
    }
    
    public ArrayList<Recepcionista> listarTodos(){
        return this.recepcionistaDAO.listarTodos();
    }

    public Recepcionista obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha){
        Recepcionista recepcionista = new Recepcionista();
        recepcionista.setNombreUsuario(nombreUsuario);
        recepcionista.setContrasenha(contrasenha);
        return this.recepcionistaDAO.obtenerPorUsuarioContrasenha(recepcionista);
    }
    
    public Boolean verificarExistenciaNombreUsuario(String nombreUsuario){
        return this.recepcionistaDAO.existeNombreUsuario(nombreUsuario);
    }
}
