package com.odontosys.users.model;

/*
 * @author Grupo04_0682
 */

import com.odontosys.services.model.Cita;
import java.util.List;

public class Paciente extends Persona {

    private List<Cita> citas;

    public Paciente() {
    }

    public List<Cita> getCitas() {
        return citas;
    }

    public void setCitas(List<Cita> citas) {
        this.citas = citas;
    }

    public void agregarCita() {
        // TODO: Implementar lógica para agregar una cita
    }

    public void consultarHistorial() {
        // TODO: Implementar lógica para consultar historial de citas
    }

    public void puntuarServicio() {
        // TODO: Implementar lógica para calificar el servicio recibido
    }

    public void consultarHistoriaMedica() {
        // TODO: Implementar lógica para consultar la historia clínica del paciente
    }
}
