package pe.pucp.edu.odontosys.dao.users;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.users.model.TipoDocumento;

public interface TipoDocumentoDAO {
    Integer insertar(TipoDocumento tipoDocumento);
    Integer modificar(TipoDocumento tipoDocumento);
    Integer eliminar(TipoDocumento tipoDocumento);
    TipoDocumento obtenerPorId(Integer id);
    ArrayList<TipoDocumento> listarTodos();
}
