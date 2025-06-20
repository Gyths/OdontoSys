package pe.pucp.edu.odontosys.services.model;


public class Valoracion {
    
    private Integer idValoracion;
    private String comentario;
    private Integer calicicacion;
    private String fechaCalificacion;

    public Valoracion() {
    }

    public Integer getIdValoracion() {
        return idValoracion;
    }

    public void setIdValoracion(Integer idValoracion) {
        this.idValoracion = idValoracion;
    }

    public String getComentario() {
        return comentario;
    }

    public void setComentario(String comentario) {
        this.comentario = comentario;
    }

    public Integer getCalicicacion() {
        return calicicacion;
    }

    public void setCalicicacion(Integer calicicacion) {
        this.calicicacion = calicicacion;
    }

    public String getFechaCalificacion() {
        return fechaCalificacion;
    }

    public void setFechaCalificacion(String fechaCalificacion) {
        this.fechaCalificacion = fechaCalificacion;
    }
    
    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Valoracion\n";
        resultado += "----------------\n";
        resultado += "idValoracion: "      + idValoracion      + "\n";
        resultado += "comentario: "        + comentario        + "\n";
        resultado += "calicicacion: "      + calicicacion      + "\n";
        resultado += "fechaCalificacion: " + fechaCalificacion + "\n";
        resultado += "================\n";
        return resultado;
    }
    
}
