package pe.pucp.edu.odontosys.bo.services;

import pe.pucp.edu.odontosys.dao.services.CitaDAO;
import pe.pucp.edu.odontosys.daoImp.services.CitaDAOImpl;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Comprobante;
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
        return this.citaDAO.listarPorOdontologoFechas(odontologo, fechaInicio, fechaFin);
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
    
    public Integer actualizarFkComprobante(Cita cita, Comprobante comprobante){
        return this.citaDAO.actualizarFkComprobante(cita, comprobante);
    }
            
    public Integer actualizarEstado(Cita cita){
        return this.citaDAO.actualizarEstado(cita);
    }
    
    public ArrayList<Cita> listarPorPacienteFechas(Paciente paciente, String fechaInicio, String fechaFin){
        return this.citaDAO.listarPorPacienteFechas(paciente, fechaInicio, fechaFin);
    }
}
