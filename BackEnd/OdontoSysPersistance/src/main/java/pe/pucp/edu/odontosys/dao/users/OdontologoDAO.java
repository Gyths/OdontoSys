package pe.pucp.edu.odontosys.dao.users;

import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.util.ArrayList;

public interface OdontologoDAO{
    Integer insertar(Odontologo odontologo);
    Integer modificar(Odontologo odontologo);
    Integer eliminar(Odontologo odontologo);
    Odontologo obtenerPorId(Integer id);
    ArrayList<Odontologo> listarTodos();
    ArrayList<Odontologo> listarPorEspecialidad(Especialidad especialidad);
    Odontologo obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha);
    Integer actualizarPuntuacion(Odontologo odontologo);
    Boolean existeNombreUsuario(String nombreUsuario);
    ArrayList<Odontologo> buscarPorNombreApellido(String nombre, String apellido);
    ArrayList<Odontologo> buscarPorNombreApellidoDocumento(String nombre, String apellido, String documento);
    ArrayList<Odontologo> buscarPorNombreApellidoTelefono(String nombre, String apellido, String telefono);
}
