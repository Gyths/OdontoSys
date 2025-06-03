package com.odontosys.bussiness;

import com.odontosys.bo.CitaBO;
import com.odontosys.bo.ComprobanteBO;
import com.odontosys.bo.DetalleTratamientoBO;
import com.odontosys.bo.EspecialidadBO;
import com.odontosys.bo.MetodoPagoBO;
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
import com.odontosys.users.model.TipoDocumento;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.ArrayList;

public class Main {
    public static ArrayList<Tratamiento> cargaTratamientos(){
        TratamientoBO tBO = new TratamientoBO();
        ArrayList<Tratamiento>listaTratamiento = tBO.listarTodos();
        return listaTratamiento;
    }
    public static ArrayList<Especialidad> cargaEspecialidad(){
        EspecialidadBO eBO = new EspecialidadBO();
        ArrayList<Especialidad>listaEspecialidad = eBO.ListarEspecialidades();
        return listaEspecialidad;
    }
    public static ArrayList<MetodoPago> cargaMetodoPago(){
        MetodoPagoBO mBO = new MetodoPagoBO();
        ArrayList<MetodoPago>listaMetodoPago = mBO.ListarMetodosDePago();
        return listaMetodoPago;
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
    public static ArrayList<Turno> insertaTurnos(){
        ArrayList<Turno>listaTur = new ArrayList<>();
        TurnoBO tBO = new TurnoBO();
        
        Turno t = new Turno();
        t.setDiaSemana(DiaSemana.MONDAY);
        t.setHoraInicio(LocalTime.of(13,30));
        t.setHoraFin(LocalTime.of(17,30));
        t.setIdTurno(tBO.InsertarTurno(t));
        listaTur.add(t);
        
        Turno t1 = new Turno();
        t1.setDiaSemana(DiaSemana.MONDAY);
        t1.setHoraInicio(LocalTime.of(8,30));
        t1.setHoraFin(LocalTime.of(12,30));
        t1.setIdTurno(tBO.InsertarTurno(t1));
        listaTur.add(t1);
        
        Turno t2 = new Turno();
        t2.setDiaSemana(DiaSemana.TUESDAY);
        t2.setHoraInicio(LocalTime.of(8,30));
        t2.setHoraFin(LocalTime.of(12,30));
        t2.setIdTurno(tBO.InsertarTurno(t2));
        listaTur.add(t2);
        
        Turno t3 = new Turno();
        t3.setDiaSemana(DiaSemana.FRIDAY);
        t3.setHoraInicio(LocalTime.of(8,30));
        t3.setHoraFin(LocalTime.of(12,30));
        t3.setIdTurno(tBO.InsertarTurno(t3));
        listaTur.add(t3);
        
        return listaTur;
    }
    
    public static ArrayList<Recepcionista>insertaRecepcionistas(){
        ArrayList<Recepcionista>listaRec = new ArrayList<>();
        RecepcionistaBO rBO = new RecepcionistaBO();
        
        Recepcionista r = new Recepcionista();
        r.setApellidos("Mendoza");
        r.setTipoDocumento(TipoDocumento.CARNE_DE_EXTRANJERIA);
        r.setNumeroDocumento("74758691");
        r.setContrasenha("pass1");
        r.setCorreo("repMendoza@gmail.com");
        r.setNombre("Carlos");
        r.setNombreUsuario("CMendoza");
        r.setTelefono("987854963");
        r.setIdRecepcionista(rBO.insertarRecepcionista(r));
        listaRec.add(r);
        
        Recepcionista r1 = new Recepcionista();
        r1.setApellidos("Paredes");
        r.setTipoDocumento(TipoDocumento.PASAPORTE);
        r1.setNumeroDocumento("21546369");
        r1.setContrasenha("pass2");
        r1.setCorreo("repParedes@gmail.com");
        r1.setNombre("Juan");
        r1.setNombreUsuario("JParedes");
        r1.setTelefono("875965215");
        r1.setIdRecepcionista(rBO.insertarRecepcionista(r1));
        listaRec.add(r1);
        
        Recepcionista r2 = new Recepcionista();
        r2.setApellidos("Castillo");
        r2.setTipoDocumento(TipoDocumento.PASAPORTE);
        r2.setNumeroDocumento("32564871");
        r2.setContrasenha("pass3");
        r2.setCorreo("repCastillo@gmail.com");
        r2.setNombre("Manuel");
        r2.setNombreUsuario("MCastillo");
        r2.setTelefono("954862315");
        r2.setIdRecepcionista(rBO.insertarRecepcionista(r2));
        listaRec.add(r2);
        
        Recepcionista r3 = new Recepcionista();
        r3.setApellidos("Pollo");
        r3.setTipoDocumento(TipoDocumento.PASAPORTE);
        r3.setNumeroDocumento("76985212");
        r3.setContrasenha("pass4");
        r3.setCorreo("repPollo@gmail.com");
        r3.setNombre("Cena");
        r3.setNombreUsuario("CPollo");
        r3.setTelefono("948632152");
        r3.setIdRecepcionista(rBO.insertarRecepcionista(r3));
        listaRec.add(r3);
        
        Recepcionista r4 = new Recepcionista();
        r4.setApellidos("Cardenas");
        r4.setTipoDocumento(TipoDocumento.CARNE_DE_EXTRANJERIA);
        r4.setNumeroDocumento("75486921");
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
        p.setTipoDocumento(TipoDocumento.DNI);
        p.setNumeroDocumento("35621489");
        p.setContrasenha("con1");
        p.setCorreo("joseGutierrez45@gmail.com");
        p.setNombre("Jose");
        p.setNombreUsuario("JoseGut74");
        p.setTelefono("963258412");
        p.setIdPaciente(pBO.insertarPaciente(p));
        listaPac.add(p);
        
        Paciente p1 = new Paciente();
        p1.setApellidos("Marquez");
        p1.setTipoDocumento(TipoDocumento.DNI);
        p1.setNumeroDocumento("15234562");
        p1.setContrasenha("papas23");
        p1.setCorreo("marmar78@gmail.com");
        p1.setNombre("Maria");
        p1.setNombreUsuario("Marq452");
        p1.setTelefono("923651245");
        p1.setIdPaciente(pBO.insertarPaciente(p1));
        listaPac.add(p1);
        
        Paciente p2 = new Paciente();
        p2.setApellidos("Milla");
        p2.setTipoDocumento(TipoDocumento.DNI);
        p2.setNumeroDocumento("52132654");
        p2.setContrasenha("vmilla785");
        p2.setCorreo("ElMetroEsSuperior@gmail.com");
        p2.setNombre("Victor");
        p2.setNombreUsuario("MillaVic4");
        p2.setTelefono("956245835");
        p2.setIdPaciente(pBO.insertarPaciente(p2));
        listaPac.add(p2);
        
        Paciente p3 = new Paciente();
        p3.setApellidos("Goku");
        p3.setTipoDocumento(TipoDocumento.PASAPORTE);
        p3.setNumeroDocumento("7621548");
        p3.setContrasenha("ssj24lvldios");
        p3.setCorreo("kamehameha45@gmail.com");
        p3.setNombre("Son");
        p3.setNombreUsuario("KiUser74");
        p3.setTelefono("964751235");
        p3.setIdPaciente(pBO.insertarPaciente(p3));
        listaPac.add(p3);
        
        Paciente p4 = new Paciente();
        p4.setApellidos("Caceres");
        p4.setTipoDocumento(TipoDocumento.DNI);
        p4.setNumeroDocumento("65212325");
        p4.setContrasenha("+kπto");
        p4.setCorreo("caceresOrlando1995@gmail.com");
        p4.setNombre("Orlando");
        p4.setNombreUsuario("Orlandokcrs");
        p4.setTelefono("912378625");
        p4.setIdPaciente(pBO.insertarPaciente(p4));
        listaPac.add(p4);
        
        return listaPac;
    }
    public static ArrayList<Odontologo>insertaOdontologos(ArrayList<Sala>listaSa,ArrayList<Especialidad>listaE){
        ArrayList<Odontologo>listaOD = new ArrayList<>();
        OdontologoBO odBO = new OdontologoBO();
        
        Odontologo o = new Odontologo();
        o.setApellidos("Castaneda");
        o.setTipoDocumento(TipoDocumento.DNI);
        o.setNumeroDocumento("25645863");
        o.setContrasenha("75486235555");
        o.setCorreo("docCastaneda@gmail.com");
        o.setNombre("Javier");
        o.setNombreUsuario("JCastaneda");
        o.setTelefono("958762135");
        o.setEspecialidad(listaE.get(4));
        o.setPuntuacionPromedio(3.2);
        o.setConsultorio(listaSa.get(1));
        o.setIdOdontologo(odBO.insertarOdontologo(o));
        listaOD.add(o);
        
        Odontologo o1 = new Odontologo();
        o1.setApellidos("Villegas");
        o1.setTipoDocumento(TipoDocumento.DNI);
        o1.setNumeroDocumento("45869523");
        o1.setContrasenha("vi__45M");
        o1.setCorreo("docVillegas@gmail.com");
        o1.setNombre("Sandra");
        o1.setNombreUsuario("SVillegas");
        o1.setTelefono("927546831");
        o1.setEspecialidad(listaE.get(2));
        o1.setPuntuacionPromedio(4.1);
        o1.setConsultorio(listaSa.get(2));
        o1.setIdOdontologo(odBO.insertarOdontologo(o1));
        listaOD.add(o1);
        
        Odontologo o2 = new Odontologo();
        o2.setApellidos("Suarez");
        o2.setTipoDocumento(TipoDocumento.DNI);
        o2.setNumeroDocumento("45862135");
        o2.setContrasenha("ss_ss-0012");
        o2.setCorreo("docSuarez@gmail.com");
        o2.setNombre("Sebastian");
        o2.setNombreUsuario("SSuarez");
        o2.setTelefono("972135628");
        o2.setEspecialidad(listaE.get(0));
        o2.setPuntuacionPromedio(4.5);
        o2.setConsultorio(listaSa.get(3));
        o2.setIdOdontologo(odBO.insertarOdontologo(o2));
        listaOD.add(o2);
        
        return listaOD;
    }
    
    public static ArrayList<Comprobante>insertaComprobantes(ArrayList<MetodoPago>listaMp){
        ComprobanteBO cBO = new ComprobanteBO();
        ArrayList<Comprobante>listaCom = cBO.ListarTodos();
        
        Comprobante c1 = new Comprobante();
        c1.setFechaEmision(LocalDate.now());
        c1.setHoraEmision(LocalTime.now());
        c1.setMetodoDePago(listaMp.get(1));
        c1.setTotal(1500);
        c1.setIdComprobante(cBO.InsertComprobante(c1));
        listaCom.add(c1);
        
        return listaCom;
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
        /*
            Modificar y eliminar deberian funcionar en principio pero no estan probados para esta nueva version
            El primer comprobante existe como placeholder para no pagados -> tiene que haber una mejor forma de hacer esto xd
        */
        /*Carga de datos fijos iniciales*/
        ArrayList<Tratamiento>listaTra = cargaTratamientos();
        ArrayList<Especialidad>listaEs = cargaEspecialidad();
        ArrayList<MetodoPago>listaMp = cargaMetodoPago();
        
        /*Dummy data (respetar el orden)*/
        ArrayList<Sala>listaSa = insertaSalas();
        ArrayList<Turno>listaTur = insertaTurnos();
        ArrayList<Comprobante>listaCom = insertaComprobantes(listaMp);
        ArrayList<Recepcionista>listaRep = insertaRecepcionistas(); //no lo usa nadie
        ArrayList<Paciente>listaPa = insertaPacientes();
        ArrayList<Odontologo>listaOd = insertaOdontologos(listaSa,listaEs);
        ArrayList<Cita>listaCita = insertaCita(listaOd,listaPa,listaCom);
        insertaDetalleTratamiento(listaCita,listaTra); 
        insertaTurnoOdontologo(listaOd,listaTur);
        
        //Test horarios libres por doctor, @jared
        OdontologoBO odBO = new OdontologoBO();
        Odontologo odontologo = odBO.obtenerPorID(2);
        System.out.println(odontologo.getNombre());
        
        TurnoXOdontologoBO toBO = new TurnoXOdontologoBO();
        ArrayList<TurnoXOdontologo>listaTurnoOd = toBO.listarPorOdontologo(odontologo.getIdOdontologo());
        TurnoBO tBO = new TurnoBO();
        ArrayList<Turno>listaTurno = new ArrayList<>();
        for(TurnoXOdontologo turno:listaTurnoOd){
            listaTurno.add(tBO.obtenerPorId(turno.getIdTurno()));
        }
        
        CitaBO cBO = new CitaBO(); 
        ArrayList<Cita>lCita = cBO.listarPorOdontologo(odontologo, "2025-05-27", "2025-06-01");
        boolean[][] test = cBO.calcularDisponibilidad(lCita, listaTurno, "2025-05-27");
        /*Test matriz*/
        for(int i=0;i<7;i++){
            for(int j=0;j<48;j++){
                System.out.print(test[i][j]);
                System.out.print(" ");
            }
            System.out.print("\n");
        }
        
    }
}
