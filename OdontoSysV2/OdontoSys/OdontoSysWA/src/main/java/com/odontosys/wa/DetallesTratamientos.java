package com.odontosys.wa;

import com.odontosys.bo.DetalleTratamientoBO;
import com.odontosys.services.model.DetalleTratamiento;
import jakarta.jws.WebService;
import jakarta.jws.WebMethod;
import jakarta.jws.WebParam;

@WebService(serviceName = "DetallesTratamientos")
public class DetallesTratamientos {

    private DetalleTratamientoBO detalleTratamientoBO;
    
    public DetallesTratamientos(){
        this.detalleTratamientoBO = new DetalleTratamientoBO();
    }
    
    @WebMethod(operationName = "InsertarDetalle")
    public Integer InsertarDetalle(@WebParam(name = "detalle") DetalleTratamiento detalle) {
        return this.detalleTratamientoBO.InsertarDetalle(detalle);
    }
    
    @WebMethod(operationName = "ModificarDetalle")
    public Integer ModificarDetalle(@WebParam(name = "detalle") DetalleTratamiento detalle) {
        return this.detalleTratamientoBO.ModificarDetalle(detalle);
    }
    
    @WebMethod(operationName = "EliminarDetalle")
    public Integer EliminarDetalle(@WebParam(name = "detalle") DetalleTratamiento detalle) {
        return this.detalleTratamientoBO.EliminarDetalle(detalle);
    }
}
