package pe.pucp.edu.odontosys.persistance;

import pe.pucp.edu.odontosys.db.DBManager;
import java.sql.Connection;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.dao.infrastructure.MetodoPagoDAO;
import pe.pucp.edu.odontosys.dao.infrastructure.TurnoDAO;
import pe.pucp.edu.odontosys.dao.services.CitaDAO;
import pe.pucp.edu.odontosys.dao.services.ComprobanteDAO;
import pe.pucp.edu.odontosys.dao.services.EspecialidadDAO;
import pe.pucp.edu.odontosys.dao.services.ValoracionDAO;
import pe.pucp.edu.odontosys.dao.users.TipoDocumentoDAO;
import pe.pucp.edu.odontosys.daoImp.infrastructure.MetodoPagoDAOImpl;
import pe.pucp.edu.odontosys.daoImp.infrastructure.TurnoDAOImpl;
import pe.pucp.edu.odontosys.daoImp.services.CitaDAOImpl;
import pe.pucp.edu.odontosys.daoImp.services.ComprobanteDAOImpl;
import pe.pucp.edu.odontosys.daoImp.services.EspecialidadDAOImpl;
import pe.pucp.edu.odontosys.daoImp.services.ValoracionDAOImpl;
import pe.pucp.edu.odontosys.daoImp.users.TipoDocumentoDAOImpl;
import pe.pucp.edu.odontosys.infrastructure.model.MetodoPago;
import pe.pucp.edu.odontosys.infrastructure.model.Sala;
import pe.pucp.edu.odontosys.infrastructure.model.Turno;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import pe.pucp.edu.odontosys.services.model.Especialidad;
import pe.pucp.edu.odontosys.services.model.EstadoCita;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.users.model.TipoDocumento;

public class Main {

