package com.odontosys.configpub.model;

import com.odontosys.config.model.Cifrado;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

/**
 *
 * @author andres
 */
public class CifradoTest {
    
    public CifradoTest() {
    }

    /**
     * Test of cifrarMD5 method, of class Cifrado.
     */
    @Test
    public void testCifrarMD5() {
        System.out.println("cifrarMD5");
        String texto = "programacion3grupo4";        
        String resultado = Cifrado.cifrarMD5(texto);
        String resultado_esperado = "oQV6OtzWvjPfQzVA2gGGNmfRGwdf1iN/";                                        
        assertEquals(resultado_esperado, resultado);        
    }

    /**
     * Test of descifrarMD5 method, of class Cifrado.
     */
    @Test
    public void testDescifrarMD5() {
        System.out.println("descifrarMD5");
        String textoEncriptado = "oQV6OtzWvjPfQzVA2gGGNmfRGwdf1iN/";
        String resultado_esperado = "programacion3grupo4";
        String resultado = Cifrado.descifrarMD5(textoEncriptado);
        System.out.println(resultado);
        assertEquals(resultado_esperado, resultado);
    }

    private void assertEquals(String resultado_esperado, String resultado) {
        throw new UnsupportedOperationException("Not supported yet."); // Generated from nbfs://nbhost/SystemFileSystem/Templates/Classes/Code/GeneratedMethodBody
    }
    
}
