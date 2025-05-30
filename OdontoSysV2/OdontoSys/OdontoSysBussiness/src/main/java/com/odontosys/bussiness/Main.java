package com.odontosys.bussiness;

import com.odontosys.bo.CitaBO;
import com.odontosys.bo.ComprobanteBO;
import com.odontosys.bo.DetalleTratamientoBO;
import com.odontosys.bo.OdontologoBO;
import com.odontosys.bo.PacienteBO;
import com.odontosys.bo.utils.PersonaEnum;
import com.odontosys.bo.RecepcionistaBO;
import com.odontosys.bo.SalaBO;
import com.odontosys.bo.TratamientoBO;
import com.odontosys.bo.TurnoBO;
import com.odontosys.bo.TurnoXOdontologoBO;
import com.odontosys.infrastructure.model.DiaSemana;
import com.odontosys.infrastructure.model.MetodoPago;
import com.odontosys.infrastructure.model.Sala;
import com.odontosys.infrastructure.model.Turno;
import com.odontosys.services.model.Comprobante;
import com.odontosys.services.model.DetalleTratamiento;
import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.users.model.Odontologo;
import com.odontosys.users.model.Paciente;
import com.odontosys.users.model.Recepcionista;
import java.time.LocalDate;
import java.time.LocalTime;



