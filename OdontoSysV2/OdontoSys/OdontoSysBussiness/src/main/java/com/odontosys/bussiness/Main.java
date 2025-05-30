package com.odontosys.bussiness;

import com.odontosys.bo.CitaBO;
import com.odontosys.bo.ComprobanteBO;
import com.odontosys.bo.DetalleTratamientoBO;
import com.odontosys.bo.OdontologoBO;
import com.odontosys.bo.PacienteBO;
import com.odontosys.bo.RecepcionistaBO;
import com.odontosys.bo.SalaBO;
import com.odontosys.bo.TratamientoBO;
import com.odontosys.bo.TurnoBO;
import com.odontosys.bo.TurnoXOdontologoBO;
import com.odontosys.infrastructure.model.DiaSemana;
import com.odontosys.infrastructure.model.MetodoPago;
import com.odontosys.infrastructure.model.Sala;
import com.odontosys.infrastructure.model.Turno;
import com.odontosys.infrastructure.model.TurnoXOdontologo;
import com.odontosys.services.model.Cita;
import com.odontosys.services.model.Comprobante;
import com.odontosys.services.model.DetalleTratamiento;
import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.services.model.Tratamiento;
import com.odontosys.users.model.Odontologo;
import com.odontosys.users.model.Paciente;
import com.odontosys.users.model.Recepcionista;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.ArrayList;



