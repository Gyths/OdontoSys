package pe.pucp.edu.odontosys.daoImp.infrastructure;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.infrastructure.SalaDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.infrastructure.model.Sala;

public class SalaDAOImpl extends DAOImplBase implements SalaDAO{
    
    private Sala sala;
    
    public SalaDAOImpl(){
        super("OS_SALAS");
        this.retornarLlavePrimaria = true;
        this.sala = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("SALA_ID",true,true));
        this.listaColumnas.add(new Columna("NUMERO_SALA",false,false));
        this.listaColumnas.add(new Columna("PISO",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.sala.getNumero());
        this.statement.setInt(2, this.sala.getPiso());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.sala.getNumero());
        this.statement.setInt(2, this.sala.getPiso());
        this.statement.setInt(3, this.sala.getIdSala()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.sala.getIdSala()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.sala.getIdSala()); 
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.sala = new Sala();
        this.sala.setIdSala(this.resultSet.getInt("SALA_ID"));
        this.sala.setNumero(this.resultSet.getString("NUMERO_SALA"));
        this.sala.setPiso(this.resultSet.getInt("PISO"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.sala = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.sala);
    }
    
    @Override
    public Integer insertar(Sala sala){
        this.sala = sala;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Sala sala){
        this.sala = sala;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Sala sala) {
       this.sala=sala;
       return super.eliminar();
    }
    
    @Override
    public Sala obtenerPorId(Integer id){
        this.sala = new Sala();
        this.sala.setIdSala(id);
        super.obtenerPorId();
        return this.sala;
    }
    
    @Override
    public ArrayList<Sala> listarTodos(){
        return (ArrayList<Sala>) super.listarTodos();
    }
    
}
