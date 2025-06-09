package pe.pucp.edu.odontosys.users.model;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.services.model.Cita;

public class Paciente extends Persona{

    private Integer idPaciente;
    private ArrayList<Cita> citas;
    
    public Paciente(){
        super();
        this.citas = new ArrayList<Cita>();
    }

    public Integer getIdPaciente() {
        return idPaciente;
    }

    public void setIdPaciente(Integer idPaciente) {
        this.idPaciente = idPaciente;
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
        resultado += "Paciente\n";
        resultado += "----------------\n";
        // bloque de Persona
        resultado += super.toString() + "\n";
        // campos propios de Paciente
        resultado += "idPaciente: " + idPaciente + "\n";
        resultado += "citas: " + "\n"; 
        resultado += citas;    
        resultado += "================\n";
        return resultado;
    }
    
}
