package com.odontosys.bo;

import com.odontosys.dao.infrastructure.TurnoXOdontologoDAO;
import com.odontosys.daoImp.infrastructure.TurnoXOdontologoDAOImpl;
import com.odontosys.infrastructure.model.TurnoXOdontologo;

public class TurnoXOdontologoBO {
   private TurnoXOdontologoDAO turnoXOdontologoDAO;
   
   public TurnoXOdontologoBO(){
       this.turnoXOdontologoDAO = new TurnoXOdontologoDAOImpl();
   }
   
   public Integer InsertarTurnoXOdontologo(TurnoXOdontologo turnoOd){
       return this.turnoXOdontologoDAO.insertar(turnoOd);
   }
   
   public Integer EliminarTurnoXOdontologo(TurnoXOdontologo turnoOd){
       return this.turnoXOdontologoDAO.eliminar(turnoOd);
   }
   
}
