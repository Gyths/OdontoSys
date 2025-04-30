package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.PersonaDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.users.model.Persona;
import com.odontosys.users.model.Usuario;
import com.odontosys.users.model.TipoUsuario;

import java.sql.*;
import java.util.ArrayList;

public class PersonaDAOImpl extends UsuarioDAOImpl implements PersonaDAO{
    private Persona persona;
    
    public PersonaDAOImpl(){
        super("persona");
        this.retornarLlavePrimaria=true;
        this.persona = null;
    }
    
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idUsuario",true,true));
        this.listaColumnas.add(new Columna("nombre",false,false));
        this.listaColumnas.add(new Columna("apellido",false,false));
        this.listaColumnas.add(new Columna("DNI",false,false));
        this.listaColumnas.add(new Columna("telefono",false,false));
    }
    
    @Override
    public Integer insertar(Persona persona) {
       this.persona=persona;
       return super.insertar();
    }

    @Override
    public Integer modificarCorreo(int idUsuario, String nuevoCorreo) {
        int resultado = 0;
        return resultado;
    }

    @Override
    public Integer eliminar(int idUsuario) {
        int resultado = 0;
        return resultado;
    }


    @Override
    public ArrayList<Usuario> listarTodos() {
        return null;
    }
    
}
