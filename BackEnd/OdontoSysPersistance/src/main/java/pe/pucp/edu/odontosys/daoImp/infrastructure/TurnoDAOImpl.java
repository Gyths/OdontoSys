package pe.pucp.edu.odontosys.daoImp.infrastructure;

import java.sql.SQLException;
import java.util.ArrayList;
import java.sql.Time;
import java.util.List;

import pe.pucp.edu.odontosys.dao.infrastructure.TurnoDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.infrastructure.model.DiaSemana;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import pe.pucp.edu.odontosys.users.model.Odontologo;

public class TurnoDAOImpl extends DAOImplBase implements TurnoDAO{
    
    private Turno turno;
    
    public TurnoDAOImpl(){
        super("OS_TURNOS");
        this.retornarLlavePrimaria = true;
        this.turno = null;
    }
    
    @Override
    protected void configurarListaDeColumnas(){
        this.listaColumnas.add(new Columna("TURNO_ID",true,true));
        this.listaColumnas.add(new Columna("HORA_INICIO",false,false));
        this.listaColumnas.add(new Columna("HORA_FIN",false,false));
        this.listaColumnas.add(new Columna("DIA_SEMANA",false,false));
    }
    
    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException{
        this.statement.setTime(1,Time.valueOf(this.turno.getHoraInicio()));
        this.statement.setTime(2,Time.valueOf(this.turno.getHoraFin()));
        this.statement.setString(3,this.turno.getDiaSemana().name());
    }
    
    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException{ 
        this.statement.setTime(1,Time.valueOf(this.turno.getHoraInicio()));
        this.statement.setTime(2,Time.valueOf(this.turno.getHoraFin()));
        this.statement.setString(3,this.turno.getDiaSemana().name());
        this.statement.setInt(4, this.turno.getIdTurno()); 
    }
    
    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException{
        this.statement.setInt(1, this.turno.getIdTurno());
    }
    
    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.turno.getIdTurno());
    }
    
    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.turno = new Turno();
        this.turno.setIdTurno(this.resultSet.getInt("TURNO_ID"));
        this.turno.setHoraInicio(this.resultSet.getTime("HORA_INICIO").toLocalTime());
        this.turno.setHoraFin(this.resultSet.getTime("HORA_FIN").toLocalTime());
        this.turno.setDiaSemana(DiaSemana.valueOf(this.resultSet.getString("DIA_SEMANA")));
    }
    
    @Override
    protected void limpiarObjetoDelResultSet() {
        this.turno = null;
    }
    
    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.turno);
    }
    
    @Override
    public Integer insertar(Turno turno){
        this.turno = turno;
        return super.insertar();
    }
    
    @Override
    public Integer modificar(Turno turno){
        this.turno = turno;
        return super.modificar();
    }
    
    @Override
    public Integer eliminar(Turno turno) {
       this.turno=turno;
       return super.eliminar();
    }
    
    @Override
    public Turno obtenerPorId(Integer id){
        this.turno = new Turno();
        this.turno.setIdTurno(id);
        super.obtenerPorId();
        return this.turno;
    }
    
    @Override
    public ArrayList<Turno> listarTodos(){
        return (ArrayList<Turno>) super.listarTodos();
    }
    
    @Override
    public ArrayList<Turno> listarPorOdontologo(Odontologo odontologo) {
        String sql= "CALL TURNOS_listar_por_odontologo(?);";
        return (ArrayList<Turno>)ejecutarStoredProcedureLista(sql, odontologo.getIdOdontologo());
    }
    
}
