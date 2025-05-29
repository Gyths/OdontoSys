
package com.odontosys.bo;

import com.odontosys.dao.infrastructure.SalaDAO;
import com.odontosys.daoImp.infrastructure.SalaDAOImpl;
import com.odontosys.infrastructure.model.Sala;
import java.util.ArrayList;

public class SalaBO {
    private SalaDAO salaDAO;
    
    public SalaBO(){
        this.salaDAO = new SalaDAOImpl();
    }
    
    public Integer InsertarSala(String numeroSala, Integer piso){
        Sala sala = new Sala();
        sala.setNumero(numeroSala);
        sala.setPiso(piso);
        return this.salaDAO.insertar(sala);
    }
    
    public Integer EliminarSala(String numeroSala, Integer piso){
        ArrayList<Sala> list = this.salaDAO.listarTodos();
        for(Sala s: list){
            if(s.getNumero().matches(numeroSala) && s.getPiso() == piso)
                return this.salaDAO.eliminar(s);
        }
        return -1;
    }
    
}
