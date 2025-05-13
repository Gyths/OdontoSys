package dao;

import com.odontosys.daoImp.RecepcionistaDAOImpl;
import com.odontosys.users.model.Recepcionista;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

public class RecepcionistaDAOTest {

    private final RecepcionistaDAOImpl dao = new RecepcionistaDAOImpl();

    @Test
    public void insertTest(){
        Recepcionista r = new Recepcionista();
        r.setContrasenha("claveSegua123");
        r.setNombreUsuario("rep1");
        r.setCorreo("rece5p" + "@test.com");
        r.setTelefono("99999999999");
        r.setNombre("Laur3a_");
        r.setApellidos("Rami2rez_");
        r.setDNI("92939923");
        
        dao.insertar(r);
    }
}