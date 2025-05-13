package com.odontosys.daoImp;

import com.odontosys.dao.RecepcionistaDAO;
import com.odontosys.daoImp.util.Columna;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class RecepcionistaDAOImpl extends DAOImplBase implements RecepcionistaDAO {
    private Recepcionista recepcionista;
    
    public RecepcionistaDAOImpl(){
        super("recepcionista");
        this.retornarLlavePrimaria=true;
        this.recepcionista = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idRecepcionista",true,true));
        this.listaColumnas.add(new Columna("idPersona",false,false));
    }
    
    @Override
    public Integer insertar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       //this.personaDAO.insertar((Persona)recepcionista);
       return super.insertar();
    }
    
    @Override
    public Integer eliminar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.eliminar();
    }
    
    @Override
    public ArrayList<Recepcionista> listarTodos(){
        return (ArrayList<Recepcionista>) super.listarTodos();
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.recepcionista = new Recepcionista();
        this.recepcionista.setIdRecepcionista(this.resultSet.getInt("idRecepcionista"));
        this.recepcionista.setIdPersona(this.resultSet.getInt("idPersona"));
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
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1,this.recepcionista.getIdPersona());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.recepcionista.getIdRecepcionista()); 
    }
}
