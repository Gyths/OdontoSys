package pe.pucp.edu.odontosys.daoImp.services;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import pe.pucp.edu.odontosys.dao.services.CitaDAO;
import pe.pucp.edu.odontosys.daoImp.DAOImplBase;
import pe.pucp.edu.odontosys.daoImp.util.Columna;
import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.services.model.EstadoCita;
import pe.pucp.edu.odontosys.users.model.*;
import java.time.LocalDate;
import java.time.LocalTime;
import pe.pucp.edu.odontosys.daoImp.QueryLoader;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import pe.pucp.edu.odontosys.services.model.Valoracion;

public class CitaDAOImpl extends DAOImplBase implements CitaDAO {

    private Cita cita;
    private static final QueryLoader queries = new QueryLoader("/citaQueries");
    
    public CitaDAOImpl() {
        super("OS_CITAS");
        this.retornarLlavePrimaria = true;
        this.cita = null;
    }

    @Override
    protected void configurarListaDeColumnas() {
        this.listaColumnas.add(new Columna("CITA_ID", true, true));
        this.listaColumnas.add(new Columna("PACIENTE_ID", false, false));
        this.listaColumnas.add(new Columna("ODONTOLOGO_ID", false, false));
        this.listaColumnas.add(new Columna("COMPROBANTE_ID", false, false));
        this.listaColumnas.add(new Columna("FECHA", false, false));
        this.listaColumnas.add(new Columna("HORA_INICIO", false, false));
        this.listaColumnas.add(new Columna("VALORACION_ID", false, false));
        this.listaColumnas.add(new Columna("ESTADO", false, false));
    }

    @Override
    protected void incluirValorDeParametrosParaInsercion() throws SQLException {
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setObject(3, this.cita.getComprobante().getIdComprobante() != 0 ? this.cita.getComprobante().getIdComprobante() : null);
        this.statement.setObject(4, LocalDate.parse(this.cita.getFecha()));
        this.statement.setObject(5, LocalTime.parse(this.cita.getHoraInicio()));
        this.statement.setObject(6, this.cita.getValoracion().getIdValoracion() != 0 ? this.cita.getValoracion().getIdValoracion() : null);
        this.statement.setString(7, this.cita.getEstado().name());
    }

    @Override
    protected void incluirValorDeParametrosParaModificacion() throws SQLException {
        this.statement.setInt(1, this.cita.getPaciente().getIdPaciente());
        this.statement.setInt(2, this.cita.getOdontologo().getIdOdontologo());
        this.statement.setObject(3, this.cita.getComprobante().getIdComprobante() != 0 ? this.cita.getComprobante().getIdComprobante() : null);
        this.statement.setObject(4, LocalDate.parse(this.cita.getFecha()));
        this.statement.setObject(5, LocalTime.parse(this.cita.getHoraInicio()));
        this.statement.setObject(6, this.cita.getValoracion().getIdValoracion() != 0 ? this.cita.getValoracion().getIdValoracion() : null);
        this.statement.setString(7, this.cita.getEstado().name());
        this.statement.setInt(8, this.cita.getIdCita());
    }

    @Override
    protected void incluirValorDeParametrosParaEliminacion() throws SQLException {
        this.statement.setInt(1, this.cita.getIdCita());
    }

    @Override
    protected void incluirValorDeParametrosParaObtenerPorId() throws SQLException {
        this.statement.setInt(1, this.cita.getIdCita());
    }

    @Override
    protected void instanciarObjetoDelResultSet() throws SQLException {
        this.cita = new Cita();
        this.cita.setIdCita(this.resultSet.getInt("CITA_ID"));
        this.cita.getPaciente().setIdPaciente(this.resultSet.getInt("PACIENTE_ID"));
        this.cita.getOdontologo().setIdOdontologo(this.resultSet.getInt("ODONTOLOGO_ID"));
        this.cita.getComprobante().setIdComprobante(this.resultSet.getInt("COMPROBANTE_ID"));
        this.cita.setFecha(this.resultSet.getObject("FECHA").toString());
        this.cita.setHoraInicio(this.resultSet.getObject("HORA_INICIO").toString());
        this.cita.getValoracion().setIdValoracion(this.resultSet.getInt("VALORACION_ID"));
        this.cita.setEstado(EstadoCita.valueOf(this.resultSet.getString("ESTADO")));
    }

