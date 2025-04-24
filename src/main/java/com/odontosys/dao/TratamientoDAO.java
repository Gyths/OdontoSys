
package com.odontosys.dao;

import com.odontosys.services.model.Tratamiento;
import java.util.ArrayList;

/**
 *
 * @author Gyts
 */
public interface TratamientoDAO {
    Integer insertar(Tratamiento tratamiento);
    Integer modificar(Integer idTratamiento,String nombre, String descripcion, Double costo);
    Integer eliminar(Integer idTratamiento);
    ArrayList<Tratamiento> listarTodos();
}
