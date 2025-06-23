
USE ODONTO_SYS;

-- =========================================================================
-- ======================================================================
--                           TRIGGERS
-- ======================================================================
-- =========================================================================


-- ---------------------------------------------------------------------
-- Trigger: ODONTOLOGOS_recalcular_puntaje_odontologo_trg
-- Description: Actualiza la puntuación promedio de un Odontologo 
-- cada vez que se inserta una nueva valoracio
-- ---------------------------------------------------------------------
DROP TRIGGER IF EXISTS ODONTOLOGOS_recalcular_puntaje_odontologo_trg;
DELIMITER $$
CREATE TRIGGER ODONTOLOGOS_recalcular_puntaje_odontologo_trg
AFTER INSERT ON OS_VALORACIONES
FOR EACH ROW
BEGIN
    DECLARE v_odontologo_id INT;
    DECLARE v_avg DOUBLE;

    /* 1. Localizar el odontólogo que recibió esta valoración */
    SELECT c.ODONTOLOGO_ID
      INTO v_odontologo_id
      FROM OS_CITAS AS c
     WHERE c.VALORACION_ID = NEW.VALORACION_ID
     LIMIT 1;

    /* 2. Promediar todas sus calificaciones */
    IF v_odontologo_id IS NOT NULL THEN
        SELECT AVG(v.CALIFICACION)
          INTO v_avg
          FROM OS_VALORACIONES AS v
          JOIN OS_CITAS AS c2
            ON c2.VALORACION_ID = v.VALORACION_ID
         WHERE c2.ODONTOLOGO_ID = v_odontologo_id;

        /* 3. Actualizar la tabla de odontólogos */
        UPDATE OS_ODONTOLOGOS
           SET PUNTUACION_PROMEDIO = COALESCE(v_avg, 0)
         WHERE ODONTOLOGO_ID = v_odontologo_id;
    END IF;
END$$
DELIMITER ;