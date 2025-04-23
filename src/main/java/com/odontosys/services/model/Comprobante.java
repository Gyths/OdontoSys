package com.odontosys.services.model;

/*
 * @author Grupo04_0682
 */
import com.odontosys.infraestructure.model.MetodoPago;
import java.util.Date;


public class Comprobante {

    private int idComprobante;
    private Date fechaEmision;
    private double total;
    private MetodoPago metodoDePago;

    public Comprobante() {
    }

    public int getIdComprobante() {
        return idComprobante;
    }

    public void setIdComprobante(int idComprobante) {
        this.idComprobante = idComprobante;
    }

    public Date getFechaEmision() {
        return fechaEmision;
    }

    public void setFechaEmision(Date fechaEmision) {
        this.fechaEmision = fechaEmision;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public MetodoPago getMetodoPago() {
        return metodoDePago;
    }

    public void setMetodoPago(MetodoPago metodoDePago) {
        this.metodoDePago = metodoDePago;
    }
}
