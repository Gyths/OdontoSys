package pe.pucp.edu.odontosys.services.model;

import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;

public class Comprobante {
    
    private Integer idComprobante;
    private String fechaEmision;
    private String horaEmision;
    private double total;
    private MetodoPago metodoDePago;

    public Comprobante() {
        this.metodoDePago = new MetodoPago();
    }

    public Integer getIdComprobante() {
        return idComprobante;
    }

    public void setIdComprobante(Integer idComprobante) {
        this.idComprobante = idComprobante;
    }

    public String getFechaEmision() {
        return fechaEmision;
    }

    public void setFechaEmision(String fechaEmision) {
        this.fechaEmision = fechaEmision;
    }

    public String getHoraEmision() {
        return horaEmision;
    }

    public void setHoraEmision(String horaEmision) {
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
        String resultado = "";
        resultado += "================\n";
        resultado += "Comprobante\n";
        resultado += "----------------\n";
        resultado += "idComprobante: " + idComprobante  + "\n";
        resultado += "fechaEmision: "  + fechaEmision   + "\n";
        resultado += "horaEmision: "   + horaEmision    + "\n";
        resultado += "total: "          + total           + "\n";
        resultado += "metodoDePago: "   + "\n"; 
        resultado += metodoDePago;    
        resultado += "================\n";
        return resultado;
    }

    
}
