package com.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.services.CitaDAO;
import com.odontosys.daoImp.DAOImplBase;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Cita;
import com.odontosys.services.model.EstadoCita;
import java.time.LocalDate;
import java.time.LocalTime;

public class CitaDAOImpl extends DAOImplBase implements CitaDAO{
    
    private Cita cita;
    
    public CitaDAOImpl(){
        super("cita");
        this.retornarLlavePrimaria = true;
        this.cita = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("idCita",true,true));
        this.listaColumnas.add(new Columna("idPaciente",false,false));
        this.listaColumnas.add(new Columna("idOdontologo",false,false));
        this.listaColumnas.add(new Columna("idComprobante",false,false));
        this.listaColumnas.add(new Columna("fecha",false,false));
        this.listaColumnas.add(new Columna("horaInicio",false,false));
        this.listaColumnas.add(new Columna("puntuacion",false,false));
        this.listaColumnas.add(new Columna("estado",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setInt(3, this.cita.getComprobante().getIdComprobante());
        this.statement.setObject(4, this.cita.getFecha());
        this.statement.setObject(5,this.cita.getHoraInicio());
        this.statement.setDouble(6,this.cita.getPuntuacion());
        this.statement.setString(7, this.cita.getEstado().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setInt(3, this.cita.getComprobante().getIdComprobante());
        this.statement.setObject(4, this.cita.getFecha());
        this.statement.setObject(5,this.cita.getHoraInicio());
        this.statement.setDouble(6,this.cita.getPuntuacion());
        this.statement.setString(7, this.cita.getEstado().name());
        this.statement.setInt(8, this.cita.getIdCita());
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
        this.cita.setIdCita(this.resultSet.getInt("idCita"));
        this.cita.getPaciente().setIdPaciente(this.resultSet.getInt("idPaciente"));
        this.cita.getOdontologo().setIdOdontologo(this.resultSet.getInt("idOdontologo"));
        this.cita.getComprobante().setIdComprobante(this.resultSet.getInt("idComprobante"));
        this.cita.setFecha(this.resultSet.getObject("fecha",LocalDate.class));
        this.cita.setHoraInicio(this.resultSet.getObject("horaInicio",LocalTime.class));
        this.cita.setPuntuacion(this.resultSet.getDouble("puntuacion"));
        this.cita.setEstado(EstadoCita.valueOf(this.resultSet.getString("estado")));
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
    
}
