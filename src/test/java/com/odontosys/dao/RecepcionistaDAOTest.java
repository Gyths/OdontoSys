package com.odontosys.dao;

import com.odontosys.daoImp.RecepcionistaDAOImpl;
import com.odontosys.users.model.Recepcionista;
import org.junit.jupiter.api.Test;

import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

public class RecepcionistaDAOTest {

    private final RecepcionistaDAOImpl dao = new RecepcionistaDAOImpl();

    @Test
    public void testCRUDRecepcionista() {
        long timestamp = System.currentTimeMillis();

        // Crear nuevo recepcionista con datos únicos y válidos
        Recepcionista r = new Recepcionista();
        r.setNombreUsuario("recep_" + timestamp);
        r.setContraseña("claveSegura123");
        r.setCorreo("recep" + timestamp + "@test.com");
        r.setNombre("Laura_" + timestamp);
        r.setApellido("Ramirez_" + timestamp);

        // Generar DNI único y ≤ 15 caracteres
        String dniSeguro = "D" + String.valueOf(timestamp).substring(0, 13); // máx. 14 + 1 = 15
        r.setDNI(dniSeguro);

        // Generar teléfono con 9 dígitos
        r.setTelefono("9" + (int)(Math.random() * 100000000)); // ej: 987654321

        // Insertar
        int id = dao.insertar(r);
        assertTrue(id > 0);
        r.setIdUsuario(id);

        System.out.println("Después de insertar:");
        mostrarRecepcionistas();

        // Modificar correo
        String nuevoCorreo = "modificado" + timestamp + "@test.com";
        int mod = dao.modificarCorreo(id, nuevoCorreo);
        assertTrue(mod > 0);

        System.out.println("Después de modificar el correo:");
        mostrarRecepcionistas();

        // Eliminar
        int del = dao.eliminar(id);
        assertTrue(del > 0);

        System.out.println("Después de eliminar:");
        mostrarRecepcionistas();
    }

    private void mostrarRecepcionistas() {
        ArrayList<Recepcionista> lista = dao.listarTodos();
        System.out.println("Recepcionistas registrados: " + lista.size());
        for (Recepcionista r : lista) {
            System.out.println("ID: " + r.getIdUsuario() +
                    ", Usuario: " + r.getNombreUsuario() +
                    ", Correo: " + r.getCorreo() +
                    ", Nombre: " + r.getNombre() +
                    ", Apellido: " + r.getApellido() +
                    ", DNI: " + r.getDNI() +
                    ", Teléfono: " + r.getTelefono());
        }
        System.out.println("-------------------------------------------");
    }
}
