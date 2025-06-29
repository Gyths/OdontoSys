package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.sql.Date;
import java.sql.Time;
import java.time.LocalDate;
import java.time.LocalTime;

import pe.pucp.edu.odontosys.dao.services.ComprobanteDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import pe.pucp.edu.odontosys.services.model.Cita;

public class ComprobanteDAOImpl extends DAOImplBase implements ComprobanteDAO{
    
    private Comprobante comprobante;
    
    public ComprobanteDAOImpl(){
        super("OS_COMPROBANTES");
        this.retornarLlavePrimaria = true;
        this.comprobante = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("COMPROBANTE_ID",true,true));
        this.listaColumnas.add(new Columna("METODO_PAGO_ID",false,false));
        this.listaColumnas.add(new Columna("FECHA_EMISION",false,false));
        this.listaColumnas.add(new Columna("HORA_EMISION",false,false));
        this.listaColumnas.add(new Columna("TOTAL",false,false));  
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.comprobante.getMetodoDePago().getIdMetodoPago());
        this.statement.setObject(2, LocalDate.parse(this.comprobante.getFechaEmision()));
        this.statement.setObject(3, LocalTime.parse(this.comprobante.getHoraEmision()));
        this.statement.setDouble(4, this.comprobante.getTotal());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setInt(1, this.comprobante.getMetodoDePago().getIdMetodoPago());
        this.statement.setObject(2, LocalDate.parse(this.comprobante.getFechaEmision()));
        this.statement.setObject(3, LocalTime.parse(this.comprobante.getHoraEmision()));
        this.statement.setDouble(4, this.comprobante.getTotal());
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
        this.comprobante.setIdComprobante(this.resultSet.getInt("COMPROBANTE_ID"));
        this.comprobante.getMetodoDePago().setIdMetodoPago(this.resultSet.getInt("METODO_PAGO_ID"));
        this.comprobante.setFechaEmision(this.resultSet.getObject("FECHA_EMISION").toString());
        this.comprobante.setHoraEmision(this.resultSet.getObject("HORA_EMISION").toString());
        this.comprobante.setTotal(this.resultSet.getDouble("TOTAL")); 
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
    public Comprobante obtenerPorId(Integer id){
        this.comprobante = new Comprobante();
        this.comprobante.setIdComprobante(id);
        super.obtenerPorId();
        return this.comprobante;
    }
    
    @Override
    public ArrayList<Comprobante> listarTodos(){
        return (ArrayList<Comprobante>) super.listarTodos();
    }
    
    @Override
    public Integer actualizarTotal(Cita cita){
        String sql = "CALL COMPROBANTES_actualizar_total(?);";
        return super.ejecutarQueryModificar(sql, cita.getIdCita()); 
    }
    
}
