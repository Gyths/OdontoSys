package com.odontosys.services.model;

import java.time.LocalTime;
import java.time.LocalDate;
import java.util.List;

import com.odontosys.users.model.Odontologo;
import com.odontosys.users.model.Paciente;

public class Cita {
    
    private int idCita;
    private LocalDate fecha;
    private LocalTime horaInicio;
    private double puntuacion;
    private EstadoCita estado;
    private Odontologo odontologo;
    private Paciente paciente;
    private Comprobante comprobante;
    private List<DetalleTratamiento> tratamientos;

    public Cita() {
        this.odontologo = new Odontologo();
        this.paciente = new Paciente();
        this.comprobante = new Comprobante();
    }

    public int getIdCita() {
        return idCita;
    }

    public void setIdCita(int idCita) {
        this.idCita = idCita;
    }

    public LocalDate getFecha() {
        return fecha;
    }

    public void setFecha(LocalDate fecha) {
        this.fecha = fecha;
    }

    public LocalTime getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(LocalTime horaInicio) {
        this.horaInicio = horaInicio;
    }

    public double getPuntuacion() {
        return puntuacion;
    }

    public void setPuntuacion(double puntuacion) {
        this.puntuacion = puntuacion;
    }

    public EstadoCita getEstado() {
        return estado;
    }

    public void setEstado(EstadoCita estado) {
        this.estado = estado;
    }

    public Odontologo getOdontologo() {
        return odontologo;
    }

    public void setOdontologo(Odontologo odontologo) {
        this.odontologo = odontologo;
    }
    
    public Paciente getPaciente() {
        return paciente;
    }
    
    public void setPaciente(Paciente paciente) {
        this.paciente = paciente;
    }
    
    public Comprobante getComprobante() {
        return comprobante;
    }

    public void setComprobante(Comprobante comprobante) {
        this.comprobante = comprobante;
    }

    public List<DetalleTratamiento> getTratamientos() {
        return tratamientos;
    }

    public void setTratamientos(List<DetalleTratamiento> tratamientos) {
        this.tratamientos = tratamientos;
    }

    @Override
    public String toString() {
        return "Cita{" + "idCita=" + idCita + ", fecha=" + fecha + ", horaInicio=" + horaInicio + ", puntuacion=" + puntuacion + ", estado=" + estado + ", odontologo=" + odontologo + ", comprobante=" + comprobante + ", tratamientos=" + tratamientos + '}';
    }
        
}
