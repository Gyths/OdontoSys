package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.TurnoDAO;
import com.odontosys.infraestructure.model.Turno;
import com.odontosys.infraestructure.model.DiaSemana;

import java.sql.*;
import java.util.ArrayList;

public class TurnoDAOImpl implements TurnoDAO {

    @Override
    public Integer insertar(Turno turno) {
        Integer idGenerado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "INSERT INTO turno (horaInicio, horaFin, diaSemana) VALUES (?, ?, ?)";
            PreparedStatement ps = conn.prepareStatement(sql, PreparedStatement.RETURN_GENERATED_KEYS);
            ps.setTime(1, turno.getHoraInicio());
            ps.setTime(2, turno.getHoraFin());
            ps.setString(3, turno.getDiaLaboral().name());

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
            System.err.println("Error al insertar turno: " + ex.getMessage());
        }

        return idGenerado;
    }

    @Override
    public Integer modificar(Turno turno) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "UPDATE turno SET horaInicio = ?, horaFin = ?, diaSemana = ? WHERE idTurno = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setTime(1, turno.getHoraInicio());
            ps.setTime(2, turno.getHoraFin());
            ps.setString(3, turno.getDiaLaboral().name());
            ps.setInt(4, turno.getIdTurno());

            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al modificar turno: " + ex.getMessage());
        }

        return resultado;
    }

    @Override
    public Integer eliminar(Turno turno) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "DELETE FROM turno WHERE idTurno = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, turno.getIdTurno());

            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al eliminar turno: " + ex.getMessage());
        }

        return resultado;
    }

    @Override
    public ArrayList<Turno> listarTodos() {
        ArrayList<Turno> lista = new ArrayList<>();
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "SELECT * FROM turno";
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Turno turno = new Turno();
                turno.setIdTurno(rs.getInt("idTurno"));
                turno.setHoraInicio(rs.getTime("horaInicio"));
                turno.setHoraFin(rs.getTime("horaFin"));
                turno.setDiaLaboral(DiaSemana.valueOf(rs.getString("diaSemana")));
                lista.add(turno);
            }

            rs.close();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al listar turnos: " + ex.getMessage());
        }

        return lista;
    }
}
