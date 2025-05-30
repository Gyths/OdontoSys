package com.odontosys.bo;

import com.odontosys.dao.infrastructure.TurnoDAO;
import com.odontosys.daoImp.infrastructure.TurnoDAOImpl;
import com.odontosys.infrastructure.model.DiaSemana;
import com.odontosys.infrastructure.model.Turno;
import java.time.LocalTime;
import java.util.ArrayList;

public class TurnoBO {
    private TurnoDAO turnoDAO;
    
    public TurnoBO(){
        this.turnoDAO = new TurnoDAOImpl();
    }
    
    public Integer InsertarTurno(Turno turno){
        return this.turnoDAO.insertar(turno);
    }
    

    public Integer ModificarTurno(Turno turno){
        return this.turnoDAO.modificar(turno);
    }
    
    public Integer EliminarTurno(Turno turno){
        return this.turnoDAO.eliminar(turno);
    }
}
