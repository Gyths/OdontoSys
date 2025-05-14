package com.odontosys.bo;

import com.odontosys.users.model.Paciente;
import com.odontosys.users.model.Persona;
import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.PersonaDAOImpl;
import com.odontosys.dao.PacienteDAO;
import com.odontosys.daoImp.PacienteDAOImpl;
import com.odontosys.users.model.TipoUsuario;
import java.util.ArrayList;

public class PacienteBO {
    private PacienteDAO pacienteDAO;
    private PersonaBO personaBO;
    
    public PacienteBO(){
        this.pacienteDAO = new PacienteDAOImpl();
        this.personaBO = new PersonaBO();
    }
    
    public Integer insertarPaciente(String contraseña,  String nombreUsuario,
            String correo, String telefono, String nombre, String apellidos,
            String DNI){
        
        Paciente p = new Paciente();
        p.setIdPersona(this.personaBO.insertarPersona(contraseña, nombreUsuario, correo, telefono, nombre,
                apellidos, DNI, TipoUsuario.PACIENTE));
        return this.pacienteDAO.insertar(p);
    }
    
    public Integer modificarPaciente(String nombreUsuario, PersonaEnum tipoDato, String cambio){
       ArrayList<Paciente> lista = this.pacienteDAO.listarTodos();
       Persona p = new Persona();
       for(Paciente pa : lista){
            p = this.personaBO.obtenerPorId(pa.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario))
                break;
       }
       if(tipoDato == PersonaEnum.CONTRASENHA)
           p.setContrasenha(cambio);
       if(tipoDato == PersonaEnum.CORREO)
           p.setCorreo(cambio);
       if(tipoDato == PersonaEnum.NOMBREUSUARIO)
           p.setNombreUsuario(cambio);
       if(tipoDato == PersonaEnum.TELEFONO)
           p.setTelefono(cambio);

       return this.personaBO.modificarPersona(p);
    }
    
    public Integer eliminarPaciente(String nombreUsuario){
       ArrayList<Paciente> lista = this.pacienteDAO.listarTodos();
       Persona p;
       for(Paciente pa : lista){
            p = this.personaBO.obtenerPorId(pa.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario)){
                this.pacienteDAO.eliminar(pa);
                return this.personaBO.eliminarPersona(p);
            }
       } 
       return -1;
    }
    
    public Persona obtenerIdPersona(String nombreUsuario){
       ArrayList<Paciente> lista = this.pacienteDAO.listarTodos();
       Persona p;
       for(Paciente pa : lista){
            p = this.personaBO.obtenerPorId(pa.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario))
                return p;
       }
       return null;
    }
    
    public ArrayList<Paciente> listarOdontologos(){
        ArrayList<Paciente> lista = this.pacienteDAO.listarTodos();
        return lista;
    }
    
}
