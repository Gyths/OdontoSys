/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package pe.pucp.edu.odontosys.webapplication.reports;

import jakarta.jms.Connection;
import java.util.HashMap;
import net.sf.jasperreports.engine.JRException;
import net.sf.jasperreports.engine.JasperExportManager;
import net.sf.jasperreports.engine.JasperFillManager;
import net.sf.jasperreports.engine.JasperPrint;
import net.sf.jasperreports.engine.JasperReport;
import net.sf.jasperreports.engine.util.JRLoader;
import pe.pucp.edu.odontosys.db.DBManager;

/**
 *
 * @author USER
 */
public class ReporteUtil {
    public static byte[]invocarReporte(String nombreReporte, HashMap parametros) throws JRException{
        byte[]reporte = null;
        java.sql.Connection conexion = DBManager.getInstance().getConnection();
        String nombreRecurso = "/" + nombreReporte + ".jasper";
        JasperReport jr = (JasperReport) JRLoader.loadObject(ReporteUtil.class.getResource(nombreRecurso));
        JasperPrint jp = JasperFillManager.fillReport(jr, parametros, conexion);
        reporte = JasperExportManager.exportReportToPdf(jp);
        return reporte;
    }
    public static byte[]reporteComprobante(Integer comprobanteId) throws JRException{
        HashMap parametros = new HashMap();
        parametros.put("ComprobanteID", comprobanteId);
        return invocarReporte("Comprobante", parametros);
    }
    public static byte[]reporteHistoriaClinica(Integer pacienteId) throws JRException{
        HashMap parametros = new HashMap();
        parametros.put("pacienteId", pacienteId);
        return invocarReporte("HistoriaClinica", parametros);
    }
}
