package pe.pucp.edu.odontosys.daoImp;

import java.io.IOException;
import java.io.InputStream;
import java.util.Map;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.core.type.TypeReference;

public class QueryLoader {
    private final Map<String, String> queries;
    
    public QueryLoader(String jsonRuta){
        try(InputStream json = getClass().getResourceAsStream(jsonRuta)){
            if(json == null)  throw new IllegalArgumentException("No existe " + jsonRuta);
            queries = new ObjectMapper().readValue(json, new TypeReference<>(){});
        } catch (IOException ex){
        throw new RuntimeException("Error cargando SQL de " + jsonRuta, ex);
        }
    }
    
    public String getQuery(String llave){
        return queries.get(llave);
    }
}
