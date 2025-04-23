package com.odontosys.infraestructure.model;

/*
 * @author Grupo04_0682
 */

import java.time.LocalTime;

public class Turno {
    private int idTurno;
    private LocalTime horaInicio;
    private LocalTime horaFin;
    private DiaSemana diaLaboral;

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

    public DiaSemana getDiaLaboral() {
        return diaLaboral;
    }

    public void setDiaLaboral(DiaSemana diaLaboral) {
        this.diaLaboral = diaLaboral;
    }
}

