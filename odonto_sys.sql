CREATE DATABASE  IF NOT EXISTS `odonto_sys` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `odonto_sys`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: odonto_sys
-- ------------------------------------------------------
-- Server version	8.0.42

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
  CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`idPaciente`) REFERENCES `paciente` (`idPaciente`),
  CONSTRAINT `cita_ibfk_2` FOREIGN KEY (`idOdontologo`) REFERENCES `odontologo` (`idOdontologo`),
  CONSTRAINT `cita_ibfk_3` FOREIGN KEY (`idComprobante`) REFERENCES `comprobante` (`idComprobante`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cita`
--

LOCK TABLES `cita` WRITE;
/*!40000 ALTER TABLE `cita` DISABLE KEYS */;
INSERT INTO `cita` VALUES (1,1,1,1,'2025-05-13','21:26:52',2,'RESERVADA');
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
  `horaEmision` time DEFAULT NULL,
  `idMetodoPago` int DEFAULT NULL,
  PRIMARY KEY (`idComprobante`),
  KEY `comprobante_ibfk_1` (`idMetodoPago`),
  CONSTRAINT `comprobante_ibfk_1` FOREIGN KEY (`idMetodoPago`) REFERENCES `metodopago` (`idMetodoPago`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `comprobante`
--

LOCK TABLES `comprobante` WRITE;
/*!40000 ALTER TABLE `comprobante` DISABLE KEYS */;
INSERT INTO `comprobante` VALUES (1,'2001-12-02',0,NULL,NULL);
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
INSERT INTO `detalletratamiento` VALUES (1,1,20,400);
/*!40000 ALTER TABLE `detalletratamiento` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `especialidad`
--

DROP TABLE IF EXISTS `especialidad`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `especialidad` (
  `idEspecialidad` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idEspecialidad`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `especialidad`
--

LOCK TABLES `especialidad` WRITE;
/*!40000 ALTER TABLE `especialidad` DISABLE KEYS */;
/*!40000 ALTER TABLE `especialidad` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `metodopago`
--

DROP TABLE IF EXISTS `metodopago`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `metodopago` (
  `idMetodoPago` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idMetodoPago`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `metodopago`
--

LOCK TABLES `metodopago` WRITE;
/*!40000 ALTER TABLE `metodopago` DISABLE KEYS */;
/*!40000 ALTER TABLE `metodopago` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `odontologo`
--

DROP TABLE IF EXISTS `odontologo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `odontologo` (
  `idOdontologo` int NOT NULL AUTO_INCREMENT,
  `puntuacionPromedio` double DEFAULT '0',
  `idSala` int DEFAULT NULL,
  `contrasenha` varchar(50) DEFAULT NULL,
  `nombreUsuario` varchar(100) DEFAULT NULL,
  `correo` varchar(100) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidos` varchar(50) DEFAULT NULL,
  `DNI` varchar(10) DEFAULT NULL,
  `idEspecialidad` int DEFAULT NULL,
  PRIMARY KEY (`idOdontologo`),
  KEY `idSala` (`idSala`),
  KEY `odontologo_ibfk_1` (`idEspecialidad`),
  CONSTRAINT `odontologo_ibfk_1` FOREIGN KEY (`idEspecialidad`) REFERENCES `especialidad` (`idEspecialidad`),
  CONSTRAINT `odontologo_ibfk_3` FOREIGN KEY (`idSala`) REFERENCES `sala` (`idSala`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `odontologo`
--

LOCK TABLES `odontologo` WRITE;
/*!40000 ALTER TABLE `odontologo` DISABLE KEYS */;
INSERT INTO `odontologo` VALUES (1,3.2,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
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
  `contrasenha` varchar(50) DEFAULT NULL,
  `nombreUsuario` UNIQUE varchar(100) DEFAULT NULL,
  `correo`  varchar(100) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidos` varchar(50) DEFAULT NULL,
  `DNI` UNIQUE varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idPaciente`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `paciente`
--

LOCK TABLES `paciente` WRITE;
/*!40000 ALTER TABLE `paciente` DISABLE KEYS */;
INSERT INTO `paciente` VALUES (1,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
/*!40000 ALTER TABLE `paciente` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recepcionista`
--

DROP TABLE IF EXISTS `recepcionista`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `recepcionista` (
  `idRecepcionista` int NOT NULL AUTO_INCREMENT,
  `contrasenha` varchar(50) DEFAULT NULL,
  `nombreUsuario` UNIQUE varchar(100) DEFAULT NULL,
  `correo` UNIQUE varchar(100) DEFAULT NULL,
  `telefono` varchar(10) DEFAULT NULL,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidos` varchar(50) DEFAULT NULL,
  `DNI` UNIQUE varchar(10) DEFAULT NULL,
  PRIMARY KEY (`idRecepcionista`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recepcionista`
--

LOCK TABLES `recepcionista` WRITE;
/*!40000 ALTER TABLE `recepcionista` DISABLE KEYS */;
INSERT INTO `recepcionista` VALUES (1,NULL,NULL,NULL,NULL,NULL,NULL,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sala`
--

LOCK TABLES `sala` WRITE;
/*!40000 ALTER TABLE `sala` DISABLE KEYS */;
INSERT INTO `sala` VALUES (1,'2',3);
/*!40000 ALTER TABLE `sala` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipousuario`
--

DROP TABLE IF EXISTS `tipousuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipousuario` (
  `idTipo` int NOT NULL AUTO_INCREMENT,
  `descripcion` varchar(100) NOT NULL,
  PRIMARY KEY (`idTipo`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipousuario`
--

LOCK TABLES `tipousuario` WRITE;
/*!40000 ALTER TABLE `tipousuario` DISABLE KEYS */;
INSERT INTO `tipousuario` VALUES (1,'PACIENTE'),(2,'ODONTOLOGO'),(3,'RECEPCIONISTA'),(4,'ADMINISTRADOR');
/*!40000 ALTER TABLE `tipousuario` ENABLE KEYS */;
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
  `especialidad` enum('ODONTOLOGIA_GENERAL','ORTODONCIA','ENDODONCIA','CIRUGIA','PEDIATRIA') DEFAULT NULL,
  PRIMARY KEY (`idTratamiento`),
  UNIQUE KEY `nombre` (`nombre`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tratamiento`
--

LOCK TABLES `tratamiento` WRITE;
/*!40000 ALTER TABLE `tratamiento` DISABLE KEYS */;
INSERT INTO `tratamiento` VALUES (1,'Endodoncia','Taladro en tu diente',5000,'PEDIATRIA');
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
  `diaSemana` enum('MONDAY','TUESDAY','WEDNESDAY','THURSDAY','FRIDAY','SATURDAY','SUNDAY') NOT NULL,
  PRIMARY KEY (`idTurno`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `turno`
--

LOCK TABLES `turno` WRITE;
/*!40000 ALTER TABLE `turno` DISABLE KEYS */;
INSERT INTO `turno` VALUES (1,'00:24:45','00:24:45','JUEVES');
/*!40000 ALTER TABLE `turno` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-05-29 19:54:47
