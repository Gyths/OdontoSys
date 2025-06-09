
package pe.pucp.edu.odontosys.bo.infrastructure;

import java.util.ArrayList;
import pe.pucp.edu.odontosys.dao.infrastructure.SalaDAO;
import pe.pucp.edu.odontosys.daoImp.infrastructure.SalaDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.Sala;

public class SalaBO {
    private SalaDAO salaDAO;
    
    public SalaBO(){
        this.salaDAO = new SalaDAOImpl();
    }
    
    public Integer insertar(Sala sala){
        return this.salaDAO.insertar(sala);
    }
    
    public Integer eliminar(Sala sala){
        return this.salaDAO.eliminar(sala);
    }
    
    public Integer modificar(Sala sala){
        return this.salaDAO.modificar(sala);
    }
    
    public ArrayList<Sala> listarTodos(){
        return this.salaDAO.listarTodos();
    }
    
    public Sala obtenerPorId(Integer id){
        return this.salaDAO.obtenerPorId(id);
    }
    
}
