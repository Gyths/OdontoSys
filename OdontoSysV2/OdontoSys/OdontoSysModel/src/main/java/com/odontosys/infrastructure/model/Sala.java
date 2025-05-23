package com.odontosys.infrastructure.model;


public class Sala {

    private int idSala;
    private String numero;
    private int piso;
    
    public Sala(){
    }
    
    public int getIdSala() {
        return idSala;
    }

    public void setIdSala(int idSala) {
        this.idSala = idSala;
    }

    public String getNumero() {
        return numero;
    }

    public void setNumero(String numero) {
        this.numero = numero;
    }

    public int getPiso() {
        return piso;
    }

    public void setPiso(int piso) {
        this.piso = piso;
    }

    @Override
    public String toString() {
        return "Sala{" + "idSala=" + idSala + ", numero=" + numero + ", piso=" + piso + '}';
    }
             
}
