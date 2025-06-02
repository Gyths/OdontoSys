package com.odontosys.users.model;

import java.util.List;

import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.Cita;
import com.odontosys.infrastructure.model.Sala;
import com.odontosys.infrastructure.model.Turno;

public class Odontologo extends Cuenta{

    private int idOdontologo;
    private Especialidad especialidad;
    private double puntuacionPromedio;
    private Sala consultorio;
    private List<Cita> citas;
    private List<Turno> turnos;

    public Odontologo() {
        this.consultorio = new Sala();
        this.especialidad = new Especialidad();
    }
           
    public Especialidad getEspecialidad() {
        return especialidad;
    }

    public void setEspecialidad(Especialidad especialidad) {
        this.especialidad = especialidad;
    }
    
    public int getIdOdontologo() {
        return idOdontologo;
    }

    public void setIdOdontologo(int idOdontologo) {
        this.idOdontologo = idOdontologo;
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

    @Override
    public String toString() {
        String herencia = super.toString() + '\n';
        return herencia + "Odontologo{" + "especialidad=" + especialidad + ", puntuacionPromedio=" + puntuacionPromedio + ", consultorio=" + consultorio + ", citas=" + citas + ", turnos=" + turnos + '}';
    }
        
}
