package pe.pucp.edu.odontosys.users.model;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.infrastructure.model.Sala;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;

public class Odontologo extends Persona{

    private Integer idOdontologo;
    private Especialidad especialidad;
    private double puntuacionPromedio;
    private Sala consultorio;
    private ArrayList<Cita> citas;
    private ArrayList<Turno> turnos;

    public Odontologo() {
        super();
        this.especialidad = new Especialidad();
        this.consultorio = new Sala();
        this.citas = new ArrayList<Cita>();
        this.turnos = new ArrayList<Turno>();
    }

    public Integer getIdOdontologo() {
        return idOdontologo;
    }

    public void setIdOdontologo(Integer idOdontologo) {
        this.idOdontologo = idOdontologo;
    }

    public Especialidad getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(Especialidad especialidad) {
        this.especialidad = especialidad;
    }

    public double getPuntuacionPromedio() {
        return puntuacionPromedio;
    }

    public void setPuntuacionPromedio(double puntuacionPromedio) {
        this.puntuacionPromedio = puntuacionPromedio;
    }

    public Sala getConsultorio() {
        return consultorio;
    }

    public void setConsultorio(Sala consultorio) {
        this.consultorio = consultorio;
    }

    public ArrayList<Cita> getCitas() {
        return citas;
    }

    public void setCitas(ArrayList<Cita> citas) {
        this.citas = citas;
    }

    public ArrayList<Turno> getTurnos() {
        return turnos;
    }

    public void setTurnos(ArrayList<Turno> turnos) {
        this.turnos = turnos;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Odontologo\n";
        resultado += "----------------\n";
        // primero el bloque de Persona
        resultado += super.toString() + "\n";
        // ahora los campos propios de Odontologo
        resultado += "idOdontologo: "        + idOdontologo        + "\n";
        resultado += "especialidad: " + "\n";
        resultado += especialidad;
        resultado += "puntuacionPromedio: "  + puntuacionPromedio  + "\n";
        resultado += "consultorio: " + "\n";
        resultado += consultorio;
        resultado += "citas: " + "\n";
        resultado += citas;
        resultado += "turnos: " + "\n";
        resultado += turnos;
        resultado += "================\n";
        return resultado;
    }
    
}
