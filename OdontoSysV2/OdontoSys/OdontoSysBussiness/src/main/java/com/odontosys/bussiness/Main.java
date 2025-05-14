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
import com.odontosys.infrastructure.model.Turno;
import com.odontosys.services.model.Comprobante;
import com.odontosys.services.model.DetalleTratamiento;
import com.odontosys.services.model.Especialidad;
import com.odontosys.services.model.EstadoCita;
import com.odontosys.users.model.TipoUsuario;
import java.time.LocalDate;
import java.time.LocalTime;

public class Main {

    public static void main(String[] args) {
        System.out.println("Hello World From Bussiness");
        
        /*
        //TEST USUARIOS (FUNCIONAN)
        //RECEPCIONISTA TEST
        //INSERT
        RecepcionistaBO recep = new RecepcionistaBO();
        int test = recep.insertarRecepcionista("test12", "admin",
            "admin@gmail.com","123456789","Elad","Ministrador",
            "1234567");
        
        //Modificar
        int mod = recep.modificarRecepcionista("admin", PersonaEnum.CORREO, "el+π&gon@gmail.com");
        
        //DELETE
        //int del = recep.eliminarRecepcionista("admin");
        
        //ODONTOLOGO TEST
        OdontologoBO od = new OdontologoBO();
        //INSERT
        int OdTest = od.insertarOdontologo("100solesLaHora", "ElDoc", "c4nc3r@gmail.com",
                "999999999", "Cha", "Pathin", "7777777", Especialidad.PEDIATRIA, 3.2, 1);
        //MOD
        int modO = od.modificarOdontologo("ElDoc", PersonaEnum.CORREO, "l3uc3mi4@icloud.com");
        //DEL
        //int delO = od.eliminarOdontologo("ElDoc");
        
        //PACIENTE TEST
        PacienteBO pbo = new PacienteBO();
        //INSERT
        int paTest = pbo.insertarPaciente("psd111", "Pikchu", "pkmn@yahoo.com", "987654321", "Carlos", "Santana", "1233567");
        //MOD
        int modP = pbo.modificarPaciente("Pikchu", PersonaEnum.CORREO, "pikmin@pucp.edu.pe");
        //DEL
        //int delP = pbo.eliminarPaciente("Pikchu");
        
        CitaBO c = new CitaBO();
        int cTest = c.insertCita(1, 1, 1 , LocalDate.now(), LocalTime.now(), 2, EstadoCita.RESERVADA);

        ComprobanteBO comprobante = new ComprobanteBO();
        int comInsert = comprobante.InsertComprobante(LocalDate.now(), LocalTime.now(),250, MetodoPago.EFECTIVO);
        Comprobante comp = new Comprobante();
        comp.setIdComprobante(2);
        int comElim = comprobante.EliminarComprobante(comp);
        
        
        TratamientoBO tratamiento = new TratamientoBO();
        int traInsert = tratamiento.InsertarTratamiento("Endodoncia", "Taladro en tu diente", 250, Especialidad.PEDIATRIA);
        int traMod = tratamiento.ModificarTratamiento("Endodoncia", Especialidad.PEDIATRIA, 5000.0);
        int traElim = tratamiento.EliminarTratamiento("Endodoncia", Especialidad.PEDIATRIA);
        
        */
        
        /*
        //ERROR
        DetalleTratamientoBO detalle = new DetalleTratamientoBO();
        //int detInsert = detalle.InsertarDetalle(1, 1, 3, 300);
        DetalleTratamiento det = new DetalleTratamiento();
        det.setIdCita(1);
        det.getTratamiento().setIdTratamiento(1);
        det.setCantidad(20);
        det.setSubtotal(400);
        int detMod = detalle.EliminarDetalle(det);
        */
        
        /*
        TurnoBO turno = new TurnoBO();
        int turInsert = turno.InsertarTurno(LocalTime.now(), LocalTime.now(), DiaSemana.VIERNES);
        Turno t = new Turno();
        t.setIdTurno(1);
        t.setHoraInicio(LocalTime.now());
        t.setHoraFin(LocalTime.now());
        t.setDiaSemana(DiaSemana.JUEVES);
        int turMod = turno.ModificarTurno(t);
        
        SalaBO sala = new SalaBO();
        int salaInsert = sala.InsertarSala("23", 2);
        int salaDel = sala.EliminarSala("23", 2);
        */
        
        //TurnoXOdontologoBO turnoOd = new TurnoXOdontologoBO();
        //int turOdInsert = turnoOd.InsertarTurnoXOdontologo(1, 1);
        //int turOdElim = turnoOd.EliminarTurnoXOdontologo(1, 1);
    }
}
