package com.odontosys.wa;

import com.odontosys.bo.TurnoXOdontologoBO;
import com.odontosys.infrastructure.model.TurnoXOdontologo;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "TurnosXOdontologo")
public class TurnosXOdontologo {
    
    private TurnoXOdontologoBO turnoXOdontologoBO;
    
    public TurnosXOdontologo(){
        this.turnoXOdontologoBO = new TurnoXOdontologoBO();
    }
    
    @WebMethod(operationName = "InsertarTurnoXOdontologo")
    public Integer InsertarTurnoXOdontologo(@WebParam(name = "turnoXOdontologo") TurnoXOdontologo turnoXOdontologo) {
        return this.turnoXOdontologoBO.InsertarTurnoXOdontologo(turnoXOdontologo);
    }
    
    @WebMethod(operationName = "EliminarTurnoXOdontologo")
    public Integer EliminarTurnoXOdontologo(@WebParam(name = "turnoXOdontologo") TurnoXOdontologo turnoXOdontologo) {
        return this.turnoXOdontologoBO.EliminarTurnoXOdontologo(turnoXOdontologo);
    }
    
    @WebMethod(operationName = "listarPorOdontologo")
    public ArrayList<TurnoXOdontologo> listarPorOdontologo(@WebParam(name = "idOdontologo") Integer idOdontologo) {
        return this.turnoXOdontologoBO.listarPorOdontologo(idOdontologo);
    }
}
