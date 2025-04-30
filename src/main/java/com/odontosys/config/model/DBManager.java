package com.odontosys.config.model;

import java.io.FileNotFoundException;
import java.io.IOException;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.util.Properties;

public  abstract class DBManager {

    private static final String ARCHIVO_CONFIGURACION = "/com/odontosys/config/model/config.properties";

    private Connection conexion;
    protected String driver;
    protected String tipo_de_driver;
    protected String base_de_datos;
    protected String nombre_de_host;
    protected String puerto;
    protected String usuario;
    protected String contrasenha;

    private static DBManager dbManager = null;

    // Constructor privado
    protected DBManager() {}

    // Método Singleton
    public static DBManager getInstance() {
        if (DBManager.dbManager == null) {
            DBManager.createInstance();
        }
        return DBManager.dbManager;
    }

    private static void createInstance() {
        if (DBManager.dbManager == null) {
            if(DBManager.obtenerMotorDeBaseDeDatos()==MotorDeBaseDeDatos.MYSQL){
                DBManager.dbManager = new DBManagerMySQL();
            }else{
                DBManager.dbManager = new DBManagerMSSQL();
            }
            DBManager.dbManager.leerArchivoDePropiedades();
        }
    }

    public Connection getConnection() {
        try {
            Class.forName(driver);
            this.conexion = DriverManager.getConnection(getURL(), this.usuario, Cifrado.descifrarMD5(contrasenha));
            System.out.println("Conexión establecida con éxito.");
        } catch (ClassNotFoundException | SQLException ex) {
            System.err.println("Error al conectar a la base de datos: " + ex.getMessage());
        }
        return conexion;
    }

    protected abstract String getURL();
    public abstract String retornarSQLParaUltimoAutoGenerado();

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
    
    private static MotorDeBaseDeDatos obtenerMotorDeBaseDeDatos(){
        Properties properties = new Properties();
        try{
            String nmArchivoConf =ARCHIVO_CONFIGURACION;
            properties.load(DBManager.class.getResourceAsStream(nmArchivoConf));
            String tipo_de_driver = properties.getProperty("tipo_de_driver");
            if(tipo_de_driver.equals("jdbc:mysql")){
                return MotorDeBaseDeDatos.MYSQL;
            }else{
                return MotorDeBaseDeDatos.MSSQL;
            }
        }catch (FileNotFoundException ex){
            System.err.println();
        }catch (IOException ex){
            System.err.println();
        }
        return null;
    }
}

