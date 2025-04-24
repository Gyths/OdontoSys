package com.odontosys.daoImp;

import com.odontosys.config.model.DBManager;
import com.odontosys.dao.TurnoDAO;
import com.odontosys.daoImp.util.Columna;
import com.odontosys.infraestructure.model.Turno;
import com.odontosys.infraestructure.model.DiaSemana;

import java.sql.*;
import java.util.ArrayList;
import java.util.logging.Level;
import java.util.logging.Logger;

public class TurnoDAOImpl extends DAOImplBase implements TurnoDAO {
    private Turno turno;
    
    public TurnoDAOImpl(){
        super("turno");
        this.retornarLlavePrimaria=true;
        this.turno=null;
    }
    @Override
    protected void configurarListaDeColumna(){
        this.listaColumnas.add(new Columna("idTurno",true,true));
        this.listaColumnas.add(new Columna("horaInicio",false,false));
        this.listaColumnas.add(new Columna("horaFin",false,false));
        this.listaColumnas.add(new Columna("diaSemana",false,false));
    }
    //Metodos base
    @Override
    public Integer insertar(Turno turno) {
        this.turno=turno;
        return super.insertar();
    }
    @Override
    public Integer eliminar(Turno turno) {
       this.turno=turno;
       return super.eliminar();
    }
    @Override
    protected void incluirValorDeParametrosParaInsercion(){
        try {
            this.statement.setTime(1,this.turno.getHoraInicio());
            this.statement.setTime(2,this.turno.getHoraFin());
            this.statement.setString(3,this.turno.getDiaLaboral().name());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    @Override
    protected void incluirValorDeParametrosParaEliminacion(){
        try {
            this.statement.setInt(1, turno.getIdTurno());
        } catch (SQLException ex) {
            Logger.getLogger(ComprobanteDAOImpl.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    //Personalizados
    @Override
    public Integer modificar(Turno turno) {
        int resultado = 0;
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "UPDATE turno SET horaInicio = ?, horaFin = ?, diaSemana = ? WHERE idTurno = ?";
            PreparedStatement ps = conn.prepareStatement(sql);
            ps.setTime(1, turno.getHoraInicio());
            ps.setTime(2, turno.getHoraFin());
            ps.setString(3, turno.getDiaLaboral().name());
            ps.setInt(4, turno.getIdTurno());

            resultado = ps.executeUpdate();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al modificar turno: " + ex.getMessage());
        }

        return resultado;
    }

    @Override
    public ArrayList<Turno> listarTodos() {
        ArrayList<Turno> lista = new ArrayList<>();
        Connection conn = DBManager.getInstance().getConnection();

        try {
            String sql = "SELECT * FROM turno";
            PreparedStatement ps = conn.prepareStatement(sql);
            ResultSet rs = ps.executeQuery();

            while (rs.next()) {
                Turno turno = new Turno();
                turno.setIdTurno(rs.getInt("idTurno"));
                turno.setHoraInicio(rs.getTime("horaInicio"));
                turno.setHoraFin(rs.getTime("horaFin"));
                turno.setDiaLaboral(DiaSemana.valueOf(rs.getString("diaSemana")));
                lista.add(turno);
            }

            rs.close();
            ps.close();
        } catch (SQLException ex) {
            System.err.println("Error al listar turnos: " + ex.getMessage());
        }

        return lista;
    }
}
