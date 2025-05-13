package com.odontosys.daoImp;

import com.odontosys.dao.PacienteDAO;
import com.odontosys.daoImp.util.Columna;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class PacienteDAOImpl extends DAOImplBase implements PacienteDAO {
    private Paciente paciente;
    
    public PacienteDAOImpl(){
        super("recepcionista");
        this.retornarLlavePrimaria=true;
        this.paciente = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idPaciente",true,true));
        this.listaColumnas.add(new Columna("idPersona",false,false));
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
    public ArrayList<Paciente> listarTodos(){
        return (ArrayList<Paciente>) super.listarTodos();
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(this.resultSet.getInt("idPaciente"));
        this.paciente.setIdPersona(this.resultSet.getInt("idPersona"));
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
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1,this.paciente.getIdPersona());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.paciente.getIdPaciente()); 
    }
}
