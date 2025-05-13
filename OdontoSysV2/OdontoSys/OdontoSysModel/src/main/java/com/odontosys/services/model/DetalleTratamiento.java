package com.odontosys.services.model;


public class DetalleTratamiento {
    
    private int idDetalle;
    private Tratamiento tratamiento;
    private int cantidad;
    private double subtotal;

    public DetalleTratamiento() {
    }

    public int getIdDetalle() {
        return idDetalle;
    }

    public void setIdDetalle(int idDetalle) {
        this.idDetalle = idDetalle;
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
        return "DetalleTratamiento{" + "idDetalle=" + idDetalle + ", tratamiento=" + tratamiento + ", cantidad=" + cantidad + ", subtotal=" + subtotal + '}';
    }
  
}
