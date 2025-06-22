USE ODONTO_SYS;

-- =========================================================================
-- ======================================================================
--                           STORED PROCEDURES
-- ======================================================================
-- =========================================================================

-- =========================================================================
-- TABLE: OS_CITAS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: CITAS_listar_por_recepcionista
-- Description: Lista todas las citas pertenecientes a un recepcionista dado.
-- Parameters:
--   IN in_recepcionista_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_listar_por_recepcionista`;
DELIMITER $$
CREATE PROCEDURE `CITAS_listar_por_recepcionista`(
    IN in_recepcionista_id INT
)
BEGIN
    SELECT
        C.CITA_ID,
        C.PACIENTE_ID,
        C.RECEPCIONISTA_ID,
        C.ODONTOLOGO_ID,
        C.COMPROBANTE_ID,
        C.FECHA,
        C.HORA_INICIO,
        C.VALORACION_ID,
        C.ESTADO
    FROM `OS_CITAS` AS C
    WHERE C.RECEPCIONISTA_ID = in_recepcionista_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_listar_por_paciente
-- Description: Lista todas las citas pertenecientes a un paciente dado.
-- Parameters:
--   IN in_paciente_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_listar_por_paciente`;
DELIMITER $$
CREATE PROCEDURE `CITAS_listar_por_paciente`(
    IN in_paciente_id INT
)
BEGIN
    SELECT
        C.CITA_ID,
        C.PACIENTE_ID,
        C.RECEPCIONISTA_ID,
        C.ODONTOLOGO_ID,
        C.COMPROBANTE_ID,
        C.FECHA,
        C.HORA_INICIO,
        C.VALORACION_ID,
        C.ESTADO
    FROM `OS_CITAS` AS C
    WHERE C.PACIENTE_ID = in_paciente_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_listar_por_paciente_fechas
-- Description: Lista todas las citas asociadas a un paciente dado en un rango de fechas.
-- Parameters:
--   IN in_idPaciente INT
--   IN in_fechaInicio DATE
--   IN in_fechaFin    DATE
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_listar_por_paciente_fechas`;
DELIMITER $$
CREATE PROCEDURE `CITAS_listar_por_paciente_fechas`(
    IN in_idPaciente INT,
    IN in_fechaInicio DATE,
    IN in_fechaFin    DATE
)
BEGIN
    SELECT
        C.CITA_ID,
        C.PACIENTE_ID,
        C.RECEPCIONISTA_ID,
        C.ODONTOLOGO_ID,
        C.COMPROBANTE_ID,
        C.FECHA,
        C.HORA_INICIO,
        C.VALORACION_ID,
        C.ESTADO
    FROM `OS_CITAS` AS C
    WHERE C.PACIENTE_ID = in_idPaciente
      AND C.FECHA BETWEEN in_fechaInicio AND in_fechaFin
    ORDER BY C.FECHA, C.HORA_INICIO;
END $$
DELIMITER ;


-- ---------------------------------------------------------------------
-- Procedure: CITAS_listar_por_odontologo
-- Description: Lista todas las citas pertenecientes a un odontólogo dado.
-- Parameters:
--   IN in_odontologo_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_listar_por_odontologo`;
DELIMITER $$
CREATE PROCEDURE `CITAS_listar_por_odontologo`(
    IN in_odontologo_id INT
)
BEGIN
    SELECT
        C.CITA_ID,
        C.PACIENTE_ID,
        C.RECEPCIONISTA_ID,
        C.ODONTOLOGO_ID,
        C.COMPROBANTE_ID,
        C.FECHA,
        C.HORA_INICIO,
        C.VALORACION_ID,
        C.ESTADO
    FROM `OS_CITAS` AS C
    WHERE C.ODONTOLOGO_ID = in_odontologo_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_listar_por_odontologo_fechas
