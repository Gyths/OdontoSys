package com.odontosys.daoImp;

import com.odontosys.dao.OdontologoDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Especialidad;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

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
        this.listaColumnas.add(new Columna("idPersona",false,false));
        this.listaColumnas.add(new Columna("puntuacionPromedio",false,false));
        this.listaColumnas.add(new Columna("especialidad",false,false));   
        this.listaColumnas.add(new Columna("idSala",false,false));   
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
    public ArrayList<Odontologo> listarTodos(){
        return (ArrayList<Odontologo>) super.listarTodos();
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.odontologo = new Odontologo();
        this.odontologo.setIdOdontologo(this.resultSet.getInt("idOdontogo"));
        this.odontologo.setIdPersona(this.resultSet.getInt("idPersona"));
        this.odontologo.setPuntuacionPromedio(this.resultSet.getDouble("puntuacionPromedio"));
        this.odontologo.setEspecialidad(Especialidad.valueOf(this.resultSet.getString("especialidad")));
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
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1,this.odontologo.getIdPersona());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.odontologo.getIdOdontologo()); 
    }
}
