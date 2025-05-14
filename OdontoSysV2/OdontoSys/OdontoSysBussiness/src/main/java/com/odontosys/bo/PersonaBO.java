
package com.odontosys.bo;

import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.PersonaDAOImpl;
import com.odontosys.users.model.Persona;
import com.odontosys.users.model.TipoUsuario;
/**
 *
 * @author Gyts
 */
public class PersonaBO {
    private PersonaDAO personaDAO;
    
    public PersonaBO(){
        this.personaDAO = new PersonaDAOImpl();
    }
    
    public Integer insertarPersona(String contraseña,  String nombreUsuario,
            String correo, String telefono, String nombre, String apellidos,
            String DNI, TipoUsuario tipoUsuario){
        
        Persona p = new Persona();
        p.setContrasenha(contraseña);
        p.setNombreUsuario(nombreUsuario);
        p.setCorreo(correo);
        p.setTelefono(telefono);
        p.setNombre(nombre);
        p.setApellidos(apellidos);
        p.setDNI(DNI);
        p.setTipoUsuario(tipoUsuario);
        return this.personaDAO.insertar(p);
    }
    
    public Integer modificarPersona(Persona persona){
        return this.personaDAO.modificar(persona);
    }
    
    public Integer eliminarPersona(Persona persona){
        return this.personaDAO.eliminar(persona);
    }
    
    public Persona obtenerPorId(Integer idPersona){
        return this.personaDAO.obtenerPorId(idPersona);
    }
}
