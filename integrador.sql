-- MySQL dump 10.13  Distrib 8.0.36, for Win64 (x86_64)
--
-- Host: localhost    Database: integrador
-- ------------------------------------------------------
-- Server version	8.0.37

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
-- Table structure for table `categoria`
--

DROP TABLE IF EXISTS `categoria`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categoria` (
  `IdCategoria` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `FechaCreacion` datetime DEFAULT NULL,
  `Estado` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`IdCategoria`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categoria`
--

LOCK TABLES `categoria` WRITE;
/*!40000 ALTER TABLE `categoria` DISABLE KEYS */;
INSERT INTO `categoria` VALUES (1,'Tecnología','2024-01-01 12:00:00','Activo'),(2,'Salud','2024-01-02 12:00:00','Activo'),(3,'Educación','2024-01-03 12:00:00','Activo'),(4,'Finanzas','2024-01-04 12:00:00','Activo'),(5,'Marketing','2024-01-05 12:00:00','Activo'),(6,'Ventas','2024-01-06 12:00:00','Activo'),(7,'Administración','2024-01-07 12:00:00','Activo'),(8,'Ingeniería','2024-01-08 12:00:00','Inactivo'),(9,'Recursos Humanos','2024-01-09 12:00:00','Activo'),(10,'Diseño','2024-01-10 12:00:00','Inactivo');
/*!40000 ALTER TABLE `categoria` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `empresa`
--

DROP TABLE IF EXISTS `empresa`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `empresa` (
  `IdEmpresa` int NOT NULL AUTO_INCREMENT,
  `NombreEmpresa` varchar(50) DEFAULT NULL,
  `Usuario` varchar(50) DEFAULT NULL,
  `Clave` varchar(50) DEFAULT NULL,
  `RUC` int DEFAULT NULL,
  `Direccion` varchar(50) DEFAULT NULL,
  `Telefono` int DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  `FraseSecreta` varchar(50) DEFAULT NULL,
  `NumeroTrabajadores` int DEFAULT NULL,
  `Estado` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`IdEmpresa`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `empresa`
--

LOCK TABLES `empresa` WRITE;
/*!40000 ALTER TABLE `empresa` DISABLE KEYS */;
INSERT INTO `empresa` VALUES (1,'Tech Solutions','usuario1','clave1',123456789,'Calle 1',987654321,'empresa1@example.com','frase1',50,'Activo'),(2,'Health Corp','usuario2','clave2',234567890,'Calle 2',876543210,'empresa2@example.com','frase2',100,'Inactivo'),(3,'Educa Pro','usuario3','clave3',345678901,'Calle 3',765432109,'empresa3@example.com','frase3',30,'Inactivo'),(4,'Finanz Asesores','usuario4','clave4',456789012,'Calle 4',654321098,'empresa4@example.com','frase4',75,'Inactivo'),(5,'Marketing Masters','usuario5','clave5',567890123,'Calle 5',543210987,'empresa5@example.com','frase5',60,'Inactivo'),(6,'Ventas Globales','usuario6','clave6',678901234,'Calle 6',432109876,'empresa6@example.com','frase6',45,'Activo'),(7,'Admin Experts','usuario7','clave7',789012345,'Calle 7',321098765,'empresa7@example.com','frase7',25,'Activo'),(8,'Ingeniería Creativa','usuario8','clave8',890123456,'Calle 8',210987654,'empresa8@example.com','frase8',40,'Activo'),(9,'HR Solutions','usuario9','clave9',901234567,'Calle 9',109876543,'empresa9@example.com','frase9',55,'Activo'),(10,'Diseño Innovador','usuario10','clave10',112345678,'Calle 10',198765432,'empresa10@example.com','frase10',20,'Inactivo'),(11,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,''),(12,'Nombre de la Empresa','usuario','clave',123456789,'Dirección de la Empresa',1234567890,'correo@empresa.com','Frase Secreta',50,'Inactivo');
/*!40000 ALTER TABLE `empresa` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `postulacion`
--

DROP TABLE IF EXISTS `postulacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `postulacion` (
  `IdPostulacion` int NOT NULL AUTO_INCREMENT,
  `IdUsuario` int DEFAULT NULL,
  `IdPublicacion` int DEFAULT NULL,
  `FechaCreacion` datetime DEFAULT NULL,
  `Estado` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`IdPostulacion`),
  KEY `IdUsuario` (`IdUsuario`),
  KEY `IdPublicacion` (`IdPublicacion`),
  CONSTRAINT `postulacion_ibfk_1` FOREIGN KEY (`IdUsuario`) REFERENCES `usuario` (`IdUsuario`),
  CONSTRAINT `postulacion_ibfk_2` FOREIGN KEY (`IdPublicacion`) REFERENCES `publicacion` (`IdPublicacion`)
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `postulacion`
--

LOCK TABLES `postulacion` WRITE;
/*!40000 ALTER TABLE `postulacion` DISABLE KEYS */;
INSERT INTO `postulacion` VALUES (1,1,1,'2024-01-01 12:00:00','Pendiente'),(2,2,2,'2024-01-02 12:00:00','Pendiente'),(3,3,3,'2024-01-03 12:00:00','Pendiente'),(4,4,4,'2024-01-04 12:00:00','Pendiente'),(5,5,5,'2024-01-05 12:00:00','Pendiente'),(6,6,6,'2024-01-06 12:00:00','Pendiente'),(7,7,7,'2024-01-07 12:00:00','Pendiente'),(8,8,8,'2024-01-08 12:00:00','Pendiente'),(9,9,9,'2024-01-09 12:00:00','Pendiente'),(10,10,10,'2024-01-10 12:00:00','Pendiente');
/*!40000 ALTER TABLE `postulacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `publicacion`
--

DROP TABLE IF EXISTS `publicacion`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `publicacion` (
  `IdPublicacion` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(50) DEFAULT NULL,
  `Descripcion` varchar(1000) DEFAULT NULL,
  `IdCategoria` int DEFAULT NULL,
  `Sueldo` decimal(10,2) DEFAULT NULL,
  `Ciudad` varchar(50) DEFAULT NULL,
  `Pais` varchar(50) DEFAULT NULL,
  `Provincia` varchar(50) DEFAULT NULL,
  `Direccion` varchar(50) DEFAULT NULL,
  `FechaCreacion` datetime DEFAULT NULL,
  `Estado` varchar(10) DEFAULT NULL,
  `IdEmpresa` int DEFAULT NULL,
  PRIMARY KEY (`IdPublicacion`),
  KEY `IdCategoria` (`IdCategoria`),
  KEY `IdEmpresa` (`IdEmpresa`),
  CONSTRAINT `publicacion_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categoria` (`IdCategoria`),
  CONSTRAINT `publicacion_ibfk_2` FOREIGN KEY (`IdEmpresa`) REFERENCES `empresa` (`IdEmpresa`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `publicacion`
--

LOCK TABLES `publicacion` WRITE;
/*!40000 ALTER TABLE `publicacion` DISABLE KEYS */;
INSERT INTO `publicacion` VALUES (1,'Desarrollador Web','Responsable del desarrollo y mantenimiento de aplicaciones web.',1,2500.00,'Ciudad 1','País 1','Provincia 1','Calle 1','2024-01-01 12:00:00','Activo',1),(2,'Enfermera','Proveer cuidados médicos y asistencia a pacientes.',2,1800.00,'Ciudad 2','País 2','Provincia 2','Calle 2','2024-01-02 12:00:00','Activo',2),(3,'Profesor de Matemáticas','Enseñar matemáticas a estudiantes de secundaria.',3,2000.00,'Ciudad 3','País 3','Provincia 3','Calle 3','2024-01-03 12:00:00','Activo',3),(4,'Contador','Manejo de cuentas y finanzas de la empresa.',4,2200.00,'Ciudad 4','País 4','Provincia 4','Calle 4','2024-01-04 12:00:00','Activo',4),(5,'Analista de Marketing','Desarrollar y ejecutar estrategias de marketing.',5,2400.00,'Ciudad 5','País 5','Provincia 5','Calle 5','2024-01-05 12:00:00','Activo',5),(6,'Vendedor','Vender productos y servicios de la empresa.',6,2100.00,'Ciudad 6','País 6','Provincia 6','Calle 6','2024-01-06 12:00:00','Activo',6),(7,'Administrador','Gestionar recursos y procesos administrativos.',7,2300.00,'Ciudad 7','País 7','Provincia 7','Calle 7','2024-01-07 12:00:00','Activo',7),(8,'Ingeniero Civil','Planificar y supervisar proyectos de construcción.',8,2600.00,'Ciudad 8','País 8','Provincia 8','Calle 8','2024-01-08 12:00:00','Activo',8),(9,'Especialista en Recursos Humanos','Gestionar el talento humano de la empresa.',9,2500.00,'Ciudad 9','País 9','Provincia 9','Calle 9','2024-01-09 12:00:00','Activo',9),(10,'Diseñador Gráfico','Crear conceptos visuales para comunicar ideas.',10,2400.00,'Ciudad 10','País 10','Provincia 10','Calle 10','2024-01-10 12:00:00','Activo',10);
/*!40000 ALTER TABLE `publicacion` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usuario`
--

DROP TABLE IF EXISTS `usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `usuario` (
  `IdUsuario` int NOT NULL AUTO_INCREMENT,
  `Nombres` varchar(50) DEFAULT NULL,
  `Apellidos` varchar(50) DEFAULT NULL,
  `Cedula` int DEFAULT NULL,
  `Telefono` int DEFAULT NULL,
  `Correo` varchar(50) DEFAULT NULL,
  `Clave` varchar(50) DEFAULT NULL,
  `Rol` varchar(50) DEFAULT NULL,
  `FechaCreacion` datetime DEFAULT CURRENT_TIMESTAMP,
  `Estado` varchar(10) DEFAULT NULL,
  `Estudios` varchar(100) DEFAULT NULL,
  `Edad` int DEFAULT NULL,
  `Idiomas` varchar(100) DEFAULT NULL,
  `Experiencia` varchar(100) DEFAULT NULL,
  `Habilidades` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`IdUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8mb3;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usuario`
--

LOCK TABLES `usuario` WRITE;
/*!40000 ALTER TABLE `usuario` DISABLE KEYS */;
INSERT INTO `usuario` VALUES (1,'Juan','Perez',111111111,987654123,'juan.perez@example.com','clave1','Admin','2024-07-14 10:34:19','Inactivo','Ingeniería',30,'Español, Inglés','5 años','Liderazgo, Comunicación'),(2,'Maria','Lopez',222222222,987654124,'maria.lopez@example.com','clave2','User','2024-07-14 10:34:19','Activo','Medicina',28,'Español, Francés','3 años','Empatía, Trabajo en equipo'),(3,'Pedro','Gonzalez',333333333,987654125,'pedro.gonzalez@example.com','clave3','User','2024-07-14 10:34:19','Activo','Educación',35,'Español, Alemán','7 años','Creatividad, Innovación'),(4,'Ana','Martinez',444444444,987654126,'ana.martinez@example.com','clave4','Admin','2024-07-14 10:34:19','Inactivo','Finanzas',32,'Español, Italiano','6 años','Analítico, Proactivo'),(5,'Luis','Hernandez',555555555,987654127,'luis.hernandez@example.com','clave5','User','2024-07-14 10:34:19','Inactivo','Marketing',29,'Español, Portugués','4 años','Estrategia, Planificación'),(6,'Laura','Garcia',666666666,987654128,'laura.garcia@example.com','clave6','User','2024-07-14 10:34:19','Activo','Ventas',27,'Español, Ruso','3 años','Negociación, Persuasión'),(7,'Carlos','Rodriguez',777777777,987654129,'carlos.rodriguez@example.com','clave7','Admin','2024-07-14 10:34:19','Activo','Administración',34,'Español, Japonés','8 años','Organización, Gestión'),(8,'Sofia','Fernandez',888888888,987654130,'sofia.fernandez@example.com','clave8','User','2024-07-14 10:34:19','Activo','Ingeniería',31,'Español, Chino','5 años','Solución de problemas, Innovación'),(9,'Jorge','Ramirez',999999999,987654131,'jorge.ramirez@example.com','clave9','User','2024-07-14 10:34:19','Activo','Recursos Humanos',30,'Español, Árabe','4 años','Empatía, Comunicación'),(10,'Marta','Diaz',101010101,987654132,'marta.diaz@example.com','clave10','Admin','2024-07-14 10:34:19','Activo','Diseño',26,'Español, Coreano','2 años','Creatividad, Innovación'),(31,'JHOWEL','BASANTES',1724255284,984677821,'arturobasantes13@gmail.com','Jhowel12345','Admin','2024-07-01 00:00:00','Activo','Inge',21,'Español','Habilidad','CR7'),(32,'aleluiya','jajaja',123456789,987456321,'Aleluya@gmail.com','123456789','Admin','2024-07-01 00:00:00','inactivo','JAJA',50,'Español','Siempre','Todas'),(33,'aa','aa',123456789,123456789,'as@xn--gmai-jqa.com','123456','Admin','0001-01-01 00:00:00','Inactivo','a',12,'a','a','a'),(34,'aa','aa',123456789,123456789,'as@xn--gmai-jqa.com','123456','Admin','0001-01-01 00:00:00','Activo','a',12,'a','a','a'),(35,'aa','aa',123456789,123456789,'as@xn--gmai-jqa.com','123456','Admin','0001-01-01 00:00:00','Activo','a',12,'a','a','a'),(36,'artur','Jhowel',123456789,123456789,'artur@gmail.com','123456','Admin','2024-07-01 00:00:00','Activo','Siempre',11,'Tofdos','Todos','Todos'),(37,'ass','as|112',1212,1212,'1212@gmail.com','1212','admin','0001-01-01 00:00:00','activo','12',12,'12','12','12'),(38,'STALIN','MEJIA',1724586542,98745632,'STALIN@GMAIL.COM','12345678','admin','2024-07-21 00:00:00','Activo','Docencia',24,'español','Si','Todas');
/*!40000 ALTER TABLE `usuario` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-07-26  7:38:42
