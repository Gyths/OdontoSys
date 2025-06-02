package com.odontosys.wa;

import com.odontosys.bo.CitaBO;
import com.odontosys.infrastructure.model.Turno;
import com.odontosys.services.model.Cita;
import com.odontosys.users.model.Odontologo;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Citas")
public class Citas {

    private CitaBO citaBO;
    
    public Citas(){
        this.citaBO = new CitaBO();
    }
    
    @WebMethod(operationName = "insertCita")
    public Integer insertCita(@WebParam(name = "cita") Cita cita) {
        return this.citaBO.insertCita(cita);
    }
    
    @WebMethod(operationName = "modificarCita")
    public Integer modificarCita(@WebParam(name = "cita") Cita cita) {
        return this.citaBO.modificarCita(cita);
    }
    
    @WebMethod(operationName = "eliminarCita")
    public Integer eliminarCita(@WebParam(name = "cita") Cita cita) {
        return this.citaBO.eliminarCita(cita);
    }
    
    @WebMethod(operationName = "listarPorOdontologo")
    public ArrayList<Cita> listarPorOdontologo(@WebParam(name = "odontologo") Odontologo odontologo, @WebParam(name = "fechaInicio") String fechaInicio, @WebParam(name = "fechaFin") String fechaFin) {
        return this.citaBO.listarPorOdontologo(odontologo, fechaInicio, fechaFin);
    }
    
    @WebMethod(operationName = "insertCita")
    public boolean[][] calcularDisponibilidad(@WebParam(name = "citas") ArrayList<Cita> citas, @WebParam(name = "turnos") ArrayList<Turno> turnos, @WebParam(name = "fechaInicio") String fechaInicio) {
        return this.citaBO.calcularDisponibilidad(citas, turnos, fechaInicio);
    }
}
