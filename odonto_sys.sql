-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: database-1.cj6kgkaa204b.us-east-1.rds.amazonaws.com    Database: odonto_sys
-- ------------------------------------------------------
-- Server version	8.4.4

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
SET @MYSQLDUMP_TEMP_LOG_BIN = @@SESSION.SQL_LOG_BIN;
SET @@SESSION.SQL_LOG_BIN= 0;

--
-- GTID state at the beginning of the backup 
--

SET @@GLOBAL.GTID_PURGED=/*!80000 '+'*/ '';

--
-- Table structure for table `cita`
--

DROP TABLE IF EXISTS `cita`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `cita` (
  `idCita` int NOT NULL AUTO_INCREMENT,
  `idPaciente` int NOT NULL,
  `idOdontologo` int NOT NULL,
  `idComprobante` int DEFAULT NULL,
  `fecha` date NOT NULL,
  `horaInicio` time NOT NULL,
  `puntuacion` int DEFAULT '0',
  `estado` enum('RESERVADA','ATENDIDA','CANCELADA','PAGO_CANCELADO') NOT NULL,
  PRIMARY KEY (`idCita`),
  KEY `idPaciente` (`idPaciente`),
  KEY `idOdontologo` (`idOdontologo`),
  KEY `idComprobante` (`idComprobante`),
  CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`idPaciente`) REFERENCES `paciente` (`idUsuario`),
  CONSTRAINT `cita_ibfk_2` FOREIGN KEY (`idOdontologo`) REFERENCES `odontologo` (`idUsuario`),
  CONSTRAINT `cita_ibfk_3` FOREIGN KEY (`idComprobante`) REFERENCES `comprobante` (`idComprobante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cita`
--

LOCK TABLES `cita` WRITE;
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
/*!40000 ALTER TABLE `cita` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `comprobante`
--

DROP TABLE IF EXISTS `comprobante`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `comprobante` (
  `idComprobante` int NOT NULL AUTO_INCREMENT,
  `fechaEmision` date NOT NULL,
  `total` double NOT NULL,
  `metodoPago` enum('EFECTIVO','TARJETA','TRANSFERENCIA','YAPE','PLIN') NOT NULL,
  PRIMARY KEY (`idComprobante`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comprobante`
--

LOCK TABLES `comprobante` WRITE;
/*!40000 ALTER TABLE `comprobante` DISABLE KEYS */;
/*!40000 ALTER TABLE `comprobante` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `detalletratamiento`
--

DROP TABLE IF EXISTS `detalletratamiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `detalletratamiento` (
  `idCita` int NOT NULL,
  `idTratamiento` int NOT NULL,
  `cantidad` int NOT NULL DEFAULT '1',
  `subtotal` double NOT NULL,
  PRIMARY KEY (`idCita`,`idTratamiento`),
  KEY `idTratamiento` (`idTratamiento`),
  CONSTRAINT `detalletratamiento_ibfk_1` FOREIGN KEY (`idCita`) REFERENCES `cita` (`idCita`),
  CONSTRAINT `detalletratamiento_ibfk_2` FOREIGN KEY (`idTratamiento`) REFERENCES `tratamiento` (`idTratamiento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `detalletratamiento`
--

LOCK TABLES `detalletratamiento` WRITE;
/*!40000 ALTER TABLE `detalletratamiento` DISABLE KEYS */;
/*!40000 ALTER TABLE `detalletratamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `odontologo`
--

DROP TABLE IF EXISTS `odontologo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `odontologo` (
  `idOdontologo` int NOT NULL AUTO_INCREMENT,
  `idPersona` int NOT NULL,
  `puntuacionPromedio` double DEFAULT '0',
  `especialidad` enum('ODONTOLOGIA_GENERAL','ORTODONCIA','ENDODONCIA','CIRUGIA','PEDIATRIA') NOT NULL,
  `idSala` int DEFAULT NULL,
  PRIMARY KEY (`idOdontologo`),
  KEY `idSala` (`idSala`),
  CONSTRAINT `odontologo_ibfk_1` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`),
  CONSTRAINT `odontologo_ibfk_3` FOREIGN KEY (`idSala`) REFERENCES `sala` (`idSala`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `odontologo`
--

LOCK TABLES `odontologo` WRITE;
/*!40000 ALTER TABLE `odontologo` DISABLE KEYS */;
/*!40000 ALTER TABLE `odontologo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `odontologo_turno`
--

DROP TABLE IF EXISTS `odontologo_turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `odontologo_turno` (
  `idOdontologo` int NOT NULL,
  `idTurno` int NOT NULL,
  PRIMARY KEY (`idOdontologo`,`idTurno`),
  KEY `idTurno` (`idTurno`),
  CONSTRAINT `odontologo_turno_ibfk_1` FOREIGN KEY (`idOdontologo`) REFERENCES `odontologo` (`idOdontologo`),
  CONSTRAINT `odontologo_turno_ibfk_2` FOREIGN KEY (`idTurno`) REFERENCES `turno` (`idTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `odontologo_turno`
--

LOCK TABLES `odontologo_turno` WRITE;
/*!40000 ALTER TABLE `odontologo_turno` DISABLE KEYS */;
/*!40000 ALTER TABLE `odontologo_turno` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `paciente`
--

DROP TABLE IF EXISTS `paciente`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `paciente` (
  `idPaciente` int NOT NULL AUTO_INCREMENT,
  `idPersona` int NOT NULL,
  PRIMARY KEY (`idPaciente`),
  CONSTRAINT `paciente_ibfk_1` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paciente`
--

LOCK TABLES `paciente` WRITE;
/*!40000 ALTER TABLE `paciente` DISABLE KEYS */;
/*!40000 ALTER TABLE `paciente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoUsuario`
--
DROP TABLE IF EXISTS `tipoUsuario`;
CREATE TABLE `tipoUsuario`(
  `idTipo` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`idTipo`)
)

--
-- Table structure for table `persona`
--

DROP TABLE IF EXISTS `persona`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `persona` (
  `idPersona` int NOT NULL AUTO_INCREMENT,
  `contrasenha` varchar(100) NOT NULL,
  `nombreUsuario` varchar(100) NOT NULL,
  `correo` varchar(100) NOT NULL,
  `telefono` varchar(100) NOT NULL,
  `nombre` varchar(100) NOT NULL,
  `apellidos` varchar(100) NOT NULL,
  `DNI` varchar(15) NOT NULL,
  `tipoUsuario` int NOT NULL,
  PRIMARY KEY (`idPersona`),
  CONSTRAINT `tipoUsuario_ibfk_1` FOREIGN KEY (`idTipo`) REFERENCES `tipoUsuario` (`idTipo`),
  UNIQUE KEY `DNI` (`DNI`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `persona`
--

LOCK TABLES `persona` WRITE;
/*!40000 ALTER TABLE `persona` DISABLE KEYS */;
/*!40000 ALTER TABLE `persona` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcionista`
--

DROP TABLE IF EXISTS `recepcionista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcionista` (
  `idRecepcionista` int NOT NULL AUTO_INCREMENT,
  `idPersona` int NOT NULL,
  PRIMARY KEY (`idRecepcionista`),
  CONSTRAINT `recepcionista_ibfk_1` FOREIGN KEY (`idPersona`) REFERENCES `persona` (`idPersona`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcionista`
--

LOCK TABLES `recepcionista` WRITE;
/*!40000 ALTER TABLE `recepcionista` DISABLE KEYS */;
/*!40000 ALTER TABLE `recepcionista` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sala`
--

DROP TABLE IF EXISTS `sala`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `sala` (
  `idSala` int NOT NULL AUTO_INCREMENT,
  `numeroSala` varchar(10) NOT NULL,
  `piso` int NOT NULL,
  PRIMARY KEY (`idSala`),
  UNIQUE KEY `numeroSala` (`numeroSala`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala`
--

LOCK TABLES `sala` WRITE;
/*!40000 ALTER TABLE `sala` DISABLE KEYS */;
/*!40000 ALTER TABLE `sala` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tratamiento`
--

DROP TABLE IF EXISTS `tratamiento`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tratamiento` (
  `idTratamiento` int NOT NULL AUTO_INCREMENT,
  `nombre` varchar(100) NOT NULL,
  `descripcion` text,
  `costo` double NOT NULL,
  PRIMARY KEY (`idTratamiento`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tratamiento`
--

LOCK TABLES `tratamiento` WRITE;
/*!40000 ALTER TABLE `tratamiento` DISABLE KEYS */;
/*!40000 ALTER TABLE `tratamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `turno`
--

DROP TABLE IF EXISTS `turno`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `turno` (
  `idTurno` int NOT NULL AUTO_INCREMENT,
  `horaInicio` time NOT NULL,
  `horaFin` time NOT NULL,
  `diaSemana` enum('LUNES','MARTES','MIERCOLES','JUEVES','VIERNES','SABADO') NOT NULL,
  PRIMARY KEY (`idTurno`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;
