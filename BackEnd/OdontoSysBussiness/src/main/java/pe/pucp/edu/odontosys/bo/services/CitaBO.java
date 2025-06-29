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
   
    public ArrayList<Cita> listarPorOdontologoFechas(Integer idOdontologo, String fechaInicio, String fechaFin){
        Odontologo odontologo = new Odontologo();
        odontologo.setIdOdontologo(idOdontologo);
        return this.citaDAO.listarPorOdontologoFechas(odontologo, fechaInicio, fechaFin);
    }
    
    public ArrayList<Cita> listarPorOdontologo(Integer idOdontologo){
        Odontologo odontologo = new Odontologo();
        odontologo.setIdOdontologo(idOdontologo);
        return this.citaDAO.listarPorOdontologo(odontologo);
    }
    
    public ArrayList<Cita> listarPorPaciente(Integer idPaciente){
        Paciente paciente = new Paciente();
        paciente.setIdPaciente(idPaciente);
        return this.citaDAO.listarPorPaciente(paciente);
    }

    
    public ArrayList<Cita> listarPorPacienteFechas(Integer idPaciente, String fechaInicio, String fechaFin){
        Paciente paciente = new Paciente();
        paciente.setIdPaciente(idPaciente);
        return this.citaDAO.listarPorPacienteFechas(paciente, fechaInicio, fechaFin);
    }
}
