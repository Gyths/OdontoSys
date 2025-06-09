package pe.pucp.edu.odontosys.services.model;

public class Especialidad {
    private Integer idEspecialidad;
    private String nombre;
    
    public Especialidad(){
    }
    
    public Integer getIdEspecialidad() {
        return idEspecialidad;
    }

    public void setIdEspecialidad(int idEspecialidad) {
        this.idEspecialidad = idEspecialidad;
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
        resultado += "Especialidad\n";
        resultado += "----------------\n";
        resultado += "idEspecialidad: " + idEspecialidad + "\n";
        resultado += "nombre: "           + nombre           + "\n";
        resultado += "================\n";
        return resultado;
    }
    
}
