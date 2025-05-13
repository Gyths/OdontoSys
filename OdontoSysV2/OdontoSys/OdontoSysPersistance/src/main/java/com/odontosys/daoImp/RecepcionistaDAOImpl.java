package com.odontosys.daoImp;

import com.odontosys.dao.RecepcionistaDAO;
import com.odontosys.daoImp.util.Columna;

import com.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

public class RecepcionistaDAOImpl extends DAOImplBase implements RecepcionistaDAO {
    private Recepcionista recepcionista;
    private PersonaDAOImpl personaDAO = new PersonaDAOImpl();
    
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
       this.personaDAO.insertar((Persona)recepcionista);
       return super.insertar();
    }
    
    @Override
       protected void incluirValorDeParametrosParaInsercion(){
           try {
               //Obtener el id del usuario ingresado asi no funciona, cambiar la tabla
               this.statement.setInt(1,this.recepcionista.getIdPersona());
           } catch (SQLException ex) {
               Logger.getLogger(RecepcionistaDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
           }
       }
}
