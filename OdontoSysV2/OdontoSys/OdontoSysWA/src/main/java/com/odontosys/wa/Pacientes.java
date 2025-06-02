package com.odontosys.wa;

import com.odontosys.bo.PacienteBO;
import com.odontosys.users.model.Paciente;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Pacientes")
public class Pacientes {

    private PacienteBO pacienteBO;
    
    public Pacientes(){
        this.pacienteBO = new PacienteBO();
    }
    
    @WebMethod(operationName = "insertarPaciente")
    public Integer insertarPaciente(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.insertarPaciente(paciente);
    }
    
    @WebMethod(operationName = "modificarPaciente")
    public Integer modificarPaciente(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.modificarPaciente(paciente);
    }
    
    @WebMethod(operationName = "eliminarPaciente")
    public Integer eliminarPaciente(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.eliminarPaciente(paciente);
    }
    
    @WebMethod(operationName = "obtenerPorID")
    public Paciente obtenerPorID(@WebParam(name = "pacienteId") Integer pacienteId) {
        return this.pacienteBO.obtenerPorID(pacienteId);
    }
    
    @WebMethod(operationName = "buscarPorUsuario")
    public Paciente buscarPorUsuario(@WebParam(name = "nombreUsuario") String nombreUsuario) {
        return this.pacienteBO.buscarPorUsuario(nombreUsuario);
    }
    
    @WebMethod(operationName = "listarOdontologos")
    public ArrayList<Paciente> listarOdontologos() {
        return this.pacienteBO.listarOdontologos();
    }
}
