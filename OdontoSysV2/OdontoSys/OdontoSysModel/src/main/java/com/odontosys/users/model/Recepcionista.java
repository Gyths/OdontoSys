package com.odontosys.users.model;

public class Recepcionista extends Persona{
    
    public Recepcionista(){
        super();
        this.tipoUsuario = TipoUsuario.RECEPCIONISTA;
    }

    @Override
    public String toString() {
        return super.toString();
    }

}
