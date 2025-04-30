package com.odontosys.configpub.model;

import com.odontosys.config.model.Cifrado;
import org.junit.jupiter.api.Test;
import static org.junit.jupiter.api.Assertions.*;

/**
 *
 * @author Grupo04_0682
 */
public class CifradoTest {
    
    public CifradoTest() {
    }

    @Test
    public void testCifrarMD5() {
        System.out.println("cifrarMD5");
        String texto = "inkachips";        
        String resultado = Cifrado.cifrarMD5(texto);
        String resultado_esperado = "LzSB9Uqa/GuIPXO0uesH8A==";                                        
        assertEquals(resultado_esperado, resultado);        
    }

    @Test
    public void testDescifrarMD5() {
        System.out.println("descifrarMD5");
        String textoEncriptado = "LzSB9Uqa/GuIPXO0uesH8A==";
        String resultado_esperado = "inkachips";
        String resultado = Cifrado.descifrarMD5(textoEncriptado);
        System.out.println(resultado);
        assertEquals(resultado_esperado, resultado);
    }
    
}
