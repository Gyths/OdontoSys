package com.odontosys.dao;

import com.odontosys.daoImp.SalaDAOImpl;
import com.odontosys.infraestructure.model.Sala;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

public class SalaDAOTest {

    private final SalaDAO dao = new SalaDAOImpl();

    @Test
    public void testCRUDSalaConLog() {
        // Insertar
        Sala sala = new Sala();
        sala.setNumero("B101");
        sala.setPiso(2);

        int id = dao.insertar(sala);
        assertTrue(id > 0);
        sala.setIdSala(id);

        System.out.println("Después de insertar:");
        mostrarSalas();

        // Modificar
        sala.setNumero("B102");
        sala.setPiso(3);
        int mod = dao.modificar(sala);
        assertTrue(mod > 0);

        System.out.println("Después de modificar:");
        mostrarSalas();

        // Eliminar
        int del = dao.eliminar(sala);
        assertTrue(del > 0);

        System.out.println("Después de eliminar:");
        mostrarSalas();
    }

    private void mostrarSalas() {
        ArrayList<Sala> salas = dao.listarTodos();
        System.out.println("Total de salas: " + salas.size());
        for (Sala s : salas) {
            System.out.println("ID: " + s.getIdSala() + ", Número: " + s.getNumero() + ", Piso: " + s.getPiso());
        }
        System.out.println("------------------------------------------");
    }
}

