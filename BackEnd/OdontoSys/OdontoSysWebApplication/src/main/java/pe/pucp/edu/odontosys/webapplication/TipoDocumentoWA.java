package pe.pucp.edu.odontosys.webapplication;

import pe.pucp.edu.odontosys.bo.users.TipoDocumentoBO;
import pe.pucp.edu.odontosys.users.model.TipoDocumento;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;


@WebService(serviceName = "TipoDocumentoWA")
public class TipoDocumentoWA {
    
    private TipoDocumentoBO tipoDocumentoBO;
    
    public TipoDocumentoWA(){
        this.tipoDocumentoBO = new TipoDocumentoBO();
    }
    
    @WebMethod(operationName = "tipoDocumento_insertar")
    public Integer tipoDocumento_insertar(@WebParam(name = "tipoDocumento") TipoDocumento tipoDocumento) {
        return this.tipoDocumentoBO.insertar(tipoDocumento);
    }
    
    @WebMethod(operationName = "tipoDocumento_modificar")
    public Integer tipoDocumento_modificar(@WebParam(name = "tipoDocumento") TipoDocumento tipoDocumento) {
        return this.tipoDocumentoBO.modificar(tipoDocumento);
    }
    
    @WebMethod(operationName = "tipoDocumento_eliminar")
    public Integer tipoDocumento_eliminar(@WebParam(name = "tipoDocumento") TipoDocumento tipoDocumento) {
        return this.tipoDocumentoBO.eliminar(tipoDocumento);
    }
    
    @WebMethod(operationName = "tipoDocumento_obtenerPorId")
    public TipoDocumento tipoDocumento_obtenerPorId(@WebParam(name = "id") Integer id) {
        return this.tipoDocumentoBO.obtenerPorId(id);
    }
    
    @WebMethod(operationName = "tipoDocumento_listarTodos")
    public ArrayList<TipoDocumento> tipoDocumento_listarTodos() {
        return this.tipoDocumentoBO.listarTodos();
    }
    
}
