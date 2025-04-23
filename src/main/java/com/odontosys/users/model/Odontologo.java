package com.odontosys.users.model;

/*
 * @author Grupo04_0682
 */

import com.odontosys.services.model.Cita;
import com.odontosys.services.model.Especialidad;
import com.odontosys.infraestructure.model.Sala;
import com.odontosys.infraestructure.model.Turno;
import java.util.List;

public class Odontologo extends Persona {

    private Especialidad especialidad;
    private double puntuacionPromedio;
    private Sala consultorio;
    private List<Cita> citas;
    private List<Turno> turnos;

    public Odontologo() {
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

    public List<Cita> getCitas() {
        return citas;
    }

    public void setCitas(List<Cita> citas) {
        this.citas = citas;
    }

    public List<Turno> getTurnos() {
        return turnos;
    }

    public void setTurnos(List<Turno> turnos) {
        this.turnos = turnos;
    }
}

