package com.mycompany.odontosys.backend;

/*
 * @author Grupo04_0682
 */
import java.time.LocalDate;

public class Comprobante {

    private int idComprobante;
    private LocalDate fechaEmision;
    private double total;
    private Cita citaMedica;
    private double importeCancelado;

    public Comprobante() {
    }
}

