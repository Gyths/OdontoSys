package pe.pucp.edu.odontosys.dao.services;

import pe.pucp.edu.odontosys.services.model.Cita;
import pe.pucp.edu.odontosys.users.model.Odontologo;
import java.time.LocalDate;
import java.util.ArrayList;
import pe.pucp.edu.odontosys.services.model.Comprobante;
import pe.pucp.edu.odontosys.services.model.Valoracion;
import pe.pucp.edu.odontosys.users.model.Paciente;
import pe.pucp.edu.odontosys.users.model.Recepcionista;

public interface CitaDAO{
    Integer insertar(Cita cita);
    Integer modificar(Cita cita);
    Integer eliminar(Cita cita);
    Cita obtenerPorId(Integer id);
    ArrayList<Cita> listarTodos();
    ArrayList<Cita> listarPorOdontologoFechas(Odontologo odontologo, String fechaInicio, String fechaFin);
    ArrayList<Cita> listarPorOdontologo(Odontologo odontologo);
    ArrayList<Cita> listarPorPaciente(Paciente paciente);
    ArrayList<Cita> listarPorRecepcionista(Recepcionista recepcionista);
    Integer actualizarFkValoracion(Cita cita, Valoracion valoracion);
    Integer actualizarFkComprobante(Cita cita, Comprobante comprobante);
    Integer actualizarEstado(Cita cita);
    ArrayList<Cita> listarPorPacienteFechas(Paciente paciente, String fechaInicio, String fechaFin);
}