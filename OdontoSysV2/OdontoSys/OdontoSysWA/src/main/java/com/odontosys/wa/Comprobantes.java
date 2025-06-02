package com.odontosys.wa;

import com.odontosys.bo.ComprobanteBO;
import com.odontosys.services.model.Comprobante;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "Comprobantes")
public class Comprobantes {
    
    private ComprobanteBO comprobanteBO;
    
    public Comprobantes(){
        this.comprobanteBO = new ComprobanteBO();
    }
    
    @WebMethod(operationName = "InsertComprobante")
    public int InsertComprobante(@WebParam(name = "comprobante") Comprobante comprobante) {
        return this.comprobanteBO.InsertComprobante(comprobante);
    }
    
    @WebMethod(operationName = "EliminarComprobante")
    public int EliminarComprobante(@WebParam(name = "comprobante") Comprobante comprobante) {
        return this.comprobanteBO.EliminarComprobante(comprobante);
    }
    
    @WebMethod(operationName = "InsertComprobante")
    public ArrayList<Comprobante> ListarTodos() {
        return this.comprobanteBO.ListarTodos();
    }
}
