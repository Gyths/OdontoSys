package com.odontosys.wa;

import com.odontosys.bo.EspecialidadBO;
import com.odontosys.services.model.Especialidad;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Especialidades")
public class Especialidades {

    private EspecialidadBO especialidadBO;
    
    public Especialidades(){
        this.especialidadBO = new EspecialidadBO();
    }
    
    @WebMethod(operationName = "InsertarEspecialidad")
    public Integer InsertarEspecialidad(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.InsertarEspecialidad(especialidad);
    }
    
    @WebMethod(operationName = "ModificarEspecialidad")
    public Integer ModificarEspecialidad(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.ModificarEspecialidad(especialidad);
    }
    
    @WebMethod(operationName = "EliminarEspecialidad")
    public Integer EliminarEspecialidad(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.especialidadBO.EliminarEspecialidad(especialidad);
    }
    
    @WebMethod(operationName = "ListarEspecialidades")
    public ArrayList<Especialidad> ListarEspecialidades() {
        return this.especialidadBO.ListarEspecialidades();
    }
}
