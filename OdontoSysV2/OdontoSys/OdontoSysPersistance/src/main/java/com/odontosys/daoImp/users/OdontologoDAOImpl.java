package com.odontosys.daoImp.users;

import com.odontosys.dao.users.OdontologoDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Especialidad;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class OdontologoDAOImpl extends DAOImplBase implements OdontologoDAO {
    private Odontologo odontologo;
    
    public OdontologoDAOImpl(){
        super("odontologo");
        this.retornarLlavePrimaria=true;
        this.odontologo = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idOdontologo",true,true));
        this.listaColumnas.add(new Columna("contrasenha",false,false));
        this.listaColumnas.add(new Columna("nombreUsuario",false,false));
        this.listaColumnas.add(new Columna("correo",false,false));
        this.listaColumnas.add(new Columna("telefono",false,false));
        this.listaColumnas.add(new Columna("nombre",false,false));
        this.listaColumnas.add(new Columna("apellidos",false,false));
        this.listaColumnas.add(new Columna("DNI",false,false));
        this.listaColumnas.add(new Columna("tipoUsuario",false,false));
        this.listaColumnas.add(new Columna("puntuacionPromedio",false,false));
        this.listaColumnas.add(new Columna("especialidad",false,false));   
        this.listaColumnas.add(new Columna("idSala",false,false));   
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.odontologo.getContrasenha());
        this.statement.setString(2,this.odontologo.getNombreUsuario());
        this.statement.setString(3,this.odontologo.getCorreo());
        this.statement.setString(4,this.odontologo.getTelefono());
        this.statement.setString(5,this.odontologo.getNombre());
        this.statement.setString(6,this.odontologo.getApellidos());
        this.statement.setString(7,this.odontologo.getDNI());
        this.statement.setInt(8,this.odontologo.getTipoUsuario().ordinal());
        this.statement.setDouble(9,this.odontologo.getPuntuacionPromedio());
        this.statement.setInt(10,this.odontologo.getEspecialidad().ordinal());
        this.statement.setInt(11,this.odontologo.getConsultorio().getIdSala());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.odontologo.getContrasenha());
        this.statement.setString(2,this.odontologo.getNombreUsuario());
        this.statement.setString(3,this.odontologo.getCorreo());
        this.statement.setString(4,this.odontologo.getTelefono());
        this.statement.setString(5,this.odontologo.getNombre());
        this.statement.setString(6,this.odontologo.getApellidos());
        this.statement.setString(7,this.odontologo.getDNI());
        this.statement.setInt(8,this.odontologo.getTipoUsuario().ordinal());
        this.statement.setDouble(9,this.odontologo.getPuntuacionPromedio());
        this.statement.setInt(10,this.odontologo.getEspecialidad().ordinal());
        this.statement.setInt(11,this.odontologo.getConsultorio().getIdSala());
        this.statement.setInt(12, this.odontologo.getIdOdontologo());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.odontologo.getIdOdontologo()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.odontologo.getIdOdontologo());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.odontologo = new Odontologo();
        this.odontologo.setIdOdontologo(this.resultSet.getInt("idOdontologo"));
        this.odontologo.setContrasenha(this.resultSet.getString("contrasenha"));
        this.odontologo.setNombreUsuario(this.resultSet.getString("nombreUsuario"));
        this.odontologo.setCorreo(this.resultSet.getString("correo"));
        this.odontologo.setTelefono(this.resultSet.getString("telefono"));
        this.odontologo.setNombre(this.resultSet.getString("nombre"));
        this.odontologo.setApellidos(this.resultSet.getString("apellidos"));
        this.odontologo.setDNI(this.resultSet.getString("DNI"));
        this.odontologo.setTipoUsuario(TipoUsuario.values()[this.resultSet.getInt("tipoUsuario")]);
        this.odontologo.setPuntuacionPromedio(this.resultSet.getDouble("puntuacionPromedio"));
        this.odontologo.setEspecialidad(Especialidad.values()[this.resultSet.getInt("especialidad")]);
        this.odontologo.getConsultorio().setIdSala(this.resultSet.getInt("idSala"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.odontologo = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.odontologo);
    }
    
    @Override
    public Integer insertar(Odontologo odontologo) {
       this.odontologo=odontologo;
       return super.insertar();
    }
    
    @Override
    public Integer eliminar(Odontologo odontologo) {
       this.odontologo=odontologo;
       return super.eliminar();
    }
    
    @Override
    public Odontologo obtenerPorId(Integer Id){
        this.odontologo = new Odontologo();
        this.odontologo.setIdOdontologo(Id);
        super.obtenerPorId();
        return this.odontologo;
    }
    
    @Override
    public ArrayList<Odontologo> listarTodos(){
        return (ArrayList<Odontologo>) super.listarTodos();
    }
   
}
