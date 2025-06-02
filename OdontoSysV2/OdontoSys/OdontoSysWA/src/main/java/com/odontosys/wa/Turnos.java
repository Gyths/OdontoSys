package com.odontosys.wa;

import com.odontosys.bo.TurnoBO;
import com.odontosys.infrastructure.model.Turno;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;

@WebService(serviceName = "Turnos")
public class Turnos {

    private TurnoBO turnoBO;
    
    public Turnos(){
        this.turnoBO = new TurnoBO();
    }
    
    @WebMethod(operationName = "InsertarTurno")
    public Integer InsertarTurno(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.InsertarTurno(turno);
    }
    
    @WebMethod(operationName = "ModificarTurno")
    public Integer ModificarTurno(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.ModificarTurno(turno);
    }
    
    @WebMethod(operationName = "EliminarTurno")
    public Integer EliminarTurno(@WebParam(name = "turno") Turno turno) {
        return this.turnoBO.EliminarTurno(turno);
    }
    
    @WebMethod(operationName = "obtenerPorId")
    public Turno obtenerPorId(@WebParam(name = "idTurno") Integer idTurno) {
        return this.turnoBO.obtenerPorId(idTurno);
    }
}
