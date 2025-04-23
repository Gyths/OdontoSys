package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.ComprobanteDAO;
import com.odontosys.services.model.Comprobante;
import com.odontosys.infraestructure.model.MetodoPago;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

public class ComprobanteDAOImpl implements ComprobanteDAO {

    @Override
    public Integer insertar(Comprobante comprobante) {
        Integer idGenerado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "INSERT INTO comprobante (fechaEmision, total, metodoPago) VALUES (?, ?, ?)";
            PreparedStatement ps = conn.prepareStatement(sql, PreparedStatement.RETURN_GENERATED_KEYS);
            ps.setDate(1, comprobante.getFechaEmision());
            ps.setDouble(2, comprobante.getTotal());
            ps.setString(3, comprobante.getMetodoPago().name());

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
            System.err.println("Error al insertar comprobante: " + ex.getMessage());
        }

        return idGenerado;
    }
    
    
    
    @Override
    public Comprobante obtenerPorId(Integer comprobanteId) {
        throw new UnsupportedOperationException("No implementado aún.");
    }


    @Override
    public ArrayList<Comprobante> listarTodos() {
        ArrayList<Comprobante> lista = new ArrayList<>();
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "SELECT * FROM comprobante";
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Comprobante comprobante = new Comprobante();
                comprobante.setIdComprobante(rs.getInt("idComprobante"));
                comprobante.setFechaEmision(rs.getDate("fechaEmision"));
                comprobante.setTotal(rs.getDouble("total"));
                comprobante.setMetodoPago(MetodoPago.valueOf(rs.getString("metodoPago")));
                lista.add(comprobante);
            }

            rs.close();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al listar comprobantes: " + ex.getMessage());
        }

        return lista;
    }


    @Override
    public Integer modificar(Comprobante comprobante) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "UPDATE comprobante SET total = ? WHERE idComprobante = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setDouble(1, comprobante.getTotal());
            ps.setInt(2, comprobante.getIdComprobante());

            resultado = ps.executeUpdate();

            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al modificar comprobante: " + ex.getMessage());
        }

        return resultado;
    }


    @Override
    public Integer eliminar(Comprobante comprobante) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "DELETE FROM comprobante WHERE idComprobante = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setInt(1, comprobante.getIdComprobante());

            resultado = ps.executeUpdate();

            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al eliminar comprobante: " + ex.getMessage());
        }

        return resultado;
    }

}
