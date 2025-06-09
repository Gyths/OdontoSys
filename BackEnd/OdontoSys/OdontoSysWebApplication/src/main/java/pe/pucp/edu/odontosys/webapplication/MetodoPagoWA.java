package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.infrastructure.MetodoPagoBO;
import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "MetodoPagoWA")
public class MetodoPagoWA {

    private MetodoPagoBO metodoPagoBO;
    
    public MetodoPagoWA(){
        this.metodoPagoBO = new MetodoPagoBO();
    }
    
    @WebMethod(operationName = "metodoPago_insertar")
    public Integer metodoPago_insertar(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.insertar(metodoPago);
    }
    
    @WebMethod(operationName = "metodoPago_modificar")
    public Integer metodoPago_modificar(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.modificar(metodoPago);
    }
    
    @WebMethod(operationName = "metodoPago_eliminar")
    public Integer metodoPago_eliminar(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.eliminar(metodoPago);
    }
    
    @WebMethod(operationName = "metodoPago_obtenerPorId")
    public MetodoPago metodoPago_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.metodoPagoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "metodoPago_listarTodos")
    public ArrayList<MetodoPago> metodoPago_listarTodos() {
        return this.metodoPagoBO.listarTodos();
    }
}
