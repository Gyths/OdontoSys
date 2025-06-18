

package pe.pucp.edu.odontosys.daoImp.users;

import pe.pucp.edu.odontosys.dao.users.OdontologoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Especialidad;

import pe.pucp.edu.odontosys.users.model.*;

import java.sql.*;
import java.util.ArrayList;
import java.util.List;

public class OdontologoDAOImpl extends DAOImplBase implements OdontologoDAO {
    private Odontologo odontologo;
    
    public OdontologoDAOImpl(){
        super("OS_ODONTOLOGOS");
        this.retornarLlavePrimaria=true;
        this.odontologo = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("ODONTOLOGO_ID",true,true));
        this.listaColumnas.add(new Columna("CONTRASENHA",false,false));
        this.listaColumnas.add(new Columna("NOMBRE_USUARIO",false,false));
        this.listaColumnas.add(new Columna("CORREO",false,false));
        this.listaColumnas.add(new Columna("TELEFONO",false,false));
        this.listaColumnas.add(new Columna("NOMBRES",false,false));
        this.listaColumnas.add(new Columna("APELLIDOS",false,false));
        this.listaColumnas.add(new Columna("TIPO_DOCUMENTO_ID",false,false));
        this.listaColumnas.add(new Columna("NUMERO_DOCUMENTO_IDENTIDAD",false,false));
        this.listaColumnas.add(new Columna("PUNTUACION_PROMEDIO",false,false));
        this.listaColumnas.add(new Columna("ESPECIALIDAD_ID",false,false));   
        this.listaColumnas.add(new Columna("SALA_ID",false,false));   
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1,this.odontologo.getContrasenha());
        this.statement.setString(2,this.odontologo.getNombreUsuario());
        this.statement.setString(3,this.odontologo.getCorreo());
        this.statement.setString(4,this.odontologo.getTelefono());
        this.statement.setString(5,this.odontologo.getNombre());
        this.statement.setString(6,this.odontologo.getApellidos());
        this.statement.setInt(7,this.odontologo.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.odontologo.getNumeroDocumento());
        this.statement.setDouble(9,this.odontologo.getPuntuacionPromedio());
        this.statement.setInt(10, this.odontologo.getEspecialidad().getIdEspecialidad());
        this.statement.setInt(11,this.odontologo.getConsultorio().getIdSala());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1,this.odontologo.getContrasenha());
        this.statement.setString(2,this.odontologo.getNombreUsuario());
        this.statement.setString(3,this.odontologo.getCorreo());
        this.statement.setString(4,this.odontologo.getTelefono());
        this.statement.setString(5,this.odontologo.getNombre());
        this.statement.setString(6,this.odontologo.getApellidos());
        this.statement.setInt(7,this.odontologo.getTipoDocumento().getIdTipoDocumento());
        this.statement.setString(8,this.odontologo.getNumeroDocumento());
        this.statement.setDouble(9,this.odontologo.getPuntuacionPromedio());
        this.statement.setInt(10, this.odontologo.getEspecialidad().getIdEspecialidad());
        this.statement.setInt(11,this.odontologo.getConsultorio().getIdSala());
        this.statement.setInt(12, this.odontologo.getIdOdontologo());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.odontologo.getIdOdontologo()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1,this.odontologo.getIdOdontologo());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException { 
        this.odontologo = new Odontologo();
        this.odontologo.setIdOdontologo(this.resultSet.getInt("ODONTOLOGO_ID"));
        this.odontologo.setContrasenha(this.resultSet.getString("CONTRASENHA"));
        this.odontologo.setNombreUsuario(this.resultSet.getString("NOMBRE_USUARIO"));
        this.odontologo.setCorreo(this.resultSet.getString("CORREO"));
        this.odontologo.setTelefono(this.resultSet.getString("TELEFONO"));
        this.odontologo.setNombre(this.resultSet.getString("NOMBRES"));
        this.odontologo.setApellidos(this.resultSet.getString("APELLIDOS"));
        this.odontologo.getTipoDocumento().setIdTipoDocumento(this.resultSet.getInt("TIPO_DOCUMENTO_ID"));
        this.odontologo.setNumeroDocumento(this.resultSet.getString("NUMERO_DOCUMENTO_IDENTIDAD"));
        this.odontologo.setPuntuacionPromedio(this.resultSet.getDouble("PUNTUACION_PROMEDIO"));
        this.odontologo.getEspecialidad().setIdEspecialidad(this.resultSet.getInt("ESPECIALIDAD_ID"));
        this.odontologo.getConsultorio().setIdSala(this.resultSet.getInt("SALA_ID"));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.odontologo = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.odontologo);
    }
    
    @Override
    public Integer insertar(Odontologo odontologo) {
       this.odontologo=odontologo;
       return super.insertar();
    }
    
    @Override
    public Integer modificar(Odontologo odontologo) {
       this.odontologo=odontologo;
       return super.modificar();
    }
    
    @Override
    public Integer eliminar(Odontologo odontologo) {
       this.odontologo=odontologo;
       return super.eliminar();
    }
    
    @Override
    public Odontologo obtenerPorId(Integer id){
        this.odontologo = new Odontologo();
        this.odontologo.setIdOdontologo(id);
        super.obtenerPorId();
        return this.odontologo;
    }
    
    @Override
    public ArrayList<Odontologo> listarTodos(){
        return (ArrayList<Odontologo>) super.listarTodos();
    }
    
    @Override
    public ArrayList<Odontologo> listarPorEspecialidad(Especialidad especialidad){
        String sql = "CALL ODONTOLOGOS_listar_por_especialidad(?);";
        return (ArrayList<Odontologo>) super.ejecutarStoredProcedureLista(sql, especialidad.getIdEspecialidad());
    }
    
    @Override
    public Odontologo obtenerPorUsuarioContrasenha(String nombreUsuario, String contrasenha) {
        String sql= "CALL ODONTOLOGOS_obtener_por_usuario_contrasenha(?, ?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario, contrasenha);
        return this.odontologo;
    }
    
    @Override
    public Integer actualizarPuntuacion(Odontologo odontologo) {
        String sql= "CALL ODONTOLOGOS_actualizar_subtotal(?);";
        return super.ejecutarStoredProcedureModificar(sql, odontologo.getIdOdontologo());
    }
    
    @Override
    public Boolean existeNombreUsuario(String nombreUsuario) {
        String sql= "CALL ODONTOLOGOS_obtener_por_usuario(?);";
        super.ejecutarStoredProcedureObtener(sql, nombreUsuario);
        if(this.odontologo==null)return false;
        return true;
    }
}
