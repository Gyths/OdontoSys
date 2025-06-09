package pe.pucp.edu.odontosys.webapplication;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

import pe.pucp.edu.odontosys.bo.services.CitaBO;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.users.model.Recepcionista;

@WebService(serviceName = "CitaWA")
public class CitaWA {

    private CitaBO citaBO;
    
    public CitaWA(){
        this.citaBO = new CitaBO();
    }
    
    @WebMethod(operationName = "cita_insertar")
    public Integer cita_insertar(@WebParam(name = "cita") Cita cita){
        return this.citaBO.insertar(cita);
    }
    
    @WebMethod(operationName = "cita_modificar")
    public Integer modificar(@WebParam(name = "cita") Cita cita){
        return this.citaBO.modificar(cita);
    }

    @WebMethod(operationName = "cita_eliminar")
    public Integer cita_eliminar(@WebParam(name = "cita") Cita cita) {
        return this.citaBO.eliminar(cita);
    }
    
    @WebMethod(operationName = "cita_obtenerPorId")
    public Cita cita_obtenerPorId(@WebParam(name = "id") Integer id){
        return this.citaBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "cita_listarTodos")
    public ArrayList<Cita> cita_listarTodos(){
        return this.citaBO.listarTodos();
    }
    
    @WebMethod(operationName = "cita_listarPorOdontologoFechas")
    public ArrayList<Cita> cita_listarPorOdontologoFechas(@WebParam(name = "odontologo") Odontologo odontologo, @WebParam(name = "fechaInicio") String fechaInicio, @WebParam(name = "fechaFin") String fechaFin){
        return this.citaBO.listarPorOdontologoFechas(odontologo, fechaInicio, fechaFin);
    }
    
    @WebMethod(operationName = "cita_listarPorOdontologo")
    public ArrayList<Cita> cita_listarPorOdontologo(@WebParam(name = "odontologo") Odontologo odontologo){
        return this.citaBO.listarPorOdontologo(odontologo);
    }
    
    @WebMethod(operationName = "cita_listarPorPaciente")
    public ArrayList<Cita> cita_listarPorPaciente(@WebParam(name = "paciente") Paciente paciente){
        return this.citaBO.listarPorPaciente(paciente);
    }
    
    @WebMethod(operationName = "cita_listarPorRecepcionista")
    public ArrayList<Cita> cita_listarPorRecepcionista(@WebParam(name = "recepcionista") Recepcionista recepcionista){
        return this.citaBO.listarPorRecepcionista(recepcionista);
    }
    
    @WebMethod(operationName = "cita_actualizarFkValoracion")
    public Integer cita_actualizarFkValoracion(@WebParam(name = "cita")Cita cita, @WebParam(name = "valoracion") Valoracion valoracion){
        return this.citaBO.actualizarFkValoracion(cita, valoracion);
    }

    @WebMethod(operationName = "cita_calcularDisponibilidad")
    public boolean[][] cita_calcularDisponibilidad(@WebParam(name = "citas") ArrayList<Cita> citas, @WebParam(name = "turnos") ArrayList<Turno> turnos, @WebParam(name = "fechaInicio") String fechaInicio) {
        return this.citaBO.calcularDisponibilidad(citas, turnos, fechaInicio);
    }
    
}
