package pe.pucp.edu.odontosys.bo.users;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.dao.users.PacienteDAO;
import pe.pucp.edu.odontosys.daoImp.users.PacienteDAOImpl;
import java.util.ArrayList;

public class PacienteBO {
    private PacienteDAO pacienteDAO;
    
    public PacienteBO(){
        this.pacienteDAO = new PacienteDAOImpl();
    }
    
    public Integer insertar(Paciente paciente){
        return this.pacienteDAO.insertar(paciente);
    }
    
    public Integer modificar(Paciente paciente){
       return this.pacienteDAO.modificar(paciente);
    }
    
    public Integer eliminar(Paciente paciente){
       return this.pacienteDAO.eliminar(paciente);
    }
    
    public Paciente obtenerPorId(Integer id){
       return this.pacienteDAO.obtenerPorId(id);
    }
    
    public ArrayList<Paciente> listarTodos(){
        return this.pacienteDAO.listarTodos();
    }

    public Paciente obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha){
        Paciente paciente = new Paciente();
        paciente.setNombreUsuario(nombreUsuario);
        paciente.setContrasenha(contrasenha);
        return this.pacienteDAO.obtenerPorUsuarioContrasenha(paciente);
    }
    
    public Boolean verificarExistenciaNombreUsuario(String nombreUsuario){
        return this.pacienteDAO.existeNombreUsuario(nombreUsuario);
    }
    
    public ArrayList<Paciente> buscarPorNombreApellido(String nombre, String apellido){
        Paciente paciente = new Paciente();
        paciente.setNombre(nombre);
        paciente.setApellidos(apellido);
        return this.pacienteDAO.buscarPorNombreApellido(paciente);
    }
    
    public ArrayList<Paciente> buscarPorNombreApellidoDocumento(String nombre, String apellido, String documento){
        Paciente paciente = new Paciente();
        paciente.setNombre(nombre);
        paciente.setApellidos(apellido);
        paciente.setNumeroDocumento(documento);
        return this.pacienteDAO.buscarPorNombreApellidoDocumento(paciente);
    }
    
    public ArrayList<Paciente> buscarPorNombreApellidoTelefono(String nombre, String apellido, String telefono){
        Paciente paciente = new Paciente();
        paciente.setNombre(nombre);
        paciente.setApellidos(apellido);
        paciente.setTelefono(telefono);
        return this.pacienteDAO.buscarPorNombreApellidoTelefono(paciente);
    }

}
