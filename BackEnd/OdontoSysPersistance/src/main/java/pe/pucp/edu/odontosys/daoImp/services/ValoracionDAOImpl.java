package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.sql.Date;
import java.sql.Time;
import java.time.LocalDate;

import pe.pucp.edu.odontosys.dao.services.ValoracionDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.users.model.Paciente;

public class ValoracionDAOImpl extends DAOImplBase implements ValoracionDAO{
    
    private Valoracion valoracion;
    
    public ValoracionDAOImpl(){
        super("OS_VALORACIONES");
        this.retornarLlavePrimaria = true;
        this.valoracion = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("VALORACION_ID",true,true));
        this.listaColumnas.add(new Columna("COMENTARIO",false,false));
        this.listaColumnas.add(new Columna("CALIFICACION",false,false));
        this.listaColumnas.add(new Columna("FECHA",false,false)); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setString(1, this.valoracion.getComentario());
        this.statement.setInt(2, this.valoracion.getCalicicacion());
        this.statement.setObject(3, LocalDate.parse(this.valoracion.getFechaCalificacion()));
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setString(1, this.valoracion.getComentario());
        this.statement.setInt(2, this.valoracion.getCalicicacion());
        this.statement.setObject(3, LocalDate.parse(this.valoracion.getFechaCalificacion()));
        this.statement.setInt(4, this.valoracion.getIdValoracion());
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.valoracion.getIdValoracion()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.valoracion.getIdValoracion());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.valoracion = new Valoracion();
        this.valoracion.setIdValoracion(this.resultSet.getInt("VALORACION_ID"));
        this.valoracion.setComentario(this.resultSet.getString("COMENTARIO"));
        this.valoracion.setCalicicacion(this.resultSet.getInt("CALIFICACION"));
        this.valoracion.setFechaCalificacion(this.resultSet.getObject("FECHA").toString());
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.valoracion = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.valoracion);
    }
    
    @Override
    public Integer insertar(Valoracion valoracion){
        this.valoracion = valoracion;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Valoracion valoracion){
        this.valoracion = valoracion;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Valoracion valoracion) {
       this.valoracion=valoracion;
       return super.eliminar();
    }
    
    @Override
    public Valoracion obtenerPorId(Integer id){
        this.valoracion = new Valoracion();
        this.valoracion.setIdValoracion(id);
        super.obtenerPorId();
        return this.valoracion;
    }
    
    @Override
    public ArrayList<Valoracion> listarTodos(){
        return (ArrayList<Valoracion>) super.listarTodos();
    }
    
}
