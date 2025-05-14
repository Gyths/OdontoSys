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
    
    private PersonaBO personaBO;
    private RecepcionistaDAO recepcionistaDAO;
    
    public RecepcionistaBO(){
        this.personaBO = new PersonaBO();
        this.recepcionistaDAO = new RecepcionistaDAOImpl();
    }
    
    public Integer insertarRecepcionista(String contraseña,  String nombreUsuario,
            String correo, String telefono, String nombre, String apellidos,
            String DNI){
        
        Recepcionista r = new Recepcionista();
        r.setIdPersona(this.personaBO.insertarPersona(contraseña, nombreUsuario, correo, telefono, nombre,
                apellidos, DNI, TipoUsuario.RECEPCIONISTA));
        return this.recepcionistaDAO.insertar(r);
    }
    
    public Integer modificarRecepcionista(String nombreUsuario, PersonaEnum tipoDato, String cambio){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p = new Persona();
       for(Recepcionista r : lista){
            p = this.personaBO.obtenerPorId(r.getIdPersona());
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
    
    public Integer eliminarRecepcionista(String nombreUsuario){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p;
       for(Recepcionista r : lista){
            p = this.personaBO.obtenerPorId(r.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario)){
                this.recepcionistaDAO.eliminar(r);
                return this.personaBO.eliminarPersona(p);
            }
       } 
       return -1;
    }
    
    public Persona obtenerIdPersona(String nombreUsuario){
       ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
       Persona p;
       for(Recepcionista r : lista){
            p = this.personaBO.obtenerPorId(r.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario))
                return p;
       }
       return null;
    }
    
    public ArrayList<Recepcionista> listarOdontologos(){
        ArrayList<Recepcionista> lista = this.recepcionistaDAO.listarTodos();
        return lista;
    }
    
}
