package pe.pucp.edu.odontosys.infrastructure.model;

import java.time.LocalTime;

public class Turno {
    
    private Integer idTurno;
    private LocalTime horaInicio;
    private LocalTime horaFin;
    private DiaSemana diaSemana;

    public Turno() {
    }

    public Integer getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(Integer idTurno) {
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
        String resultado = "";
        resultado += "================\n";
        resultado += "Turno\n";
        resultado += "----------------\n";
        resultado += "idTurno: " + idTurno + "\n";
        resultado += "horaInicio: " + horaInicio + "\n";
        resultado += "horaFin: " + horaFin + "\n";
        resultado += "diaSemana: " + diaSemana + "\n";
        resultado += "================\n";
        return resultado;
    }
     
}
