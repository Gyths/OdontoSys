package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.services.ComprobanteBO;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "ComprobanteWA")
public class ComprobanteWA {
    
    private ComprobanteBO comprobanteBO;
    
    public ComprobanteWA(){
        this.comprobanteBO = new ComprobanteBO();
    }
    
    @WebMethod(operationName = "comprobante_insertar")
    public Integer comprobante_insertar(@WebParam(name = "comprobante") Comprobante comprobante) {
        return this.comprobanteBO.insertar(comprobante);
    }
    
    @WebMethod(operationName = "comprobante_modifica")
    public Integer comprobante_modificar(@WebParam(name = "comprobante") Comprobante comprobante) {
        return this.comprobanteBO.modificar(comprobante);
    }
    
    @WebMethod(operationName = "comprobante_eliminar")
    public Integer comprobante_eliminar(@WebParam(name = "comprobante") Comprobante comprobante) {
        return this.comprobanteBO.eliminar(comprobante);
    }
    
    @WebMethod(operationName = "comprobante_obtenerPorId")
    public Comprobante comprobante_obtenerPorId(@WebParam(name = "id") Integer id){
        return this.comprobanteBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "comprobante_listarTodos")
    public ArrayList<Comprobante> comprobantes_listarTodos() {
        return this.comprobanteBO.listarTodos();
    }
    
    @WebMethod(operationName = "comprobante_actualizarTotal")
    public Integer comprobante_actualizarTotal(@WebParam(name = "idCita") Integer idCita){
        return this.comprobanteBO.actualizarTotal(idCita);
    }
            
}
