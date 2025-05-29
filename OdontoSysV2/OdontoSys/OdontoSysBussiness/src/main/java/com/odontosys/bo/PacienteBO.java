package com.odontosys.bo;
import com.odontosys.users.model.Paciente;
import com.odontosys.dao.users.PacienteDAO;
import com.odontosys.daoImp.users.PacienteDAOImpl;
import java.util.ArrayList;

public class PacienteBO {
    private PacienteDAO pacienteDAO;
    
    public PacienteBO(){
        this.pacienteDAO = new PacienteDAOImpl();
    }
    
    public Integer insertarPaciente(Paciente paciente){
        return this.pacienteDAO.insertar(paciente);
    }
    
    public Integer modificarPaciente(Paciente paciente){
       return this.pacienteDAO.modificar(paciente);
    }
    
    public Integer eliminarPaciente(Paciente paciente){
       return this.pacienteDAO.eliminar(paciente);
    }
    
    public Paciente obtenerPorID(Integer pacienteID){
       return this.pacienteDAO.obtenerPorId(pacienteID);
    }
    
    public Paciente buscarPorUsuario(String nombreUsuario){
        return this.pacienteDAO.buscarPorUsuario(nombreUsuario);
    }
    
    public ArrayList<Paciente> listarOdontologos(){
        ArrayList<Paciente> lista = this.pacienteDAO.listarTodos();
        return lista;
    }
    
}
