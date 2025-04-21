package com.mycompany.odontosys.backend;

/*
 * @author Grupo04_0682
 */

import java.time.LocalDate;
import java.time.LocalTime;
import java.util.List;

public class Cita {

    private int idCita;
    private LocalDate fecha;
    private LocalTime horaInicio;
    private int puntuacion;
    private EstadoCita estado;
    private Odontologo odontologo;
    private Comprobante comprobante;
    private List<DetalleTratamiento> tratamientos;

    public Cita() {
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

    public int getPuntuacion() {
        return puntuacion;
    }

    public void setPuntuacion(int puntuacion) {
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

    public void agregarTratamiento() {
        // TODO: Implementar lógica para agregar tratamiento a la cita
    }

    public void enviarCorreo() {
        // TODO: Implementar lógica para enviar confirmación por correo
    }
}
