package com.odontosys.wa;

import com.odontosys.bo.OdontologoBO;
import com.odontosys.services.model.Especialidad;
import com.odontosys.users.model.Odontologo;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Odontologos")
public class Odontologos {

    private OdontologoBO odontologoBO;
    
    public Odontologos(){
        this.odontologoBO = new OdontologoBO();
    }
    @WebMethod(operationName = "insertarOdontologo")
    public Integer insertarOdontologo(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.insertarOdontologo(odontologo);
    }
    
    @WebMethod(operationName = "modificarOdontologo")
    public Integer modificarOdontologo(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.modificarOdontologo(odontologo);
    }
    
    @WebMethod(operationName = "eliminarOdontologo")
    public Integer eliminarOdontologo(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.eliminarOdontologo(odontologo);
    }
    
    @WebMethod(operationName = "od_obtenerPorID")
    public Odontologo od_obtenerPorID(@WebParam(name = "odontologoId") Integer odontologoId) {
        return this.odontologoBO.obtenerPorID(odontologoId);
    }
    
    @WebMethod(operationName = "od_buscarPorUsuario")
    public Odontologo od_buscarPorUsuario(@WebParam(name = "odontologoUsuario") String odontologoUsuario) {
        return this.odontologoBO.buscarPorUsuario(odontologoUsuario);
    }
    
    @WebMethod(operationName = "listarPorEspecialidad")
    public ArrayList<Odontologo> listarPorEspecialidad(@WebParam(name = "especialidad") Especialidad especialidad) {
        return this.odontologoBO.listarPorEspecialidad(especialidad);
    }
    
    @WebMethod(operationName = "od_listarOdontologos")
    public ArrayList<Odontologo> od_listarOdontologos() {
        return this.odontologoBO.listarOdontologos();
    }
}
