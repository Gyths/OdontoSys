package com.odontosys.services.model;

/*
 * @author Grupo04_0682
 */
import com.odontosys.infraestructure.model.MetodoPago;
import java.time.LocalDate;

public class Comprobante {

    private int idComprobante;
    private LocalDate fechaEmision;
    private double total;
    private double importeCancelado;
    private MetodoPago metodoDePago;

    public Comprobante() {
    }

    public int getIdComprobante() {
        return idComprobante;
    }

    public void setIdComprobante(int idComprobante) {
        this.idComprobante = idComprobante;
    }

    public LocalDate getFechaEmision() {
        return fechaEmision;
    }

    public void setFechaEmision(LocalDate fechaEmision) {
        this.fechaEmision = fechaEmision;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public double getImporteCancelado() {
        return importeCancelado;
    }

    public void setImporteCancelado(double importeCancelado) {
        this.importeCancelado = importeCancelado;
    }

    public MetodoPago getMetodoPago() {
        return metodoDePago;
    }

    public void setMetodoPago(MetodoPago metodoDePago) {
        this.metodoDePago = metodoDePago;
    }
}
