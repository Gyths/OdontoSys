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
    Odontologo obtenerPorUsuarioContrasenha(Odontologo odontologo);
    ArrayList<Odontologo> buscarPorNombreApellido(Odontologo odontologo);
    ArrayList<Odontologo> buscarPorNombreApellidoDocumento(Odontologo odontologo);
    Boolean existeNombreUsuario(String nombreUsuario);
    Odontologo obtenerCompletoPorId(Odontologo odontologo);
}
