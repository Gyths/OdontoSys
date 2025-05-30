package com.odontosys.daoImp.infrastructure;

import com.odontosys.dao.infrastructure.MetodoPagoDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infrastructure.model.MetodoPago;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

public class MetodoPagoDAOImpl extends DAOImplBase implements MetodoPagoDAO{
        
    private MetodoPago metodoPago;
    
    public MetodoPagoDAOImpl(){
        super("metodoPago");
        this.retornarLlavePrimaria = true;
        this.metodoPago = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idMetodoPago",true,true));
        this.listaColumnas.add(new Columna("nombre",false,false));
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
        this.metodoPago.setIdMetodoPago(this.resultSet.getInt("idMetodoPago"));
        this.metodoPago.setNombre(this.resultSet.getString("nombre"));
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
    public MetodoPago obtenerPorId(Integer Id){
        this.metodoPago = new MetodoPago();
        this.metodoPago.setIdMetodoPago(Id);
        super.obtenerPorId();
        return this.metodoPago;
    }
    
    @Override
    public ArrayList<MetodoPago> listarTodos(){
        return (ArrayList<MetodoPago>) super.listarTodos();
    }
    
}
