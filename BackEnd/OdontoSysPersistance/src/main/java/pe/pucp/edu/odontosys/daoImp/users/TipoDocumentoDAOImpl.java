package pe.pucp.edu.odontosys.daoImp.users;

import pe.pucp.edu.odontosys.dao.users.TipoDocumentoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;

import pe.pucp.edu.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;


public class TipoDocumentoDAOImpl extends DAOImplBase implements TipoDocumentoDAO {
    private TipoDocumento tipoDocumento;
    
    public TipoDocumentoDAOImpl(){
        super("OS_TIPOS_DOCUMENTOS");
        this.retornarLlavePrimaria=true;
        this.tipoDocumento = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("TIPO_DOCUMENTO_ID",true,true));
        this.listaColumnas.add(new Columna("DESCRIPCION",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.tipoDocumento.getNombre());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.tipoDocumento.getNombre());
        this.statement.setInt(2,this.tipoDocumento.getIdTipoDocumento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(2,this.tipoDocumento.getIdTipoDocumento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(2,this.tipoDocumento.getIdTipoDocumento());
    }
    
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.tipoDocumento = new TipoDocumento();
        this.tipoDocumento.setIdTipoDocumento(this.resultSet.getInt("TIPO_DOCUMENTO_ID"));
        this.tipoDocumento.setNombre(this.resultSet.getString("DESCRIPCION"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.tipoDocumento = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.tipoDocumento);
    }
    
    @Override
    public Integer insertar(TipoDocumento tipoDocumento) {
       this.tipoDocumento=tipoDocumento;
       return super.insertar();
    }
    
    @Override
    public Integer modificar(TipoDocumento tipoDocumento) {
       this.tipoDocumento=tipoDocumento;
       return super.modificar();
    }
    
    @Override
    public Integer eliminar(TipoDocumento tipoDocumento) {
       this.tipoDocumento=tipoDocumento;
       return super.eliminar();
    }
    
    @Override
    public TipoDocumento obtenerPorId(Integer id){
        this.tipoDocumento = new TipoDocumento();
        this.tipoDocumento.setIdTipoDocumento(id);
        super.obtenerPorId();
        return this.tipoDocumento;
    }
    
    @Override
    public ArrayList<TipoDocumento> listarTodos(){
        return (ArrayList<TipoDocumento>) super.listarTodos();
    }
    
}
