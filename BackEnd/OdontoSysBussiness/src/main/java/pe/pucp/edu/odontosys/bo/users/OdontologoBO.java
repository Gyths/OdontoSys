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

    public ArrayList<Odontologo> listarPorEspecialidad(Especialidad especialidad){
        return this.odontologoDAO.listarPorEspecialidad(especialidad);
    }
    
    public Odontologo obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha){
        return this.odontologoDAO.obtenerPorUsuarioContrasenha(nombreUsuario, contrasenha);
    }
    
    public Integer actualizarPuntuacion(Odontologo odontologo){
        return this.odontologoDAO.actualizarPuntuacion(odontologo);
    }
    
    public Boolean verificarExistenciaNombreUsuario(String nombreUsuario){
        return this.odontologoDAO.existeNombreUsuario(nombreUsuario);
    }
}
