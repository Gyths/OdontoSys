USE ODONTO_SYS;

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