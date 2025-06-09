package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.infrastructure.TurnoBO;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.users.model.Odontologo;


@WebService(serviceName = "TurnoWA")
public class TurnoWA {

    private TurnoBO turnoBO;
    
    public TurnoWA(){
        this.turnoBO = new TurnoBO();
    }
    
    @WebMethod(operationName = "turno_insertar")
    public Integer turno_insertar(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.insertar(turno);
    }
    
    @WebMethod(operationName = "turno_modificar")
    public Integer turno_modificar(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.modificar(turno);
    }
    
    @WebMethod(operationName = "turno_eliminar")
    public Integer turno_eliminar(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.eliminar(turno);
    }
    
    @WebMethod(operationName = "turno_obtenerPorId")
    public Turno turno_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.turnoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "turno_listarTodos")
    public ArrayList<Turno> turno_listarTodos(){
        return this.turnoBO.listarTodos();
    }
    
    @WebMethod(operationName = "turno_listarPorOdontologo")
    public ArrayList<Turno> turno_listarPorOdontologo(@WebParam(name = "odontologo") Odontologo odontologo){
        return this.turnoBO.listarPorOdontologo(odontologo);
    }
    
}
