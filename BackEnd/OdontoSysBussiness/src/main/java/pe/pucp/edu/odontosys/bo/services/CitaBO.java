package pe.pucp.edu.odontosys.bo.services;

import pe.pucp.edu.odontosys.dao.services.CitaDAO;
import pe.pucp.edu.odontosys.daoImp.services.CitaDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.time.DayOfWeek;
import java.time.LocalDate;
import java.time.temporal.ChronoUnit;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.users.model.Recepcionista;

public class CitaBO {
    private CitaDAO citaDAO;
    
    public CitaBO(){
        this.citaDAO = new CitaDAOImpl();
    }
    
    public Integer insertar(Cita cita){
        return this.citaDAO.insertar(cita);
    }
    
    public Integer modificar(Cita cita){
        return this.citaDAO.modificar(cita);
    }
    
    public Integer eliminar(Cita cita){
        return this.citaDAO.eliminar(cita);
    }
    
    public Cita obtenerPorId(Integer id){
        return this.citaDAO.obtenerPorId(id);
    }
    
    public ArrayList<Cita> listarTodos(){
        return this.citaDAO.listarTodos();
    }
   
    public ArrayList<Cita> listarPorOdontologoFechas(Odontologo odontologo, String fechaInicio, String fechaFin){
        return this.citaDAO.listarPorOdontologoFechas(odontologo, LocalDate.parse(fechaInicio), LocalDate.parse(fechaInicio));
    }
    
    public ArrayList<Cita> listarPorOdontologo(Odontologo odontologo){
        return this.citaDAO.listarPorOdontologo(odontologo);
    }
    
    public ArrayList<Cita> listarPorPaciente(Paciente paciente){
        return this.citaDAO.listarPorPaciente(paciente);
    }
    public ArrayList<Cita> listarPorRecepcionista(Recepcionista recepcionista){
        return this.citaDAO.listarPorRecepcionista(recepcionista);
    }
    
    public Integer actualizarFkValoracion(Cita cita, Valoracion valoracion){
        return this.citaDAO.actualizarFkValoracion(cita, valoracion);
    }
    
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
