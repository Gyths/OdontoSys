package com.odontosys.daoImp.users;

import com.odontosys.dao.users.RecepcionistaDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;


public class RecepcionistaDAOImpl extends DAOImplBase implements RecepcionistaDAO {
    private Recepcionista recepcionista;
    
    public RecepcionistaDAOImpl(){
        super("recepcionista");
        this.retornarLlavePrimaria=true;
        this.recepcionista = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idrecepcionista",true,true));
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
        this.statement.setString(1,this.recepcionista.getContrasenha());
        this.statement.setString(2,this.recepcionista.getNombreUsuario());
        this.statement.setString(3,this.recepcionista.getCorreo());
        this.statement.setString(4,this.recepcionista.getTelefono());
        this.statement.setString(5,this.recepcionista.getNombre());
        this.statement.setString(6,this.recepcionista.getApellidos());
        this.statement.setString(7,this.recepcionista.getDNI());
        this.statement.setInt(8,this.recepcionista.getTipoUsuario().ordinal());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.recepcionista.getContrasenha());
        this.statement.setString(2,this.recepcionista.getNombreUsuario());
        this.statement.setString(3,this.recepcionista.getCorreo());
        this.statement.setString(4,this.recepcionista.getTelefono());
        this.statement.setString(5,this.recepcionista.getNombre());
        this.statement.setString(6,this.recepcionista.getApellidos());
        this.statement.setString(7,this.recepcionista.getDNI());
        this.statement.setInt(8,this.recepcionista.getTipoUsuario().ordinal());
        this.statement.setInt(9,this.recepcionista.getIdRecepcionista());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1,this.recepcionista.getIdRecepcionista());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.recepcionista.getIdRecepcionista());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.recepcionista = new Recepcionista();
        this.recepcionista.setIdRecepcionista(this.resultSet.getInt("idRecepcionista"));
        this.recepcionista.setContrasenha(this.resultSet.getString("contrasenha"));
        this.recepcionista.setNombreUsuario(this.resultSet.getString("nombreUsuario"));
        this.recepcionista.setCorreo(this.resultSet.getString("correo"));
        this.recepcionista.setTelefono(this.resultSet.getString("telefono"));
        this.recepcionista.setNombre(this.resultSet.getString("nombre"));
        this.recepcionista.setApellidos(this.resultSet.getString("apellidos"));
        this.recepcionista.setDNI(this.resultSet.getString("DNI"));
        this.recepcionista.setTipoUsuario(TipoUsuario.values()[this.resultSet.getInt("tipoUsuario")]);
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.recepcionista = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.recepcionista);
    }
    
    @Override
    public Integer insertar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.insertar();
    }
    
    @Override
    public Integer eliminar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.eliminar();
    }
    
    @Override
    public Recepcionista obtenerPorId(Integer Id){
        this.recepcionista = new Recepcionista();
        this.recepcionista.setIdRecepcionista(Id);
        super.obtenerPorId();
        return this.recepcionista;
    }
    
    @Override
    public ArrayList<Recepcionista> listarTodos(){
        return (ArrayList<Recepcionista>) super.listarTodos();
    }
}
