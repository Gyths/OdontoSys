package pe.pucp.edu.odontosys.daoImp.infrastructure;

import pe.pucp.edu.odontosys.dao.infrastructure.MetodoPagoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class MetodoPagoDAOImpl extends DAOImplBase implements MetodoPagoDAO{
        
    private MetodoPago metodoPago;
    
    public MetodoPagoDAOImpl(){
        super("OS_METODOS_PAGOS");
        this.retornarLlavePrimaria = true;
        this.metodoPago = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("METODO_PAGO_ID",true,true));
        this.listaColumnas.add(new Columna("DESCRIPCION",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.metodoPago.getNombre());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.metodoPago.getNombre());
        this.statement.setInt(2, this.metodoPago.getIdMetodoPago()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.metodoPago.getIdMetodoPago()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.metodoPago.getIdMetodoPago()); 
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.metodoPago = new MetodoPago();
        this.metodoPago.setIdMetodoPago(this.resultSet.getInt("METODO_PAGO_ID"));
        this.metodoPago.setNombre(this.resultSet.getString("DESCRIPCION"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.metodoPago = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.metodoPago);
    }
    
    @Override
    public Integer insertar(MetodoPago metodoPago){
        this.metodoPago = metodoPago;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(MetodoPago metodoPago){
        this.metodoPago = metodoPago;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(MetodoPago metodoPago) {
       this.metodoPago=metodoPago;
       return super.eliminar();
    }
    
    @Override
    public MetodoPago obtenerPorId(Integer id){
        this.metodoPago = new MetodoPago();
        this.metodoPago.setIdMetodoPago(id);
        super.obtenerPorId();
        return this.metodoPago;
    }
    
    @Override
    public ArrayList<MetodoPago> listarTodos(){
        return (ArrayList<MetodoPago>) super.listarTodos();
    }
    
}
