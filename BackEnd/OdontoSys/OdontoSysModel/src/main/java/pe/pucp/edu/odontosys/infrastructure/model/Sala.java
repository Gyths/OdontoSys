package pe.pucp.edu.odontosys.infrastructure.model;


public class Sala {

    private Integer idSala;
    private String numero;
    private Integer piso;
    
    public Sala(){
    }

    public Integer getIdSala() {
        return idSala;
    }

    public void setIdSala(Integer idSala) {
        this.idSala = idSala;
    }

    public String getNumero() {
        return numero;
    }

    public void setNumero(String numero) {
        this.numero = numero;
    }

    public Integer getPiso() {
        return piso;
    }

    public void setPiso(Integer piso) {
        this.piso = piso;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Sala\n";
        resultado += "----------------\n";
        resultado += "idSala: " + idSala + "\n";
        resultado += "numero: " + numero + "\n";
        resultado += "piso: " + piso + "\n";
        resultado += "================\n";
        return resultado;
    }
      
}
