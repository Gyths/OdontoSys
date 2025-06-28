package pe.pucp.edu.odontosys.services.model;

import java.util.ArrayList;

import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.users.model.Recepcionista;

public class Cita {
    
    private Integer idCita;
    private String fecha;
    private String horaInicio;
    private Valoracion valoracion;
    private EstadoCita estado;
    private Odontologo odontologo;
    private Paciente paciente;
    private Comprobante comprobante;
    private ArrayList<DetalleTratamiento> tratamientos;

    public Cita() {
        this.valoracion = new Valoracion();
        this.odontologo = new Odontologo();
        this.paciente = new Paciente();
        this.comprobante = new Comprobante();
        this.tratamientos = new ArrayList<DetalleTratamiento>();
    }

    public Integer getIdCita() {
        return idCita;
    }

    public void setIdCita(Integer idCita) {
        this.idCita = idCita;
    }

    public String getFecha() {
        return fecha;
    }

    public void setFecha(String fecha) {
        this.fecha = fecha;
    }

    public String getHoraInicio() {
        return horaInicio;
    }

    public void setHoraInicio(String horaInicio) {
        this.horaInicio = horaInicio;
    }

    public Valoracion getValoracion() {
        return valoracion;
    }

    public void setValoracion(Valoracion valoracion) {
        this.valoracion = valoracion;
    }

    public EstadoCita getEstado() {
        return estado;
    }

    public void setEstado(EstadoCita estado) {
        this.estado = estado;
    }

    public Odontologo getOdontologo() {
        return odontologo;
    }

    public void setOdontologo(Odontologo odontologo) {
        this.odontologo = odontologo;
    }

    public Paciente getPaciente() {
        return paciente;
    }

    public void setPaciente(Paciente paciente) {
        this.paciente = paciente;
    }

    public Comprobante getComprobante() {
        return comprobante;
    }

    public void setComprobante(Comprobante comprobante) {
        this.comprobante = comprobante;
    }

    public ArrayList<DetalleTratamiento> getTratamientos() {
        return tratamientos;
    }

    public void setTratamientos(ArrayList<DetalleTratamiento> tratamientos) {
        this.tratamientos = tratamientos;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Cita\n";
        resultado += "----------------\n";
        resultado += "idCita: "         + idCita         + "\n";
        resultado += "fecha: "          + fecha          + "\n";
        resultado += "horaInicio: "     + horaInicio     + "\n";
        resultado += "valoracion: "     + "\n";
        resultado += valoracion;     
        resultado += "estado: "         + estado         + "\n";
        resultado += "odontologo: "     + "\n";
        resultado += odontologo;
        resultado += "paciente: "       + "\n";
        resultado += paciente;
        resultado += "comprobante: "    + "\n";
        resultado += comprobante;
        resultado += "tratamientos: "   + "\n";
        resultado += tratamientos;
        resultado += "================\n";
        return resultado;
    }

}
