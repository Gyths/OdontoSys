package pe.pucp.edu.odontosys.persistance;

import pe.pucp.edu.odontosys.db.DBManager;
import java.sql.Connection;

public class Main {

    public static void main(String[] args) {
        Connection conexion = DBManager.getInstance().getConnection();
        if (conexion != null) {
            System.out.println("Successful connection from Persistence");
        } else {
            System.out.println("Failed connection");
        }
    }
}
