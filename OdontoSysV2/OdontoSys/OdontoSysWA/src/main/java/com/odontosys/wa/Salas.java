package com.odontosys.wa;

import com.odontosys.bo.SalaBO;
import com.odontosys.infrastructure.model.Sala;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;

@WebService(serviceName = "Salas")
public class Salas {

    private SalaBO salaBO;
    
    public Salas(){
        this.salaBO = new SalaBO();
    }
    
    @WebMethod(operationName = "InsertarSala")
    public Integer InsertarSala(@WebParam(name = "sala") Sala sala) {
        return this.salaBO.InsertarSala(sala);
    }
    
    @WebMethod(operationName = "EliminarSala")
    public Integer EliminarSala(@WebParam(name = "sala") Sala sala) {
        return this.salaBO.EliminarSala(sala);
    }
}
