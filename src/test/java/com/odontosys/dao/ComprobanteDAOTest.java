package com.odontosys.dao;
import com.odontosys.daoImp.ComprobanteDAOImpl;
import com.odontosys.infraestructure.model.MetodoPago;
import com.odontosys.services.model.Comprobante;
import java.sql.Date;
import java.util.ArrayList;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;


public class ComprobanteDAOTest {
    private ComprobanteDAO comprobanteDAO;    
    
    public ComprobanteDAOTest() {
        this.comprobanteDAO = new ComprobanteDAOImpl();        
    }
    
    @Test
    public void testInsertar() {
        System.out.println("insertar");
        ArrayList<Integer> listaComprobanteId = new ArrayList<>();
        insertarComprobantes(listaComprobanteId);
        eliminarTodo();
    }
    
    private void insertarComprobantes(ArrayList<Integer> listaComprobanteId) {
        Comprobante comprobante = new Comprobante();
        comprobante.setFechaEmision(Date.valueOf("2023-07-14"));
        comprobante.setTotal(30.56);
        comprobante.setMetodoPago(MetodoPago.EFECTIVO);
        Integer resultado = this.comprobanteDAO.insertar(comprobante);
        assertTrue(resultado != 0);
        listaComprobanteId.add(resultado);
        
        comprobante.setFechaEmision(Date.valueOf("2021-02-10"));
        comprobante.setTotal(20.56);
        comprobante.setMetodoPago(MetodoPago.YAPE);
        resultado = this.comprobanteDAO.insertar(comprobante);
        assertTrue(resultado != 0);
        listaComprobanteId.add(resultado);
        
        comprobante.setFechaEmision(Date.valueOf("2024-07-15"));
        comprobante.setTotal(40.56);
        comprobante.setMetodoPago(MetodoPago.TARJETA);
        resultado = this.comprobanteDAO.insertar(comprobante);
        assertTrue(resultado != 0);
        listaComprobanteId.add(resultado);        
    }
    
    @Test
    public void testObtenerPorId() {
        System.out.println("obtenerPorId");
        ArrayList<Integer> listaComprobanteId = new ArrayList<>();
        insertarComprobantes(listaComprobanteId);
        Comprobante comprobante = this.comprobanteDAO.obtenerPorId(listaComprobanteId.get(0));
        assertEquals(comprobante.getIdComprobante(), listaComprobanteId.get(0));
        
        
        comprobante = this.comprobanteDAO.obtenerPorId(listaComprobanteId.get(1));
        assertEquals(comprobante.getIdComprobante(), listaComprobanteId.get(1));
        
        comprobante = this.comprobanteDAO.obtenerPorId(listaComprobanteId.get(2));
        assertEquals(comprobante.getIdComprobante(), listaComprobanteId.get(2));
        eliminarTodo();
    }
    
    @Test
    public void testListarTodos() {
        System.out.println("listarTodos");
        ArrayList<Integer> listaComprobanteId = new ArrayList<>();
        insertarComprobantes(listaComprobanteId);
        
        ArrayList<Comprobante> listaComprobantes = this.comprobanteDAO.listarTodos();
        assertEquals(listaComprobanteId.size(), listaComprobantes.size());
        for (Integer i = 0; i < listaComprobanteId.size(); i++) {
            assertEquals(listaComprobanteId.get(i), listaComprobantes.get(i).getIdComprobante());
        }
        eliminarTodo();
    }
    
    @Test
    public void testModificar() {
        System.out.println("modificar");
        ArrayList<Integer> listaComprobanteId = new ArrayList<>();
        insertarComprobantes(listaComprobanteId);
        
        ArrayList<Comprobante> listaComprobantes = this.comprobanteDAO.listarTodos();
        assertEquals(listaComprobanteId.size(), listaComprobantes.size());
        for (Integer i = 0; i < listaComprobanteId.size(); i++) {
            listaComprobantes.get(i).setTotal(0);//va a poner todos los totales en 0
            this.comprobanteDAO.modificar(listaComprobantes.get(i));
        }
        
        ArrayList<Comprobante> listaComprobantesModificados = this.comprobanteDAO.listarTodos();
        assertEquals( listaComprobantes.size(), listaComprobantesModificados.size());
        for (Integer i = 0; i < listaComprobantes.size(); i++) {
            assertEquals(listaComprobantes.get(i).getTotal(), listaComprobantesModificados.get(i).getTotal());
        }
        eliminarTodo();
    }
    
    @Test
    public void testEliminar() {
        System.out.println("eliminar");
        ArrayList<Integer> listaComprobanteId = new ArrayList<>();
        insertarComprobantes(listaComprobanteId);
        eliminarTodo();
    }
    
    private void eliminarTodo(){                
        ArrayList<Comprobante> listaComprobantes = this.comprobanteDAO.listarTodos();
        for (Integer i = 0; i < listaComprobantes.size(); i++) {
            Integer resultado = this.comprobanteDAO.eliminar(listaComprobantes.get(i));
            assertNotEquals(0, resultado);
            Comprobante almacen = this.comprobanteDAO.obtenerPorId(listaComprobantes.get(i).getIdComprobante());
            assertNull(almacen);
        }
    }
}
