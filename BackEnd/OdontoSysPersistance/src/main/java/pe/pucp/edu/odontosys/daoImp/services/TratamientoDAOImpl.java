package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.services.TratamientoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.QueryLoader;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Tratamiento;
import pe.pucp.edu.odontosys.services.model.Especialidad;

public class TratamientoDAOImpl extends DAOImplBase implements TratamientoDAO{
    
    private Tratamiento tratamiento;
    private static final QueryLoader queries = new QueryLoader("/tratamientoQueries.json");
    
    public TratamientoDAOImpl(){
        super("OS_TRATAMIENTOS");
        this.retornarLlavePrimaria = true;
        this.tratamiento = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("TRATAMIENTO_ID",true,true));
        this.listaColumnas.add(new Columna("ESPECIALIDAD_ID",false,false));
        this.listaColumnas.add(new Columna("NOMBRE",false,false));
        this.listaColumnas.add(new Columna("DESCRIPCION",false,false));
        this.listaColumnas.add(new Columna("COSTO",false,false));  
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.tratamiento.getEspecialidad().getIdEspecialidad());
        this.statement.setString(2, this.tratamiento.getNombre());
        this.statement.setString(3, this.tratamiento.getDescripcion());
        this.statement.setDouble(4, this.tratamiento.getCosto()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setInt(1, this.tratamiento.getEspecialidad().getIdEspecialidad());
        this.statement.setString(2, this.tratamiento.getNombre());
        this.statement.setString(3, this.tratamiento.getDescripcion());
        this.statement.setDouble(4, this.tratamiento.getCosto()); 
        this.statement.setInt(5, this.tratamiento.getIdTratamiento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.tratamiento.getIdTratamiento()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.tratamiento.getIdTratamiento());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.tratamiento = new Tratamiento();
        this.tratamiento.setIdTratamiento(this.resultSet.getInt("TRATAMIENTO_ID"));
        this.tratamiento.getEspecialidad().setIdEspecialidad(this.resultSet.getInt("ESPECIALIDAD_ID"));
        this.tratamiento.setNombre(this.resultSet.getString("NOMBRE"));
        this.tratamiento.setDescripcion(this.resultSet.getString("DESCRIPCION"));
        this.tratamiento.setCosto(this.resultSet.getDouble("COSTO")); 
    }
    
    @Override
    protected void instanciarObjetoCompletoDelResultSet() throws SQLException {
        this.instanciarObjetoDelResultSet();
        this.tratamiento.getEspecialidad().setNombre(this.resultSet.getString("ESPECIALIDAD_DESCRIPCION"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.tratamiento = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.tratamiento);
    }
    
    @Override
    public Integer insertar(Tratamiento tratamiento){
        this.tratamiento = tratamiento;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Tratamiento tratamiento){
        this.tratamiento = tratamiento;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Tratamiento tratamiento) {
       this.tratamiento=tratamiento;
       return super.eliminar();
    }
    
    @Override
    public Tratamiento obtenerPorId(Integer id){
        this.tratamiento = new Tratamiento();
        this.tratamiento.setIdTratamiento(id);
        super.obtenerPorId();
        return this.tratamiento;
    }
    
    @Override
    public ArrayList<Tratamiento> listarTodos(){
        return (ArrayList<Tratamiento>) super.listarTodos();
    }
    
    @Override
    public ArrayList<Tratamiento> listarPorEspecialidad(Especialidad especialidad){
        String sql = queries.getQuery("listarTratamientosPorEspecialidad");
        return (ArrayList<Tratamiento>) super.ejecutarQueryListar(sql, especialidad.getIdEspecialidad());
    }
    
}
