package com.odontosys.bo;

import com.odontosys.dao.services.CitaDAO;
import com.odontosys.daoImp.services.CitaDAOImpl;
import com.odontosys.services.model.Cita;
import com.odontosys.services.model.Comprobante;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.users.model.Odontologo;
import com.odontosys.users.model.Paciente;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.ArrayList;

public class CitaBO {
    private CitaDAO citaDAO;
    private PacienteBO pacienteBO;
    
    public CitaBO(){
        this.citaDAO = new CitaDAOImpl();
        this.pacienteBO = new PacienteBO();
    }
    
    public Integer insertCita(Odontologo odontologo,Paciente paciente, Comprobante comprobante,
            LocalDate fecha, LocalTime horaInicio, double puntuacion, EstadoCita estado){
        Cita cita = new Cita();
        cita.setOdontologo(odontologo);
        cita.setPaciente(paciente);
        cita.setComprobante(comprobante);
        cita.setFecha(fecha);
        cita.setHoraInicio(horaInicio);
        cita.setPuntuacion(puntuacion);
        cita.setEstado(estado);
        return this.citaDAO.insertar(cita);
    }
    
    public Integer modificarCita(Cita cita){
        return this.citaDAO.modificar(cita);
    }
    
    public Integer eliminarCita(Cita cita){
        return this.citaDAO.eliminar(cita);
    }
    
    public ArrayList<Cita>listarPorOdontologo(Odontologo odontologo,String fechaInicio,String fechaFin){
        ArrayList<Cita>lista = this.citaDAO.listarPorOdontologo(odontologo,LocalDate.parse(fechaInicio),LocalDate.parse(fechaFin));
        return lista;
    }
    
    public Integer[] calcularDisponibilidadDia(ArrayList<Cita>citas){
        Integer[] timeSlots = new Integer[48];
        for(Cita cita:citas){
           Integer index = cita.getHoraInicio().getHour();
           if(cita.getHoraInicio().getMinute() != 0)index++;
           timeSlots[index] = 1;
        }
        return timeSlots;
    }
    
    public ArrayList<Integer[]> calcularDisponibilidad(ArrayList<Cita>citas){
        ArrayList<Cita>lista = new ArrayList<>();
        for(int i=0;i<citas.size();i++){
            if(citas.get(i).getFecha().equals(citas.get(i+1).getFecha())){
                lista.add(citas.get(i));
            }
            else{
                lista.add(citas.get(i));
                calcularDisponibilidadDia(lista);
            }
        }
    }
}
