package com.odontosys.daoImp.infrastructure;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.infrastructure.TurnoXOdontologoDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infrastructure.model.TurnoXOdontologo;

public class TurnoXOdontologoDAOImpl extends DAOImplBase implements TurnoXOdontologoDAO{
    
    private TurnoXOdontologo turnoXOdontologo;
    
    public TurnoXOdontologoDAOImpl(){
        super("OS_TURNOS_POR_ODONTOLOGOS");
        this.retornarLlavePrimaria = true;
        this.turnoXOdontologo = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("ODONTOLOGO_ID",true,false));
        this.listaColumnas.add(new Columna("TURNO_ID",true,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.turnoXOdontologo.getIdOdontologo());
        this.statement.setInt(2, this.turnoXOdontologo.getIdTurno());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        System.out.println("No se necesita");
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.turnoXOdontologo.getIdOdontologo());
        this.statement.setInt(2, this.turnoXOdontologo.getIdTurno()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.turnoXOdontologo.getIdOdontologo());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.turnoXOdontologo = new TurnoXOdontologo();
        this.turnoXOdontologo.setIdOdontologo(this.resultSet.getInt("ODONTOLOGO_ID"));
        this.turnoXOdontologo.setIdTurno(this.resultSet.getInt("TURNO_ID"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.turnoXOdontologo = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.turnoXOdontologo);
    }
    
    @Override
    public Integer insertar(TurnoXOdontologo turnoXOdontologo){
        this.turnoXOdontologo = turnoXOdontologo;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(TurnoXOdontologo turnoXOdontologo){
        this.turnoXOdontologo = turnoXOdontologo;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(TurnoXOdontologo TurnoXOdontologo) {
       this.turnoXOdontologo=TurnoXOdontologo;
       return this.Eliminar();
    }
    
    @Override
    public TurnoXOdontologo obtenerPorId(Integer Id){
        this.turnoXOdontologo = new TurnoXOdontologo();
        this.turnoXOdontologo.setIdOdontologo(Id);
        super.obtenerPorId();
        return this.turnoXOdontologo;
    }
    
    @Override
    public ArrayList<TurnoXOdontologo> listarTodos(){
        return (ArrayList<TurnoXOdontologo>) super.listarTodos();
    }
    
    public Integer Eliminar() {
        int resultado = 0;
        try {
            this.iniciarTransaccion();
             String sql = "DELETE FROM OS_ODONTOLOGOS_POR_TURNOS WHERE ODONTOLOGO_ID = ? AND TURNO_ID = ?";
             this.colocarSQLenStatement(sql);
             this.incluirValorDeParametrosParaEliminacion();
             resultado = this.ejecutarModificacionEnBD();
             this.comitarTransaccion();
        } catch (SQLException ex) {
            System.err.println("Error al intentar ejecutar eliminacio");
            try{
                this.rollbackTransaccion();
            } catch (SQLException ex1){
                System.err.println("Error al hacer rollback - " + ex);
            }
        } finally{
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return resultado;
    }
    
    @Override
    public ArrayList<TurnoXOdontologo> listarPorDoctor(Integer odontologoID){
        String sql = "SELECT * FROM OS_TURNOS_POR_ODONTOLOGOS WHERE ODONTOLOGO_ID = ";
        sql+=odontologoID.toString();
        List lista = new ArrayList<>();
        try {
            this.abrirConexion();
            this.colocarSQLenStatement(sql);
            this.ejecutarConsultaEnBD();
            while (this.resultSet.next()) {
                agregarObjetoALaLista(lista);
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar listar - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return (ArrayList<TurnoXOdontologo>)lista;
    }
}