-- Description: Lista todas las citas de un odontólogo dentro de un rango de fechas.
-- Parameters:
--   IN in_odontologo_id INT
--   IN in_fecha_inicio DATE
--   IN in_fecha_fin DATE
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_listar_por_odontologo_fechas`;
DELIMITER $$
CREATE PROCEDURE `CITAS_listar_por_odontologo_fechas`(
    IN in_odontologo_id   INT,
    IN in_fecha_inicio    DATE,
    IN in_fecha_fin       DATE
)
BEGIN
    SELECT
        C.CITA_ID,
        C.PACIENTE_ID,
        C.RECEPCIONISTA_ID,
        C.ODONTOLOGO_ID,
        C.COMPROBANTE_ID,
        C.FECHA,
        C.HORA_INICIO,
        C.VALORACION_ID,
        C.ESTADO
    FROM `OS_CITAS` AS C
    WHERE 
        C.ODONTOLOGO_ID = in_odontologo_id
        AND C.FECHA BETWEEN in_fecha_inicio AND in_fecha_fin;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_actualizar_fk_valoracion
-- Description: Actualiza el campo VALORACION_ID de una cita específica.
-- Parameters:
--   IN in_cita_id INT
--   IN in_valoracion_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_actualizar_fk_valoracion`;
DELIMITER $$
CREATE PROCEDURE `CITAS_actualizar_fk_valoracion`(
    IN in_cita_id        INT,
    IN in_valoracion_id  INT
)
BEGIN
    UPDATE `OS_CITAS`
    SET VALORACION_ID = in_valoracion_id
    WHERE CITA_ID = in_cita_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_actualizar_fk_comprobante
