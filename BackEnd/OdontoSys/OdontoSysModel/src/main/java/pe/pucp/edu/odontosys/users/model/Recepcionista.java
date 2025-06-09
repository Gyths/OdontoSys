package pe.pucp.edu.odontosys.users.model;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Cita;

public class Recepcionista extends Persona{
    private Integer idRecepcionista;
    private ArrayList<Cita> citas;
    
    public Recepcionista(){
        super();
        this.citas = new ArrayList<Cita>();
    }

    public Integer getIdRecepcionista() {
        return idRecepcionista;
    }

    public void setIdRecepcionista(Integer idRecepcionista) {
        this.idRecepcionista = idRecepcionista;
    }

    public ArrayList<Cita> getCitas() {
        return citas;
    }

    public void setCitas(ArrayList<Cita> citas) {
        this.citas = citas;
    }
    
    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Recepcionista\n";
        resultado += "----------------\n";
        // bloque de Persona
        resultado += super.toString() + "\n";
        // campos propios de Recepcionista
        resultado += "idRecepcionista: " + idRecepcionista + "\n";
        resultado += "citas: " + "\n";
        resultado += citas;      
        resultado += "================\n";
        return resultado;
    }

}
