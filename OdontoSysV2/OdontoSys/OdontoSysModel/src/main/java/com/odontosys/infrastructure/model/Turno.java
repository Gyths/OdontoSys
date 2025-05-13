package com.odontosys.infrastructure.model;

import java.time.LocalTime;

public class Turno {
    
    private int idTurno;
    private LocalTime horaInicio;
    private LocalTime horaFin;
    private DiaSemana diaSemana;

    public Turno() {
    }
      
    public int getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(int idTurno) {
        this.idTurno = idTurno;
    }

    public LocalTime getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(LocalTime horaInicio) {
        this.horaInicio = horaInicio;
    }

    public LocalTime getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(LocalTime horaFin) {
        this.horaFin = horaFin;
    }

    public DiaSemana getDiaSemana() {
        return diaSemana;
    }

    public void setDiaSemana(DiaSemana diaSemana) {
        this.diaSemana = diaSemana;
    }

    @Override
    public String toString() {
        return "Turno{" + "idTurno=" + idTurno + ", horaInicio=" + horaInicio + ", horaFin=" + horaFin + ", diaLaboral=" + diaSemana + '}';
    }
           
}
