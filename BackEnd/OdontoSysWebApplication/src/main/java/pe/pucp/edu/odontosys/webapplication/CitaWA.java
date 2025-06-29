package pe.pucp.edu.odontosys.webapplication;

import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

import pe.pucp.edu.odontosys.bo.services.CitaBO;
import pe.pucp.edu.odontosys.services.model.Cita;

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
    public ArrayList<Cita> cita_listarPorOdontologoFechas(@WebParam(name = "idOdontologo") Integer idOdontologo, @WebParam(name = "fechaInicio") String fechaInicio, @WebParam(name = "fechaFin") String fechaFin){
        return this.citaBO.listarPorOdontologoFechas(idOdontologo, fechaInicio, fechaFin);
    }
    
    @WebMethod(operationName = "cita_listarPorOdontologo")
    public ArrayList<Cita> cita_listarPorOdontologo(@WebParam(name = "idOdontologo") Integer idOdontologo){
        return this.citaBO.listarPorOdontologo(idOdontologo);
    }
    
    @WebMethod(operationName = "cita_listarPorPaciente")
    public ArrayList<Cita> cita_listarPorPaciente(@WebParam(name = "idPaciente") Integer idPaciente){
        return this.citaBO.listarPorPaciente(idPaciente);
    }
    
    @WebMethod(operationName = "cita_listarPorPacienteFechas")
    public ArrayList<Cita> cita_listarPorPacienteFechas(@WebParam(name = "idPaciente") Integer idPaciente, @WebParam(name = "fechaInicio") String fechaInicio, @WebParam(name = "fechaFin") String fechaFin){
        return this.citaBO.listarPorPacienteFechas(idPaciente, fechaInicio, fechaFin);
    }
    
}
