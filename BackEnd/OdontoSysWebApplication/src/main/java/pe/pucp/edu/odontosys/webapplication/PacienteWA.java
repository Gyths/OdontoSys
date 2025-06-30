package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.users.PacienteBO;
import pe.pucp.edu.odontosys.users.model.Paciente;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;
import net.sf.jasperreports.engine.JRException;
import pe.pucp.edu.odontosys.webapplication.reports.ReporteUtil;

@WebService(serviceName = "PacienteWA")
public class PacienteWA {

    private PacienteBO pacienteBO;
    
    public PacienteWA(){
        this.pacienteBO = new PacienteBO();
    }
    
    @WebMethod(operationName = "paciente_insertar")
    public Integer paciente_insertar(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.insertar(paciente);
    }
    
    @WebMethod(operationName = "paciente_modificar")
    public Integer paciente_modificar(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.modificar(paciente);
    }
    
    @WebMethod(operationName = "paciente_eliminar")
    public Integer paciente_eliminar(@WebParam(name = "paciente") Paciente paciente) {
        return this.pacienteBO.eliminar(paciente);
    }
    
    @WebMethod(operationName = "paciente_obtenerPorId")
    public Paciente paciente_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.pacienteBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "paciente_listarTodos")
    public ArrayList<Paciente> paciente_listarTodos() {
        return this.pacienteBO.listarTodos();
    }
    
    @WebMethod(operationName = "paciente_obtenerPorUsuarioContrasenha")
    public Paciente paciente_obtenerPorUsuarioContrasenha(@WebParam(name = "nombreUsuario") String nombreUsuario, @WebParam(name = "contrasenha") String contrasenha){
        return this.pacienteBO.obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
    }
    
    @WebMethod(operationName = "paciente_verificarExistenciaNombreUsuario")
    public Boolean paciente_verificarExistenciaNombreUsuario(@WebParam(name = "nombreUsuario") String nombreUsuario){
        return this.pacienteBO.verificarExistenciaNombreUsuario(nombreUsuario);
    }
    
    @WebMethod(operationName = "paciente_buscarPorNombreApellido")
    public ArrayList<Paciente> paciente_buscarPorNombreApellido(@WebParam(name = "nombre") String nombre, @WebParam(name = "apellido") String apellido){
        return this.pacienteBO.buscarPorNombreApellido(nombre, apellido);
    }
    
    @WebMethod(operationName = "paciente_buscarPorNombreApellidoDocumento")
    public ArrayList<Paciente> paciente_buscarPorNombreApellidoDocumento(@WebParam(name = "nombre") String nombre, @WebParam(name = "apellido") String apellido, @WebParam(name = "documento") String documento){
        return this.pacienteBO.buscarPorNombreApellidoDocumento(nombre, apellido, documento);
    }
    
    @WebMethod(operationName = "paciente_buscarPorNombreApellidoTelefono")
    public ArrayList<Paciente> paciente_buscarPorNombreApellidoTelefono(@WebParam(name = "nombre") String nombre, @WebParam(name = "apellido") String apellido, @WebParam(name = "telefono") String telefono){
        return this.pacienteBO.buscarPorNombreApellidoTelefono(nombre, apellido, telefono);
    }
    @WebMethod(operationName = "reporteHistoriaClinica")
    public byte[]reporteHistoriaClinica(@WebParam(name = "pacienteId") Integer pacienteId) throws JRException{
        return ReporteUtil.reporteHistoriaClinica(pacienteId);
    }
}
