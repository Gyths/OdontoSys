package pe.pucp.edu.odontosys.bo.infrastructure;

import pe.pucp.edu.odontosys.dao.infrastructure.TurnoDAO;
import pe.pucp.edu.odontosys.daoImp.infrastructure.TurnoDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.DiaSemana;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import java.time.LocalTime;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.users.model.Odontologo;

public class TurnoBO {
    private TurnoDAO turnoDAO;
    
    public TurnoBO(){
        this.turnoDAO = new TurnoDAOImpl();
    }
    
    public Integer insertar(Turno turno){
        return this.turnoDAO.insertar(turno);
    }

    public Integer modificar(Turno turno){
        return this.turnoDAO.modificar(turno);
    }
    
    public Integer eliminar(Turno turno){
        return this.turnoDAO.eliminar(turno);
    }
    
    public Turno obtenerPorId(Integer id){
        return this.turnoDAO.obtenerPorId(id);
    }
    
    public ArrayList<Turno> listarTodos(){
        return this.turnoDAO.listarTodos();
    }
    
    public ArrayList<Turno> listarPorOdontologo(Odontologo odontologo){
        return this.turnoDAO.listarPorOdontologo(odontologo);
    }
    
}
