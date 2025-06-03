package com.odontosys.wa;

import com.odontosys.bo.MetodoPagoBO;
import com.odontosys.infrastructure.model.MetodoPago;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;
import java.util.ArrayList;

@WebService(serviceName = "MetodosPago")
public class MetodosPago {

    private MetodoPagoBO metodoPagoBO;
    
    public MetodosPago(){
        this.metodoPagoBO = new MetodoPagoBO();
    }
    
    @WebMethod(operationName = "InsertarMetodoPago")
    public Integer InsertarMetodoPago(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.InsertarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "ModificarMetodoPago")
    public Integer ModificarMetodoPago(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.ModificarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "EliminarMetodoPago")
    public Integer EliminarMetodoPago(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.EliminarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "ListarMetodosPago")
    public ArrayList<MetodoPago> ListarMetodoPago() {
        return this.metodoPagoBO.ListarMetodosDePago();
    }
}
