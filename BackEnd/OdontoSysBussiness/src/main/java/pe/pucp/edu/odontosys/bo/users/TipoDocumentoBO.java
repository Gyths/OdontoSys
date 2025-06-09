package pe.pucp.edu.odontosys.bo.users;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.dao.users.TipoDocumentoDAO;
import pe.pucp.edu.odontosys.daoImp.users.TipoDocumentoDAOImpl;
import pe.pucp.edu.odontosys.users.model.TipoDocumento;

public class TipoDocumentoBO {
    
    private TipoDocumentoDAO tipoDocumentoDAO;

    public TipoDocumentoBO() {
        this.tipoDocumentoDAO = new TipoDocumentoDAOImpl();
    }
    
    public Integer insertar(TipoDocumento tipoDocumento){
        return this.tipoDocumentoDAO.insertar(tipoDocumento);
    }

    public Integer modificar(TipoDocumento tipoDocumento){
        return this.tipoDocumentoDAO.modificar(tipoDocumento);
    }
    
    public Integer eliminar(TipoDocumento tipoDocumento){
        return this.tipoDocumentoDAO.eliminar(tipoDocumento);
    }
    
    public TipoDocumento obtenerPorId(Integer id){
        return this.tipoDocumentoDAO.obtenerPorId(id);
    }
    
    public ArrayList<TipoDocumento> listarTodos(){
        return this.tipoDocumentoDAO.listarTodos();
    }
    
    
    
}
