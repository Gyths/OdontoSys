package com.mycompany.odontosys.backend;

/*
 * @author Grupo04_0682
 */

import java.time.LocalDate;

public class Comprobante {

    private int idComprobante;
    private LocalDate fechaEmision;
    private double total;
    private double importeCancelado;
    private String metodoPago;

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

    public String getMetodoPago() {
        return metodoPago;
    }

    public void setMetodoPago(String metodoPago) {
        this.metodoPago = metodoPago;
    }
}
