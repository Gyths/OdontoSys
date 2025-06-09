package pe.pucp.edu.odontosys.dbmanager;

import java.sql.Connection;

import pe.pucp.edu.odontosys.db.DBManager;
import pe.pucp.edu.odontosys.db.util.Cifrado;

public class Main {

    public static void main(String[] args) {
        
        Connection conexion = DBManager.getInstance().getConnection();
        if (conexion != null) {
            System.out.println("Successful connection");
        } else {
            System.out.println("Failed connection");
        }
        
    }
}
