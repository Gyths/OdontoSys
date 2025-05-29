package com.odontosys.daoImp.users;

import com.odontosys.dao.users.PacienteDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class PacienteDAOImpl extends DAOImplBase implements PacienteDAO {
    private Paciente paciente;
    
    public PacienteDAOImpl(){
        super("paciente");
        this.retornarLlavePrimaria=true;
        this.paciente = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idPaciente",true,true));
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
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setString(7,this.paciente.getDNI());
        this.statement.setInt(8,this.paciente.getTipoUsuario().ordinal());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setString(7,this.paciente.getDNI());
        this.statement.setInt(8,this.paciente.getTipoUsuario().ordinal());
        this.statement.setInt(9,this.paciente.getIdPaciente());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1,this.paciente.getIdPaciente());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.paciente.getIdPaciente());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(this.resultSet.getInt("idPaciente"));
        this.paciente.setContrasenha(this.resultSet.getString("contrasenha"));
        this.paciente.setNombreUsuario(this.resultSet.getString("nombreUsuario"));
        this.paciente.setCorreo(this.resultSet.getString("correo"));
        this.paciente.setTelefono(this.resultSet.getString("telefono"));
        this.paciente.setNombre(this.resultSet.getString("nombre"));
        this.paciente.setApellidos(this.resultSet.getString("apellidos"));
        this.paciente.setDNI(this.resultSet.getString("DNI"));
        this.paciente.setTipoUsuario(TipoUsuario.values()[this.resultSet.getInt("tipoUsuario")]);
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.paciente = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.paciente);
    }
    
    @Override
    public Integer insertar(Paciente paciente) {
       this.paciente=paciente;
       return super.insertar();
    }
    
    @Override
    public Integer eliminar(Paciente paciente) {
       this.paciente=paciente;
       return super.eliminar();
    }
    
    @Override
    public Paciente obtenerPorId(Integer Id){
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(Id);
        super.obtenerPorId();
        return this.paciente;
    }
    
    @Override
    public ArrayList<Paciente> listarTodos(){
        return (ArrayList<Paciente>) super.listarTodos();
    }
    
}
