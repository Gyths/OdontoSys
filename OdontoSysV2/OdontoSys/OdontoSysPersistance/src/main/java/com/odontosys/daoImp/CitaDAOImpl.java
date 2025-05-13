package com.odontosys.daoImp;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import com.odontosys.dao.CitaDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.services.model.Cita;

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
        this.statement.setString(1, this.cita.);
        this.statement.setString(2, this.cita.getDescripcion());
        this.statement.setDouble(3, this.cita.getCosto());
        this.statement.setString(4, this.cita.getEspecialidad().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1, this.cita.getNombre());
        this.statement.setString(2, this.cita.getDescripcion());
        this.statement.setDouble(3, this.cita.getCosto());
        this.statement.setString(4, this.cita.getEspecialidad().name());
        this.statement.setInt(5, this.cita.getIdTratamiento());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(5, this.cita.getIdTratamiento()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(5, this.cita.getIdTratamiento());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.cita = new Cita();
        this.cita.setIdTratamiento(this.resultSet.getInt("idTratamiento"));
        this.cita.setNombre(this.resultSet.getString("nombre"));
        this.cita.setDescripcion(this.resultSet.getString("descripcion"));
        this.cita.setCosto(this.resultSet.getDouble("costo"));
        this.cita.setEspecialidad(Especialidad.valueOf(this.resultSet.getString("especialidad")));
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
        this.tratamiento = tratamiento;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Cita cita) {
       this.tratamiento=tratamiento;
       return super.eliminar();
    }
    
    @Override
    public Cita obtenerPorId(Integer Id){
        this.cita = new Cita();
        this.cita.setIdTratamiento(Id);
        super.obtenerPorId();
        return this.cita;
    }
    
    @Override
    public ArrayList<Cita> listarTodos(){
        return (ArrayList<Cita>) super.listarTodos();
    }
    
}
