package com.odontosys.users.model;

public class Recepcionista extends Cuenta{
    private int idRecepcionista;
    
    public Recepcionista(){
        super();
        this.tipoUsuario = TipoUsuario.RECEPCIONISTA;
    }

    public int getIdRecepcionista() {
        return idRecepcionista;
    }

    public void setIdRecepcionista(int idRecepcionista) {
        this.idRecepcionista = idRecepcionista;
    }
    
    @Override
    public String toString() {
        return super.toString();
    }

}
