package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.services.DetalleTratamientoBO;
import pe.pucp.edu.odontosys.services.model.DetalleTratamiento;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Cita;

@WebService(serviceName = "DetalleTratamientoWA")
public class DetalleTratamientoWA {

    private DetalleTratamientoBO detalleTratamientoBO;
    
    public DetalleTratamientoWA(){
        this.detalleTratamientoBO = new DetalleTratamientoBO();
    }
    
    @WebMethod(operationName = "detalleTratamiento_insertar")
    public Integer detalleTratamiento_insertar(@WebParam(name = "detalleTratamiento") DetalleTratamiento detalleTratamiento) {
        return this.detalleTratamientoBO.insertar(detalleTratamiento);
    }
    
    @WebMethod(operationName = "detalleTratamiento_modificar")
    public Integer detalleTratamiento_modificar(@WebParam(name = "detalleTratamiento") DetalleTratamiento detalleTratamiento) {
        return this.detalleTratamientoBO.modificar(detalleTratamiento);
    }
    
    @WebMethod(operationName = "detalleTratamiento_eliminar")
    public Integer detalleTratamiento_eliminar(@WebParam(name = "detalleTratamiento") DetalleTratamiento detalleTratamiento) {
        return this.detalleTratamientoBO.eliminar(detalleTratamiento);
    }
    
    @WebMethod(operationName = "detalleTratamiento_obtenerPorId")
    public DetalleTratamiento detalleTratamiento_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.detalleTratamientoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "detalleTratamiento_listarTodos")
    public ArrayList<DetalleTratamiento> detalleTratamiento_listarTodos() {
        return this.detalleTratamientoBO.listarTodos();
    }
    
    @WebMethod(operationName = "detalleTratamiento_listarPorCita")
    public ArrayList<DetalleTratamiento> detalleTratamiento_listarPorCita(@WebParam(name = "cita") Cita cita) {
        return this.detalleTratamientoBO.listarPorCita(cita);
    }
    
    @WebMethod(operationName = "detalleTratamiento_actualizarSubtotal")
    public Integer detalleTratamiento_actualizarSubtotal(@WebParam(name = "cita") Cita cita) {
        return this.detalleTratamientoBO.actualizarSubtotal(cita);
    }
    
}
