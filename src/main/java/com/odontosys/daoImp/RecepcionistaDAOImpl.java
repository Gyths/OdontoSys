package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.RecepcionistaDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.users.model.Recepcionista;
import com.odontosys.users.model.TipoUsuario;

import java.sql.*;
import java.util.ArrayList;

public class RecepcionistaDAOImpl extends DAOImplBase implements RecepcionistaDAO {
    private Recepcionista recepcionista;
    
    public RecepcionistaDAOImpl(){
        super("recepcionista");
        this.retornarLlavePrimaria=true;
        this.recepcionista = null;
    }
    
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idComprobante",true,true));
        this.listaColumnas.add(new Columna("fechaEmision",false,false));
        this.listaColumnas.add(new Columna("total",false,false));
        this.listaColumnas.add(new Columna("metodoPago",false,false));
    }
    
    @Override
    public Integer insertar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.insertar();
    }

    @Override
    public Integer modificarCorreo(int idUsuario, String nuevoCorreo) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();
        try {
            String sql = "UPDATE usuario SET correo = ? WHERE idUsuario = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setString(1, nuevoCorreo);
            ps.setInt(2, idUsuario);
            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al modificar correo: " + ex.getMessage());
        }
        return resultado;
    }

    @Override
    public Integer eliminar(int idUsuario) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            conn.setAutoCommit(false);

            // Paso 1: eliminar de recepcionista
            String sqlRecep = "DELETE FROM recepcionista WHERE idUsuario = ?";
            PreparedStatement psRecep = conn.prepareStatement(sqlRecep);
            psRecep.setInt(1, idUsuario);
            psRecep.executeUpdate();
            psRecep.close();

            // Paso 2: eliminar de persona
            String sqlPersona = "DELETE FROM persona WHERE idUsuario = ?";
            PreparedStatement psPersona = conn.prepareStatement(sqlPersona);
            psPersona.setInt(1, idUsuario);
            psPersona.executeUpdate();
            psPersona.close();

            // Paso 3: eliminar de usuario
            String sqlUsuario = "DELETE FROM usuario WHERE idUsuario = ?";
            PreparedStatement psUsuario = conn.prepareStatement(sqlUsuario);
            psUsuario.setInt(1, idUsuario);
            resultado = psUsuario.executeUpdate();
            psUsuario.close();

            conn.commit();
        } catch (SQLException ex) {
            System.err.println("Error al eliminar recepcionista en cascada: " + ex.getMessage());
            try {
                conn.rollback();
            } catch (SQLException rollbackEx) {
                System.err.println("Error en rollback: " + rollbackEx.getMessage());
            }
        } finally {
            try {
                conn.setAutoCommit(true);
            } catch (SQLException ex) {
                System.err.println("Error al restaurar autoCommit: " + ex.getMessage());
            }
        }

        return resultado;
    }


    @Override
    public ArrayList<Recepcionista> listarTodos() {
        ArrayList<Recepcionista> lista = new ArrayList<>();
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = """
                SELECT u.idUsuario, u.nombreUsuario, u.correo, p.nombre, p.apellido, p.DNI, p.telefono
                FROM usuario u
                JOIN persona p ON u.idUsuario = p.idUsuario
                JOIN recepcionista r ON u.idUsuario = r.idUsuario
                WHERE u.tipoUsuario = 'RECEPCIONISTA'
                """;
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Recepcionista r = new Recepcionista();
                r.setIdUsuario(rs.getInt("idUsuario"));
                r.setNombreUsuario(rs.getString("nombreUsuario"));
                r.setCorreo(rs.getString("correo"));
                r.setNombre(rs.getString("nombre"));
                r.setApellido(rs.getString("apellido"));
                r.setDNI(rs.getString("DNI"));
                r.setTelefono(rs.getString("telefono"));
                lista.add(r);
            }

            rs.close();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al listar recepcionistas: " + ex.getMessage());
        }

        return lista;
    }
}

