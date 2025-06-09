package pe.pucp.edu.odontosys.daoImp.services;

import pe.pucp.edu.odontosys.dao.services.EspecialidadDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class EspecialidadDAOImpl extends DAOImplBase implements EspecialidadDAO{
    private Especialidad especialidad;
    
    public EspecialidadDAOImpl(){
        super("OS_ESPECIALIDADES");
        this.retornarLlavePrimaria = true;
        this.especialidad = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("ESPECIALIDAD_ID",true,true));
        this.listaColumnas.add(new Columna("DESCRIPCION",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.especialidad.getNombre());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.especialidad.getNombre());
        this.statement.setInt(2, this.especialidad.getIdEspecialidad()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.especialidad.getIdEspecialidad()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.especialidad.getIdEspecialidad()); 
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.especialidad = new Especialidad();
        this.especialidad.setIdEspecialidad(this.resultSet.getInt("ESPECIALIDAD_ID"));
        this.especialidad.setNombre(this.resultSet.getString("DESCRIPCION"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.especialidad = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.especialidad);
    }
    
    @Override
    public Integer insertar(Especialidad especialidad){
        this.especialidad = especialidad;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Especialidad especialidad){
        this.especialidad = especialidad;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Especialidad especialidad) {
       this.especialidad=especialidad;
       return super.eliminar();
    }
    
    @Override
    public Especialidad obtenerPorId(Integer id){
        this.especialidad = new Especialidad();
        this.especialidad.setIdEspecialidad(id);
        super.obtenerPorId();
        return this.especialidad;
    }
    
    @Override
    public ArrayList<Especialidad> listarTodos(){
        return (ArrayList<Especialidad>) super.listarTodos();
    }
}
