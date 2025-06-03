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
        super("OS_PACIENTES");
        this.retornarLlavePrimaria=true;
        this.paciente = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("PACIENTE_ID",true,true));
        this.listaColumnas.add(new Columna("CONTRASENHA",false,false));
        this.listaColumnas.add(new Columna("NOMBRE_USUARIO",false,false));
        this.listaColumnas.add(new Columna("CORREO",false,false));
        this.listaColumnas.add(new Columna("TELEFONO",false,false));
        this.listaColumnas.add(new Columna("NOMBRES",false,false));
        this.listaColumnas.add(new Columna("APELLIDOS",false,false));
        this.listaColumnas.add(new Columna("TIPO_DOCUMENTO_ID",false,false));
        this.listaColumnas.add(new Columna("NUMERO_DOCUMENTO_IDENTIDAD",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setInt(7,this.paciente.getTipoDocumento().ordinal());
        this.statement.setString(8,this.paciente.getNumeroDocumento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setInt(7,this.paciente.getTipoDocumento().ordinal());
        this.statement.setString(8,this.paciente.getNumeroDocumento());
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
    protected void incluirValorDeParametrosParaObtenerPorNombreUsuario() throws SQLException {
        this.statement.setString(1,this.paciente.getNombreUsuario());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(this.resultSet.getInt("PACIENTE_ID"));
        this.paciente.setContrasenha(this.resultSet.getString("CONTRASENHA"));
        this.paciente.setNombreUsuario(this.resultSet.getString("NOMBRE_USUARIO"));
        this.paciente.setCorreo(this.resultSet.getString("CORREO"));
        this.paciente.setTelefono(this.resultSet.getString("TELEFONO"));
        this.paciente.setNombre(this.resultSet.getString("NOMBRES"));
        this.paciente.setApellidos(this.resultSet.getString("APELLIDOS"));
        this.paciente.setTipoDocumento(TipoDocumento.values()[this.resultSet.getInt("TIPO_DOCUMENTO_ID")]);
        this.paciente.setNumeroDocumento(this.resultSet.getString("NUMERO_DOCUMENTO_IDENTIDAD"));
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
    public Integer modificar(Paciente paciente) {
       this.paciente=paciente;
       return super.modificar();
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
    
    @Override
    public Paciente buscarPorUsuario(String nombreUsuario){
        this.paciente = new Paciente();
        this.paciente.setNombreUsuario(nombreUsuario);
        super.obtenerPorNombreUsuario();
        return this.paciente;
    }
    
}
