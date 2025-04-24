package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.SalaDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infraestructure.model.Sala;

import java.sql.*;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

public class SalaDAOImpl extends DAOImplBase implements SalaDAO {
    private Sala sala;
    
    public SalaDAOImpl(){
        super("sala");
        this.retornarLlavePrimaria=true;
        this.sala=null;
    }
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idSala",true,true));
        this.listaColumnas.add(new Columna("numeroSala",false,false));
        this.listaColumnas.add(new Columna("piso",false,false));
    }
    //Metodos Base
    @Override
    public Integer insertar(Sala sala) {
        this.sala=sala;
        return super.insertar();
    }
    @Override
    public Integer eliminar(Sala sala) {
        this.sala=sala;
        return super.eliminar();
    }
    @Override
    protected void incluirValorDeParametrosParaEliminacion(){
        try {
            this.statement.setInt(1, sala.getIdSala());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    @Override
    protected void incluirValorDeParametrosParaInsercion(){
        try {
            this.statement.setString(1,this.sala.getNumero());
            this.statement.setInt(2,this.sala.getPiso());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    //Personalizados
    @Override
    public ArrayList<Sala> listarTodos() {
        ArrayList<Sala> lista = new ArrayList<>();
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "SELECT * FROM sala";
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Sala sala = new Sala();
                sala.setIdSala(rs.getInt("idSala"));
                sala.setNumero(rs.getString("numeroSala"));
                sala.setPiso(rs.getInt("piso"));
                lista.add(sala);
            }

            rs.close();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al listar salas: " + ex.getMessage());
        }

        return lista;
    }

    @Override
    public Integer modificar(Sala sala) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "UPDATE sala SET numeroSala = ?, piso = ? WHERE idSala = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, sala.getNumero());
            ps.setInt(2, sala.getPiso());
            ps.setInt(3, sala.getIdSala());

            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al modificar sala: " + ex.getMessage());
        }

        return resultado;
    }
}
