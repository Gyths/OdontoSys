package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.infrastructure.SalaBO;
import pe.pucp.edu.odontosys.infrastructure.model.Sala;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;


@WebService(serviceName = "SalaWA")
public class SalaWA {

    private SalaBO salaBO;
    
    public SalaWA(){
        this.salaBO = new SalaBO();
    }
    
    @WebMethod(operationName = "sala_insertar")
    public Integer sala_insertar(@WebParam(name = "sala") Sala sala) {
        return this.salaBO.insertar(sala);
    }
    
    @WebMethod(operationName = "sala_modificar")
    public Integer sala_modificar(@WebParam(name = "sala") Sala sala) {
        return this.salaBO.modificar(sala);
    }
    
    @WebMethod(operationName = "sala_eliminar")
    public Integer sala_eliminar(@WebParam(name = "sala") Sala sala) {
        return this.salaBO.eliminar(sala);
    }
    
    @WebMethod(operationName = "sala_obtenerPorId")
    public Sala sala_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.salaBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "sala_listarTodos")
    public ArrayList<Sala> sala_listarTodos() {
        return this.salaBO.listarTodos();
    }
    
}
