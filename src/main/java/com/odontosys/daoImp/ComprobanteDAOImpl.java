package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.ComprobanteDAO;
import com.odontosys.services.model.Comprobante;
import com.odontosys.infraestructure.model.MetodoPago;
import com.odontosys.daoImp.util.Columna;



import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ComprobanteDAOImpl extends DAOImplBase implements ComprobanteDAO {
    private Comprobante comprobante;
    
    public ComprobanteDAOImpl(){
        super("comprobante");
        this.retornarLlavePrimaria=true;
        this.comprobante=null;
    }
    
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idComprobante",true,true));
        this.listaColumnas.add(new Columna("fechaEmision",false,false));
        this.listaColumnas.add(new Columna("total",false,false));
        this.listaColumnas.add(new Columna("metodoPago",false,false));
    }
    @Override
    public Integer insertar(Comprobante comprobante) {
        this.comprobante=comprobante;
        return super.insertar();
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion(){
        try {
            this.statement.setDate(1,this.comprobante.getFechaEmision());
            this.statement.setDouble(2,this.comprobante.getTotal());
            this.statement.setString(3, this.comprobante.getMetodoPago().name());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
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
