package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.ComprobanteDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infraestructure.model.MetodoPago;
import com.odontosys.services.model.Comprobante;
import java.sql.Date;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.logging.Level;
import java.util.logging.Logger;

public class ComprobanteDAOImpl extends DAOImplBase implements ComprobanteDAO{

    private Comprobante comprobante;

    public ComprobanteDAOImpl() {
        super("comprobante");
        this.retornarLlavePrimaria = true;
        this.comprobante = null;
    }

    @Override
    protected void configurarListaDeColumna() {
        this.listaColumnas.add(new Columna("idComprobante", true, true));
        this.listaColumnas.add(new Columna("fechaEmision", false, false));
        this.listaColumnas.add(new Columna("total", false, false));
        this.listaColumnas.add(new Columna("metodoPago", false, false));
    }

    @Override
    public Integer insertar(Comprobante comprobante) {
        this.comprobante = comprobante;
        return super.insertar();
    }

    @Override
    protected void incluirValorDeParametrosParaInsercion() {
        try {
            this.statement.setDate(1, (Date) this.comprobante.getFechaEmision());
            this.statement.setDouble(2, this.comprobante.getTotal());
            this.statement.setString(3, this.comprobante.getMetodoPago().name());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }

    @Override
    public Comprobante obtenerPorId(Integer comprobanteId) {
        Comprobante comprobante = null;
        try {
            this.conexion = DBManager.getInstance().getConnection();
            String sql = this.generarSQLParaObtenerPorId();
            this.statement = this.conexion.prepareCall(sql);
            this.statement.setInt(1, comprobanteId);
            this.resultSet = this.statement.executeQuery();
            if (this.resultSet.next()) {
                comprobante = new Comprobante();
                comprobante.setIdComprobante(this.resultSet.getInt("idComprobante"));
                comprobante.setFechaEmision(this.resultSet.getDate("fechaEmision"));
                comprobante.setTotal(this.resultSet.getDouble("total"));
                comprobante.setMetodoPago(MetodoPago.valueOf(this.resultSet.getString("metodoPago")));
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar obtenerPorId - " + ex);
        } finally {
            try {
                if (this.conexion != null) {
                    this.conexion.close();
                }
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return comprobante;
    }

    @Override
    public ArrayList<Comprobante> listarTodos() {
        ArrayList<Comprobante> listaAlmacenes = new ArrayList<>();
        try {
            this.conexion = DBManager.getInstance().getConnection();
            String sql = this.generarSQLParaListarTodos();
            this.statement = this.conexion.prepareCall(sql);
            this.resultSet = this.statement.executeQuery();
            while (this.resultSet.next()) {
                Comprobante almacen = new Comprobante();
                comprobante.setIdComprobante(this.resultSet.getInt("idComprobante"));
                comprobante.setFechaEmision(this.resultSet.getDate("fechaEmision"));
                comprobante.setTotal(this.resultSet.getDouble("total"));
                comprobante.setMetodoPago(MetodoPago.valueOf(this.resultSet.getString("metodoPago")));
                listaAlmacenes.add(almacen);
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar listarTodos - " + ex);
        } finally {
            try {
                if (this.conexion != null) {
                    this.conexion.close();
                }
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return listaAlmacenes;
    }

    @Override
    public Integer modificar(Comprobante comprobante) {
        int resultado = 0;
        try {
            this.conexion = DBManager.getInstance().getConnection();
            this.conexion.setAutoCommit(false);
            String sql = this.generarSQLParaModificacion();
            this.statement = this.conexion.prepareCall(sql);
            this.statement.setDate(1, (Date) comprobante.getFechaEmision());
            this.statement.setDouble(2, comprobante.getTotal());
            this.statement.setString(3, comprobante.getMetodoPago().name());
            resultado = this.statement.executeUpdate();
            this.conexion.commit();
        } catch (SQLException ex) {
            System.err.println("Error al intentar modificar - " + ex);
            try {
                if (this.conexion != null) {
                    this.conexion.rollback();
                }
            } catch (SQLException ex1) {
                System.err.println("Error al hacer rollback - " + ex1);
            }
        } finally {
            try {
                if (this.conexion != null) {
                    this.conexion.close();
                }
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }

    @Override
    public Integer eliminar(Comprobante comprobante) {
        int resultado = 0;
        try {
            this.conexion = DBManager.getInstance().getConnection();
            this.conexion.setAutoCommit(false);
            String sql = this.generarSQLParaEliminacion();
            this.statement = this.conexion.prepareCall(sql);
            this.statement.setInt(1, comprobante.getIdComprobante());
            resultado = this.statement.executeUpdate();
            this.conexion.commit();
        } catch (SQLException ex) {
            System.err.println("Error al intentar eliminar - " + ex);
            try {
                if (this.conexion != null) {
                    this.conexion.rollback();
                }
            } catch (SQLException ex1) {
                System.err.println("Error al hacer rollback - " + ex1);
            }
        } finally {
            try {
                if (this.conexion != null) {
                    this.conexion.close();
                }
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }    
}
