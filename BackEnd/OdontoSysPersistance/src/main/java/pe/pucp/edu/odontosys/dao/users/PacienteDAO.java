package pe.pucp.edu.odontosys.dao.users;

import pe.pucp.edu.odontosys.users.model.Paciente;
import java.util.ArrayList;

public interface PacienteDAO{
    Integer insertar(Paciente paciente);
    Integer modificar(Paciente paciente);
    Integer eliminar(Paciente paciente);
    Paciente obtenerPorId(Integer id);
    ArrayList<Paciente> listarTodos();
    Paciente obtenerPorUsuarioContrasenha(Paciente paciente);
    Boolean existeNombreUsuario(String nombreUsuario);
}
