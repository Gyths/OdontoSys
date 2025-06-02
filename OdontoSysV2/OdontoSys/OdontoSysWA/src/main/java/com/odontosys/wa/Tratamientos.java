package com.odontosys.wa;

import com.odontosys.bo.TratamientoBO;
import com.odontosys.services.model.Tratamiento;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Tratamientos")
public class Tratamientos {

    private TratamientoBO tratamientoBO;
    
    public Tratamientos(){
        this.tratamientoBO = new TratamientoBO();
    }
    
    @WebMethod(operationName = "InsertarTratamiento")
    public Integer InsertarTratamiento(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.InsertarTratamiento(tratamiento);
    }
    
    @WebMethod(operationName = "ModificarTratamiento")
    public Integer ModificarTratamiento(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.ModificarTratamiento(tratamiento);
    }
    
    @WebMethod(operationName = "EliminarTratamiento")
    public Integer EliminarTratamiento(@WebParam(name = "tratamiento") Tratamiento tratamiento) {
        return this.tratamientoBO.EliminarTratamiento(tratamiento);
    }
    
    @WebMethod(operationName = "listarTodos")
    public ArrayList<Tratamiento> listarTodos() {
        return this.tratamientoBO.listarTodos();
    }
}
