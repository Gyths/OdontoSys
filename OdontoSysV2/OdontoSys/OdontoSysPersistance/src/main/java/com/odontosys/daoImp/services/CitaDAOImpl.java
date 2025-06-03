package com.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.services.CitaDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Cita;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.users.model.Odontologo;
import java.time.LocalDate;
import java.time.LocalTime;

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
        this.listaColumnas.add(new Columna("PUNTUACION",false,false));
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
        this.statement.setDouble(7,this.cita.getPuntuacion());
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
        this.statement.setDouble(7,this.cita.getPuntuacion());
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
        this.cita.setPuntuacion(this.resultSet.getDouble("PUNTUACION"));
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
    public Cita obtenerPorId(Integer Id){
        this.cita = new Cita();
        this.cita.setIdCita(Id);
        super.obtenerPorId();
        return this.cita;
    }
    
    @Override
    public ArrayList<Cita> listarTodos(){
        return (ArrayList<Cita>) super.listarTodos();
    }
    
    @Override
    public ArrayList<Cita>listarPorOdontologo(Odontologo odontologo,LocalDate fechaInicio,LocalDate fechaFin){
        String sql = "SELECT * FROM OS_CITAS WHERE ODONTOLOGO_ID = ";
        sql+=odontologo.getIdOdontologo();
        sql+= " and FECHA < '";
        sql+=fechaFin.toString();
        sql+= "' and FECHA > '";
        sql+=fechaInicio.toString();
        sql+="' ORDER BY FECHA, HORA_INICIO";
        
        List lista = new ArrayList<>();
        try {
            this.abrirConexion();
            this.colocarSQLenStatement(sql);
            this.ejecutarConsultaEnBD();
            while (this.resultSet.next()) {
                agregarObjetoALaLista(lista);
            }
        } catch (SQLException ex) {
            System.err.println("Error al intentar listar - " + ex);
        } finally {
            try {
                this.cerrarConexion();
            } catch (SQLException ex) {
                System.err.println("Error al cerrar la conexión - " + ex);
            }
        }
        return (ArrayList<Cita>)lista;
    }
    
}
