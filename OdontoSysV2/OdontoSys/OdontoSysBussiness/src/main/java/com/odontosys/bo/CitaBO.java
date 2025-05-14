package com.odontosys.bo;

import com.odontosys.bo.utils.CitaEnum;
import com.odontosys.dao.CitaDAO;
import com.odontosys.daoImp.CitaDAOImpl;
import com.odontosys.services.model.Cita;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.users.model.Persona;
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
    
    public Integer insertCita(Integer idOdontologo,Integer idPaciente, Integer idComprobante,
            LocalDate fecha, LocalTime horaInicio, double puntuacion, EstadoCita estado){
        Cita cita = new Cita();
        cita.getOdontologo().setIdOdontologo(idOdontologo);
        cita.getPaciente().setIdPaciente(idPaciente);
        cita.getComprobante().setIdComprobante(idComprobante);
        cita.setFecha(fecha);
        cita.setHoraInicio(horaInicio);
        cita.setPuntuacion(puntuacion);
        cita.setEstado(estado);
        
        return this.citaDAO.insertar(cita);
    }
    
    
    public Integer modificarCita(String nombrePaciente, LocalDate fecha, LocalTime horaInicio,EstadoCita estado, CitaEnum tipoDato){
        ArrayList<Cita>lista = this.citaDAO.listarTodos();
        Cita cita = new Cita();
        Persona p;
        for(Cita c : lista){
           p = this.pacienteBO.obtenerIdPersona(nombrePaciente);
           if((c.getPaciente().getIdPersona() == p.getIdPersona()) &&
                    (c.getFecha() == fecha) && (c.getHoraInicio() == horaInicio)){
               break;
           }
        }
        //Modificar
        if(tipoDato == CitaEnum.ESTADO){
            cita.setEstado(estado);
        }
        if(tipoDato == CitaEnum.FECHA){
            cita.setFecha(fecha);
        }
        if(tipoDato == CitaEnum.HORA){
            cita.setHoraInicio(horaInicio);
        }
        return this.citaDAO.modificar(cita);
    }
    
    public Integer eliminarCita(String nombrePaciente, LocalDate fecha, LocalTime horaInicio){
        ArrayList<Cita>lista = this.citaDAO.listarTodos();
        Cita cita = new Cita();
        Persona p;
        for(Cita c : lista){
           p = this.pacienteBO.obtenerIdPersona(nombrePaciente);
           if((c.getPaciente().getIdPersona() == p.getIdPersona()) &&
                    (c.getFecha() == fecha) && (c.getHoraInicio() == horaInicio)){
               return this.citaDAO.eliminar(c);
           }
        }
        return -1;
    }
}
