package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.services.ValoracionBO;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.users.model.Paciente;


@WebService(serviceName = "ValoracionWA")
public class ValoracionWA {
    
    private ValoracionBO valoracionBO;
    
    public ValoracionWA(){
        this.valoracionBO = new ValoracionBO();
    }
    
    @WebMethod(operationName = "valoracion_insertar")
    public Integer valoracion_insertar(@WebParam(name = "valoracion") Valoracion valoracion) {
        return this.valoracionBO.insertar(valoracion);
    }
    
    @WebMethod(operationName = "valoracion_modificar")
    public Integer valoracion_modificar(@WebParam(name = "valoracion") Valoracion valoracion) {
        return this.valoracionBO.modificar(valoracion);
    }
    
    @WebMethod(operationName = "valoracion_eliminar")
    public Integer valoracion_eliminar(@WebParam(name = "valoracion") Valoracion valoracion) {
        return this.valoracionBO.eliminar(valoracion);
    }
    
    @WebMethod(operationName = "valoracion_obtenerPorId")
    public Valoracion valoracion_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.valoracionBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "valoracion_listarTodos")
    public ArrayList<Valoracion> valoracion_listarTodos() {
        return this.valoracionBO.listarTodos();
    }
    
    @WebMethod(operationName = "valoracion_listarPorOdontologo")
    public ArrayList<Valoracion> valoracion_listarPorOdontologo(@WebParam(name = "odontologo") Odontologo odontologo){
        return this.valoracionBO.listarPorOdontologo(odontologo);
    }
    
    @WebMethod(operationName = "valoracion_listarPorPaciente")
    public ArrayList<Valoracion> valoracion_listarPorPaciente(@WebParam(name = "paciente") Paciente paciente){
        return this.valoracionBO.listarPorPaciente(paciente);
    }
    
}
