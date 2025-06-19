package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.users.OdontologoBO;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "OdontologoWA")
public class OdontologoWA {

    private OdontologoBO odontologoBO;
    
    public OdontologoWA(){
        this.odontologoBO = new OdontologoBO();
    }
    
    @WebMethod(operationName = "odontologo_insertar")
    public Integer odontologo_insertar(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.insertar(odontologo);
    }
    
    @WebMethod(operationName = "odontologo_modificar")
    public Integer odontologo_modificar(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.modificar(odontologo);
    }
    
    @WebMethod(operationName = "odontologo_eliminar")
    public Integer odontologo_eliminar(@WebParam(name = "odontologo") Odontologo odontologo) {
        return this.odontologoBO.eliminar(odontologo);
    }
    
    @WebMethod(operationName = "odontologo_obtenerPorId")
    public Odontologo odontologo_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.odontologoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "odontologo_listarTodos")
    public ArrayList<Odontologo> odontologo_listarTodos() {
        return this.odontologoBO.listarTodos();
    }
    
    @WebMethod(operationName = "odontologo_listarPorEspecialidad")
    public ArrayList<Odontologo> odontologo_listarPorEspecialidad(@WebParam(name = "especialidad") Especialidad especialidad){
        return this.odontologoBO.listarPorEspecialidad(especialidad);
    }
    
    @WebMethod(operationName = "odontologo_obtenerPorUsuarioContrasenha")
    public Odontologo odontologo_obtenerPorUsuarioContrasenha(@WebParam(name = "nombreUsuario") String nombreUsuario, @WebParam(name = "contrasenha") String contrasenha){
        return this.odontologoBO.obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
    }
    
    @WebMethod(operationName = "odontologo_actualizarPuntuacion")
    public Integer odontologo_actualizarPuntuacion(@WebParam(name = "odontologo") Odontologo odontologo){
        return this.odontologoBO.actualizarPuntuacion(odontologo);
    }
    
    @WebMethod(operationName = "odontologo_verificarExistenciaNombreUsuario")
    public Boolean odontologo_verificarExistenciaNombreUsuario(@WebParam(name = "nombreUsuario") String nombreUsuario){
        return this.odontologoBO.verificarExistenciaNombreUsuario(nombreUsuario);
    }
}
