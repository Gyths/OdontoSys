package com.odontosys.daoImp;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.TurnoXOdontologoDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infrastructure.model.TurnoXOdontologo;

public class TurnoXOdontologoDAOImpl extends DAOImplBase implements TurnoXOdontologoDAO{
    
    private TurnoXOdontologo turnoXOdontologo;
    
    public TurnoXOdontologoDAOImpl(){
        super("odontologo_turno");
        this.retornarLlavePrimaria = true;
        this.turnoXOdontologo = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idOdontologo",true,false));
        this.listaColumnas.add(new Columna("idTurno",true,false));
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
        this.turnoXOdontologo.setIdOdontologo(this.resultSet.getInt("idOdontologo"));
        this.turnoXOdontologo.setIdTurno(this.resultSet.getInt("idTurno"));
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
       return super.eliminar();
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
    
}