-- Description: Actualiza la clave foránea de comprobante en una cita dada.
-- Parameters:
--   IN in_idCita        INT
--   IN in_idComprobante INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_actualizar_fk_comprobante`;
DELIMITER $$
CREATE PROCEDURE `CITAS_actualizar_fk_comprobante`(
    IN in_idCita        INT,
    IN in_idComprobante INT
)
BEGIN
    UPDATE `OS_CITAS`
    SET COMPROBANTE_ID = in_idComprobante
    WHERE CITA_ID = in_idCita;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: CITAS_actualizar_estado
-- Description: Actualiza el estado de una cita dada (enum).
-- Parameters:
--   IN in_idCita   INT
--   IN in_estado   ENUM('RESERVADA','ATENDIDA','CANCELADA')  
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `CITAS_actualizar_estado`;
DELIMITER $$
CREATE PROCEDURE `CITAS_actualizar_estado`(
    IN in_idCita   INT,
    IN in_estado   ENUM('RESERVADA','ATENDIDA','CANCELADA')
)
BEGIN
    UPDATE `OS_CITAS`
    SET ESTADO = in_estado
    WHERE CITA_ID = in_idCita;
END $$
DELIMITER ;

-- =========================================================================
-- TABLE: OS_VALORACIONES
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: VALORACIONES_listar_por_odontologo
-- Description: Lista todas las valoraciones asociadas a un odontólogo dado.
-- Parameters:
--   IN in_odontologo_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `VALORACIONES_listar_por_odontologo`;
DELIMITER $$
CREATE PROCEDURE `VALORACIONES_listar_por_odontologo`(
    IN in_odontologo_id INT
)
BEGIN
    SELECT
        V.VALORACION_ID,
        V.COMENTARIO,
        V.CALIFICACION,
        V.FECHA
    FROM `OS_VALORACIONES` AS V
    INNER JOIN `OS_CITAS` AS C
        ON V.VALORACION_ID = C.VALORACION_ID
    WHERE C.ODONTOLOGO_ID = in_odontologo_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: VALORACIONES_listar_por_paciente
-- Description: Lista todas las valoraciones asociadas a un paciente dado.
-- Parameters:
--   IN in_paciente_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `VALORACIONES_listar_por_paciente`;
DELIMITER $$
CREATE PROCEDURE `VALORACIONES_listar_por_paciente`(
    IN in_paciente_id INT
)
BEGIN
    SELECT
        V.VALORACION_ID,
        V.COMENTARIO,
        V.CALIFICACION,
        V.FECHA
    FROM `OS_VALORACIONES` AS V
    INNER JOIN `OS_CITAS` AS C
        ON V.VALORACION_ID = C.VALORACION_ID
    WHERE C.PACIENTE_ID = in_paciente_id;
END $$
DELIMITER ;



-- =========================================================================
-- TABLE: OS_TURNOS & OS_TURNOS_POR_ODONTOLOGOS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: TURNOS_listar_por_odontologo
-- Description: Lista todos los turnos asignados a un odontólogo dado.
-- Parameters:
--   IN in_odontologo_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `TURNOS_listar_por_odontologo`;
DELIMITER $$
CREATE PROCEDURE `TURNOS_listar_por_odontologo`(
    IN in_odontologo_id INT
)
BEGIN
    SELECT
        T.TURNO_ID,
        T.HORA_INICIO,
        T.HORA_FIN,
        T.DIA_SEMANA
    FROM `OS_TURNOS` AS T
    INNER JOIN `OS_TURNOS_POR_ODONTOLOGOS` AS PTO
        ON T.TURNO_ID = PTO.TURNO_ID
    WHERE PTO.ODONTOLOGO_ID = in_odontologo_id;
END $$
DELIMITER ;



-- =========================================================================
-- TABLE: OS_ODONTOLOGOS_POR_TURNOS
-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_POR_TURNOS_eliminar
-- Description: Elimina la asignación de un turno a un odontólogo.
-- Parameters:
--   IN in_odontologo_id INT
--   IN in_turno_id      INT
-- =========================================================================
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_POR_TURNOS_eliminar`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_POR_TURNOS_eliminar`(
    IN in_odontologo_id INT,
    IN in_turno_id      INT
)
BEGIN
    DELETE FROM `OS_ODONTOLOGOS_POR_TURNOS`
    WHERE ODONTOLOGO_ID = in_odontologo_id
      AND TURNO_ID      = in_turno_id;
END $$
DELIMITER ;




-- =========================================================================
-- TABLE: OS_DETALLES_TRATAMIENTOS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: DETALLES_TRATAMIENTOS_listar_por_cita
-- Description: Lista todos los detalles de tratamiento para una cita específica.
-- Parameters:
--   IN in_cita_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `DETALLES_TRATAMIENTOS_listar_por_cita`;
DELIMITER $$
CREATE PROCEDURE `DETALLES_TRATAMIENTOS_listar_por_cita`(
    IN in_cita_id INT
)
BEGIN
    SELECT
        DT.CITA_ID,
        DT.TRATAMIENTO_ID,
        DT.CANTIDAD,
        DT.SUBTOTAL
    FROM `OS_DETALLES_TRATAMIENTOS` AS DT
    INNER JOIN `OS_TRATAMIENTOS` AS T
        ON DT.TRATAMIENTO_ID = T.TRATAMIENTO_ID
    WHERE DT.CITA_ID = in_cita_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: DETALLES_TRATAMIENTOS_actualizar_subtotal
-- Description: Recalcula el campo SUBTOTAL de todos los detalles de tratamiento
--              para una cita dada, usando la cantidad actual y el costo unitario.
-- Parameters:
--   IN in_cita_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `DETALLES_TRATAMIENTOS_actualizar_subtotal`;
DELIMITER $$
CREATE PROCEDURE `DETALLES_TRATAMIENTOS_actualizar_subtotal`(
    IN in_cita_id INT
)
BEGIN
    UPDATE `OS_DETALLES_TRATAMIENTOS` AS DT
    INNER JOIN `OS_TRATAMIENTOS` AS T
        ON DT.TRATAMIENTO_ID = T.TRATAMIENTO_ID
    SET 
        DT.SUBTOTAL = DT.CANTIDAD * T.COSTO
    WHERE 
        DT.CITA_ID = in_cita_id;
END $$
DELIMITER ;



-- =========================================================================
-- TABLE: OS_TRATAMIENTOS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: TRATAMIENTOS_listar_por_especialidad
-- Description: Lista todos los tratamientos que pertenecen a una
--              especialidad dada.
-- Parameters:
--   IN in_especialidad_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `TRATAMIENTOS_listar_por_especialidad`;
DELIMITER $$
CREATE PROCEDURE `TRATAMIENTOS_listar_por_especialidad`(
    IN in_especialidad_id INT
)
BEGIN
    SELECT
        T.TRATAMIENTO_ID,
        T.NOMBRE,
        T.DESCRIPCION,
        T.COSTO,
        T.ESPECIALIDAD_ID
    FROM `OS_TRATAMIENTOS` AS T
    WHERE T.ESPECIALIDAD_ID = in_especialidad_id;
END $$
DELIMITER ;



-- =========================================================================
-- TABLE: OS_PACIENTES
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: PACIENTES_obtener_por_usuario_contrasenha
-- Description: Obtiene el registro de un paciente según usuario y contraseña.
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
--   IN in_contrasenha      VARCHAR(50)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `PACIENTES_obtener_por_usuario_contrasenha`;
DELIMITER $$
CREATE PROCEDURE `PACIENTES_obtener_por_usuario_contrasenha`(
    IN in_nombre_usuario VARCHAR(100),
    IN in_contrasenha      TEXT
)
BEGIN
    SELECT
        P.PACIENTE_ID,
        P.CONTRASENHA,
        P.NOMBRE_USUARIO,
        P.CORREO,
        P.TELEFONO,
        P.NOMBRES,
        P.APELLIDOS,
        P.TIPO_DOCUMENTO_ID,
        P.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_PACIENTES` AS P
    WHERE P.NOMBRE_USUARIO = in_nombre_usuario
      AND P.CONTRASENHA    = in_contrasenha;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: PACIENTES_obtener_por_usuario
