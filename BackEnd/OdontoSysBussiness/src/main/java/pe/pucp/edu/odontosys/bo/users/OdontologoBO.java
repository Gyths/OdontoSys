package pe.pucp.edu.odontosys.bo.users;

import pe.pucp.edu.odontosys.dao.users.OdontologoDAO;
import pe.pucp.edu.odontosys.daoImp.users.OdontologoDAOImpl;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public class OdontologoBO {
    private OdontologoDAO odontologoDAO;
    
    public OdontologoBO(){
        this.odontologoDAO = new OdontologoDAOImpl();
    }
    
    public Integer insertar(Odontologo odontologo){
        return this.odontologoDAO.insertar(odontologo);
    }
    
    public Integer modificar(Odontologo odontologo){
       return this.odontologoDAO.modificar(odontologo);
    }
    
    public Integer eliminar(Odontologo odontologo){
       return this.odontologoDAO.eliminar(odontologo);
    }
    
    public Odontologo obtenerPorId(Integer id){
        return this.odontologoDAO.obtenerPorId(id);
    }
    
    public ArrayList<Odontologo> listarTodos(){
        return this.odontologoDAO.listarTodos();
    }

    public ArrayList<Odontologo> listarPorEspecialidad(Integer idEspecialidad){
        Especialidad especialidad = new Especialidad();
        especialidad.setIdEspecialidad(idEspecialidad);
        return this.odontologoDAO.listarPorEspecialidad(especialidad);
    }
    
    public Odontologo obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha){
        Odontologo odontologo = new Odontologo();
        odontologo.setNombreUsuario(nombreUsuario);
        odontologo.setContrasenha(contrasenha);
        return this.odontologoDAO.obtenerPorUsuarioContrasenha(odontologo);
    }

    public ArrayList<Odontologo> buscarPorNombreApellido(String nombre, String apellido){
        Odontologo odontologo = new Odontologo();
        odontologo.setNombre(nombre);
        odontologo.setApellidos(apellido);
        return this.odontologoDAO.buscarPorNombreApellido(odontologo);
    }
    
    public ArrayList<Odontologo> buscarPorNombreApellidoDocumento(String nombre, String apellido, String documento){
        Odontologo odontologo = new Odontologo();
        odontologo.setNombre(nombre);
        odontologo.setApellidos(apellido);
        odontologo.setNumeroDocumento(documento);
        return this.odontologoDAO.buscarPorNombreApellidoDocumento(odontologo);
    }

    public Boolean verificarExistenciaNombreUsuario(String nombreUsuario){
        return this.odontologoDAO.existeNombreUsuario(nombreUsuario);
    }
    
}
