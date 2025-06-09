package pe.pucp.edu.odontosys.users.model;

public class TipoDocumento {
    
    private Integer idTipoDocumento;
    private String nombre;

    public TipoDocumento() {
    }

    public Integer getIdTipoDocumento() {
        return idTipoDocumento;
    }

    public void setIdTipoDocumento(Integer idTipoDocumento) {
        this.idTipoDocumento = idTipoDocumento;
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
        resultado += "TipoDocumento\n";
        resultado += "----------------\n";
        resultado += "idTipoDocumento: " + idTipoDocumento + "\n";
        resultado += "nombre: " + nombre + "\n";
        resultado += "================\n";
        return resultado;
    }
    
}
