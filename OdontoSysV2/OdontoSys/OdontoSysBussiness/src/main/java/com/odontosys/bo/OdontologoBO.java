package com.odontosys.bo;
import com.odontosys.bo.utils.PersonaEnum;
import com.odontosys.dao.OdontologoDAO;
import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.OdontologoDAOImpl;
import com.odontosys.daoImp.PersonaDAOImpl;
import com.odontosys.services.model.Especialidad;
import com.odontosys.users.model.Odontologo;
import com.odontosys.users.model.Persona;
import com.odontosys.users.model.TipoUsuario;
import java.util.ArrayList;

public class OdontologoBO {
    private OdontologoDAO odontologoDAO;
    private PersonaBO personaBO;
    
    public OdontologoBO(){
        this.odontologoDAO = new OdontologoDAOImpl();
        this.personaBO = new PersonaBO();
    }
    
    public Integer insertarOdontologo(String contraseña,  String nombreUsuario,
            String correo, String telefono, String nombre, String apellidos,
            String DNI, Especialidad especialidad,
            double puntuacionPromedio, int idSala){
        
        Odontologo o = new Odontologo();
        o.setIdPersona(this.personaBO.insertarPersona(contraseña, nombreUsuario, correo, telefono, nombre,
                apellidos, DNI, TipoUsuario.ODONTOLOGO));
        o.setEspecialidad(especialidad);
        o.setPuntuacionPromedio(puntuacionPromedio);
        o.getConsultorio().setIdSala(idSala);
        return this.odontologoDAO.insertar(o);
    }
    
    public Integer modificarOdontologo(String nombreUsuario, PersonaEnum tipoDato, String cambio){
       ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
       Persona p = new Persona();
       for(Odontologo o : lista){
            p = this.personaBO.obtenerPorId(o.getIdPersona());
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
    
    public Integer eliminarOdontologo(String nombreUsuario){
       ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
       Persona p;
       for(Odontologo o : lista){
            p = this.personaBO.obtenerPorId(o.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario)){
                this.odontologoDAO.eliminar(o);
                return this.personaBO.eliminarPersona(p);
            }
       } 
       return -1;
    }
    
    public Persona obtenerIdPersona(String nombreUsuario){
       ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
       Persona p;
       for(Odontologo o : lista){
            p = this.personaBO.obtenerPorId(o.getIdPersona());
            if(p.getNombreUsuario().equals(nombreUsuario))
                return p;
       }
       return null;
    }
    
    public ArrayList<Odontologo> listarOdontologos(){
        ArrayList<Odontologo> lista = this.odontologoDAO.listarTodos();
        return lista;
    }
}
