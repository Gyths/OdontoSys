package pe.pucp.edu.odontosys.services.model;


public class Tratamiento {
    
    private Integer idTratamiento;
    private String nombre;
    private String descripcion;
    private double costo;
    private Especialidad especialidad;

    public Tratamiento() {
        this.especialidad = new Especialidad();
    }

    public Integer getIdTratamiento() {
        return idTratamiento;
    }

    public void setIdTratamiento(Integer idTratamiento) {
        this.idTratamiento = idTratamiento;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getDescripcion() {
        return descripcion;
    }

    public void setDescripcion(String descripcion) {
        this.descripcion = descripcion;
    }

    public double getCosto() {
        return costo;
    }

    public void setCosto(double costo) {
        this.costo = costo;
    }

    public Especialidad getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(Especialidad especialidad) {
        this.especialidad = especialidad;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Tratamiento\n";
        resultado += "----------------\n";
        resultado += "idTratamiento: " + idTratamiento + "\n";
        resultado += "nombre: "         + nombre         + "\n";
        resultado += "descripcion: "    + descripcion    + "\n";
        resultado += "costo: "          + costo          + "\n";
        resultado += "especialidad: "   + especialidad   + "\n";
        resultado += "================\n";
        return resultado;
    }
            
}
