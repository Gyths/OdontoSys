package pe.pucp.edu.odontosys.infrastructure.model;

public class MetodoPago {
    private Integer idMetodoPago;
    private String nombre;
    
    public MetodoPago(){
    }

    public Integer getIdMetodoPago() {
        return idMetodoPago;
    }

    public void setIdMetodoPago(Integer idMetodoPago) {
        this.idMetodoPago = idMetodoPago;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }
    
    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "MetodoPago\n";
        resultado += "----------------\n";
        resultado += "idMetodoPago: " + idMetodoPago + "\n";
        resultado += "nombre: " + nombre + "\n";
        resultado += "================\n";
        return resultado;
    }

}
