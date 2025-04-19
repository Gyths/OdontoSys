package com.mycompany.odontosys.backend;

/*
 * @author Grupo04_0682
 */
import java.util.List;

public class Paciente {

    private int idCliente;
    private String nombre;
    private String apellido;
    private String DNI;
    private String telefono;
    private String correo;
    private List<Cita> citas;

    public Paciente() {
    }
}

