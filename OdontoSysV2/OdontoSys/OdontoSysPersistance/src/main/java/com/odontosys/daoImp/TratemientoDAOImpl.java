package com.odontosys.daoImp;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.TratamientoDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Tratamiento;
import com.odontosys.services.model.Especialidad;

public class TratemientoDAOImpl extends DAOImplBase implements TratamientoDAO{
    
    private Tratamiento tratamiento;
    
    public TratemientoDAOImpl(){
        super("tratamiento");
        this.retornarLlavePrimaria = true;
        this.tratamiento = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idTratamiento",true,true));
        this.listaColumnas.add(new Columna("nombre",false,false));
        this.listaColumnas.add(new Columna("descripcion",false,false));
        this.listaColumnas.add(new Columna("costo",false,false));
        this.listaColumnas.add(new Columna("especialidad",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1, this.tratamiento.getNombre());
        this.statement.setString(2, this.tratamiento.getDescripcion());
        this.statement.setDouble(3, this.tratamiento.getCosto());
        this.statement.setString(4, this.tratamiento.getEspecialidad().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1, this.tratamiento.getNombre());
        this.statement.setString(2, this.tratamiento.getDescripcion());
        this.statement.setDouble(3, this.tratamiento.getCosto());
        this.statement.setString(4, this.tratamiento.getEspecialidad().name());
        this.statement.setInt(5, this.tratamiento.getIdTratamiento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(5, this.tratamiento.getIdTratamiento()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(5, this.tratamiento.getIdTratamiento());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.tratamiento = new Tratamiento();
        this.tratamiento.setIdTratamiento(this.resultSet.getInt("idTratamiento"));
        this.tratamiento.setNombre(this.resultSet.getString("nombre"));
        this.tratamiento.setDescripcion(this.resultSet.getString("descripcion"));
        this.tratamiento.setCosto(this.resultSet.getDouble("costo"));
        this.tratamiento.setEspecialidad(Especialidad.valueOf(this.resultSet.getString("especialidad")));
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
    public Tratamiento obtenerPorId(Integer Id){
        this.tratamiento = new Tratamiento();
        this.tratamiento.setIdTratamiento(Id);
        super.obtenerPorId();
        return this.tratamiento;
    }
    
    @Override
    public ArrayList<Tratamiento> listarTodos(){
        return (ArrayList<Tratamiento>) super.listarTodos();
    }
    
}
