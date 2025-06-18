CREATE DATABASE  IF NOT EXISTS `ODONTO_SYS` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `ODONTO_SYS`;
-- MySQL dump 10.13  Distrib 8.0.42, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: ODONTO_SYS
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
-- Table structure for table `OS_CITAS`
--

DROP TABLE IF EXISTS `OS_CITAS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_CITAS` (
  `CITA_ID` int NOT NULL AUTO_INCREMENT,
  `PACIENTE_ID` int NOT NULL,
  `RECEPCIONISTA_ID` int DEFAULT NULL,
  `ODONTOLOGO_ID` int NOT NULL,
  `COMPROBANTE_ID` int DEFAULT NULL,
  `FECHA` date NOT NULL,
  `HORA_INICIO` time NOT NULL,
  `VALORACION_ID` int DEFAULT NULL,
  `ESTADO` enum('RESERVADA','ATENDIDA','CANCELADA','PAGO_CANCELADO') NOT NULL,
  PRIMARY KEY (`CITA_ID`),
  KEY `PACIENTE_ID` (`PACIENTE_ID`),
  KEY `RECEPCIONISTA_ID` (`RECEPCIONISTA_ID`),
  KEY `ODONTOLOGO_ID` (`ODONTOLOGO_ID`),
  KEY `COMPROBANTE_ID` (`COMPROBANTE_ID`),
  KEY `VALORACION_ID` (`VALORACION_ID`),
  CONSTRAINT `cita_ibfk_1` FOREIGN KEY (`PACIENTE_ID`) REFERENCES `OS_PACIENTES` (`PACIENTE_ID`),
  CONSTRAINT `cita_ibfk_2` FOREIGN KEY (`RECEPCIONISTA_ID`) REFERENCES `OS_RECEPCIONISTAS` (`RECEPCIONISTA_ID`),
  CONSTRAINT `cita_ibfk_3` FOREIGN KEY (`ODONTOLOGO_ID`) REFERENCES `OS_ODONTOLOGOS` (`ODONTOLOGO_ID`),
  CONSTRAINT `cita_ibfk_4` FOREIGN KEY (`COMPROBANTE_ID`) REFERENCES `OS_COMPROBANTES` (`COMPROBANTE_ID`),
  CONSTRAINT `cita_ibfk_5` FOREIGN KEY (`VALORACION_ID`) REFERENCES `OS_VALORACIONES` (`VALORACION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_CITAS`
--

LOCK TABLES `OS_CITAS` WRITE;
/*!40000 ALTER TABLE `OS_CITAS` DISABLE KEYS */;
/*!40000 ALTER TABLE `OS_CITAS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_COMPROBANTES`
--

DROP TABLE IF EXISTS `OS_COMPROBANTES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_COMPROBANTES` (
  `COMPROBANTE_ID` int NOT NULL AUTO_INCREMENT,
  `FECHA_EMISION` date NOT NULL,
  `TOTAL` double NOT NULL,
  `HORA_EMISION` time DEFAULT NULL,
  `METODO_PAGO_ID` int DEFAULT NULL,
  PRIMARY KEY (`COMPROBANTE_ID`),
  KEY `comprobante_ibfk_1` (`METODO_PAGO_ID`),
  CONSTRAINT `comprobante_ibfk_1` FOREIGN KEY (`METODO_PAGO_ID`) REFERENCES `OS_METODOS_PAGOS` (`METODO_PAGO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_COMPROBANTES`
--

LOCK TABLES `OS_COMPROBANTES` WRITE;
/*!40000 ALTER TABLE `OS_COMPROBANTES` DISABLE KEYS */;
/*!40000 ALTER TABLE `OS_COMPROBANTES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_DETALLES_TRATAMIENTOS`
--

DROP TABLE IF EXISTS `OS_DETALLES_TRATAMIENTOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_DETALLES_TRATAMIENTOS` (
  `CITA_ID` int NOT NULL,
  `TRATAMIENTO_ID` int NOT NULL,
  `CANTIDAD` int NOT NULL DEFAULT '1',
  `SUBTOTAL` double NOT NULL,
  PRIMARY KEY (`CITA_ID`,`TRATAMIENTO_ID`),
  KEY `TRATAMIENTO_ID` (`TRATAMIENTO_ID`),
  CONSTRAINT `detalletratamiento_ibfk_1` FOREIGN KEY (`CITA_ID`) REFERENCES `OS_CITAS` (`CITA_ID`),
  CONSTRAINT `detalletratamiento_ibfk_2` FOREIGN KEY (`TRATAMIENTO_ID`) REFERENCES `OS_TRATAMIENTOS` (`TRATAMIENTO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_DETALLES_TRATAMIENTOS`
--

LOCK TABLES `OS_DETALLES_TRATAMIENTOS` WRITE;
/*!40000 ALTER TABLE `OS_DETALLES_TRATAMIENTOS` DISABLE KEYS */;
/*!40000 ALTER TABLE `OS_DETALLES_TRATAMIENTOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_ESPECIALIDADES`
--

DROP TABLE IF EXISTS `OS_ESPECIALIDADES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_ESPECIALIDADES` (
  `ESPECIALIDAD_ID` int NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`ESPECIALIDAD_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_ESPECIALIDADES`
--

LOCK TABLES `OS_ESPECIALIDADES` WRITE;
/*!40000 ALTER TABLE `OS_ESPECIALIDADES` DISABLE KEYS */;
-- Insertar las especialidades dentales principales en la tabla para que las tablas que la requieran puedan asociarse a ellas
INSERT INTO `OS_ESPECIALIDADES` (`DESCRIPCION`) VALUES  
('ODONTOLOGIA_GENERAL'),
('ORTODONCIA'),
('ENDODONCIA'),
('CIRUGIA'),
('PEDIATRIA');
/*!40000 ALTER TABLE `OS_ESPECIALIDADES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_METODOS_PAGOS`
--

DROP TABLE IF EXISTS `OS_METODOS_PAGOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_METODOS_PAGOS` (
  `METODO_PAGO_ID` int NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`METODO_PAGO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_METODOS_PAGOS`
--

LOCK TABLES `OS_METODOS_PAGOS` WRITE;
/*!40000 ALTER TABLE `OS_METODOS_PAGOS` DISABLE KEYS */;
-- Insertar metodos de pago disponibles para transacciones.
INSERT INTO `OS_METODOS_PAGOS` (`DESCRIPCION`) VALUES
  ('EFECTIVO'),
  ('TARJETA'),
  ('TRANSFERENCIA'),
  ('YAPE'),
  ('PLIN');
/*!40000 ALTER TABLE `OS_METODOS_PAGOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_ODONTOLOGOS`
--

DROP TABLE IF EXISTS `OS_ODONTOLOGOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_ODONTOLOGOS` (
  `ODONTOLOGO_ID` int NOT NULL AUTO_INCREMENT,
  `PUNTUACION_PROMEDIO` double DEFAULT '0',
  `SALA_ID` int DEFAULT NULL,
  `CONTRASENHA` text DEFAULT NULL,
  `NOMBRE_USUARIO` varchar(100) DEFAULT NULL,
  `CORREO` varchar(100) DEFAULT NULL,
  `TELEFONO` varchar(10) DEFAULT NULL,
  `NOMBRES` varchar(50) DEFAULT NULL,
  `APELLIDOS` varchar(50) DEFAULT NULL,
  `TIPO_DOCUMENTO_ID` int NOT NULL,
  `NUMERO_DOCUMENTO_IDENTIDAD` varchar(12) DEFAULT NULL,
  `ESPECIALIDAD_ID` int DEFAULT NULL,
  PRIMARY KEY (`ODONTOLOGO_ID`),
  KEY `SALA_ID` (`SALA_ID`),
  KEY `TIPO_DOCUMENTO_ID` (`TIPO_DOCUMENTO_ID`),
  KEY `ESPECIALIDAD_ID` (`ESPECIALIDAD_ID`),
  CONSTRAINT `odontologo_ibfk_1` FOREIGN KEY (`ESPECIALIDAD_ID`) REFERENCES `OS_ESPECIALIDADES` (`ESPECIALIDAD_ID`),
  CONSTRAINT `odontologo_ibfk_2` FOREIGN KEY (`TIPO_DOCUMENTO_ID`) REFERENCES `OS_TIPOS_DOCUMENTOS` (`TIPO_DOCUMENTO_ID`),
  CONSTRAINT `odontologo_ibfk_3` FOREIGN KEY (`SALA_ID`) REFERENCES `OS_SALAS` (`SALA_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_ODONTOLOGOS`
--

LOCK TABLES `OS_ODONTOLOGOS` WRITE;
/*!40000 ALTER TABLE `OS_ODONTOLOGOS` DISABLE KEYS */;
-- Insertar datos de odontologos activos.
INSERT INTO `OS_ODONTOLOGOS` (`PUNTUACION_PROMEDIO`, `SALA_ID`, `CONTRASENHA`, `NOMBRE_USUARIO`, `CORREO`, `TELEFONO`, `NOMBRES`, `APELLIDOS`, `TIPO_DOCUMENTO_ID`, `NUMERO_DOCUMENTO_IDENTIDAD`, `ESPECIALIDAD_ID`) VALUES
-- 2 odontologos para ODONTOLOGIA GENERAL (ESPECIALIDAD_ID = 1)
(0,  1, 'fcb99c4cdcda82fa84aeb196dc9663edc570e99c31e70529541b3309d18c0683',   'ogeneral_juanp',   'juan.perez@odontosys.com',    '987654001', 'Juan',  'Pérez Gómez',    1, '52345678', 1),
(0,  2, 'a9402f22e6f60f51d6367c58dbdce411cb796553202152d0b9650b936a2273a4',   'ogeneral_marial',  'maria.lopez@odontosys.com',   '987654002', 'María', 'López Aliaga',    1, '87654321', 1),

-- 2 odontologos para ORTODONCIA (ESPECIALIDAD_ID = 2)
(0,  3, '9b3706a899c55f7e6df8590934c9191774d853172fd6297e726be8df0d25e7f9',    'ortodojas1',       'jose.alfaro@odontosys.com',    '987654011', 'José',  'Alfaro Corvetto',   1, '71223344', 2),
(0,  5, 'c73e7060d7a406bb6e6bc1ec23b5679a72320630b46e5df1b838832c8316d8ba',    'ortodona2',        'ana.guzman@odontosys.com',     '987654012', 'Ana',   'Guzmán Medina',   1, '44332211', 2),

-- 1 odontologo para ENDODONCIA (ESPECIALIDAD_ID = 3)
(0,  6, '5d86c7acf18d5213a94860bd3510e5c8b223e0c7294d6188566ff27b58441c3c',    'endodon_diego',    'diego.ramos@odontosys.com',    '987654021', 'Diego', 'Ramos García',    1, '55667788', 3),

-- 1 odontologo para CIRUGIA (ESPECIALIDAD_ID = 4)
(0,  7, 'eb00167bc474e07633db17fdacf7b18173adc5d6c74811bd033950fb3de6a8af',    'cirugia_carla',    'carla.sanchez@odontosys.com',  '987654031', 'Carla', 'Sánchez Montenegro',  1, '88776655', 4),

-- 1 odontologo para PEDIATRIA (ESPECIALIDAD_ID = 5)
(0,  4, '089f3572306aba72914eddfcc4dea0324477304e23c3537121cf21854af20b36',     'pediatra_luis',    'luis.morales@odontosys.com',   '987654041', 'Luis',  'Morales Mendoza',  1, '99887766', 5);

/*!40000 ALTER TABLE `OS_ODONTOLOGOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_PACIENTES`
--

DROP TABLE IF EXISTS `OS_PACIENTES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_PACIENTES` (
  `PACIENTE_ID` int NOT NULL AUTO_INCREMENT,
  `CONTRASENHA` text DEFAULT NULL,
  `NOMBRE_USUARIO` varchar(100) DEFAULT NULL,
  `CORREO` varchar(100) DEFAULT NULL,
  `TELEFONO` varchar(10) DEFAULT NULL,
  `NOMBRES` varchar(50) DEFAULT NULL,
  `APELLIDOS` varchar(50) DEFAULT NULL,
  `TIPO_DOCUMENTO_ID` int NOT NULL,
  `NUMERO_DOCUMENTO_IDENTIDAD` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`PACIENTE_ID`),
  UNIQUE KEY `NOMBRE_USUARIO` (`NOMBRE_USUARIO`),
  UNIQUE KEY `NUMERO_DOCUMENTO_IDENTIDAD` (`NUMERO_DOCUMENTO_IDENTIDAD`),
  KEY `TIPO_DOCUMENTO_ID` (`TIPO_DOCUMENTO_ID`),
  CONSTRAINT `paciente_ibfk_1` FOREIGN KEY (`TIPO_DOCUMENTO_ID`) REFERENCES `OS_TIPOS_DOCUMENTOS` (`TIPO_DOCUMENTO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_PACIENTES`
--

LOCK TABLES `OS_PACIENTES` WRITE;
/*!40000 ALTER TABLE `OS_PACIENTES` DISABLE KEYS */;
/*!40000 ALTER TABLE `OS_PACIENTES` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_RECEPCIONISTAS`
--

DROP TABLE IF EXISTS `OS_RECEPCIONISTAS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_RECEPCIONISTAS` (
  `RECEPCIONISTA_ID` int NOT NULL AUTO_INCREMENT,
  `CONTRASENHA` text DEFAULT NULL,
  `NOMBRE_USUARIO` varchar(100) DEFAULT NULL,
  `CORREO` varchar(100) DEFAULT NULL,
  `TELEFONO` varchar(10) DEFAULT NULL,
  `NOMBRES` varchar(50) DEFAULT NULL,
  `APELLIDOS` varchar(50) DEFAULT NULL,
  `TIPO_DOCUMENTO_ID` int NOT NULL,
  `NUMERO_DOCUMENTO_IDENTIDAD` varchar(12) DEFAULT NULL,
  PRIMARY KEY (`RECEPCIONISTA_ID`),
  UNIQUE KEY `NOMBRE_USUARIO` (`NOMBRE_USUARIO`),
  UNIQUE KEY `CORREO` (`CORREO`),
  UNIQUE KEY `TELEFONO` (`TELEFONO`),
  UNIQUE KEY `NUMERO_DOCUMENTO_IDENTIDAD` (`NUMERO_DOCUMENTO_IDENTIDAD`),
  KEY `TIPO_DOCUMENTO_ID` (`TIPO_DOCUMENTO_ID`),
  CONSTRAINT `recepcionista_ibfk_1` FOREIGN KEY (`TIPO_DOCUMENTO_ID`) REFERENCES `OS_TIPOS_DOCUMENTOS` (`TIPO_DOCUMENTO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_RECEPCIONISTAS`
--

LOCK TABLES `OS_RECEPCIONISTAS` WRITE;
/*!40000 ALTER TABLE `OS_RECEPCIONISTAS` DISABLE KEYS */;
-- Insertar un recepcionista por defecto para asignar a las citas que los pacientes reservan desde la web y no son gestionadas por un recepcionista real
INSERT INTO `OS_RECEPCIONISTAS` (`CONTRASENHA`, `NOMBRE_USUARIO`, `CORREO`, `TELEFONO`, `NOMBRES`, `APELLIDOS`, `TIPO_DOCUMENTO_ID`, `NUMERO_DOCUMENTO_IDENTIDAD`) VALUES
('Contrasenha123', 'default', 'r.default@gmail.com', '999999999', 'Recepcionista', 'Default', 1, '12345678'),
('bd90e96a1bc1ccc5001e268d298835b77bd6c055df15dd16fac79304eec34079', 'giancarlo.carrillo', 'giancarlo.carrillo@gmail.com', '981234567', 'Giancarlo', 'Carrillo Aquise', 1, '45678901'),
('91fa43dd10a589b847de65f63e2533fa508389a9661e3357a6de95ea738ba918',  'fiorela.herrera',  'fiorela.herrera@gmail.com',  '982345678', 'Fiorela',   'Herrera Torres',   1, '56789012');
/*!40000 ALTER TABLE `OS_RECEPCIONISTAS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_SALAS`
--

DROP TABLE IF EXISTS `OS_SALAS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_SALAS` (
  `SALA_ID` int NOT NULL AUTO_INCREMENT,
  `NUMERO_SALA` varchar(10) NOT NULL,
  `PISO` int NOT NULL,
  PRIMARY KEY (`SALA_ID`),
  UNIQUE KEY `NUMERO_SALA` (`NUMERO_SALA`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_SALAS`
--

LOCK TABLES `OS_SALAS` WRITE;
/*!40000 ALTER TABLE `OS_SALAS` DISABLE KEYS */;
-- Salas de atencion disponibles para atención
INSERT INTO `OS_SALAS` (`NUMERO_SALA`, `PISO`) VALUES
  ('101-OG', 1),  -- Odontología General – Odontólogo 1
  ('102-OG', 1),  -- Odontología General – Odontólogo 2
  ('103-OR', 1),  -- Ortodoncia – Odontólogo 1
  ('104-PE', 1),  -- Pediatría (Infantil) – Odontólogo
  ('201-OR', 2),  -- Ortodoncia – Odontólogo 2
  ('202-EN', 2),  -- Endodoncia – Odontólogo
  ('203-CI', 2);  -- Cirugía – Odontólogo
/*!40000 ALTER TABLE `OS_SALAS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_TIPOS_DOCUMENTOS`
--

DROP TABLE IF EXISTS `OS_TIPOS_DOCUMENTOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_TIPOS_DOCUMENTOS` (
  `TIPO_DOCUMENTO_ID` int NOT NULL AUTO_INCREMENT,
  `DESCRIPCION` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`TIPO_DOCUMENTO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_TIPOS_DOCUMENTOS`
--

LOCK TABLES `OS_TIPOS_DOCUMENTOS` WRITE;
/*!40000 ALTER TABLE `OS_TIPOS_DOCUMENTOS` DISABLE KEYS */;
-- Insertar tipos de documentos válidos para pacientes, odontólogos y recepcionistas
INSERT INTO `OS_TIPOS_DOCUMENTOS` (`DESCRIPCION`) VALUES
  ('DNI'),
  ('CARNE_DE_EXTRANJERIA');
/*!40000 ALTER TABLE `OS_TIPOS_DOCUMENTOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_TRATAMIENTOS`
--

DROP TABLE IF EXISTS `OS_TRATAMIENTOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_TRATAMIENTOS` (
  `TRATAMIENTO_ID` int NOT NULL AUTO_INCREMENT,
  `NOMBRE` varchar(100) NOT NULL,
  `DESCRIPCION` text,
  `COSTO` double NOT NULL,
  `ESPECIALIDAD_ID` int NOT NULL,
  PRIMARY KEY (`TRATAMIENTO_ID`),
  UNIQUE KEY `NOMBRE` (`NOMBRE`),
  KEY `tratamiento_ibfk_1` (`ESPECIALIDAD_ID`),
  CONSTRAINT `tratamiento_ibfk_1` FOREIGN KEY (`ESPECIALIDAD_ID`) REFERENCES `OS_ESPECIALIDADES` (`ESPECIALIDAD_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_TRATAMIENTOS`
--

LOCK TABLES `OS_TRATAMIENTOS` WRITE;
/*!40000 ALTER TABLE `OS_TRATAMIENTOS` DISABLE KEYS */;
-- Insertar lista completa de tratamientos disponibles
INSERT INTO `OS_TRATAMIENTOS` (`NOMBRE`, `DESCRIPCION`, `COSTO`, `ESPECIALIDAD_ID`) VALUES
  -- ODONTOLOGÍA GENERAL (ESPECIALIDAD_ID = 1)
  ('Limpieza Dental',                  'Limpieza y profilaxis básica de placa y sarro',        120, 1),
  ('Profilaxis Profunda',              'Eliminación avanzada de sarro y pulido dental',        180, 1),
  ('Sellado de Surcos',                'Aplicación de sellantes para prevenir caries',         150, 1),
  ('Obturación (Empaste)',            'Relleno de cavidades con material compuesto',           200, 1),
  ('Radiografía Intraoral',            'Toma de radiografía para diagnóstico de caries',         80, 1),
  ('Examen Dental Completo',           'Revisión general de boca con detección de patologías',  100, 1),
  ('Aplicación de Fluor',              'Aplicación de flúor tópico para fortalecer esmalte',    90, 1),

  -- ORTODONCIA (ESPECIALIDAD_ID = 2)
  ('Frenillos Metálicos',              'Colocación de brackets metálicos para corrección',      2000, 2),
  ('Frenillos Cerámicos',              'Brackets cerámicos estéticos para ortodoncia',          2500, 2),
  ('Frenillos Linguales',              'Brackets colocados en cara lingual (interna)',          3000, 2),
  ('Alineadores Transparentes',        'Sistema de férulas invisibles para mover dientes',      3500, 2),
  ('Retenedor Fijo',                   'Dispositivo fijo para mantener posición dental',         800, 2),
  ('Retenedor Removible',              'Placa removible para conservar alineación dental',       600, 2),
  ('Expansor Palatal',                 'Aparato para ensanchar el paladar y corregir mordida',  1800, 2),

  -- ENDODONCIA (ESPECIALIDAD_ID = 3)
  ('Tratamiento de Conducto',          'Desvitalización y sellado de conductos radiculares',    500, 3),
  ('Retratamiento Endodóntico',        'Reapertura y retratamiento de conductos infectados',    650, 3),
  ('Apicoformación',                   'Procedimiento para cerrar ápice en dientes inmaduros',  700, 3),
  ('Tratamiento Pulpar Directo',       'Protección pulpar con apósito biocerámico',             450, 3),
  ('Obturación de Canal',              'Sellado final de canal radicular con gutapercha',       550, 3),
  ('Biopulpectomía Infantil',          'Desvitalización parcial en dientes de leche',           480, 3),
  ('Curetaje Pulpar',                  'Limpieza profunda de tejido pulpar necrosado',           600, 3),

  -- CIRUGÍA (ESPECIALIDAD_ID = 4)
  ('Extracción Simple',                'Remoción de diente con anestesia local',               300, 4),
  ('Extracción Quirúrgica',            'Remoción de muela del juicio o pieza impactada',        500, 4),
  ('Injerto Óseo',                     'Colocación de injerto para regeneración ósea',         1500, 4),
  ('Biopsia Oral',                     'Toma de muestra de tejido para estudio patológico',      800, 4),
  ('Alargamiento Coronario',           'Exposición de más corona clínica para restauración',    900, 4),
  ('Cirugía Periodontal',              'Tratamiento quirúrgico de encías y hueso alveolar',     1200, 4),
  ('Remoción de Quistes Maxilares',     'Extirpación de quiste en maxilar o mandíbula',          1100, 4),

  -- PEDIATRÍA (INFANTIL) (ESPECIALIDAD_ID = 5)
  ('Aplicación de Flúor Infantil',     'Flúor tópico en niños para prevenir caries',           100, 5),
  ('Limpieza Dental Infantil',          'Profilaxis adaptada a la dentición infantil',          120, 5),
  ('Sellado de Surcos Infantil',        'Sellantes para molares de niños para prevenir caries', 150, 5),
  ('Examen de Caries Infantil',         'Detección temprana de caries en dentición primaria',    110, 5),
  ('Pulpectomía Infantil',              'Tratamiento de pulpa en dientes de leche con infección',550, 5),
  ('Obturación Infantil (Empaste)',     'Empaste de caries en dientes temporales',               130, 5),
  ('Sellado de Fisuras Infantil',       'Aplicación de resina selladora en molares infantiles',  140, 5);
/*!40000 ALTER TABLE `OS_TRATAMIENTOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_TURNOS`
--

DROP TABLE IF EXISTS `OS_TURNOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_TURNOS` (
  `TURNO_ID` int NOT NULL AUTO_INCREMENT,
  `HORA_INICIO` time NOT NULL,
  `HORA_FIN` time NOT NULL,
  `DIA_SEMANA` enum('MONDAY','TUESDAY','WEDNESDAY','THURSDAY','FRIDAY','SATURDAY','SUNDAY') NOT NULL,
  PRIMARY KEY (`TURNO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_TURNOS`
--

LOCK TABLES `OS_TURNOS` WRITE;
/*!40000 ALTER TABLE `OS_TURNOS` DISABLE KEYS */;
-- Insertar los turnos disponibles para cada día de la semana, indicando la hora de inicio, hora de fin y el día correspondiente
INSERT INTO `OS_TURNOS` (`HORA_INICIO`, `HORA_FIN`,  `DIA_SEMANA`) VALUES
  -- Lunes
  ('08:00:00', '12:00:00', 'MONDAY'),   -- 1: Lunes mañana
  ('14:00:00', '18:00:00', 'MONDAY'),   -- 2: Lunes tarde
  ('19:00:00', '21:00:00', 'MONDAY'),   -- 3: Lunes noche

  -- Martes
  ('08:00:00', '12:00:00', 'TUESDAY'),  -- 4: Martes mañana
  ('14:00:00', '18:00:00', 'TUESDAY'),  -- 5: Martes tarde
  ('19:00:00', '21:00:00', 'TUESDAY'),  -- 6: Martes noche

  -- Miércoles
  ('08:00:00', '12:00:00', 'WEDNESDAY'),-- 7: Miércoles mañana
  ('14:00:00', '18:00:00', 'WEDNESDAY'),-- 8: Miércoles tarde
  ('19:00:00', '21:00:00', 'WEDNESDAY'),-- 9: Miércoles noche

  -- Jueves
  ('08:00:00', '12:00:00', 'THURSDAY'), -- 10: Jueves mañana
  ('14:00:00', '18:00:00', 'THURSDAY'), -- 11: Jueves tarde
  ('19:00:00', '21:00:00', 'THURSDAY'), -- 12: Jueves noche

  -- Viernes
  ('08:00:00', '12:00:00', 'FRIDAY'),   -- 13: Viernes mañana
  ('14:00:00', '18:00:00', 'FRIDAY'),   -- 14: Viernes tarde
  ('19:00:00', '21:00:00', 'FRIDAY'),   -- 15: Viernes noche

  -- Sábado
  ('08:00:00', '12:00:00', 'SATURDAY'), -- 16: Sábado mañana
  ('14:00:00', '18:00:00', 'SATURDAY'), -- 17: Sábado tarde
  ('19:00:00', '21:00:00', 'SATURDAY'); -- 18: Sábado noche
/*!40000 ALTER TABLE `OS_TURNOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_TURNOS_POR_ODONTOLOGOS`
--

DROP TABLE IF EXISTS `OS_TURNOS_POR_ODONTOLOGOS`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_TURNOS_POR_ODONTOLOGOS` (
  `ODONTOLOGO_ID` int NOT NULL,
  `TURNO_ID` int NOT NULL,
  PRIMARY KEY (`ODONTOLOGO_ID`,`TURNO_ID`),
  KEY `TURNO_ID` (`TURNO_ID`),
  CONSTRAINT `odontologo_turno_ibfk_1` FOREIGN KEY (`ODONTOLOGO_ID`) REFERENCES `OS_ODONTOLOGOS` (`ODONTOLOGO_ID`),
  CONSTRAINT `odontologo_turno_ibfk_2` FOREIGN KEY (`TURNO_ID`) REFERENCES `OS_TURNOS` (`TURNO_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_TURNOS_POR_ODONTOLOGOS`
--

LOCK TABLES `OS_TURNOS_POR_ODONTOLOGOS` WRITE;
/*!40000 ALTER TABLE `OS_TURNOS_POR_ODONTOLOGOS` DISABLE KEYS */;
-- Asiganacion de turnos a odontologos
INSERT INTO `OS_TURNOS_POR_ODONTOLOGOS` (`ODONTOLOGO_ID`, `TURNO_ID`) VALUES
  -- Odontólogo 1 (Juan Pérez) – 5 días, con 2 días combinados (lunes y martes)
  (1,  1),  -- Lunes mañana
  (1,  2),  -- Lunes tarde (combinado con mañana)
  (1,  5),  -- Martes tarde
  (1,  6),  -- Martes noche (combinado con tarde)
  (1,  7),  -- Miércoles mañana
  (1, 11),  -- Jueves tarde
  (1, 13),  -- Viernes mañana

  -- Odontólogo 2 (María López) – 4 días, con 2 días combinados (martes y sábado)
  (2,  4),  -- Martes mañana
  (2,  5),  -- Martes tarde (combinado con mañana)
  (2,  9),  -- Miércoles noche
  (2, 10),  -- Jueves mañana
  (2, 17),  -- Sábado tarde
  (2, 18),  -- Sábado noche (combinado con tarde)

  -- Odontólogo 3 (José Alfaro) – 4 días, con 2 días combinados (miércoles y viernes)
  (3,  3),  -- Lunes noche
  (3,  7),  -- Miércoles mañana
  (3,  8),  -- Miércoles tarde (combinado con mañana)
  (3, 14),  -- Viernes tarde
  (3, 15),  -- Viernes noche (combinado con tarde)
  (3, 16),  -- Sábado mañana

  -- Odontólogo 4 (Ana Guzmán) – 5 días, con 2 días combinados (martes y jueves)
  (4,  2),  -- Lunes tarde
  (4,  4),  -- Martes mañana
  (4,  5),  -- Martes tarde (combinado con mañana)
  (4,  9),  -- Miércoles noche
  (4, 11),  -- Jueves tarde
  (4, 12),  -- Jueves noche (combinado con tarde)
  (4, 14),  -- Viernes tarde

  -- Odontólogo 5 (Diego Ramos) – 4 días, con 2 días combinados (miércoles y viernes)
  (5,  4),  -- Martes mañana
  (5,  8),  -- Miércoles tarde
  (5,  9),  -- Miércoles noche (combinado con tarde)
  (5, 13),  -- Viernes mañana
  (5, 14),  -- Viernes tarde (combinado con mañana)
  (5, 17),  -- Sábado tarde

  -- Odontólogo 6 (Carla Sánchez) – 4 días, con 2 días combinados (jueves y sábado)
  (6,  1),  -- Lunes mañana
  (6,  6),  -- Martes noche
  (6, 10),  -- Jueves mañana
  (6, 11),  -- Jueves tarde (combinado con mañana)
  (6, 16),  -- Sábado mañana
  (6, 17),  -- Sábado tarde (combinado con mañana)

  -- Odontólogo 7 (Luis Morales) – 5 días, con 2 días combinados (lunes y viernes)
  (7,  2),  -- Lunes tarde
  (7,  3),  -- Lunes noche (combinado con tarde)
  (7,  7),  -- Miércoles mañana
  (7, 12),  -- Jueves noche
  (7, 14),  -- Viernes tarde
  (7, 15),  -- Viernes noche (combinado con tarde)
  (7, 18);  -- Sábado noche
/*!40000 ALTER TABLE `OS_TURNOS_POR_ODONTOLOGOS` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `OS_VALORACIONES`
--

DROP TABLE IF EXISTS `OS_VALORACIONES`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `OS_VALORACIONES` (
  `VALORACION_ID` int NOT NULL AUTO_INCREMENT,
  `COMENTARIO` text,
  `CALIFICACION` int NOT NULL,
  `FECHA` date NOT NULL,
  PRIMARY KEY (`VALORACION_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `OS_VALORACIONES`
--

LOCK TABLES `OS_VALORACIONES` WRITE;
/*!40000 ALTER TABLE `OS_VALORACIONES` DISABLE KEYS */;
/*!40000 ALTER TABLE `OS_VALORACIONES` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-06-05 22:57:12
