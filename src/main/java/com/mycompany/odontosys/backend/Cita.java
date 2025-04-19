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
    private EstadoCita estado;
    private Odontologo odontologo;
    private List<DetalleTratamiento> tratamientos;
    private Receta receta;

    public Cita() {
    }
}
