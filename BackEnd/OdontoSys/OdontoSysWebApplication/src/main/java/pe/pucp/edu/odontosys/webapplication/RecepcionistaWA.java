package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.users.RecepcionistaBO;
import pe.pucp.edu.odontosys.users.model.Recepcionista;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "RecepcionistaWA")
public class RecepcionistaWA {

    private RecepcionistaBO recepcionistaBO;
    
    public RecepcionistaWA(){
        this.recepcionistaBO = new RecepcionistaBO();
    }
    
    @WebMethod(operationName = "recepcionista_insertar")
    public Integer recepcionista_insertar(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.insertar(recepcionista);
    }
    
    @WebMethod(operationName = "recepcionista_modificar")
    public Integer recepcionista_modificar(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.modificar(recepcionista);
    }
    
    @WebMethod(operationName = "recepcionista_eliminar")
    public Integer recepcionista_eliminar(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.eliminar(recepcionista);
    }
    
    @WebMethod(operationName = "recepcionista_obtenerPorId")
    public Recepcionista recepcionista_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.recepcionistaBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "recepcionista_listarTodos")
    public ArrayList<Recepcionista> recepcionista_listarTodos() {
        return this.recepcionistaBO.listarTodos();
    }
    
    @WebMethod(operationName = "recepcionista_obtenerPorUsuarioContrasenha")
    public Recepcionista recepcionista_obtenerPorUsuarioContrasenha(@WebParam(name = "nombreUsuario") String nombreUsuario, @WebParam(name = "contrasenha") String contrasenha){
        return this.recepcionistaBO.obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
    }
    
}
