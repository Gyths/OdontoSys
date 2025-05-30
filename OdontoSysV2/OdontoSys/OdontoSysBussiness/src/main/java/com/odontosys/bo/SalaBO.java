
package com.odontosys.bo;

import com.odontosys.dao.infrastructure.SalaDAO;
import com.odontosys.daoImp.infrastructure.SalaDAOImpl;
import com.odontosys.infrastructure.model.Sala;

public class SalaBO {
    private SalaDAO salaDAO;
    
    public SalaBO(){
        this.salaDAO = new SalaDAOImpl();
    }
    
    public Integer InsertarSala(Sala sala){
        return this.salaDAO.insertar(sala);
    }
    
    public Integer EliminarSala(Sala sala){
        return this.salaDAO.eliminar(sala);
    }
    
}
