package com.odontosys.bo;

import com.odontosys.users.model.Recepcionista;
import com.odontosys.users.model.Persona;
import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.PersonaDAOImpl;
import com.odontosys.dao.RecepcionistaDAO;
import com.odontosys.daoImp.RecepcionistaDAOImpl;
import com.odontosys.users.model.TipoUsuario;
import java.util.ArrayList;

public class RecepcionistaBO {
    
    private PersonaDAO personaDAO;
    private RecepcionistaDAO recepcionistaDAO;
    
    public RecepcionistaBO(){
        this.personaDAO = new PersonaDAOImpl();
        this.recepcionistaDAO = new RecepcionistaDAOImpl();
    }
    
    public Integer insertarRecepcionista(String contraseña,  String nombreUsuario,
            String correo, String telefono, String nombre, String apellidos,
            String DNI, TipoUsuario tipoUsuario){
        
        Persona persona = new Recepcionista();
        persona.setContrasenha(contraseña);
        persona.setNombreUsuario(nombreUsuario);
        persona.setCorreo(correo);
        persona.setTelefono(telefono);
        persona.setNombre(nombre);
        persona.setApellidos(apellidos);
        persona.setDNI(DNI);
        persona.setTipoUsuario(tipoUsuario);
        
        persona.setIdPersona(this.personaDAO.insertar((Persona)persona));
        this.recepcionistaDAO.insertar((Recepcionista) persona);
        return persona.getIdPersona();
        
    }
    
    public Integer modificarRecepcionista(String nombreUsuario, PersonaEnum tipoDato, String cambio){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p = new Persona();
       for(Recepcionista r : lista){
            p = this.personaDAO.obtenerPorId(r.getIdPersona());
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

       return this.personaDAO.modificar(p);
    }
    
    public Integer eliminarRecepcionista(String nombreUsuario){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p = new Persona();
       for(Recepcionista r : lista){
            p = this.personaDAO.obtenerPorId(r.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario)){
                this.recepcionistaDAO.eliminar(r);
                return this.personaDAO.eliminar(p);
            }
       } 
       return -1;
    }
    
    public Persona obtenerIdPersona(String nombreUsuario){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p = new Persona();
       for(Recepcionista r : lista){
            p = this.personaDAO.obtenerPorId(r.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario))
                return p;
       }
       return null;
    }
    
}
