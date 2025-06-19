package pe.pucp.edu.odontosys.daoImp.users;

import pe.pucp.edu.odontosys.dao.users.RecepcionistaDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;

import pe.pucp.edu.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;


public class RecepcionistaDAOImpl extends DAOImplBase implements RecepcionistaDAO {
    private Recepcionista recepcionista;
    
    public RecepcionistaDAOImpl(){
        super("OS_RECEPCIONISTAS");
        this.retornarLlavePrimaria=true;
        this.recepcionista = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("RECEPCIONISTA_ID",true,true));
        this.listaColumnas.add(new Columna("CONTRASENHA",false,false));
        this.listaColumnas.add(new Columna("NOMBRE_USUARIO",false,false));
        this.listaColumnas.add(new Columna("CORREO",false,false));
        this.listaColumnas.add(new Columna("TELEFONO",false,false));
        this.listaColumnas.add(new Columna("NOMBRES",false,false));
        this.listaColumnas.add(new Columna("APELLIDOS",false,false));
        this.listaColumnas.add(new Columna("TIPO_DOCUMENTO_ID",false,false));
        this.listaColumnas.add(new Columna("NUMERO_DOCUMENTO_IDENTIDAD",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.recepcionista.getContrasenha());
        this.statement.setString(2,this.recepcionista.getNombreUsuario());
        this.statement.setString(3,this.recepcionista.getCorreo());
        this.statement.setString(4,this.recepcionista.getTelefono());
        this.statement.setString(5,this.recepcionista.getNombre());
        this.statement.setString(6,this.recepcionista.getApellidos());
        this.statement.setInt(7, this.recepcionista.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.recepcionista.getNumeroDocumento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.recepcionista.getContrasenha());
        this.statement.setString(2,this.recepcionista.getNombreUsuario());
        this.statement.setString(3,this.recepcionista.getCorreo());
        this.statement.setString(4,this.recepcionista.getTelefono());
        this.statement.setString(5,this.recepcionista.getNombre());
        this.statement.setString(6,this.recepcionista.getApellidos());
        this.statement.setInt(7, this.recepcionista.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.recepcionista.getNumeroDocumento());
        this.statement.setInt(9,this.recepcionista.getIdRecepcionista());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1,this.recepcionista.getIdRecepcionista());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.recepcionista.getIdRecepcionista());
    }

    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.recepcionista = new Recepcionista();
        this.recepcionista.setIdRecepcionista(this.resultSet.getInt("RECEPCIONISTA_ID"));
        this.recepcionista.setContrasenha(this.resultSet.getString("CONTRASENHA"));
        this.recepcionista.setNombreUsuario(this.resultSet.getString("NOMBRE_USUARIO"));
        this.recepcionista.setCorreo(this.resultSet.getString("CORREO"));
        this.recepcionista.setTelefono(this.resultSet.getString("TELEFONO"));
        this.recepcionista.setNombre(this.resultSet.getString("NOMBRES"));
        this.recepcionista.setApellidos(this.resultSet.getString("APELLIDOS"));
        this.recepcionista.getTipoDocumento().setIdTipoDocumento(this.resultSet.getInt("TIPO_DOCUMENTO_ID"));
        this.recepcionista.setNumeroDocumento(this.resultSet.getString("NUMERO_DOCUMENTO_IDENTIDAD"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.recepcionista = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.recepcionista);
    }
    
    @Override
    public Integer insertar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.insertar();
    }
    
    @Override
    public Integer modificar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.modificar();
    }
    
    @Override
    public Integer eliminar(Recepcionista recepcionista) {
       this.recepcionista=recepcionista;
       return super.eliminar();
    }
    
    @Override
    public Recepcionista obtenerPorId(Integer id){
        this.recepcionista = new Recepcionista();
        this.recepcionista.setIdRecepcionista(id);
        super.obtenerPorId();
        return this.recepcionista;
    }
    
    @Override
    public ArrayList<Recepcionista> listarTodos(){
        return (ArrayList<Recepcionista>) super.listarTodos();
    }

    @Override
    public Recepcionista obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha){
        String sql = "CALL RECEPCIONISTAS_obtener_por_usuario_contrasenha(?, ?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario, contrasenha);
        return this.recepcionista;
    }
    
    @Override
    public Boolean existeNombreUsuario(String nombreUsuario) {
        String sql= "CALL RECEPCIONISTAS_obtener_por_usuario(?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario);
        if(this.recepcionista==null)return false;
        return true;
    }
}
