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
    
    @WebMethod(operationName = "InsertarEspecialidad")
    public Integer InsertarEspecialidad(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.InsertarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "ModificarEspecialidad")
    public Integer ModificarEspecialidad(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.ModificarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "EliminarEspecialidad")
    public Integer EliminarEspecialidad(@WebParam(name = "metodoPago") MetodoPago metodoPago) {
        return this.metodoPagoBO.EliminarMetodoPago(metodoPago);
    }
    
    @WebMethod(operationName = "ListarEspecialidades")
    public ArrayList<MetodoPago> ListarEspecialidades() {
        return this.metodoPagoBO.ListarMetodosDePago();
    }
}
