package pe.pucp.edu.odontosys.users.model;

public abstract class Persona {
    
    protected String contrasenha;
    protected String nombreUsuario;
    protected String correo;
    protected String telefono;
    protected String nombre;
    protected String apellidos;
    protected TipoDocumento tipoDocumento;
    protected String NumeroDocumento;
    
    public Persona(){  
        this.tipoDocumento = new TipoDocumento();
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

    public TipoDocumento getTipoDocumento() {
        return tipoDocumento;
    }

    public void setTipoDocumento(TipoDocumento tipoDocumento) {
        this.tipoDocumento = tipoDocumento;
    }

    public String getNumeroDocumento() {
        return NumeroDocumento;
    }

    public void setNumeroDocumento(String NumeroDocumento) {
        this.NumeroDocumento = NumeroDocumento;
    }

    @Override
    public String toString() {
        String resultado = "";
        resultado += "================\n";
        resultado += "Persona\n";
        resultado += "----------------\n";
        resultado += "contrasenha: "     + contrasenha     + "\n";
        resultado += "nombreUsuario: "   + nombreUsuario   + "\n";
        resultado += "correo: "          + correo          + "\n";
        resultado += "telefono: "        + telefono        + "\n";
        resultado += "nombre: "          + nombre          + "\n";
        resultado += "apellidos: "       + apellidos       + "\n";
        resultado += "tipoDocumento: "   + "\n";
        resultado += tipoDocumento;
        resultado += "NumeroDocumento: " + NumeroDocumento + "\n";
        resultado += "================\n";
        return resultado;
    }
    
}