    @Override
    protected void instanciarObjetoCompletoDelResultSet() throws SQLException {
        instanciarObjetoDelResultSet();

        // -------- DATOS DEL PACIENTE --------
        this.cita.getPaciente().setNombre(this.resultSet.getString("PACIENTE_NOMBRES"));
        this.cita.getPaciente().setApellidos(this.resultSet.getString("PACIENTE_APELLIDOS"));
        this.cita.getPaciente().setCorreo(this.resultSet.getString("PACIENTE_CORREO"));
        this.cita.getPaciente().setTelefono(this.resultSet.getString("PACIENTE_TELEFONO"));
        this.cita.getPaciente().setNombreUsuario(this.resultSet.getString("PACIENTE_USUARIO"));
        this.cita.getPaciente().setContrasenha(this.resultSet.getString("PACIENTE_CONTRASENHA"));
        this.cita.getPaciente().getTipoDocumento().setIdTipoDocumento(this.resultSet.getInt("PACIENTE_TIPO_DOCUMENTO_ID"));
        this.cita.getPaciente().getTipoDocumento().setNombre(this.resultSet.getString("PACIENTE_TIPO_DOCUMENTO_NOMBRE"));
        this.cita.getPaciente().setNumeroDocumento(this.resultSet.getString("PACIENTE_NUM_DOC"));

        // -------- DATOS DEL ODONTÓLOGO --------
        this.cita.getOdontologo().setNombre(this.resultSet.getString("ODONTOLOGO_NOMBRES"));
        this.cita.getOdontologo().setApellidos(this.resultSet.getString("ODONTOLOGO_APELLIDOS"));
        this.cita.getOdontologo().setCorreo(this.resultSet.getString("ODONTOLOGO_CORREO"));
        this.cita.getOdontologo().setTelefono(this.resultSet.getString("ODONTOLOGO_TELEFONO"));
        this.cita.getOdontologo().setNombreUsuario(this.resultSet.getString("ODONTOLOGO_USUARIO"));
        this.cita.getOdontologo().setContrasenha(this.resultSet.getString("ODONTOLOGO_CONTRASENHA"));
        this.cita.getOdontologo().setNumeroDocumento(this.resultSet.getString("ODONTOLOGO_NUM_DOC"));
        this.cita.getOdontologo().setPuntuacionPromedio(this.resultSet.getDouble("ODONTOLOGO_PUNTUACION"));

        // -------- DATOS DEL COMPROBANTE --------
        if (this.resultSet.getObject("COMPROBANTE_ID") != null) {
            this.cita.getComprobante().setFechaEmision(this.resultSet.getDate("COMPROBANTE_FECHA").toString());
            this.cita.getComprobante().setHoraEmision(this.resultSet.getTime("COMPROBANTE_HORA").toString());
            this.cita.getComprobante().setTotal(this.resultSet.getDouble("COMPROBANTE_TOTAL"));
            // Cargar Metodo de Pago (dentro de Comprobante)
            if (this.resultSet.getObject("METODO_PAGO_ID") != null) {
                this.cita.getComprobante().getMetodoDePago().setIdMetodoPago(this.resultSet.getInt("METODO_PAGO_ID"));
                this.cita.getComprobante().getMetodoDePago().setNombre(this.resultSet.getString("METODO_PAGO_NOMBRE"));
            }
        }

        // -------- DATOS DE LA VALORACIÓN --------
        if (this.resultSet.getObject("VALORACION_ID") != null) {
            this.cita.getValoracion().setComentario(this.resultSet.getString("VALORACION_COMENTARIO"));
            this.cita.getValoracion().setCalicicacion(this.resultSet.getInt("VALORACION_CALIFICACION"));
            this.cita.getValoracion().setFechaCalificacion(this.resultSet.getDate("VALORACION_FECHA").toString());
        }
    }

    @Override
    protected void limpiarObjetoDelResultSet() {
        this.cita = null;
    }

    @Override
    protected void agregarObjetoALaLista(List lista) throws SQLException {
        this.instanciarObjetoDelResultSet();
        lista.add(this.cita);
    }
    
    @Override
    protected void agregarObjetoCompletoALaLista(List lista) throws SQLException {
        this.instanciarObjetoCompletoDelResultSet();
        lista.add(this.cita);
    }

    @Override
    public Integer insertar(Cita cita) {
        this.cita = cita;
        return super.insertar();
    }

    @Override
    public Integer modificar(Cita cita) {
        this.cita = cita;
        return super.modificar();
    }

    @Override
    public Integer eliminar(Cita cita) {
        this.cita = cita;
        return super.eliminar();
    }

    @Override
    public Cita obtenerPorId(Integer id) {
        this.cita = new Cita();
        this.cita.setIdCita(id);
        super.obtenerPorId();
        return this.cita;
    }

    @Override
    public ArrayList<Cita> listarTodos() {
        return (ArrayList<Cita>) super.listarTodos();
    }

    @Override
    public ArrayList<Cita> listarPorOdontologoFechas(Odontologo odontologo, String fechaInicio, String fechaFin) {
        String sql = queries.getQuery("listarCitasPorOdontologoFechas");
        return (ArrayList<Cita>) ejecutarQueryListar(sql, odontologo.getIdOdontologo(), LocalDate.parse(fechaInicio), LocalDate.parse(fechaFin));
    }

    @Override
    public ArrayList<Cita> listarPorOdontologo(Odontologo odontologo) {
        String sql = queries.getQuery("listarCitasPorOdontologo");
        return (ArrayList<Cita>) super.ejecutarQueryListar(sql, odontologo.getIdOdontologo());
    }

    @Override
    public ArrayList<Cita> listarPorPaciente(Paciente paciente) {
        String sql = queries.getQuery("listarCitasPorPaciente");
        return (ArrayList<Cita>) super.ejecutarQueryListar(sql, paciente.getIdPaciente());
    }

    @Override
    public ArrayList<Cita> listarPorPacienteFechas(Paciente paciente, String fechaInicio, String fechaFin) {
        String sql = queries.getQuery("listarCitasPorPacienteFechas");
        return (ArrayList<Cita>) ejecutarQueryListar(sql, paciente.getIdPaciente(), LocalDate.parse(fechaInicio), LocalDate.parse(fechaFin));
    }

}
