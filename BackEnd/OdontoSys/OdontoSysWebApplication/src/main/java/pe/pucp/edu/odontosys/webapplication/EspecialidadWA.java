package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.services.EspecialidadBO;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "EspecialidadWA")
public class EspecialidadWA {

    private EspecialidadBO especialidadBO;
    
    public EspecialidadWA(){
        this.especialidadBO = new EspecialidadBO();
    }
    
    @WebMethod(operationName = "especialidad_insertar")
    public Integer especialidad_insertar(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.insertar(especialidad);
    }
    
    @WebMethod(operationName = "especialidad_modificar")
    public Integer especialidad_modificar(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.modificar(especialidad);
    }
    
    @WebMethod(operationName = "especialidad_eliminar")
    public Integer especialidad_eliminar(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.eliminar(especialidad);
    }
    
    @WebMethod(operationName = "especialidad_obtenerPorId")
    public Especialidad especialidad_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.especialidadBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "especialidad_listarTodos")
    public ArrayList<Especialidad> especialidad_listarTodos() {
        return this.especialidadBO.listarTodos();
    }
}
