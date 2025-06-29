package pe.pucp.edu.odontosys.daoImp;

import java.io.InputStream;
import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

public class QueryLoaderXML {
    private final Map<String, String> queries = new ConcurrentHashMap<>();

    public QueryLoaderXML(String resourcePath) {
        Map<String, String> loaded = loadQueriesFrom(resourcePath);
        queries.putAll(loaded);
    }

    private Map<String, String> loadQueriesFrom(String resourcePath) {
        try (InputStream is = getClass().getResourceAsStream(resourcePath)) {
            if (is == null) {
                throw new IllegalArgumentException("Recurso no encontrado: " + resourcePath);
            }
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            factory.setIgnoringComments(true);
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document doc = builder.parse(is);
            NodeList list = doc.getElementsByTagName("query");

            Map<String, String> map = new ConcurrentHashMap<>();
            for (int i = 0; i < list.getLength(); i++) {
                Element elem = (Element) list.item(i);
                String id = elem.getAttribute("id");
                String sql = elem.getTextContent().trim();
                map.put(id, sql);
            }
            return map;
        } catch (Exception e) {
            throw new RuntimeException("Error cargando consultas desde XML: " + resourcePath, e);
        }
    }

    public String getQuery(String key) {
        String sql = queries.get(key);
        if (sql == null) {
            throw new IllegalArgumentException(
                "Consulta con clave '" + key + "' no encontrada en el XML cargado");
        }
        return sql;
    }
}
