package com.odontosys.users.model;

public class Persona {
    
    protected int idPersona;
    protected String contrasenha;
    protected String nombreUsuario;
    protected String correo;
    protected String telefono;
    protected String nombre;
    protected String apellidos;
    protected String DNI;
    protected TipoUsuario tipoUsuario;
    
    public Persona(){    
    }
    
    public int getIdPersona() {
        return idPersona;
    }

    public void setIdPersona(int idPersona) {
        this.idPersona = idPersona;
    }

    public String getContrasenha() {
        return contrasenha;
    }

    public void setContrasenha(String contrasenha) {
        this.contrasenha = contrasenha;
    }

    public String getNombreUsuario() {
        return nombreUsuario;
    }

    public void setNombreUsuario(String nombreUsuario) {
        this.nombreUsuario = nombreUsuario;
    }

    public String getCorreo() {
        return correo;
    }

    public void setCorreo(String correo) {
        this.correo = correo;
    }

    public String getTelefono() {
        return telefono;
    }

    public void setTelefono(String telefono) {
        this.telefono = telefono;
    }

    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    public String getApellidos() {
        return apellidos;
    }

    public void setApellidos(String apellidos) {
        this.apellidos = apellidos;
    }

    public String getDNI() {
        return DNI;
    }

    public void setDNI(String DNI) {
        this.DNI = DNI;
    }

    public TipoUsuario getTipoUsuario() {
        return tipoUsuario;
    }

    public void setTipoUsuario(TipoUsuario tipoUsuario) {
        this.tipoUsuario = tipoUsuario;
    }

    @Override
    public String toString() {
        return "Persona{" + "idUsuario=" + idPersona + ", contrase\u00f1a=" + contrasenha + ", nombreUsuario=" + nombreUsuario + ", correo=" + correo + ", telefono=" + telefono + ", nombre=" + nombre + ", apellidos=" + apellidos + ", DNI=" + DNI + ", tipoUsuario=" + tipoUsuario + '}';
    }
    
}