    public static void main(String[] args) {
//        Paciente p = new Paciente();
//        PacienteDAO pacienteDAO = new PacienteDAOImpl();
//        p = pacienteDAO.obtenerPorUsuarioContrasenha("usuario_prueba", "Secreto123!");
//        System.out.println(p);

//        String fecha1 ="2025-03-15";
//        String fecha2 ="2024-12-05";
//        String fecha3 ="2023-07-21";
//        String fecha4 ="2025-06-29";
//        String fecha5 ="2022-11-10";
//
//        String hora1= "08:30:00";
//        String hora2= "13:45:00";
//        String hora3= "17:15:00";
//        String hora4= "19:05:00";
//        String hora5= "21:50:00";
//
//
//        EspecialidadDAO especialidadDAO = new EspecialidadDAOImpl();
//        ArrayList<Especialidad>listaE = especialidadDAO.listarTodos();
//
//        MetodoPagoDAO metodoPagoDAO = new MetodoPagoDAOImpl();
//        ArrayList<MetodoPago>listaMp = metodoPagoDAO.listarTodos();
//        
//        TipoDocumentoDAO tipoDocumentoDAO = new TipoDocumentoDAOImpl();
//        ArrayList<TipoDocumento>listaTd = tipoDocumentoDAO.listarTodos();
//        
//        ValoracionDAO valoracionDAO = new ValoracionDAOImpl();
//        ArrayList<Valoracion>listaV = valoracionDAO.listarTodos();
//        
//        
//        //COMPROBANTES:
//        ComprobanteDAO comprobacionDAO = new ComprobanteDAOImpl();
//        ArrayList<Comprobante>listaCom = comprobacionDAO.listarTodos();
//        
//        Comprobante comp1 = new Comprobante();
//        comp1.setFechaEmision(fecha1);
//        comp1.setHoraEmision(fecha1);
//        comp1.setTotal(110);
//        comp1.setMetodoDePago(listaMp.get(1));
//        comp1.setIdComprobante(1);
//        listaCom.add(comp1);
//        
//        
//        //SALAS:
//        ArrayList<Sala>listaSa = new ArrayList<>();
//        Sala s = new Sala();
//        s.setNumero("101");
//        s.setPiso(1);
//        s.setIdSala(1);
//        listaSa.add(s);
//        
//        Sala s1 = new Sala();
//        s1.setNumero("201");
//        s1.setPiso(2);
//        s1.setIdSala(2);
//        listaSa.add(s1);
//        
//        Sala s2 = new Sala();
//        s2.setNumero("301");
//        s2.setPiso(3);
//        s2.setIdSala(3);
//        listaSa.add(s2);
//        
//        Sala s3 = new Sala();
//        s3.setNumero("102");
//        s3.setPiso(1);
//        s3.setIdSala(4);
//        listaSa.add(s3);
//        
//        Sala s4 = new Sala();
//        s4.setNumero("202");
//        s4.setPiso(2);
//        s4.setIdSala(5);
//        listaSa.add(s4);
//        
//        Sala s5 = new Sala();
//        s5.setNumero("302");
//        s5.setPiso(3);
//        s5.setIdSala(6);
//        listaSa.add(s5);
//        
//        //PACIENTES:
//        ArrayList<Paciente>listaPac = new ArrayList<>();
//        
//        Paciente p = new Paciente();
//        p.setApellidos("Gutierrez");
//        p.setTipoDocumento(listaTd.get(1));
//        p.setNumeroDocumento("35621489");
//        p.setContrasenha("con1");
//        p.setCorreo("joseGutierrez45@gmail.com");
//        p.setNombre("Jose");
//        p.setNombreUsuario("JoseGut74");
//        p.setTelefono("963258412");
//        p.setIdPaciente(1);
//        listaPac.add(p);
//        
//        Paciente p1 = new Paciente();
//        p1.setApellidos("Marquez");
//        p1.setTipoDocumento(listaTd.get(0));
//        p1.setNumeroDocumento("15234562");
//        p1.setContrasenha("papas23");
//        p1.setCorreo("marmar78@gmail.com");
//        p1.setNombre("Maria");
//        p1.setNombreUsuario("Marq452");
//        p1.setTelefono("923651245");
//        p1.setIdPaciente(2);
//        listaPac.add(p1);
//        
//        Paciente p2 = new Paciente();
//        p2.setApellidos("Milla");
//        p2.setTipoDocumento(listaTd.get(0));
//        p2.setNumeroDocumento("52132654");
//        p2.setContrasenha("vmilla785");
//        p2.setCorreo("ElMetroEsSuperior@gmail.com");
//        p2.setNombre("Victor");
//        p2.setNombreUsuario("MillaVic4");
//        p2.setTelefono("956245835");
//        p2.setIdPaciente(3);
//        listaPac.add(p2);
//        
//        Paciente p3 = new Paciente();
//        p3.setApellidos("Goku");
//        p3.setTipoDocumento(listaTd.get(1));
//        p3.setNumeroDocumento("7621548");
//        p3.setContrasenha("ssj24lvldios");
//        p3.setCorreo("kamehameha45@gmail.com");
//        p3.setNombre("Son");
//        p3.setNombreUsuario("KiUser74");
//        p3.setTelefono("964751235");
//        p3.setIdPaciente(4);
//        listaPac.add(p3);
//        
//        Paciente p4 = new Paciente();
//        p4.setApellidos("Caceres");
//        p4.setTipoDocumento(listaTd.get(0));
//        p4.setNumeroDocumento("65212325");
//        p4.setContrasenha("+kπto");
//        p4.setCorreo("caceresOrlando1995@gmail.com");
//        p4.setNombre("Orlando");
//        p4.setNombreUsuario("Orlandokcrs");
//        p4.setTelefono("912378625");
//        p4.setIdPaciente(5);
//        listaPac.add(p4);
//        
//        //ODONTOLOGOS:
//        ArrayList<Odontologo>listaOd = new ArrayList<>();
//        Odontologo o = new Odontologo();
//        o.setApellidos("Castaneda");
//        o.setTipoDocumento(listaTd.get(0));
//        o.setNumeroDocumento("25645863");
//        o.setContrasenha("75486235555");
//        o.setCorreo("docCastaneda@gmail.com");
//        o.setNombre("Javier");
//        o.setNombreUsuario("JCastaneda");
//        o.setTelefono("958762135");
//        o.setEspecialidad(listaE.get(4));
//        o.setPuntuacionPromedio(3.2);
//        o.setConsultorio(listaSa.get(1));
//        o.setIdOdontologo(1);
//        listaOd.add(o);
//        
//        Odontologo o1 = new Odontologo();
//        o1.setApellidos("Villegas");
//        o1.setTipoDocumento(listaTd.get(1));
//        o1.setNumeroDocumento("45869523");
//        o1.setContrasenha("vi__45M");
//        o1.setCorreo("docVillegas@gmail.com");
//        o1.setNombre("Sandra");
//        o1.setNombreUsuario("SVillegas");
//        o1.setTelefono("927546831");
//        o1.setEspecialidad(listaE.get(2));
//        o1.setPuntuacionPromedio(4.1);
//        o1.setConsultorio(listaSa.get(2));
//        o1.setIdOdontologo(2);
//        listaOd.add(o1);
//        
//        Odontologo o2 = new Odontologo();
//        o2.setApellidos("Suarez");
//        o2.setTipoDocumento(listaTd.get(0));
//        o2.setNumeroDocumento("45862135");
//        o2.setContrasenha("ss_ss-0012");
//        o2.setCorreo("docSuarez@gmail.com");
//        o2.setNombre("Sebastian");
//        o2.setNombreUsuario("SSuarez");
//        o2.setTelefono("972135628");
//        o2.setEspecialidad(listaE.get(0));
//        o2.setPuntuacionPromedio(4.5);
//        o2.setConsultorio(listaSa.get(3));
//        o2.setIdOdontologo(3);
//        listaOd.add(o2);
//        
//        //CITAS:
//        ArrayList<Cita>listaCita = new ArrayList<>();
//        Cita c = new Cita();
//        c.setOdontologo(listaOd.get(0));
//        c.setPaciente(listaPac.get(0));
//        c.setHoraInicio(hora1);
//        c.getValoracion().setIdValoracion(0);
//        c.getComprobante().setIdComprobante(0);
//        c.setEstado(EstadoCita.RESERVADA);
//        c.setFecha(fecha1);
//        c.setIdCita(1);
//        listaCita.add(c);
//        
//        
//        Cita c1 = new Cita();
//        c1.setOdontologo(listaOd.get(1));
//        c1.setPaciente(listaPac.get(0));
//        c1.setHoraInicio(hora2);
//        c1.getValoracion().setIdValoracion(0);
//        c1.getComprobante().setIdComprobante(0);
//        c1.setEstado(EstadoCita.ATENDIDA);
//        c1.setFecha(fecha2);
//        c1.setIdCita(2);
//        listaCita.add(c1);
//        
//        Cita c2 = new Cita();
//        c2.setOdontologo(listaOd.get(2));
//        c2.setPaciente(listaPac.get(0));
//        c2.setHoraInicio(hora3);
//        c2.getValoracion().setIdValoracion(0);
//        c2.getComprobante().setIdComprobante(0);
//        c2.setEstado(EstadoCita.CANCELADA);
//        c2.setFecha(fecha3);
//        c2.setIdCita(3);
//        listaCita.add(c2);
//        
//        CitaDAO citaDAO= new CitaDAOImpl();
//        ArrayList<Cita> citasPrueba = citaDAO.listarPorPaciente(p);
//        for(Cita cita: listaCita){
//            citaDAO.insertar(cita);
//        }
//        for(Cita cit : citasPrueba){
//            System.out.println(cit);
//        }

        TurnoDAO turnoDAO = new TurnoDAOImpl();
        Odontologo o2 = new Odontologo();
        o2.setIdOdontologo(1);
        ArrayList<Turno> turnos = turnoDAO.listarPorOdontologo(o2);
        for(Turno t : turnos)
            System.out.println(t);

    }
}
