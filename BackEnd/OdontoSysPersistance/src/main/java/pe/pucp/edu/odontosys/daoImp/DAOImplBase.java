package pe.pucp.edu.odontosys.daoImp;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.function.Consumer;
import java.util.logging.Level;
import java.util.logging.Logger;

import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.daoImp.util.Tipo_Operacion;

import pe.pucp.edu.odontosys.db.DBManager;

public abstract class DAOImplBase {
    
    protected String nombre_tabla;
    protected ArrayList<Columna> listaColumnas;
    protected Boolean retornarLlavePrimaria;
    protected Boolean mostrarSentenciaSQL;
    protected Connection conexion;
    protected CallableStatement statement;
    protected ResultSet resultSet;
    
    public DAOImplBase(String nombre_tabla) {
        this.nombre_tabla = nombre_tabla;
        this.retornarLlavePrimaria = false;
        this.mostrarSentenciaSQL = true;
        this.incluirListaDeColumnas();
    }

    private void incluirListaDeColumnas() {
        this.listaColumnas = new ArrayList<>();
        this.configurarListaDeColumnas();
    }

    protected abstract void configurarListaDeColumnas();

    protected void abrirConexion() {
        this.conexion = DBManager.getInstance().getConnection();
    }

    protected void cerrarConexion() throws SQLException {
        if (this.conexion != null) {
            this.conexion.close();
            this.conexion = null;
        }
    }

    protected void iniciarTransaccion() throws SQLException {
        this.abrirConexion();
        this.conexion.setAutoCommit(false);
    }

    protected void comitarTransaccion() throws SQLException {
        this.conexion.commit();
    }

    protected void rollbackTransaccion() throws SQLException {
        if (this.conexion != null) {
            this.conexion.rollback();
        }
    }

    protected void colocarSQLenStatement(String sql) throws SQLException {
        this.statement = this.conexion.prepareCall(sql);
    }

    protected Integer ejecutarModificacionEnBD() throws SQLException {
        if (this.mostrarSentenciaSQL) {
            Logger.getLogger(DAOImplBase.class.getName()).log(Level.INFO, this.statement.toString());
        }
        return this.statement.executeUpdate();
    }

    protected void ejecutarConsultaEnBD() throws SQLException {
        this.resultSet = this.statement.executeQuery();
    }

    private Integer ejecuta_DML(Tipo_Operacion tipo_Operacion) {
        int resultado = 0;
        try {
            this.iniciarTransaccion();
            String sql = null;
            switch (tipo_Operacion) {
                case Tipo_Operacion.INSERTAR ->
                    sql = this.generarSQLParaInsercion();
                case Tipo_Operacion.MODIFICAR ->
                    sql = this.generarSQLParaModificacion();
                case Tipo_Operacion.ELIMINAR ->
                    sql = this.generarSQLParaEliminacion();
            }
            this.colocarSQLenStatement(sql);
            switch (tipo_Operacion) {
                case Tipo_Operacion.INSERTAR ->
                    this.incluirValorDeParametrosParaInsercion();
                case Tipo_Operacion.MODIFICAR ->
                    this.incluirValorDeParametrosParaModificacion();
                case Tipo_Operacion.ELIMINAR ->
                    this.incluirValorDeParametrosParaEliminacion();
            }
            System.out.println(sql);
            System.out.println(statement);
            resultado = this.ejecutarModificacionEnBD();
            if (this.retornarLlavePrimaria && tipo_Operacion == Tipo_Operacion.INSERTAR) {
                resultado = this.retornarUltimoAutoGenerado();
            }
            this.comitarTransaccion();
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar consulta - " + tipo_Operacion.toString() + ": " + ex);
            try {
                this.rollbackTransaccion();
            } catch (SQLException ex1) {
                System.err.println("Error al hacer rollback - " + ex);
            }
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }

    protected String generarSQLParaInsercion() {
        //sentencia SQL a generar similar a 
        //INSERT INTO NOMBRE_TABLA (COL1, COL2) VALUES (?,?)
        String sql = "INSERT INTO ";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat("(");
        String sql_columnas = "";
        String sql_parametros = "";
        for (Columna columna : this.listaColumnas) {
            if (!columna.getEsAutoGenerado()) {
                if (!sql_columnas.isBlank()) {
                    sql_columnas = sql_columnas.concat(", ");
                    sql_parametros = sql_parametros.concat(", ");
                }
                sql_columnas = sql_columnas.concat(columna.getNombre());
                sql_parametros = sql_parametros.concat("?");
            }
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(") VALUES (");
        sql = sql.concat(sql_parametros);
        sql = sql.concat(")");
        return sql;
    }

    protected String generarSQLParaModificacion() {
        //sentencia SQL a generar similar a 
        //UPDATE NOMBRE_TABLA SET COL1=?, COL2=? WHERE COL_ID=?
        String sql = "UPDATE ";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" SET ");
        String sql_columnas = "";
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsllavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    sql_predicado = sql_predicado.concat(", ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            } else {
                if (!sql_columnas.isBlank()) {
                    sql_columnas = sql_columnas.concat(", ");
                }
                sql_columnas = sql_columnas.concat(columna.getNombre());
                sql_columnas = sql_columnas.concat("=?");
            }
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" WHERE ");
        sql = sql.concat(sql_predicado);
        return sql;
    }

