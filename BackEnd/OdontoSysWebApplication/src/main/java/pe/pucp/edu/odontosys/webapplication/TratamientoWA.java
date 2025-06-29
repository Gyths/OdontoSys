package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.services.TratamientoBO;
import pe.pucp.edu.odontosys.services.model.Tratamiento;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "TratamientoWA")
public class TratamientoWA {

    private TratamientoBO tratamientoBO;
    
    public TratamientoWA(){
        this.tratamientoBO = new TratamientoBO();
    }
    
    @WebMethod(operationName = "tratamiento_insertar")
    public Integer tratamiento_insertar(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.insertar(tratamiento);
    }
    
    @WebMethod(operationName = "tratamiento_modificar")
    public Integer tratamiento_modificar(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.modificar(tratamiento);
    }
    
    @WebMethod(operationName = "tratamiento_eliminar")
    public Integer tratamiento_eliminar(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.eliminar(tratamiento);
    }
    
    @WebMethod(operationName = "tratamiento_obtenerPorId")
        public Tratamiento tratamiento_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.tratamientoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "tratamiento_listarTodos")
    public ArrayList<Tratamiento> tratamiento_listarTodos() {
        return this.tratamientoBO.listarTodos();
    }
    
    @WebMethod(operationName = "tratamiento_listarPorEspecilidad")
    public ArrayList<Tratamiento> tratamiento_listarPorEspecilidad(@WebParam(name = "idEspecialidad") Integer idEspecialidad) {
        return this.tratamientoBO.listarPorEspecialidad(idEspecialidad);
    }
    
}
