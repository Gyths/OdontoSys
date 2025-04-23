package com.odontosys.config.model;

import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public class DBManager {

    private static final String ARCHIVO_CONFIGURACION = "/com/odontosys/config/model/config.properties";

    private Connection conexion;
    private String driver;
    private String tipo_de_driver;
    private String base_de_datos;
    private String nombre_de_host;
    private String puerto;
    private String usuario;
    private String contrasenha;

    private static DBManager dbManager = null;

    // Constructor privado
    private DBManager() {}

    // Método Singleton
    public static DBManager getInstance() {
        if (dbManager == null) {
            createInstance();
        }
        return dbManager;
    }

    private static void createInstance() {
        if (dbManager == null) {
            dbManager = new DBManager();
            dbManager.leerArchivoDePropiedades();
        }
    }

    public Connection getConnection() {
        try {
            Class.forName(driver);
            conexion = DriverManager.getConnection(getURL(), usuario, Cifrado.descifrarMD5(contrasenha));
            System.out.println("Conexión establecida con éxito.");
        } catch (ClassNotFoundException | SQLException ex) {
            System.err.println("Error al conectar a la base de datos: " + ex.getMessage());
        }
        return conexion;
    }

    private String getURL() {
        return tipo_de_driver + "://" + nombre_de_host + ":" + puerto + "/" + base_de_datos;
    }

    private void leerArchivoDePropiedades() {
        Properties properties = new Properties();
        try {
            properties.load(DBManager.class.getResourceAsStream(ARCHIVO_CONFIGURACION));

            this.driver = properties.getProperty("driver");
            this.tipo_de_driver = properties.getProperty("tipo_de_driver");
            this.base_de_datos = properties.getProperty("base_de_datos");
            this.nombre_de_host = properties.getProperty("nombre_de_host");
            this.puerto = properties.getProperty("puerto");
            this.usuario = properties.getProperty("usuario");
            this.contrasenha = properties.getProperty("contrasenha");

        } catch (IOException ex) {
            System.err.println("❌ Error al leer el archivo de propiedades: " + ex.getMessage());
        }
    }
}