public class Main {
    public static ArrayList<Recepcionista>insertaRecepcionistas(){
        ArrayList<Recepcionista>listaRec = new ArrayList<>();
        RecepcionistaBO rBO = new RecepcionistaBO();
        
        Recepcionista r = new Recepcionista();
        r.setApellidos("Mendoza");
        r.setDNI("74758691");
        r.setContrasenha("pass1");
        r.setCorreo("repMendoza@gmail.com");
        r.setNombre("Carlos");
        r.setNombreUsuario("CMendoza");
        r.setTelefono("987854963");
        r.setIdRecepcionista(rBO.insertarRecepcionista(r));
        listaRec.add(r);
        
        Recepcionista r1 = new Recepcionista();
        r1.setApellidos("Paredes");
        r1.setDNI("21546369");
        r1.setContrasenha("pass2");
        r1.setCorreo("repParedes@gmail.com");
        r1.setNombre("Juan");
        r1.setNombreUsuario("JParedes");
        r1.setTelefono("875965215");
        r1.setIdRecepcionista(rBO.insertarRecepcionista(r1));
        listaRec.add(r1);
        
        Recepcionista r2 = new Recepcionista();
        r2.setApellidos("Castillo");
        r2.setDNI("32564871");
        r2.setContrasenha("pass3");
        r2.setCorreo("repCastillo@gmail.com");
        r2.setNombre("Manuel");
        r2.setNombreUsuario("MCastillo");
        r2.setTelefono("954862315");
        r2.setIdRecepcionista(rBO.insertarRecepcionista(r2));
        listaRec.add(r2);
        
        Recepcionista r3 = new Recepcionista();
        r3.setApellidos("Pollo");
        r3.setDNI("76985212");
        r3.setContrasenha("pass4");
        r3.setCorreo("repPollo@gmail.com");
        r3.setNombre("Cena");
        r3.setNombreUsuario("CPollo");
        r3.setTelefono("948632152");
        r3.setIdRecepcionista(rBO.insertarRecepcionista(r3));
        listaRec.add(r3);
        
        Recepcionista r4 = new Recepcionista();
        r4.setApellidos("Cardenas");
        r4.setDNI("75486921");
        r4.setContrasenha("pass5");
        r4.setCorreo("repCardenas@gmail.com");
        r4.setNombre("Pedro");
        r4.setNombreUsuario("PCardenas");
        r4.setTelefono("953261489");
        r4.setIdRecepcionista(rBO.insertarRecepcionista(r4));
        listaRec.add(r4);
        
        return listaRec;
    }
    public static ArrayList<Paciente>insertaPacientes(){
        ArrayList<Paciente>listaPac = new ArrayList<>();
        PacienteBO pBO = new PacienteBO();
        
        Paciente p = new Paciente();
        p.setApellidos("Gutierrez");
        p.setDNI("35621489");
        p.setContrasenha("con1");
        p.setCorreo("joseGutierrez45@gmail.com");
        p.setNombre("Jose");
        p.setNombreUsuario("JoseGut74");
        p.setTelefono("963258412");
        p.setIdPaciente(pBO.insertarPaciente(p));
        listaPac.add(p);
        
        Paciente p1 = new Paciente();
        p1.setApellidos("Marquez");
        p1.setDNI("15234562");
        p1.setContrasenha("papas23");
        p1.setCorreo("marmar78@gmail.com");
        p1.setNombre("Maria");
        p1.setNombreUsuario("Marq452");
        p1.setTelefono("923651245");
        p1.setIdPaciente(pBO.insertarPaciente(p1));
        listaPac.add(p1);
        
        Paciente p2 = new Paciente();
        p2.setApellidos("Milla");
        p2.setDNI("52132654");
        p2.setContrasenha("vmilla785");
        p2.setCorreo("ElMetroEsSuperior@gmail.com");
        p2.setNombre("Victor");
        p2.setNombreUsuario("MillaVic4");
        p2.setTelefono("956245835");
        p2.setIdPaciente(pBO.insertarPaciente(p2));
        listaPac.add(p2);
        
        Paciente p3 = new Paciente();
        p3.setApellidos("Goku");
        p3.setDNI("7621548");
        p3.setContrasenha("ssj24lvldios");
        p3.setCorreo("kamehameha45@gmail.com");
        p3.setNombre("Son");
        p3.setNombreUsuario("KiUser74");
        p3.setTelefono("964751235");
        p3.setIdPaciente(pBO.insertarPaciente(p3));
        listaPac.add(p3);
        
        Paciente p4 = new Paciente();
        p4.setApellidos("Caceres");
        p4.setDNI("65212325");
        p4.setContrasenha("+kπto");
        p4.setCorreo("caceresOrlando1995@gmail.com");
        p4.setNombre("Orlando");
        p4.setNombreUsuario("Orlandokcrs");
        p4.setTelefono("912378625");
        p4.setIdPaciente(pBO.insertarPaciente(p4));
        listaPac.add(p4);
        
        return listaPac;
    }
    public static ArrayList<Odontologo>insertaOdontologos(ArrayList<Sala>listaSa){
        ArrayList<Odontologo>listaOD = new ArrayList<>();
        OdontologoBO odBO = new OdontologoBO();
        
        Odontologo o = new Odontologo();
        o.setApellidos("Castaneda");
        o.setDNI("25645863");
        o.setContrasenha("75486235555");
        o.setCorreo("docCastaneda@gmail.com");
        o.setNombre("Javier");
        o.setNombreUsuario("JCastaneda");
        o.setTelefono("958762135");
        o.setEspecialidad(Especialidad.PEDIATRIA);
        o.setPuntuacionPromedio(3.2);
        o.setConsultorio(listaSa.get(1));
        o.setIdOdontologo(odBO.insertarOdontologo(o));
        listaOD.add(o);
        
        Odontologo o1 = new Odontologo();
        o1.setApellidos("Villegas");
        o1.setDNI("45869523");
        o1.setContrasenha("vi__45M");
        o1.setCorreo("docVillegas@gmail.com");
        o1.setNombre("Sandra");
        o1.setNombreUsuario("SVillegas");
        o1.setTelefono("927546831");
        o1.setEspecialidad(Especialidad.ENDODONCIA);
        o1.setPuntuacionPromedio(4.1);
        o1.setConsultorio(listaSa.get(2));
        o1.setIdOdontologo(odBO.insertarOdontologo(o1));
        listaOD.add(o1);
        
        Odontologo o2 = new Odontologo();
        o2.setApellidos("Suarez");
        o2.setDNI("45862135");
        o2.setContrasenha("ss_ss-0012");
        o2.setCorreo("docSuarez@gmail.com");
        o2.setNombre("Sebastian");
        o2.setNombreUsuario("SSuarez");
        o2.setTelefono("972135628");
        o2.setEspecialidad(Especialidad.ENDODONCIA);
        o2.setPuntuacionPromedio(4.5);
        o2.setConsultorio(listaSa.get(3));
        o2.setIdOdontologo(odBO.insertarOdontologo(o2));
        listaOD.add(o2);
        
        return listaOD;
    }
    public static ArrayList<Sala> insertaSalas(){
        ArrayList<Sala>listaSa = new ArrayList<>();
        SalaBO sBO = new SalaBO();
        Sala s = new Sala();
        s.setNumero("101");
        s.setPiso(1);
        s.setIdSala(sBO.InsertarSala(s));
        listaSa.add(s);
        
        Sala s1 = new Sala();
        s1.setNumero("201");
        s1.setPiso(2);
        s1.setIdSala(sBO.InsertarSala(s1));
        listaSa.add(s1);
        
        Sala s2 = new Sala();
        s2.setNumero("301");
        s2.setPiso(3);
        s2.setIdSala(sBO.InsertarSala(s2));
        listaSa.add(s2);
        
        Sala s3 = new Sala();
        s3.setNumero("102");
        s3.setPiso(1);
        s3.setIdSala(sBO.InsertarSala(s3));
        listaSa.add(s3);
        
        Sala s4 = new Sala();
        s4.setNumero("202");
        s4.setPiso(2);
        s4.setIdSala(sBO.InsertarSala(s4));
        listaSa.add(s4);
        
        Sala s5 = new Sala();
        s5.setNumero("302");
        s5.setPiso(3);
        s5.setIdSala(sBO.InsertarSala(s5));
        listaSa.add(s5);
        
        return listaSa;
        
    }
    public static ArrayList<Tratamiento> insertaTratamientos(){
        ArrayList<Tratamiento>listaTra = new ArrayList<>();
        TratamientoBO tBO = new TratamientoBO();
        
        Tratamiento t = new Tratamiento();
        t.setCosto(500);
        t.setDescripcion("Tratamiento del interior del diente");
        t.setNombre("Endodoncia");
        t.setEspecialidad(Especialidad.ENDODONCIA);
        t.setIdTratamiento(tBO.InsertarTratamiento(t));
        listaTra.add(t);
        
        Tratamiento t1 = new Tratamiento();
        t1.setCosto(150);
        t1.setDescripcion("Tratamiento exterior");
        t1.setNombre("Limpieza");
        t1.setEspecialidad(Especialidad.PEDIATRIA);
        t1.setIdTratamiento(tBO.InsertarTratamiento(t1));
        listaTra.add(t1);
        
        Tratamiento t2 = new Tratamiento();
        t2.setCosto(300);
        t2.setDescripcion("Recubrimiento superiror del diente");
        t2.setNombre("Corona");
        t2.setEspecialidad(Especialidad.ODONTOLOGIA_GENERAL);
        t2.setIdTratamiento(tBO.InsertarTratamiento(t2));
        listaTra.add(t2);
        
        Tratamiento t3 = new Tratamiento();
        t3.setCosto(100);
        t3.setDescripcion("Tratamiento superficial de caries");
        t3.setNombre("Curacion");
        t3.setEspecialidad(Especialidad.ODONTOLOGIA_GENERAL);
        t3.setIdTratamiento(tBO.InsertarTratamiento(t3));
        listaTra.add(t3);
        
        return listaTra;
        
    }
    public static ArrayList<Turno> insertaTurnos(){
        ArrayList<Turno>listaTur = new ArrayList<>();
        TurnoBO tBO = new TurnoBO();
        
        Turno t = new Turno();
        t.setDiaSemana(DiaSemana.LUNES);
        t.setHoraInicio(LocalTime.of(13,30));
        t.setHoraFin(LocalTime.of(17,30));
        t.setIdTurno(tBO.InsertarTurno(t));
        listaTur.add(t);
        
        Turno t1 = new Turno();
        t1.setDiaSemana(DiaSemana.LUNES);
        t1.setHoraInicio(LocalTime.of(8,30));
        t1.setHoraFin(LocalTime.of(12,30));
        t1.setIdTurno(tBO.InsertarTurno(t1));
        listaTur.add(t1);
        
        Turno t2 = new Turno();
        t2.setDiaSemana(DiaSemana.MARTES);
        t2.setHoraInicio(LocalTime.of(8,30));
        t2.setHoraFin(LocalTime.of(12,30));
        t2.setIdTurno(tBO.InsertarTurno(t2));
        listaTur.add(t2);
        
        Turno t3 = new Turno();
        t3.setDiaSemana(DiaSemana.VIERNES);
        t3.setHoraInicio(LocalTime.of(8,30));
        t3.setHoraFin(LocalTime.of(12,30));
        t3.setIdTurno(tBO.InsertarTurno(t3));
        listaTur.add(t3);
        
        return listaTur;
    }
    public static void insertaTurnoOdontologo(ArrayList<Odontologo>listaOd,ArrayList<Turno>listaTur){
        TurnoXOdontologoBO toBO = new TurnoXOdontologoBO();
        TurnoXOdontologo to = new TurnoXOdontologo();
        to.setIdOdontologo(listaOd.get(0).getIdOdontologo());
        to.setIdTurno(listaTur.get(0).getIdTurno());
        toBO.InsertarTurnoXOdontologo(to);
        
        to.setIdOdontologo(listaOd.get(0).getIdOdontologo());
        to.setIdTurno(listaTur.get(1).getIdTurno());
        toBO.InsertarTurnoXOdontologo(to);
        
        to.setIdOdontologo(listaOd.get(1).getIdOdontologo());
        to.setIdTurno(listaTur.get(0).getIdTurno());
        toBO.InsertarTurnoXOdontologo(to);
        
        to.setIdOdontologo(listaOd.get(1).getIdOdontologo());
        to.setIdTurno(listaTur.get(3).getIdTurno());
        toBO.InsertarTurnoXOdontologo(to);
        
        to.setIdOdontologo(listaOd.get(2).getIdOdontologo());
        to.setIdTurno(listaTur.get(2).getIdTurno());
        toBO.InsertarTurnoXOdontologo(to);
    }
    public static ArrayList<Comprobante>insertaComprobantes(){
        ArrayList<Comprobante>listaCom = new ArrayList<>();
        ComprobanteBO cBO = new ComprobanteBO();
        
        Comprobante c = new Comprobante();
        c.setFechaEmision(LocalDate.of(1000,1,1));
        c.setHoraEmision(LocalTime.of(0,0));
        c.setMetodoDePago(MetodoPago.PLIN);
        c.setTotal(0);
        c.setIdComprobante(cBO.InsertComprobante(c));
        listaCom.add(c);
        
        Comprobante c1 = new Comprobante();
        c1.setFechaEmision(LocalDate.now());
        c1.setHoraEmision(LocalTime.now());
        c1.setMetodoDePago(MetodoPago.TARJETA);
        c1.setTotal(1500);
        c1.setIdComprobante(cBO.InsertComprobante(c1));
        listaCom.add(c1);
        
        return listaCom;
    }
    public static ArrayList<Cita> insertaCita(ArrayList<Odontologo>listaOd,ArrayList<Paciente>listaPa,ArrayList<Comprobante>listaCom){
        ArrayList<Cita>listaCita = new ArrayList<>();
        CitaBO cBO = new CitaBO();
        
        Cita c = new Cita();
        c.setOdontologo(listaOd.get(0));
        c.setPaciente(listaPa.get(0));
        c.setHoraInicio(LocalTime.now());
        c.setPuntuacion(3.24);
        c.setComprobante(listaCom.get(0));
        c.setEstado(EstadoCita.RESERVADA);
        c.setFecha(LocalDate.now());
        c.setIdCita(cBO.insertCita(c));
        listaCita.add(c);
        
        Cita c1 = new Cita();
        c1.setOdontologo(listaOd.get(1));
        c1.setPaciente(listaPa.get(1));
        c1.setHoraInicio(LocalTime.now());
        c1.setPuntuacion(4.5);
        c1.setComprobante(listaCom.get(1));
        c1.setEstado(EstadoCita.ATENDIDA);
        c1.setFecha(LocalDate.now());
        c1.setIdCita(cBO.insertCita(c1));
        listaCita.add(c1);
        
        Cita c2 = new Cita();
        c2.setOdontologo(listaOd.get(2));
        c2.setPaciente(listaPa.get(2));
        c2.setHoraInicio(LocalTime.now());
        c2.setPuntuacion(0);
        c2.setComprobante(listaCom.get(0));
        c2.setEstado(EstadoCita.CANCELADA);
        c2.setFecha(LocalDate.now());
        c2.setIdCita(cBO.insertCita(c2));
        listaCita.add(c2);
        
        return listaCita;
    }
    public static void insertaDetalleTratamiento(ArrayList<Cita>listaCita,ArrayList<Tratamiento>listaTra){
        DetalleTratamientoBO dBO = new DetalleTratamientoBO();
        DetalleTratamiento d = new DetalleTratamiento();
        d.setIdCita(listaCita.get(1).getIdCita());
        d.setTratamiento(listaTra.get(0));
        d.setSubtotal(150);
        d.setCantidad(1);
        dBO.InsertarDetalle(d);
        
        DetalleTratamiento d1 = new DetalleTratamiento();
        d1.setIdCita(listaCita.get(0).getIdCita());
        d1.setTratamiento(listaTra.get(1));
        d1.setSubtotal(1500);
        d1.setCantidad(1);
        dBO.InsertarDetalle(d1);
        
        DetalleTratamiento d2 = new DetalleTratamiento();
        d2.setIdCita(listaCita.get(0).getIdCita());
        d2.setTratamiento(listaTra.get(2));
        d2.setSubtotal(100);
        d2.setCantidad(1);
        dBO.InsertarDetalle(d2);
        
        DetalleTratamiento d3 = new DetalleTratamiento();
        d3.setIdCita(listaCita.get(2).getIdCita());
        d3.setTratamiento(listaTra.get(1));
        d3.setSubtotal(200);
        d3.setCantidad(2);
        dBO.InsertarDetalle(d3);
        
        DetalleTratamiento d4 = new DetalleTratamiento();
        d4.setIdCita(listaCita.get(2).getIdCita());
        d4.setTratamiento(listaTra.get(0));
        d4.setSubtotal(300);
        d4.setCantidad(2);
        dBO.InsertarDetalle(d4);
    }
    
