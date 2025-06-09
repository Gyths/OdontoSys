package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.services.CitaDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.services.model.EstadoCita;
import pe.pucp.edu.odontosys.users.model.*;
import java.time.LocalDate;
import java.time.LocalTime;
import pe.pucp.edu.odontosys.services.model.Valoracion;

public class CitaDAOImpl extends DAOImplBase implements CitaDAO{
    
    private Cita cita;
    
    public CitaDAOImpl(){
        super("OS_CITAS");
        this.retornarLlavePrimaria = true;
        this.cita = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("CITA_ID",true,true));
        this.listaColumnas.add(new Columna("PACIENTE_ID",false,false));
        this.listaColumnas.add(new Columna("RECEPCIONISTA_ID", false, false));
        this.listaColumnas.add(new Columna("ODONTOLOGO_ID",false,false));
        this.listaColumnas.add(new Columna("COMPROBANTE_ID",false,false));
        this.listaColumnas.add(new Columna("FECHA",false,false));
        this.listaColumnas.add(new Columna("HORA_INICIO",false,false));
        this.listaColumnas.add(new Columna("VALORACION_ID",false,false));
        this.listaColumnas.add(new Columna("ESTADO",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getRecepcionista().getIdRecepcionista());
        this.statement.setInt(3, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setInt(4, this.cita.getComprobante().getIdComprobante());
        this.statement.setObject(5, this.cita.getFecha());
        this.statement.setObject(6,this.cita.getHoraInicio());
        this.statement.setDouble(7,this.cita.getValoracion().getIdValoracion());
        this.statement.setString(8, this.cita.getEstado().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getRecepcionista().getIdRecepcionista());
        this.statement.setInt(3, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setInt(4, this.cita.getComprobante().getIdComprobante());
        this.statement.setObject(5, this.cita.getFecha());
        this.statement.setObject(6,this.cita.getHoraInicio());
        this.statement.setDouble(7,this.cita.getValoracion().getIdValoracion());
        this.statement.setString(8, this.cita.getEstado().name());
        this.statement.setInt(9, this.cita.getIdCita());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.cita.getIdCita()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.cita.getIdCita());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.cita = new Cita();
        this.cita.setIdCita(this.resultSet.getInt("CITA_ID"));
        this.cita.getPaciente().setIdPaciente(this.resultSet.getInt("PACIENTE_ID"));
        this.cita.getRecepcionista().setIdRecepcionista(this.resultSet.getInt("RECEPCIONISTA_ID"));
        this.cita.getOdontologo().setIdOdontologo(this.resultSet.getInt("ODONTOLOGO_ID"));
        this.cita.getComprobante().setIdComprobante(this.resultSet.getInt("COMPROBANTE_ID"));
        this.cita.setFecha(this.resultSet.getObject("FECHA",LocalDate.class));
        this.cita.setHoraInicio(this.resultSet.getObject("HORA_INICIO",LocalTime.class));
        this.cita.getValoracion().setIdValoracion(this.resultSet.getInt("VALORACION_ID"));
        this.cita.setEstado(EstadoCita.valueOf(this.resultSet.getString("ESTADO")));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.cita = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.cita);
    }
    
    @Override
    public Integer insertar(Cita cita){
        this.cita = cita;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Cita cita){
        this.cita = cita;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Cita cita) {
       this.cita=cita;
       return super.eliminar();
    }
    
    @Override
    public Cita obtenerPorId(Integer id){
        this.cita = new Cita();
        this.cita.setIdCita(id);
        super.obtenerPorId();
        return this.cita;
    }
    
    @Override
    public ArrayList<Cita> listarTodos(){
        return (ArrayList<Cita>) super.listarTodos();
    }
    
    @Override
    public ArrayList<Cita> listarPorOdontologoFechas(Odontologo odontologo, LocalDate fechaInicio, LocalDate fechaFin){
        String sql = "CALL CITAS_listar_por_odontologo_fechas(?, ?, ?);"; 
        return (ArrayList<Cita>) ejecutarStoredProcedureLista(sql, odontologo.getIdOdontologo(), fechaInicio, fechaFin);
    }
    
    @Override
    public ArrayList<Cita> listarPorOdontologo(Odontologo odontologo){
        String sql = "CALL CITAS_listar_por_odontologo(?);";
        return (ArrayList<Cita>) super.ejecutarStoredProcedureLista(sql, odontologo.getIdOdontologo());
    }
    
    @Override
    public ArrayList<Cita> listarPorPaciente(Paciente paciente){
        String sql = "CALL CITAS_listar_por_paciente(?);";
        return (ArrayList<Cita>) super.ejecutarStoredProcedureLista(sql, paciente.getIdPaciente());
    }
    
    @Override
    public ArrayList<Cita> listarPorRecepcionista(Recepcionista recepcionista){
        String sql = "CALL CITAS_listar_por_recepcionista(?);";
        
        return (ArrayList<Cita>) super.ejecutarStoredProcedureLista(sql, recepcionista.getIdRecepcionista());
    }
    
    @Override
    public Integer actualizarFkValoracion(Cita cita, Valoracion valoracion){
        String sql = "CALL CITAS_actualizar_fk_valoracion(?, ?);";
        return super.ejecutarStoredProcedureModificar(sql, cita.getIdCita(), valoracion.getIdValoracion());
    }
    
}
