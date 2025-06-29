package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.services.DetalleTratamientoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.QueryLoader;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.services.model.DetalleTratamiento;
import pe.pucp.edu.odontosys.services.model.Tratamiento;

public class DetalleTratamientoDAOImpl extends DAOImplBase implements DetalleTratamientoDAO{
    
    private DetalleTratamiento detalleTratamiento;
    private static final QueryLoader queries = new QueryLoader("/detalleTratamientoQueries.json");
    
    public DetalleTratamientoDAOImpl(){
        super("OS_DETALLES_TRATAMIENTOS");
        this.retornarLlavePrimaria = true;
        this.detalleTratamiento = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("CITA_ID",true,false));
        this.listaColumnas.add(new Columna("TRATAMIENTO_ID",true,false));
        this.listaColumnas.add(new Columna("CANTIDAD",false,false));
        this.listaColumnas.add(new Columna("SUBTOTAL",false,false));
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
        this.detalleTratamiento.setIdCita(this.resultSet.getInt("CITA_ID"));
        this.detalleTratamiento.getTratamiento().setIdTratamiento(this.resultSet.getInt("TRATAMIENTO_ID"));
        this.detalleTratamiento.setCantidad(this.resultSet.getInt("CANTIDAD"));
        this.detalleTratamiento.setSubtotal(this.resultSet.getDouble("SUBTOTAL"));
    }
    
    @Override
    protected void instanciarObjetoCompletoDelResultSet() throws SQLException {
        this.instanciarObjetoDelResultSet();
        this.detalleTratamiento.getTratamiento().setNombre(this.resultSet.getString("TRATAMIENTO_NOMBRE"));
        this.detalleTratamiento.getTratamiento().setDescripcion(this.resultSet.getString("TRATAMIENTO_DESCRIPCION"));
        this.detalleTratamiento.getTratamiento().setCosto(this.resultSet.getDouble("TRATAMIENTO_COSTO"));
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
    protected void agregarObjetoCompletoALaLista(List lista) throws SQLException {
        this.instanciarObjetoCompletoDelResultSet();
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
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(DetalleTratamiento DetalleTratamiento) {
       this.detalleTratamiento=DetalleTratamiento;
       return super.eliminar();
    }
    
    @Override
    public DetalleTratamiento obtenerPorId(Integer id){
        this.detalleTratamiento = new DetalleTratamiento();
        this.detalleTratamiento.setIdCita(id);
        super.obtenerPorId();
        return this.detalleTratamiento;
    }
    
    @Override
    public ArrayList<DetalleTratamiento> listarTodos(){
        return (ArrayList<DetalleTratamiento>) super.listarTodos();
    }
    
    @Override
    public ArrayList<DetalleTratamiento> listarPorCita(Cita cita) {
        String sql = queries.getQuery("listarDetallesTratamientosPorCita");
        return (ArrayList<DetalleTratamiento>) super.ejecutarQueryListar(sql, cita.getIdCita());
    }
    
    @Override
    public Integer actualizarSubtotal(Cita cita) {
        String sql= "CALL DETALLES_TRATAMIENTOS_actualizar_subtotal(?);";
        return super.ejecutarQueryModificar(sql, cita.getIdCita());
    }
}
