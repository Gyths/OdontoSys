package com.odontosys.infraestructure.model;

/*
 * @author Grupo04_0682
 */

import java.time.LocalTime;
import java.sql.Time;
public class Turno {
    private int idTurno;
    private Time horaInicio;
    private Time horaFin;
    private DiaSemana diaLaboral;

    public Turno() {
    }

    public int getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(int idTurno) {
        this.idTurno = idTurno;
    }
    
    
    public Time getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(Time horaInicio) {
        this.horaInicio = horaInicio;
    }

    public Time getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(Time horaFin) {
        this.horaFin = horaFin;
    }

    public DiaSemana getDiaLaboral() {
        return diaLaboral;
    }

    public void setDiaLaboral(DiaSemana diaLaboral) {
        this.diaLaboral = diaLaboral;
    }
}

