package com.odontosys.users.model;

import java.util.List;

import com.odontosys.services.model.Cita;

public class Paciente extends Persona{
    
    private List<Cita> citas;
    
    public Paciente(){
        
    }

    public List<Cita> getCitas() {
        return citas;
    }

    public void setCitas(List<Cita> citas) {
        this.citas = citas;
    }

    @Override
    public String toString() {
        return super.toString();
    }
    
}
