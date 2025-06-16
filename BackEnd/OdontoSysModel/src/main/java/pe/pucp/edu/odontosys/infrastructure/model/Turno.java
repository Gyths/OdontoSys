package pe.pucp.edu.odontosys.infrastructure.model;

public class Turno {
    
    private Integer idTurno;
    
    private String horaInicio;
    
    private String horaFin;
    
    private DiaSemana diaSemana;

    public Turno() {
    }

    public Integer getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(Integer idTurno) {
        this.idTurno = idTurno;
    }

    public String getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(String horaInicio) {
        this.horaInicio = horaInicio;
    }

    public String getHoraFin() {
        return horaFin;
    }

    public void setHoraFin(String horaFin) {
        this.horaFin = horaFin;
    }

    public DiaSemana getDiaSemana() {
        return diaSemana;
    }

    public void setDiaSemana(DiaSemana diaSemana) {
        this.diaSemana = diaSemana;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Turno\n";
        resultado += "----------------\n";
        resultado += "idTurno: " + idTurno + "\n";
        resultado += "horaInicio: " + horaInicio + "\n";
        resultado += "horaFin: " + horaFin + "\n";
        resultado += "diaSemana: " + diaSemana + "\n";
        resultado += "================\n";
        return resultado;
    }
     
}