public class Main {
    public static void insertaRecepcionistas(){
        RecepcionistaBO rBO = new RecepcionistaBO();
        Recepcionista r = new Recepcionista();
        r.setApellidos("Mendoza");
        r.setDNI("74758691");
        r.setContrasenha("pass1");
        r.setCorreo("repMendoza@gmail.com");
        r.setNombre("Carlos");
        r.setNombreUsuario("CMendoza");
        r.setTelefono("987854963");
        rBO.insertarRecepcionista(r);

        r.setApellidos("Paredes");
        r.setDNI("21546369");
        r.setContrasenha("pass2");
        r.setCorreo("repParedes@gmail.com");
        r.setNombre("Juan");
        r.setNombreUsuario("JParedes");
        r.setTelefono("875965215");
        rBO.insertarRecepcionista(r);

        r.setApellidos("Castillo");
        r.setDNI("32564871");
        r.setContrasenha("pass3");
        r.setCorreo("repCastillo@gmail.com");
        r.setNombre("Manuel");
        r.setNombreUsuario("MCastillo");
        r.setTelefono("954862315");
        rBO.insertarRecepcionista(r);

        r.setApellidos("Pollo");
        r.setDNI("76985212");
        r.setContrasenha("pass4");
        r.setCorreo("repPollo@gmail.com");
        r.setNombre("Cena");
        r.setNombreUsuario("CPollo");
        r.setTelefono("948632152");
        rBO.insertarRecepcionista(r);

        r.setApellidos("Cardenas");
        r.setDNI("75486921");
        r.setContrasenha("pass5");
        r.setCorreo("repCardenas@gmail.com");
        r.setNombre("Pedro");
        r.setNombreUsuario("PCardenas");
        r.setTelefono("953261489");
        rBO.insertarRecepcionista(r);
    }
    public static void insertaPacientes(){
        PacienteBO pBO = new PacienteBO();
        Paciente p = new Paciente();
        p.setApellidos("Gutierrez");
        p.setDNI("35621489");
        p.setContrasenha("con1");
        p.setCorreo("joseGutierrez45@gmail.com");
        p.setNombre("Jose");
        p.setNombreUsuario("JoseGut74");
        p.setTelefono("963258412");
        pBO.insertarPaciente(p);
        
        p.setApellidos("Marquez");
        p.setDNI("15234562");
        p.setContrasenha("papas23");
        p.setCorreo("marmar78@gmail.com");
        p.setNombre("Maria");
        p.setNombreUsuario("Marq452");
        p.setTelefono("923651245");
        pBO.insertarPaciente(p);
        
        p.setApellidos("Milla");
        p.setDNI("52132654");
        p.setContrasenha("vmilla785");
        p.setCorreo("ElMetroEsSuperior@gmail.com");
        p.setNombre("Victor");
        p.setNombreUsuario("MillaVic4");
        p.setTelefono("956245835");
        pBO.insertarPaciente(p);
        
        p.setApellidos("Goku");
        p.setDNI("7621548");
        p.setContrasenha("ssj24lvldios");
        p.setCorreo("kamehameha45@gmail.com");
        p.setNombre("Son");
        p.setNombreUsuario("KiUser74");
        p.setTelefono("964751235");
        pBO.insertarPaciente(p);
        
        p.setApellidos("Caceres");
        p.setDNI("65212325");
        p.setContrasenha("+kπto");
        p.setCorreo("caceresOrlando1995@gmail.com");
        p.setNombre("Orlando");
        p.setNombreUsuario("Orlandokcrs");
        p.setTelefono("912378625");
        pBO.insertarPaciente(p);
    }
    public static void insertaOdontologos(){
        OdontologoBO odBO = new OdontologoBO();
        Odontologo o = new Odontologo();
        Sala s = new Sala();
        o.setApellidos("Castaneda");
        o.setDNI("25645863");
        o.setContrasenha("75486235555");
        o.setCorreo("docCastaneda@gmail.com");
        o.setNombre("Javier");
        o.setNombreUsuario("JCastaneda");
        o.setTelefono("958762135");
        o.setEspecialidad(Especialidad.PEDIATRIA);
        o.setPuntuacionPromedio(3.2);
        s.setIdSala(1);
        o.setConsultorio(s);
        odBO.insertarOdontologo(o);
        
        o.setApellidos("Villegas");
        o.setDNI("45869523");
        o.setContrasenha("vi__45M");
        o.setCorreo("docVillegas@gmail.com");
        o.setNombre("Sandra");
        o.setNombreUsuario("SVillegas");
        o.setTelefono("927546831");
        o.setEspecialidad(Especialidad.ENDODONCIA);
        o.setPuntuacionPromedio(4.1);
        s.setIdSala(3);
        o.setConsultorio(s);
        odBO.insertarOdontologo(o);
        
        o.setApellidos("Suarez");
        o.setDNI("45862135");
        o.setContrasenha("ss_ss-0012");
        o.setCorreo("docSuarez@gmail.com");
        o.setNombre("Sebastian");
        o.setNombreUsuario("SSuarez");
        o.setTelefono("972135628");
        o.setEspecialidad(Especialidad.ENDODONCIA);
        o.setPuntuacionPromedio(4.5);
        s.setIdSala(5);
        o.setConsultorio(s);
        odBO.insertarOdontologo(o);
    }
    public static void insertaSalas(){
        SalaBO sBO = new SalaBO();
        sBO.InsertarSala("101",1);
        sBO.InsertarSala("102",1);
        sBO.InsertarSala("103",1);
        sBO.InsertarSala("201",2);
        sBO.InsertarSala("202",2);
        sBO.InsertarSala("203",2);
        sBO.InsertarSala("301",3);
        sBO.InsertarSala("302",3);
    }
    public static void insertaTratamientos(){
        TratamientoBO tratamiento = new TratamientoBO();
        tratamiento.InsertarTratamiento("Endodoncia", "tratamiento del interior del diente", 500, Especialidad.ENDODONCIA);
        tratamiento.InsertarTratamiento("Limpieza", "tratemiento exterior", 150, Especialidad.PEDIATRIA);
        tratamiento.InsertarTratamiento("Corona", "recubrimiento superiror del diente", 300, Especialidad.ODONTOLOGIA_GENERAL);
        tratamiento.InsertarTratamiento("Curacion", "tratamiento superficial de caries", 100, Especialidad.ODONTOLOGIA_GENERAL);
    }
    
    public static void main(String[] args) {
        System.out.println("Hello World From Bussiness");
        /*Dummy data
            Especialidades deben ya existir en la bd, son fijas (sino no va a insertar odontologos)
            Falta insertar citas,turnoXodontologo,detalleTratamiento -> puede ser a mano o devolver listas del insertar 
                                                                        para tener los objetos listos
            ModificarBOs para que todos reciban objetos enves de parametros(sala,turno,citas,....)
        */
        insertaRecepcionistas();
        insertaPacientes();
        insertaOdontologos();
        insertaSalas();
        insertaTratamientos();
        
    }
}
