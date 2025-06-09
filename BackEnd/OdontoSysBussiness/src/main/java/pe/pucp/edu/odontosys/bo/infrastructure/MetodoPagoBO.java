package pe.pucp.edu.odontosys.bo.infrastructure;

import pe.pucp.edu.odontosys.dao.infrastructure.MetodoPagoDAO;
import pe.pucp.edu.odontosys.daoImp.infrastructure.MetodoPagoDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import java.util.ArrayList;

public class MetodoPagoBO {
    private MetodoPagoDAO metodoPagoDAO;
    
    public MetodoPagoBO(){
        this.metodoPagoDAO = new MetodoPagoDAOImpl();
    }
    
    public Integer insertar(MetodoPago metodoPago){
        return this.metodoPagoDAO.insertar(metodoPago);
    }
    
    public Integer modificar(MetodoPago metodoPago){
        return this.metodoPagoDAO.modificar(metodoPago);
    }
    
    public Integer eliminar(MetodoPago metodoPago){
        return this.metodoPagoDAO.eliminar(metodoPago);
    }
    
    public MetodoPago obtenerPorId(Integer id){
        return this.metodoPagoDAO.obtenerPorId(id);
    }
    
    public ArrayList<MetodoPago> listarTodos(){
        return this.metodoPagoDAO.listarTodos();
    }
}
