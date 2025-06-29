package pe.pucp.edu.odontosys.dao.users;

import pe.pucp.edu.odontosys.users.model.Recepcionista;
import java.util.ArrayList;

public interface RecepcionistaDAO{
    Integer insertar(Recepcionista recepcionista);
    Integer modificar(Recepcionista recepcionista);
    Integer eliminar(Recepcionista recepcionista);
    Recepcionista obtenerPorId(Integer id);
    ArrayList<Recepcionista> listarTodos();
    Recepcionista obtenerPorUsuarioContrasenha(Recepcionista recepcionista);
    Boolean existeNombreUsuario(String nombreUsuario);
}