    public static void main(String[] args) {
        System.out.println("Hello World From Bussiness");
        /*Dummy data (respetar el orden)
            Especialidades ya deben existir en la bd, son fijas (sino no va a insertar odontologos), utilizar estas sentencias
                insert into especialidad (descripcion) values ('ODONTOLOGIA_GENERAL');
                insert into especialidad (descripcion) values ('ORTODONCIA');
                insert into especialidad (descripcion) values ('ENDODONCIA');
                insert into especialidad (descripcion) values ('CIRUGIA');
                insert into especialidad (descripcion) values ('PEDIATRIA');
            Metodos de pago ya deben existir en la bd, son fijas (sino no va a insertar cita), utilizar estas sentencias
                insert into metodopago (descripcion) values ('EFECTIVO');
                insert into metodopago (descripcion) values ('TARJETA');
                insert into metodopago (descripcion) values ('TRANSFERENCIA');
                insert into metodopago (descripcion) values ('YAPE');
                insert into metodopago (descripcion) values ('PLIN'); 
            Especialidad y MetodoPago deberian ser una clase aparte con sus DAOs
            Modificar y eliminar deberian funcionar en principio pero no estan probados para esta nueva version
            El primer comprobante existe como placeholder para no pagados -> tiene que haber una mejor forma de hacer esto xd
        */
        ArrayList<Sala>listaSa = insertaSalas();
        ArrayList<Turno>listaTur = insertaTurnos();
        //insertarEspecialidades(); //no implementado
        //insertarMetodosPago(); //no implementado
        ArrayList<Tratamiento>listaTra = insertaTratamientos();
        ArrayList<Comprobante>listaCom = insertaComprobantes();
        ArrayList<Recepcionista>listaRep = insertaRecepcionistas(); //no lo usa nadie pipipi
        ArrayList<Paciente>listaPa = insertaPacientes();
        ArrayList<Odontologo>listaOd = insertaOdontologos(listaSa);
        ArrayList<Cita>listaCita = insertaCita(listaOd,listaPa,listaCom);
        insertaDetalleTratamiento(listaCita,listaTra); //seria util que reciba objeto cita enves de id en el model?
        insertaTurnoOdontologo(listaOd,listaTur); // lo mismo que arriba, seria mejor objetos enves de solo ids?
    }
}
