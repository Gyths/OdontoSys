package pe.pucp.edu.odontosys.services.model;


public class DetalleTratamiento {
    
    private Integer idCita;
    private Tratamiento tratamiento;
    private Integer cantidad;
    private double subtotal;

    public DetalleTratamiento() {
        this.tratamiento = new Tratamiento();
    }

    public Integer getIdCita() {
        return idCita;
    }

    public void setIdCita(Integer idCita) {
        this.idCita = idCita;
    }

    public Tratamiento getTratamiento() {
        return tratamiento;
    }

    public void setTratamiento(Tratamiento tratamiento) {
        this.tratamiento = tratamiento;
    }

    public Integer getCantidad() {
        return cantidad;
    }

    public void setCantidad(Integer cantidad) {
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
        String resultado = "";
        resultado += "================\n";
        resultado += "DetalleTratamiento\n";
        resultado += "----------------\n";
        resultado += "idCita: "       + idCita       + "\n";
        resultado += "tratamiento: "  + tratamiento  + "\n";
        resultado += "cantidad: "     + cantidad     + "\n";
        resultado += "subtotal: "     + subtotal     + "\n";
        resultado += "================\n";
        return resultado;
    }

}
