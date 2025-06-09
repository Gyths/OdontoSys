package pe.pucp.edu.odontosys.daoImp.infrastructure;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.infrastructure.TurnoXOdontologoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.infrastructure.model.TurnoXOdontologo;

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
    
    public Integer eliminar(TurnoXOdontologo turnoXOdontologo) {
        String sql = "CALL ODONTOLOGOS_POR_TURNOS_eliminar(?, ?);";
        return super.ejecutarStoredProcedureModificar(sql, turnoXOdontologo.getIdOdontologo(), turnoXOdontologo.getIdTurno());
    }
    
    @Override
    public TurnoXOdontologo obtenerPorId(Integer id){
        this.turnoXOdontologo = new TurnoXOdontologo();
        this.turnoXOdontologo.setIdOdontologo(id);
        super.obtenerPorId();
        return this.turnoXOdontologo;
    }
    
    @Override
    public ArrayList<TurnoXOdontologo> listarTodos(){
        return (ArrayList<TurnoXOdontologo>) super.listarTodos();
    }
    
    
    
}
