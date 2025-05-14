package com.odontosys.daoImp;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.DetalleTratamientoDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.DetalleTratamiento;
import com.odontosys.services.model.Tratamiento;

public class DetalleTratamientoDAOImpl extends DAOImplBase implements DetalleTratamientoDAO{
    
    private DetalleTratamiento detalleTratamiento;
    
    public DetalleTratamientoDAOImpl(){
        super("DetalleTratamiento");
        this.retornarLlavePrimaria = true;
        this.detalleTratamiento = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idCita",true,false));
        this.listaColumnas.add(new Columna("idTratamiento",true,false));
        this.listaColumnas.add(new Columna("cantidad",false,false));
        this.listaColumnas.add(new Columna("subtotal",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.detalleTratamiento.getIdCita());
        this.statement.setInt(2, this.detalleTratamiento.getTratamiento().getIdTratamiento());
        this.statement.setInt(3, this.detalleTratamiento.getCantidad());
        this.statement.setDouble(4, this.detalleTratamiento.getSubtotal());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setInt(1, this.detalleTratamiento.getCantidad());
        this.statement.setDouble(2, this.detalleTratamiento.getSubtotal());
        this.statement.setInt(3, this.detalleTratamiento.getIdCita());
        this.statement.setInt(4, this.detalleTratamiento.getTratamiento().getIdTratamiento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.detalleTratamiento.getIdCita());
        this.statement.setInt(2, this.detalleTratamiento.getTratamiento().getIdTratamiento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.detalleTratamiento.getIdCita());
        this.statement.setInt(2, this.detalleTratamiento.getTratamiento().getIdTratamiento());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.detalleTratamiento = new DetalleTratamiento();
        this.detalleTratamiento.setIdCita(this.resultSet.getInt("idCita"));
        Tratamiento t = new Tratamiento();
        t.setIdTratamiento(this.resultSet.getInt("idTratamiento"));
        this.detalleTratamiento.setTratamiento(t);
        this.detalleTratamiento.setCantidad(this.resultSet.getInt("cantidad"));
        this.detalleTratamiento.setSubtotal(this.resultSet.getDouble("subtotal"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.detalleTratamiento = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.detalleTratamiento);
    }
    
    @Override
    public Integer insertar(DetalleTratamiento detalleTratamiento){
        this.detalleTratamiento = detalleTratamiento;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(DetalleTratamiento detalleTratamiento){
        this.detalleTratamiento = detalleTratamiento;
        return this.Modificar();
    }
    
    @Override
    public Integer eliminar(DetalleTratamiento DetalleTratamiento) {
       this.detalleTratamiento=DetalleTratamiento;
       return this.Delete();
    }
    
    @Override
    public DetalleTratamiento obtenerPorId(Integer Id){
        this.detalleTratamiento = new DetalleTratamiento();
        this.detalleTratamiento.setIdCita(Id);
        super.obtenerPorId();
        return this.detalleTratamiento;
    }
    
    @Override
    public ArrayList<DetalleTratamiento> listarTodos(){
        return (ArrayList<DetalleTratamiento>) super.listarTodos();
    }
    
     private Integer Delete() {
        int resultado = 0;
        try {
            this.iniciarTransaccion();
            String sql = null;
            sql = "DELETE FROM DetalleTratamiento WHERE idCita=? AND idTratamiento=?";
            this.colocarSQLenStatement(sql);
            this.incluirValorDeParametrosParaEliminacion();
            System.out.println(sql);
            System.out.println(statement);
            resultado = this.ejecutarModificacionEnBD();
            this.comitarTransaccion();
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar eliminacion - " + ex);
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
     
    private Integer Modificar() {
        int resultado = 0;
        try {
            this.iniciarTransaccion();
            String sql = null;
            sql = "UPDATE DetalleTratamiento SET cantidad=?, subtotal=? WHERE idCita=? AND idTratamiento=?";
            this.colocarSQLenStatement(sql);
            this.incluirValorDeParametrosParaModificacion();
            System.out.println(sql);
            System.out.println(statement);
            resultado = this.ejecutarModificacionEnBD();
            this.comitarTransaccion();
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar modificacion - " + ex);
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
    
}
