package com.odontosys.services.model;


public class DetalleTratamiento {
    
    private int idCita;
    private Tratamiento tratamiento;
    private int cantidad;
    private double subtotal;

    public DetalleTratamiento() {
        this.tratamiento = new Tratamiento();
    }

    public int getIdCita() {
        return idCita;
    }

    public void setIdCita(int idCita) {
        this.idCita = idCita;
    }

    public Tratamiento getTratamiento() {
        return tratamiento;
    }

    public void setTratamiento(Tratamiento tratamiento) {
        this.tratamiento = tratamiento;
    }

    public int getCantidad() {
        return cantidad;
    }

    public void setCantidad(int cantidad) {
        this.cantidad = cantidad;
    }

    public double getSubtotal() {
        return subtotal;
    }

    public void setSubtotal(double subtotal) {
        this.subtotal = subtotal;
    }

    @Override
    public String toString() {
        return "DetalleTratamiento{" + "idDetalle=" + idCita + ", tratamiento=" + tratamiento + ", cantidad=" + cantidad + ", subtotal=" + subtotal + '}';
    }
  
}
