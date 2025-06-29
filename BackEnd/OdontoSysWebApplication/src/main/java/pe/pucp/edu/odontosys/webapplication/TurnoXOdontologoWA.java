package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.infrastructure.TurnoXOdontologoBO;
import pe.pucp.edu.odontosys.infrastructure.model.TurnoXOdontologo;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "TurnoXOdontologoWA")
public class TurnoXOdontologoWA {
    
    private TurnoXOdontologoBO turnoXOdontologoBO;
    
    public TurnoXOdontologoWA(){
        this.turnoXOdontologoBO = new TurnoXOdontologoBO();
    }
    
    @WebMethod(operationName = "turnoXOdontologo_insertar")
    public Integer turnoXOdontologo_insertar(@WebParam(name = "turnoXOdontologo") TurnoXOdontologo turnoXOdontologo) {
        return this.turnoXOdontologoBO.insertar(turnoXOdontologo);
    }
    
    @WebMethod(operationName = "turnoXOdontologo_modificar")
    public Integer turnoXOdontologo_modificar(@WebParam(name = "turnoXOdontologo") TurnoXOdontologo turnoXOdontologo) {
        return this.turnoXOdontologoBO.modificar(turnoXOdontologo);
    }
    
    @WebMethod(operationName = "turnoXOdontologo_eliminar")
    public Integer turnoXOdontologo_eliminar(@WebParam(name = "idOdontologo") Integer idOdontologo, @WebParam(name = "idTurno") Integer idTurno) {
        return this.turnoXOdontologoBO.eliminar(idOdontologo, idTurno);
    }
    
    @WebMethod(operationName = "turnoXOdontologo_listarTodos")
    public ArrayList<TurnoXOdontologo> turnoXOdontologo_listarTodos(){
        return this.turnoXOdontologoBO.listarTodos();
    }
    
}
