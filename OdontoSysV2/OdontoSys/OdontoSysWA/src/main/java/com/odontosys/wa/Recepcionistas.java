package com.odontosys.wa;

import com.odontosys.bo.RecepcionistaBO;
import com.odontosys.users.model.Recepcionista;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Recepcionistas")
public class Recepcionistas {

    private RecepcionistaBO recepcionistaBO;
    
    public Recepcionistas(){
        this.recepcionistaBO = new RecepcionistaBO();
    }
    
    @WebMethod(operationName = "insertarRecepcionista")
    public Integer insertarRecepcionista(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.insertarRecepcionista(recepcionista);
    }
    
    @WebMethod(operationName = "modificarRecepcionista")
    public Integer modificarRecepcionista(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.modificarRecepcionista(recepcionista);
    }
    
    @WebMethod(operationName = "eliminarRecepcionista")
    public Integer eliminarRecepcionista(@WebParam(name = "recepcionista") Recepcionista recepcionista) {
        return this.recepcionistaBO.eliminarRecepcionista(recepcionista);
    }
    
    @WebMethod(operationName = "obtenerPorID")
    public Recepcionista rep_obtenerPorID(@WebParam(name = "recepcionistaId") Integer recepcionistaId) {
        return this.recepcionistaBO.obtenerPorID(recepcionistaId);
    }
    
    @WebMethod(operationName = "buscarPorUsuario")
    public Recepcionista rep_buscarPorUsuario(@WebParam(name = "nombreUsuario") String nombreUsuario) {
        return this.recepcionistaBO.buscarPorUsuario(nombreUsuario);
    }
    
    @WebMethod(operationName = "listarRecepcionista")
    public ArrayList<Recepcionista> listarRecepcionista() {
        return this.recepcionistaBO.listarRecepcionista();
    }
}
