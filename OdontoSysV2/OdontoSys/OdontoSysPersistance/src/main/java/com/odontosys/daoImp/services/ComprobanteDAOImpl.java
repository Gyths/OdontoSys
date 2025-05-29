package com.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.sql.Date;
import java.sql.Time;

import com.odontosys.dao.services.ComprobanteDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Comprobante;
import com.odontosys.infrastructure.model.MetodoPago;

public class ComprobanteDAOImpl extends DAOImplBase implements ComprobanteDAO{
    
    private Comprobante comprobante;
    
    public ComprobanteDAOImpl(){
        super("comprobante");
        this.retornarLlavePrimaria = true;
        this.comprobante = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idComprobante",true,true));
        this.listaColumnas.add(new Columna("fechaEmision",false,false));
        this.listaColumnas.add(new Columna("horaEmision",false,false));
        this.listaColumnas.add(new Columna("total",false,false));
        this.listaColumnas.add(new Columna("metodoPago",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setDate(1, Date.valueOf(this.comprobante.getFechaEmision()));
        this.statement.setTime(2, Time.valueOf(this.comprobante.getHoraEmision()));
        this.statement.setDouble(3, this.comprobante.getTotal());
        this.statement.setString(4, this.comprobante.getMetodoDePago().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setDate(1, Date.valueOf(this.comprobante.getFechaEmision()));
        this.statement.setTime(2, Time.valueOf(this.comprobante.getHoraEmision()));
        this.statement.setDouble(3, this.comprobante.getTotal());
        this.statement.setString(4, this.comprobante.getMetodoDePago().name());
        this.statement.setInt(5, this.comprobante.getIdComprobante());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.comprobante.getIdComprobante()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.comprobante.getIdComprobante());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.comprobante = new Comprobante();
        this.comprobante.setIdComprobante(this.resultSet.getInt("idComprobante"));
        this.comprobante.setFechaEmision(this.resultSet.getDate("fechaEmision").toLocalDate());
        this.comprobante.setHoraEmision(this.resultSet.getTime("horaEmision").toLocalTime());
        this.comprobante.setTotal(this.resultSet.getDouble("total"));
        this.comprobante.setMetodoDePago(MetodoPago.valueOf(this.resultSet.getString("metodoDePago")));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.comprobante = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.comprobante);
    }
    
    @Override
    public Integer insertar(Comprobante comprobante){
        this.comprobante = comprobante;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Comprobante comprobante){
        this.comprobante = comprobante;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Comprobante comprobante) {
       this.comprobante=comprobante;
       return super.eliminar();
    }
    
    @Override
    public Comprobante obtenerPorId(Integer Id){
        this.comprobante = new Comprobante();
        this.comprobante.setIdComprobante(Id);
        super.obtenerPorId();
        return this.comprobante;
    }
    
    @Override
    public ArrayList<Comprobante> listarTodos(){
        return (ArrayList<Comprobante>) super.listarTodos();
    }
    
}
