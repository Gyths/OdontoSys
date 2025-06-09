package pe.pucp.edu.odontosys.infrastructure.model;

public class TurnoXOdontologo {
    
    private Integer idOdontologo;
    private Integer idTurno;

    public TurnoXOdontologo() {
    }

    public Integer getIdOdontologo() {
        return idOdontologo;
    }

    public void setIdOdontologo(Integer idOdontologo) {
        this.idOdontologo = idOdontologo;
    }

    public Integer getIdTurno() {
        return idTurno;
    }

    public void setIdTurno(Integer idTurno) {
        this.idTurno = idTurno;
    }
    
    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "TurnoXOdontologo\n";
        resultado += "----------------\n";
        resultado += "idOdontologo: " + idOdontologo + "\n";
        resultado += "idTurno: " + idTurno + "\n";
        resultado += "================\n";
        return resultado;
    }

}
