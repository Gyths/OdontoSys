package pe.pucp.edu.odontosys.persistance;

import pe.pucp.edu.odontosys.db.DBManager;
import java.sql.Connection;
import pe.pucp.edu.odontosys.dao.users.PacienteDAO;
import pe.pucp.edu.odontosys.daoImp.users.PacienteDAOImpl;
import pe.pucp.edu.odontosys.users.model.Paciente;

public class Main {

    public static void main(String[] args) {
        Paciente p = new Paciente();
        PacienteDAO pacienteDAO = new PacienteDAOImpl();
        p = pacienteDAO.obtenerPorUsuarioContrasenha("usuario_prueba", "Secreto123!");
        System.out.println(p);
    }
}
