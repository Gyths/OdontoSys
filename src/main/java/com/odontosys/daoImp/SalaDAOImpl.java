package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.SalaDAO;
import com.odontosys.infraestructure.model.Sala;

import java.sql.*;
import java.util.ArrayList;

public class SalaDAOImpl implements SalaDAO {

    @Override
    public Integer insertar(Sala sala) {
        Integer idGenerado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "INSERT INTO sala (numeroSala, piso) VALUES (?, ?)";
            PreparedStatement ps = conn.prepareStatement(sql, PreparedStatement.RETURN_GENERATED_KEYS);
            ps.setString(1, sala.getNumero());
            ps.setInt(2, sala.getPiso());

            int resultado = ps.executeUpdate();

            if (resultado != 0) {
                ResultSet rs = ps.getGeneratedKeys();
                if (rs.next()) {
                    idGenerado = rs.getInt(1);
                }
                rs.close();
            }

            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al insertar sala: " + ex.getMessage());
        }

        return idGenerado;
    }

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

    @Override
    public Integer eliminar(Sala sala) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "DELETE FROM sala WHERE idSala = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, sala.getIdSala());

            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al eliminar sala: " + ex.getMessage());
        }

        return resultado;
    }
}