    protected String generarSQLParaEliminacion() {
        //sentencia SQL a generar similar a 
        //DELETE FROM NOMBRE_TABLA WHERE COL_ID=?
        String sql = "DELETE FROM ";
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" WHERE ");
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsllavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    sql_predicado = sql_predicado.concat(", ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            }
        }
        sql = sql.concat(sql_predicado);
        return sql;
    }
    
    protected String generarSQLParaObtenerPorId() {
        //sentencia SQL a generar es similar a 
        //SELECT COL1, COL2, COL3 FROM NOMBRE_TABLA WHERE COL_ID = ?
        String sql = "SELECT ";
        String sql_columnas = "*";
        String sql_predicado = "";
        for (Columna columna : this.listaColumnas) {
            if (columna.getEsllavePrimaria()) {
                if (!sql_predicado.isBlank()) {
                    sql_predicado = sql_predicado.concat(", ");
                }
                sql_predicado = sql_predicado.concat(columna.getNombre());
                sql_predicado = sql_predicado.concat("=?");
            }
        }
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" FROM ");
        sql = sql.concat(this.nombre_tabla);
        sql = sql.concat(" WHERE ");
        sql = sql.concat(sql_predicado);
        return sql;
    }
    
    protected String generarSQLParaListarTodos() {
        //sentencia SQL a generar es similar a 
        //SELECT COL1, COL2, COL3 FROM NOMBRE_TABLA
        String sql = "SELECT ";
        String sql_columnas = "*";
        sql = sql.concat(sql_columnas);
        sql = sql.concat(" FROM ");
        sql = sql.concat(this.nombre_tabla);
        return sql;
    }

    protected void incluirValorDeParametrosParaInsercion() throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }

    protected void incluirValorDeParametrosParaModificacion() throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }

    protected void incluirValorDeParametrosParaEliminacion() throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }
    
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }
    
    
    protected Integer insertar() {
        return this.ejecuta_DML(Tipo_Operacion.INSERTAR);
    }

    protected Integer modificar() {
        return this.ejecuta_DML(Tipo_Operacion.MODIFICAR);
    }

    protected Integer eliminar() {
        return this.ejecuta_DML(Tipo_Operacion.ELIMINAR);
    }
    
    public Integer retornarUltimoAutoGenerado() {
        Integer resultado = null;
        try {
            //cambiamos la sentencia para hacer el SW agnóstico a la base de datos
            //String sql = "select @@last_insert_id as id";
            String sql = DBManager.getInstance().retornarSQLParaUltimoAutoGenerado();
            this.statement = this.conexion.prepareCall(sql);
            this.resultSet = this.statement.executeQuery();
            if (this.resultSet.next()) {
                resultado = this.resultSet.getInt("id");
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar retornarUltimoAutoGenerado - " + ex);
        }
        return resultado;
    }

    public void obtenerPorId() {
        try {
            this.abrirConexion();
            String sql = this.generarSQLParaObtenerPorId();
            this.colocarSQLenStatement(sql);
            this.incluirValorDeParametrosParaObtenerPorId();
            this.ejecutarConsultaEnBD();
            if (this.resultSet.next()) {
                instanciarObjetoDelResultSet();
            } else {
                limpiarObjetoDelResultSet();
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar obtenerPorId - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
    }

    public List listarTodos() {
        String sql = null;
        Consumer incluirValorDeParametros = null;
        Object parametros = null;
        return this.listarTodos(sql, incluirValorDeParametros, parametros);
    }

    public List listarTodos(String sql, Consumer incluirValorDeParametros, Object parametros) {
        List lista = new ArrayList<>();
        try {
            this.abrirConexion();
            if (sql == null) {
                sql = this.generarSQLParaListarTodos();
            }
            this.colocarSQLenStatement(sql);
            if (incluirValorDeParametros != null) {
                incluirValorDeParametros.accept(parametros);
            }
            this.ejecutarConsultaEnBD();
            while (this.resultSet.next()) {
                agregarObjetoALaLista(lista);
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar listarTodos - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return lista;
    }
    
    protected void instanciarObjetoDelResultSet() throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }

    protected void limpiarObjetoDelResultSet() {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }

    protected void agregarObjetoALaLista(List lista) throws SQLException {
        throw new UnsupportedOperationException("Método no sobreescrito.");
    }
    
    protected List ejecutarStoredProcedureLista(String sql, Object... parametros){
        List resultado = new ArrayList<>();
        try {
            this.abrirConexion();
            this.colocarSQLenStatement(sql);
            if (parametros != null){
                for(int i = 0; i < parametros.length; i++){
                    this.statement.setObject(i+1, parametros[i]);
                }
            }
            this.ejecutarConsultaEnBD();
            while (this.resultSet.next()) {
                agregarObjetoALaLista(resultado);
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar Stored Procedure de Listar - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }
    
    protected Integer ejecutarStoredProcedureModificar(String sql, Object... parametros) {
        int resultado = 0;
        try {
            this.iniciarTransaccion();
            this.colocarSQLenStatement(sql);
            if (parametros != null){
                for(int i = 0; i < parametros.length; i++){
                    this.statement.setObject(i+1, parametros[i]);
                }
            }
            resultado = this.ejecutarModificacionEnBD();
            this.comitarTransaccion();
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar Stored Procedure de Modificacion - : " + ex);
            try {
                this.rollbackTransaccion();
            } catch (SQLException ex1) {
                System.err.println("Error al hacer rollback - " + ex);
            }
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }
    
    
    
    
    protected void ejecutarStoredProcedureObtener(String sql, Object... parametros){
        try {
            this.abrirConexion();
            this.colocarSQLenStatement(sql);
            if (parametros != null){
                for(int i = 0; i < parametros.length; i++){
                    this.statement.setObject(i+1, parametros[i]);
                }
            }
            this.ejecutarConsultaEnBD();
            if (this.resultSet.next()) {
                instanciarObjetoDelResultSet();
            } else {
                limpiarObjetoDelResultSet();
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar Stored Procedure de obtener - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
    }
    
}
