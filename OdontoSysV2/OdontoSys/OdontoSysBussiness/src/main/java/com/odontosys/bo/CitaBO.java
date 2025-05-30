package com.odontosys.bo;

import com.odontosys.dao.services.CitaDAO;
import com.odontosys.daoImp.services.CitaDAOImpl;
import com.odontosys.infrastructure.model.Turno;
import com.odontosys.services.model.Cita;
import com.odontosys.users.model.Odontologo;
import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;

public class CitaBO {
    private CitaDAO citaDAO;
    private PacienteBO pacienteBO;
    
    public CitaBO(){
        this.citaDAO = new CitaDAOImpl();
        this.pacienteBO = new PacienteBO();
    }
    
    public Integer insertCita(Cita cita){
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
    
    //Magia de @jared
    public boolean[][] calcularDisponibilidad(ArrayList<Cita> citas, ArrayList<Turno> turnos, String fechaInicio){
        boolean[][] disponibilidad = new boolean[7][48];
        LocalDate inicio = LocalDate.parse(fechaInicio);
        
        for(int i=0; i<7; i++){
            LocalDate fecha = inicio.plusDays(i);
            DayOfWeek dia = fecha.getDayOfWeek();
            
            for(Turno turno : turnos){
                if(turno.getDiaSemana().toString().equals(dia.toString())){
                    int inicioBloque = (turno.getHoraInicio().getHour() * 2) + 
                                      (turno.getHoraInicio().getMinute() >= 30 ? 1 : 0);
                    int finBloque = (turno.getHoraFin().getHour() * 2) + 
                                   (turno.getHoraFin().getMinute() > 0 ? 1 : 0);
                    
                    for(int j = inicioBloque; j < finBloque; j++)
                        disponibilidad[i][j] = true;
                }
            }
            
            for (Cita cita : citas){
                LocalDate fechaCita = cita.getFecha();
                int diferencia = (int) ChronoUnit.DAYS.between(inicio, fechaCita);
                if(diferencia >= 0 && diferencia < 7){
                    int bloque = cita.getHoraInicio().getHour() * 2 + 
                            (cita.getHoraInicio().getMinute() >= 30 ? 1 : 0);
                    disponibilidad[diferencia][bloque] = false;
                }
            }
        }
        return disponibilidad;
    }

}