-- Description: Obtiene un paciente a partir de su nombre de usuario
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `PACIENTES_obtener_por_usuario`;
DELIMITER $$

CREATE PROCEDURE `PACIENTES_obtener_por_usuario`(
    IN in_nombre_usuario VARCHAR(100)
)
BEGIN
    SELECT
        P.PACIENTE_ID,
        P.CONTRASENHA,
        P.NOMBRE_USUARIO,
        P.CORREO,
        P.TELEFONO,
        P.NOMBRES,
        P.APELLIDOS,
        P.TIPO_DOCUMENTO_ID,
        P.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_PACIENTES` AS P
    WHERE P.NOMBRE_USUARIO = in_nombre_usuario
    LIMIT 1;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: PACIENTES_buscar_por_nombre_apellido
-- Description: Busca pacientes por nombre y apellido (uso de LIKE para búsqueda parcial)
-- Parameters:
--   IN in_nombre   VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `PACIENTES_buscar_por_nombre_apellido`;
DELIMITER $$
CREATE PROCEDURE `PACIENTES_buscar_por_nombre_apellido`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100)
)
BEGIN
    SELECT
        P.PACIENTE_ID,
        P.CONTRASENHA,
        P.NOMBRE_USUARIO,
        P.CORREO,
        P.TELEFONO,
        P.NOMBRES,
        P.APELLIDOS,
        P.TIPO_DOCUMENTO_ID,
        P.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_PACIENTES` AS P
    WHERE P.NOMBRES   LIKE CONCAT('%', in_nombre, '%')
      AND P.APELLIDOS LIKE CONCAT('%', in_apellidos, '%');
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: PACIENTES_buscar_por_nombre_apellido_telefono
-- Description: Busca pacientes por nombre, apellido y teléfono (todos con LIKE)
-- Parameters:
--   IN in_nombre    VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
--   IN in_telefono  VARCHAR(20)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `PACIENTES_buscar_por_nombre_apellido_telefono`;
DELIMITER $$
CREATE PROCEDURE `PACIENTES_buscar_por_nombre_apellido_telefono`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100),
    IN in_telefono  VARCHAR(20)
)
BEGIN
    SELECT
        P.PACIENTE_ID,
        P.CONTRASENHA,
        P.NOMBRE_USUARIO,
        P.CORREO,
        P.TELEFONO,
        P.NOMBRES,
        P.APELLIDOS,
        P.TIPO_DOCUMENTO_ID,
        P.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_PACIENTES` AS P
    WHERE P.NOMBRES   LIKE CONCAT('%', in_nombre, '%')
      AND P.APELLIDOS LIKE CONCAT('%', in_apellidos, '%')
      AND P.TELEFONO  LIKE CONCAT('%', in_telefono, '%');
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: PACIENTES_buscar_por_nombre_apellido_documento
-- Description: Busca pacientes por nombre, apellido y número de documento (igualdad exacta)
-- Parameters:
--   IN in_nombre    VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
--   IN in_documento VARCHAR(50)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `PACIENTES_buscar_por_nombre_apellido_documento`;
DELIMITER $$
CREATE PROCEDURE `PACIENTES_buscar_por_nombre_apellido_documento`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100),
    IN in_documento VARCHAR(50)
)
BEGIN
    SELECT
        P.PACIENTE_ID,
        P.CONTRASENHA,
        P.NOMBRE_USUARIO,
        P.CORREO,
        P.TELEFONO,
        P.NOMBRES,
        P.APELLIDOS,
        P.TIPO_DOCUMENTO_ID,
        P.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_PACIENTES` AS P
    WHERE P.NOMBRES                     LIKE CONCAT('%', in_nombre, '%')
      AND P.APELLIDOS                   LIKE CONCAT('%', in_apellidos, '%')
      AND P.NUMERO_DOCUMENTO_IDENTIDAD = in_documento;
END $$
DELIMITER ;

