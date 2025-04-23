package com.odontosys.dao;

import com.odontosys.daoImp.TurnoDAOImpl;
import com.odontosys.infraestructure.model.DiaSemana;
import com.odontosys.infraestructure.model.Turno;
import org.junit.jupiter.api.Test;

import java.sql.Time;
import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

public class TurnoDAOTest {

    private final TurnoDAO dao = new TurnoDAOImpl();

    @Test
    public void testCRUDTurnoConLog() {
        // Insertar
        Turno t = new Turno();
        t.setHoraInicio(Time.valueOf("08:00:00"));
        t.setHoraFin(Time.valueOf("10:00:00"));
        t.setDiaLaboral(DiaSemana.LUNES);

        int id = dao.insertar(t);
        assertTrue(id > 0);
        t.setIdTurno(id);

        System.out.println("Después de insertar:");
        mostrarTurnos();

        // Modificar
        t.setHoraFin(Time.valueOf("10:30:00"));
        t.setDiaLaboral(DiaSemana.MARTES);
        int mod = dao.modificar(t);
        assertTrue(mod > 0);

        System.out.println("Después de modificar:");
        mostrarTurnos();

        // Eliminar
        int del = dao.eliminar(t);
        assertTrue(del > 0);

        System.out.println("Después de eliminar:");
        mostrarTurnos();
    }

    private void mostrarTurnos() {
        ArrayList<Turno> lista = dao.listarTodos();
        System.out.println("Total de turnos: " + lista.size());
        for (Turno t : lista) {
            System.out.println("ID: " + t.getIdTurno() +
                    ", Inicio: " + t.getHoraInicio() +
                    ", Fin: " + t.getHoraFin() +
                    ", Día: " + t.getDiaLaboral());
        }
        System.out.println("------------------------------------");
    }
}
