package com.odontosys.dbmanager;

import java.sql.Connection;

import com.odontosys.db.DBManager;

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
