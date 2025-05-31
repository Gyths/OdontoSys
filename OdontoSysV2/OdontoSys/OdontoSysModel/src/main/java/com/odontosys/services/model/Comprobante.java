package com.odontosys.services.model;

import java.time.LocalDate;
import java.time.LocalTime;
import com.odontosys.infrastructure.model.MetodoPago;

public class Comprobante {
    
    private int idComprobante;
    private LocalDate fechaEmision;
    private LocalTime horaEmision;
    private double total;
    private MetodoPago metodoDePago;

    public Comprobante() {
        this.metodoDePago = new MetodoPago();
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

    public LocalTime getHoraEmision() {
        return horaEmision;
    }

    public void setHoraEmision(LocalTime horaEmision) {
        this.horaEmision = horaEmision;
    }

    public double getTotal() {
        return total;
    }

    public void setTotal(double total) {
        this.total = total;
    }

    public MetodoPago getMetodoDePago() {
        return metodoDePago;
    }

    public void setMetodoDePago(MetodoPago metodoDePago) {
        this.metodoDePago = metodoDePago;
    }

    @Override
    public String toString() {
        return "Comprobante{" + "idComprobante=" + idComprobante + ", fechaEmision=" + fechaEmision + ", horaEmision=" + horaEmision + ", total=" + total + ", metodoDePago=" + metodoDePago + '}';
    }
    
}