-- =========================================================================
-- TABLE: OS_ODONTOLOGOS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_obtener_por_usuario_contrasenha
-- Description: Obtiene el registro de un odontólogo según usuario y contraseña.
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
--   IN in_contrasenha      VARCHAR(50)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_obtener_por_usuario_contrasenha`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_obtener_por_usuario_contrasenha`(
    IN in_nombre_usuario VARCHAR(100),
    IN in_contrasenha      TEXT
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.PUNTUACION_PROMEDIO,
        O.SALA_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.NOMBRE_USUARIO = in_nombre_usuario
      AND O.CONTRASENHA    = in_contrasenha;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_obtener_por_usuario
-- Description: Obtiene el registro de un odontólogo según su nombre de usuario.
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_obtener_por_usuario`;
DELIMITER $$

CREATE PROCEDURE `ODONTOLOGOS_obtener_por_usuario`(
    IN in_nombre_usuario VARCHAR(100)
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.PUNTUACION_PROMEDIO,
        O.SALA_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.NOMBRE_USUARIO = in_nombre_usuario
    LIMIT 1;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_actualizar_puntuacion
-- Description: Actualiza el campo PUNTUACION_PROMEDIO de un odontólogo.
-- Parameters:
--   IN in_odontologo_id INT
--   IN in_puntuacion     DOUBLE
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_actualizar_puntuacion`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_actualizar_puntuacion` (
    IN in_odontologo_id INT
)
BEGIN
    DECLARE promedio DOUBLE;

    -- Calcular promedio de calificaciones para el odontólogo
    SELECT AVG(V.CALIFICACION) INTO promedio
    FROM `OS_VALORACIONES` V
    INNER JOIN `OS_CITAS` C ON V.VALORACION_ID = C.VALORACION_ID
    WHERE C.ODONTOLOGO_ID = in_odontologo_id;

    -- Actualizar la tabla de odontólogos con el promedio calculado
    UPDATE `OS_ODONTOLOGOS`
    SET PUNTUACION_PROMEDIO = IFNULL(promedio, 0)
    WHERE ODONTOLOGO_ID = in_odontologo_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_listar_por_especialidad
-- Description: Lista todos los odontólogos que pertenecen a una
--              especialidad dada.
-- Parameters:
--   IN in_especialidad_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_listar_por_especialidad`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_listar_por_especialidad`(
    IN in_especialidad_id INT
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.PUNTUACION_PROMEDIO,
        O.SALA_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.ESPECIALIDAD_ID = in_especialidad_id;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_buscar_por_nombre_apellido
-- Description: Busca odontólogos por nombre y apellido (búsqueda parcial usando LIKE).
-- Parameters:
--   IN in_nombre    VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_buscar_por_nombre_apellido`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_buscar_por_nombre_apellido`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100)
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID,
        O.SALA_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.NOMBRES   LIKE CONCAT('%', in_nombre, '%')
      AND O.APELLIDOS LIKE CONCAT('%', in_apellidos, '%');
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_buscar_por_nombre_apellido_telefono
-- Description: Busca odontólogos por nombre, apellido y teléfono (búsqueda parcial usando LIKE).
-- Parameters:
--   IN in_nombre    VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
--   IN in_telefono  VARCHAR(20)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_buscar_por_nombre_apellido_telefono`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_buscar_por_nombre_apellido_telefono`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100),
    IN in_telefono  VARCHAR(20)
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID,
        O.SALA_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.NOMBRES   LIKE CONCAT('%', in_nombre, '%')
      AND O.APELLIDOS LIKE CONCAT('%', in_apellidos, '%')
      AND O.TELEFONO  LIKE CONCAT('%', in_telefono, '%');
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: ODONTOLOGOS_buscar_por_nombre_apellido_documento
-- Description: Busca odontólogos por nombre, apellido y número de documento (documento exacto).
-- Parameters:
--   IN in_nombre    VARCHAR(100)
--   IN in_apellidos VARCHAR(100)
--   IN in_documento VARCHAR(50)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `ODONTOLOGOS_buscar_por_nombre_apellido_documento`;
DELIMITER $$
CREATE PROCEDURE `ODONTOLOGOS_buscar_por_nombre_apellido_documento`(
    IN in_nombre    VARCHAR(100),
    IN in_apellidos VARCHAR(100),
    IN in_documento VARCHAR(50)
)
BEGIN
    SELECT
        O.ODONTOLOGO_ID,
        O.CONTRASENHA,
        O.NOMBRE_USUARIO,
        O.CORREO,
        O.TELEFONO,
        O.NOMBRES,
        O.APELLIDOS,
        O.TIPO_DOCUMENTO_ID,
        O.NUMERO_DOCUMENTO_IDENTIDAD,
        O.ESPECIALIDAD_ID,
        O.SALA_ID
    FROM `OS_ODONTOLOGOS` AS O
    WHERE O.NOMBRES                     LIKE CONCAT('%', in_nombre, '%')
      AND O.APELLIDOS                   LIKE CONCAT('%', in_apellidos, '%')
      AND O.NUMERO_DOCUMENTO_IDENTIDAD = in_documento;
END $$
DELIMITER ;


-- =========================================================================
-- TABLE: OS_RECEPCIONISTAS
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: RECEPCIONISTAS_obtener_por_usuario_contrasenha
-- Description: Obtiene el registro de un recepcionista según usuario y contraseña.
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
--   IN in_contrasenha      VARCHAR(50)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `RECEPCIONISTAS_obtener_por_usuario_contrasenha`;
DELIMITER $$
CREATE PROCEDURE `RECEPCIONISTAS_obtener_por_usuario_contrasenha`(
    IN in_nombre_usuario VARCHAR(100),
    IN in_contrasenha      TEXT
)
BEGIN
    SELECT
        R.RECEPCIONISTA_ID,
        R.CONTRASENHA,
        R.NOMBRE_USUARIO,
        R.CORREO,
        R.TELEFONO,
        R.NOMBRES,
        R.APELLIDOS,
        R.TIPO_DOCUMENTO_ID,
        R.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_RECEPCIONISTAS` AS R
    WHERE R.NOMBRE_USUARIO = in_nombre_usuario
      AND R.CONTRASENHA    = in_contrasenha;
END $$
DELIMITER ;

-- ---------------------------------------------------------------------
-- Procedure: RECEPCIONISTAS_obtener_por_usuario
-- Description: Obtiene el registro de un recepcionista según su nombre de usuario.
-- Parameters:
--   IN in_nombre_usuario VARCHAR(100)
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `RECEPCIONISTAS_obtener_por_usuario`;
DELIMITER $$

CREATE PROCEDURE `RECEPCIONISTAS_obtener_por_usuario`(
    IN in_nombre_usuario VARCHAR(100)
)
BEGIN
    SELECT
        R.RECEPCIONISTA_ID,
        R.CONTRASENHA,
        R.NOMBRE_USUARIO,
        R.CORREO,
        R.TELEFONO,
        R.NOMBRES,
        R.APELLIDOS,
        R.TIPO_DOCUMENTO_ID,
        R.NUMERO_DOCUMENTO_IDENTIDAD
    FROM `OS_RECEPCIONISTAS` AS R
    WHERE R.NOMBRE_USUARIO = in_nombre_usuario
    LIMIT 1;
END $$
DELIMITER ;


-- =========================================================================
-- TABLE: OS_COMPROBANTES
-- =========================================================================

-- ---------------------------------------------------------------------
-- Procedure: COMPROBANTES_actualizar_total
-- Description: Calcula y actualiza el campo TOTAL de un comprobante
--              sumando todos los subtotales de detalles de tratamiento
--              para una cita dada.
-- Parameters:
--   IN in_cita_id INT
-- ---------------------------------------------------------------------
DROP PROCEDURE IF EXISTS `COMPROBANTES_actualizar_total`;
DELIMITER $$
CREATE PROCEDURE `COMPROBANTES_actualizar_total`(
    IN in_cita_id INT
)
BEGIN
    DECLARE v_comprobante_id INT;
    DECLARE v_total         DOUBLE;

    -- Obtener el COMPROBANTE_ID asociado a la cita
    SELECT C.COMPROBANTE_ID
    INTO v_comprobante_id
    FROM `OS_CITAS` AS C
    WHERE C.CITA_ID = in_cita_id;

    -- Sumar todos los subtotales de Detalles Tratamientos para esa cita
    SELECT COALESCE(SUM(DT.SUBTOTAL), 0)
    INTO v_total
    FROM `OS_DETALLES_TRATAMIENTOS` AS DT
    WHERE DT.CITA_ID = in_cita_id;

    -- Actualizar el TOTAL en la tabla OS_COMPROBANTES
    UPDATE `OS_COMPROBANTES`
    SET TOTAL = v_total
    WHERE COMPROBANTE_ID = v_comprobante_id;
END $$
DELIMITER ;