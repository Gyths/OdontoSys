package com.mycompany.odontosys.backend;

/*
 * @author Grupo04_0682
 */
import java.util.List;

public class Odontologo extends Empleado {

    private Especialidad especialidad;
    private Sala consultorio;
    private List<Cita> citas;
    private List<Turno> turno;

    public Odontologo() {
    }
}
