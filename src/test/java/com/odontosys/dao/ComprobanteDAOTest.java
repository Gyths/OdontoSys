package com.odontosys.dao;

import com.odontosys.daoImp.ComprobanteDAOImpl;
import com.odontosys.infraestructure.model.MetodoPago;
import com.odontosys.services.model.Comprobante;
import org.junit.jupiter.api.Test;

import java.sql.Date;
import java.time.LocalDate;
import java.util.ArrayList;

import static org.junit.jupiter.api.Assertions.*;

public class ComprobanteDAOTest {

    private final ComprobanteDAO dao = new ComprobanteDAOImpl();

    @Test
    public void testCRUDCompletoDeComprobantes() {
        System.out.println("Test completo de CRUD para Comprobante");

        ArrayList<Integer> ids = new ArrayList<>();

        // 👉 Inserción de 3 comprobantes
        for (int i = 1; i <= 3; i++) {
            Comprobante c = new Comprobante();
            c.setFechaEmision(Date.valueOf(LocalDate.now()));
            c.setTotal(i * 10.0);
            c.setMetodoPago(MetodoPago.EFECTIVO);
            int id = dao.insertar(c);
            assertTrue(id > 0, "Debe haberse insertado correctamente el comprobante " + i);
            c.setIdComprobante(id);
            ids.add(id);

            System.out.println("Insertado comprobante " + i + " con ID: " + id);

            // 👉 Consultar después del primero
            if (i == 1) {
                System.out.println("Lista después de insertar 1 comprobante:");
                listarTodosYMostrar();
            }
        }

        // 👉 Modificar el segundo comprobante
        Comprobante aModificar = new Comprobante();
        aModificar.setIdComprobante(ids.get(1)); // segundo insertado
        aModificar.setTotal(999.99);
        int modificado = dao.modificar(aModificar);
        assertTrue(modificado > 0, "Debe haberse modificado el segundo comprobante");
        System.out.println("Se modificó el total del comprobante con ID: " + ids.get(1));

        System.out.println("Lista después de la modificación:");
        listarTodosYMostrar();

        // 👉 Eliminar el segundo comprobante
        Comprobante aEliminar = new Comprobante();
        aEliminar.setIdComprobante(ids.get(1));
        int eliminado = dao.eliminar(aEliminar);
        assertTrue(eliminado > 0, "Debe haberse eliminado el segundo comprobante");
        System.out.println("Se eliminó el comprobante con ID: " + ids.get(1));

        System.out.println("Lista final después del eliminado:");
        listarTodosYMostrar();
    }

    private void listarTodosYMostrar() {
        ArrayList<Comprobante> lista = dao.listarTodos();
        System.out.println("Total registros: " + lista.size());
        for (Comprobante c : lista) {
            System.out.println("ID: " + c.getIdComprobante() +
                    " | Total: " + c.getTotal() +
                    " | Fecha: " + c.getFechaEmision() +
                    " | Pago: " + c.getMetodoPago());
        }
        System.out.println("--------------------------------------------------");
    }
}
