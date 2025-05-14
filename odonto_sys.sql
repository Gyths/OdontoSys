-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema odonto_sys
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema odonto_sys
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `odonto_sys` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `odonto_sys` ;

-- -----------------------------------------------------
-- Table `odonto_sys`.`tipousuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`tipousuario` (
  `idTipo` INT NOT NULL AUTO_INCREMENT,
  `descripcion` VARCHAR(100) NOT NULL,
  PRIMARY KEY (`idTipo`))
ENGINE = InnoDB
AUTO_INCREMENT = 5
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`persona`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`persona` (
  `idPersona` INT NOT NULL AUTO_INCREMENT,
  `contrasenha` VARCHAR(100) NOT NULL,
  `nombreUsuario` VARCHAR(100) NOT NULL,
  `correo` VARCHAR(100) NOT NULL,
  `telefono` VARCHAR(100) NOT NULL,
  `nombre` VARCHAR(100) NOT NULL,
  `apellidos` VARCHAR(100) NOT NULL,
  `DNI` VARCHAR(15) NOT NULL,
  `tipoUsuario` INT NOT NULL,
  PRIMARY KEY (`idPersona`),
  UNIQUE INDEX `DNI` (`DNI` ASC) VISIBLE,
  INDEX `tipoUsuario_ibfk_1` (`tipoUsuario` ASC) VISIBLE,
  CONSTRAINT `tipoUsuario_ibfk_1`
    FOREIGN KEY (`tipoUsuario`)
    REFERENCES `odonto_sys`.`tipousuario` (`idTipo`))
ENGINE = InnoDB
AUTO_INCREMENT = 4
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`paciente`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`paciente` (
  `idPaciente` INT NOT NULL AUTO_INCREMENT,
  `idPersona` INT NOT NULL,
  PRIMARY KEY (`idPaciente`),
  INDEX `paciente_ibfk_1` (`idPersona` ASC) VISIBLE,
  CONSTRAINT `paciente_ibfk_1`
    FOREIGN KEY (`idPersona`)
    REFERENCES `odonto_sys`.`persona` (`idPersona`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`sala`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`sala` (
  `idSala` INT NOT NULL AUTO_INCREMENT,
  `numeroSala` VARCHAR(10) NOT NULL,
  `piso` INT NOT NULL,
  PRIMARY KEY (`idSala`),
  UNIQUE INDEX `numeroSala` (`numeroSala` ASC) VISIBLE)
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`odontologo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`odontologo` (
  `idOdontologo` INT NOT NULL AUTO_INCREMENT,
  `idPersona` INT NOT NULL,
  `puntuacionPromedio` DOUBLE NULL DEFAULT '0',
  `especialidad` ENUM('ODONTOLOGIA_GENERAL', 'ORTODONCIA', 'ENDODONCIA', 'CIRUGIA', 'PEDIATRIA') NOT NULL,
  `idSala` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idOdontologo`),
  INDEX `idSala` (`idSala` ASC) VISIBLE,
  INDEX `odontologo_ibfk_1` (`idPersona` ASC) VISIBLE,
  CONSTRAINT `odontologo_ibfk_1`
    FOREIGN KEY (`idPersona`)
    REFERENCES `odonto_sys`.`persona` (`idPersona`),
  CONSTRAINT `odontologo_ibfk_3`
    FOREIGN KEY (`idSala`)
    REFERENCES `odonto_sys`.`sala` (`idSala`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`comprobante`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`comprobante` (
  `idComprobante` INT NOT NULL AUTO_INCREMENT,
  `fechaEmision` DATE NOT NULL,
  `horaEmision` TIME NOT NULL,
  `total` DOUBLE NOT NULL,
  `metodoPago` ENUM('EFECTIVO', 'TARJETA', 'TRANSFERENCIA', 'YAPE', 'PLIN') NOT NULL,
  PRIMARY KEY (`idComprobante`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`cita`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`cita` (
  `idCita` INT NOT NULL AUTO_INCREMENT,
  `idPaciente` INT NOT NULL,
  `idOdontologo` INT NOT NULL,
  `idComprobante` INT NULL DEFAULT NULL,
  `fecha` DATE NOT NULL,
  `horaInicio` TIME NOT NULL,
  `puntuacion` INT NULL DEFAULT '0',
  `estado` ENUM('RESERVADA', 'ATENDIDA', 'CANCELADA', 'PAGO_CANCELADO') NOT NULL,
  PRIMARY KEY (`idCita`),
  INDEX `idPaciente` (`idPaciente` ASC) VISIBLE,
  INDEX `idOdontologo` (`idOdontologo` ASC) VISIBLE,
  INDEX `idComprobante` (`idComprobante` ASC) VISIBLE,
  CONSTRAINT `cita_ibfk_1`
    FOREIGN KEY (`idPaciente`)
    REFERENCES `odonto_sys`.`paciente` (`idPaciente`),
  CONSTRAINT `cita_ibfk_2`
    FOREIGN KEY (`idOdontologo`)
    REFERENCES `odonto_sys`.`odontologo` (`idOdontologo`),
  CONSTRAINT `cita_ibfk_3`
    FOREIGN KEY (`idComprobante`)
    REFERENCES `odonto_sys`.`comprobante` (`idComprobante`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`tratamiento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`tratamiento` (
  `idTratamiento` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(100) NOT NULL,
  `descripcion` TEXT NULL DEFAULT NULL,
  `costo` DOUBLE NOT NULL,
  `especialidad` ENUM('ODONTOLOGIA_GENERAL', 'ORTODONCIA', 'ENDODONCIA', 'CIRUGIA', 'PEDIATRIA') NOT NULL,
  PRIMARY KEY (`idTratamiento`),
  UNIQUE INDEX `nombre` (`nombre` ASC) VISIBLE)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`detalletratamiento`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`detalletratamiento` (
  `idCita` INT NOT NULL,
  `idTratamiento` INT NOT NULL,
  `cantidad` INT NOT NULL DEFAULT '1',
  `subtotal` DOUBLE NOT NULL,
  PRIMARY KEY (`idCita`, `idTratamiento`),
  INDEX `idTratamiento` (`idTratamiento` ASC) VISIBLE,
  CONSTRAINT `detalletratamiento_ibfk_1`
    FOREIGN KEY (`idCita`)
    REFERENCES `odonto_sys`.`cita` (`idCita`),
  CONSTRAINT `detalletratamiento_ibfk_2`
    FOREIGN KEY (`idTratamiento`)
    REFERENCES `odonto_sys`.`tratamiento` (`idTratamiento`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`turno`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`turno` (
  `idTurno` INT NOT NULL AUTO_INCREMENT,
  `horaInicio` TIME NOT NULL,
  `horaFin` TIME NOT NULL,
  `diaSemana` ENUM('LUNES', 'MARTES', 'MIERCOLES', 'JUEVES', 'VIERNES', 'SABADO') NOT NULL,
  PRIMARY KEY (`idTurno`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`odontologo_turno`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`odontologo_turno` (
  `idOdontologo` INT NOT NULL,
  `idTurno` INT NOT NULL,
  PRIMARY KEY (`idOdontologo`, `idTurno`),
  INDEX `idTurno` (`idTurno` ASC) VISIBLE,
  CONSTRAINT `odontologo_turno_ibfk_1`
    FOREIGN KEY (`idOdontologo`)
    REFERENCES `odonto_sys`.`odontologo` (`idOdontologo`),
  CONSTRAINT `odontologo_turno_ibfk_2`
    FOREIGN KEY (`idTurno`)
    REFERENCES `odonto_sys`.`turno` (`idTurno`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `odonto_sys`.`recepcionista`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `odonto_sys`.`recepcionista` (
  `idRecepcionista` INT NOT NULL AUTO_INCREMENT,
  `idPersona` INT NOT NULL,
  PRIMARY KEY (`idRecepcionista`),
  INDEX `recepcionista_ibfk_1` (`idPersona` ASC) VISIBLE,
  CONSTRAINT `recepcionista_ibfk_1`
    FOREIGN KEY (`idPersona`)
    REFERENCES `odonto_sys`.`persona` (`idPersona`))
ENGINE = InnoDB
AUTO_INCREMENT = 2
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
