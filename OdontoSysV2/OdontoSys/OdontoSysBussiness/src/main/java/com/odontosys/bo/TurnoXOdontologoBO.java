package com.odontosys.bo;

import com.odontosys.dao.TurnoXOdontologoDAO;
import com.odontosys.daoImp.TurnoXOdontologoDAOImpl;
import com.odontosys.infrastructure.model.TurnoXOdontologo;
import java.util.ArrayList;

public class TurnoXOdontologoBO {
   private TurnoXOdontologoDAO turnoXOdontologoDAO;
   
   public TurnoXOdontologoBO(){
       this.turnoXOdontologoDAO = new TurnoXOdontologoDAOImpl();
   }
   
   public Integer InsertarTurnoXOdontologo(Integer idOdontologo, Integer idTurno){
       TurnoXOdontologo turnoOd = new TurnoXOdontologo();
       turnoOd.setIdOdontologo(idOdontologo);
       turnoOd.setIdTurno(idTurno);
       return this.turnoXOdontologoDAO.insertar(turnoOd);
   }
   
   public Integer EliminarTurnoXOdontologo(Integer idOdontologo,Integer idTurno){
       ArrayList<TurnoXOdontologo> list = this.turnoXOdontologoDAO.listarTodos();
       for(TurnoXOdontologo t : list){
           if(t.getIdOdontologo()==idOdontologo && t.getIdTurno() == idTurno)
               return this.turnoXOdontologoDAO.eliminar(t);
       }
       return -1;
   }
   
}
