package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.UsuarioDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.users.model.Usuario;
import com.odontosys.users.model.TipoUsuario;

import java.sql.*;
import java.util.ArrayList;

public class UsuarioDAOImpl extends DAOImplBase implements UsuarioDAO{
    private Usuario usuario;
    
    public UsuarioDAOImpl(){
        super("usuario");
        this.retornarLlavePrimaria=true;
        this.usuario = null;
    }
    
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idUsuario",true,true));
        this.listaColumnas.add(new Columna("nombreUsuario",false,false));
        this.listaColumnas.add(new Columna("contraseña",false,false));
        this.listaColumnas.add(new Columna("activo",false,false));
        this.listaColumnas.add(new Columna("correo",false,false));
        this.listaColumnas.add(new Columna("tipoUsuario",false,false));
    }
    
    @Override
    public Integer insertar(Usuario usuario) {
       this.usuario=usuario;
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
