package pe.pucp.edu.odontosys.daoImp.users;

import pe.pucp.edu.odontosys.dao.users.PacienteDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;

import pe.pucp.edu.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class PacienteDAOImpl extends DAOImplBase implements PacienteDAO {
    private Paciente paciente;
    
    public PacienteDAOImpl(){
        super("OS_PACIENTES");
        this.retornarLlavePrimaria=true;
        this.paciente = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("PACIENTE_ID",true,true));
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
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setInt(7,this.paciente.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.paciente.getNumeroDocumento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.paciente.getContrasenha());
        this.statement.setString(2,this.paciente.getNombreUsuario());
        this.statement.setString(3,this.paciente.getCorreo());
        this.statement.setString(4,this.paciente.getTelefono());
        this.statement.setString(5,this.paciente.getNombre());
        this.statement.setString(6,this.paciente.getApellidos());
        this.statement.setInt(7,this.paciente.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.paciente.getNumeroDocumento());
        this.statement.setInt(9,this.paciente.getIdPaciente());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1,this.paciente.getIdPaciente());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.paciente.getIdPaciente());
    }

    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(this.resultSet.getInt("PACIENTE_ID"));
        this.paciente.setContrasenha(this.resultSet.getString("CONTRASENHA"));
        this.paciente.setNombreUsuario(this.resultSet.getString("NOMBRE_USUARIO"));
        this.paciente.setCorreo(this.resultSet.getString("CORREO"));
        this.paciente.setTelefono(this.resultSet.getString("TELEFONO"));
        this.paciente.setNombre(this.resultSet.getString("NOMBRES"));
        this.paciente.setApellidos(this.resultSet.getString("APELLIDOS"));
        this.paciente.getTipoDocumento().setIdTipoDocumento(this.resultSet.getInt("TIPO_DOCUMENTO_ID"));
        this.paciente.setNumeroDocumento(this.resultSet.getString("NUMERO_DOCUMENTO_IDENTIDAD"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.paciente = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.paciente);
    }
    
    @Override
    public Integer insertar(Paciente paciente) {
       this.paciente=paciente;
       return super.insertar();
    }
    
    @Override
    public Integer modificar(Paciente paciente) {
       this.paciente=paciente;
       return super.modificar();
    }
    
    @Override
    public Integer eliminar(Paciente paciente) {
       this.paciente=paciente;
       return super.eliminar();
    }
    
    @Override
    public Paciente obtenerPorId(Integer id){
        this.paciente = new Paciente();
        this.paciente.setIdPaciente(id);
        super.obtenerPorId();
        return this.paciente;
    }
    
    @Override
    public ArrayList<Paciente> listarTodos(){
        return (ArrayList<Paciente>) super.listarTodos();
    }   
    
    @Override
    public Paciente obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha) {
        String sql= "CALL PACIENTES_obtener_por_usuario_contrasenha(?, ?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario, contrasenha);
        return this.paciente;
    }
    
    @Override
    public Boolean existeNombreUsuario(String nombreUsuario) {
        String sql= "CALL PACIENTES_obtener_por_usuario(?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario);
        if(this.paciente==null)return false;
        return true;
    }
    
    @Override
    public ArrayList<Paciente> buscarPorNombreApellido(String nombre, String apellido){
        String sql = "CALL PACIENTES_buscar_por_nombre_apellido(?, ?);";
        return (ArrayList<Paciente>) super.ejecutarStoredProcedureLista(sql, nombre, apellido);
    }
    
    @Override
    public ArrayList<Paciente> buscarPorNombreApellidoDocumento(String nombre, String apellido, String documento){
        String sql = "CALL PACIENTES_buscar_por_nombre_apellido_documento(?, ?, ?);";
        return (ArrayList<Paciente>) super.ejecutarStoredProcedureLista(sql, nombre, apellido, documento);
    }
    
    @Override
    public ArrayList<Paciente> buscarPorNombreApellidoTelefono(String nombre, String apellido, String telefono){
        String sql = "CALL PACIENTES_buscar_por_nombre_apellido_telefono(?, ?, ?);";
        return (ArrayList<Paciente>) super.ejecutarStoredProcedureLista(sql, nombre, apellido, telefono);
    }
    
    @Override
    public Boolean existeNumeroDocumento(String numDoc){
        String sql= "CALL PACIENTES_obtener_por_numero_documento(?);";
        super.ejecutarStoredProcedureObtener(sql, numDoc);
        if(this.paciente==null)return false;
        return true;
    }
}
