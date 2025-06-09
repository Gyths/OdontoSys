package pe.pucp.edu.odontosys.bo.infrastructure;

import pe.pucp.edu.odontosys.dao.infrastructure.TurnoXOdontologoDAO;
import pe.pucp.edu.odontosys.daoImp.infrastructure.TurnoXOdontologoDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.TurnoXOdontologo;
import java.util.ArrayList;

public class TurnoXOdontologoBO {
   private TurnoXOdontologoDAO turnoXOdontologoDAO;
   
   public TurnoXOdontologoBO(){
       this.turnoXOdontologoDAO = new TurnoXOdontologoDAOImpl();
   }
   
   public Integer insertar(TurnoXOdontologo turnoXOdontologo){
        return this.turnoXOdontologoDAO.insertar(turnoXOdontologo);
    }

    public Integer modificar(TurnoXOdontologo turnoXOdontologo){
         return this.turnoXOdontologoDAO.modificar(turnoXOdontologo);
    }
   
    public Integer eliminar(TurnoXOdontologo turnoOd){
        return this.turnoXOdontologoDAO.eliminar(turnoOd);
    }
   
    public TurnoXOdontologo obtenerPorId(Integer id){
        return this.turnoXOdontologoDAO.obtenerPorId(id);
    }
    
    public ArrayList<TurnoXOdontologo> listarTodos(){
        return this.turnoXOdontologoDAO.listarTodos();
    }
   
}
