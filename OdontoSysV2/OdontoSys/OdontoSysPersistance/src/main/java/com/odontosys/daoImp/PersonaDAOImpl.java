package com.odontosys.daoImp;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.users.model.*;

public class PersonaDAOImpl extends DAOImplBase implements PersonaDAO{
    
    private Persona persona;
    
    public PersonaDAOImpl(){
        super("persona");
        this.retornarLlavePrimaria = true;
        this.persona = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idPersona",true,true));
        this.listaColumnas.add(new Columna("contrasenha",false,false));
        this.listaColumnas.add(new Columna("nombreUsuario",false,false));
        this.listaColumnas.add(new Columna("correo",false,false));
        this.listaColumnas.add(new Columna("telefono",false,false));
        this.listaColumnas.add(new Columna("nombre",false,false));
        this.listaColumnas.add(new Columna("apellidos",false,false));
        this.listaColumnas.add(new Columna("DNI",false,false));
        this.listaColumnas.add(new Columna("tipoUsuario",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.persona.getContrasenha());
        this.statement.setString(2,this.persona.getNombreUsuario());
        this.statement.setString(3,this.persona.getCorreo());
        this.statement.setString(4,this.persona.getTelefono());
        this.statement.setString(5,this.persona.getNombre());
        this.statement.setString(6,this.persona.getApellidos());
        this.statement.setString(7,this.persona.getDNI());
        this.statement.setInt(8,this.persona.getTipoUsuario().ordinal());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.persona.getContrasenha());
        this.statement.setString(2,this.persona.getNombreUsuario());
        this.statement.setString(3,this.persona.getCorreo());
        this.statement.setString(4,this.persona.getTelefono());
        this.statement.setString(5,this.persona.getNombre());
        this.statement.setString(6,this.persona.getApellidos());
        this.statement.setString(7,this.persona.getDNI());
        this.statement.setInt(8,this.persona.getTipoUsuario().ordinal());
        this.statement.setInt(9,this.persona.getIdPersona());
        
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1,this.persona.getIdPersona());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.persona.getIdPersona());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.persona = new Persona();
        this.persona.setIdPersona(this.resultSet.getInt("idPersona"));
        this.persona.setContrasenha(this.resultSet.getString("contrasenha"));
        this.persona.setNombreUsuario(this.resultSet.getString("nombreUsuario"));
        this.persona.setCorreo(this.resultSet.getString("correo"));
        this.persona.setTelefono(this.resultSet.getString("telefono"));
        this.persona.setNombre(this.resultSet.getString("nombre"));
        this.persona.setApellidos(this.resultSet.getString("apellidos"));
        this.persona.setDNI(this.resultSet.getString("DNI"));
        this.persona.setTipoUsuario(TipoUsuario.valueOf(this.resultSet.getString("tipoUsuario")));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.persona = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.persona);
    }
    
    @Override
    public Integer insertar(Persona persona){
        this.persona = persona;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Persona persona){
        this.persona = persona;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Persona persona) {
       this.persona=persona;
       return super.eliminar();
    }
    
    @Override
    public Persona obtenerPorId(Integer Id){
        this.persona = new Persona();
        this.persona.setIdPersona(Id);
        super.obtenerPorId();
        return this.persona;
    }
    
    @Override
    public ArrayList<Persona> listarTodos(){
        return (ArrayList<Persona>) super.listarTodos();
    }
    
}

