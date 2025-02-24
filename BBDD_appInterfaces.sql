-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: localhost    Database: interfacesapp
-- ------------------------------------------------------
-- Server version	8.0.40

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
-- Table structure for table `biblioteca`
--

DROP TABLE IF EXISTS `biblioteca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `biblioteca` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idUsuario` int DEFAULT NULL,
  `idVideojuego` int DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `idUsuario` (`idUsuario`,`idVideojuego`),
  KEY `idVideojuego` (`idVideojuego`),
  CONSTRAINT `biblioteca_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `users` (`id`),
  CONSTRAINT `biblioteca_ibfk_2` FOREIGN KEY (`idVideojuego`) REFERENCES `videojuegos` (`idVideojuego`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(45) NOT NULL,
  `passwd` varchar(45) NOT NULL,
  `email` varchar(255) DEFAULT NULL,
  `rol` varchar(45) NOT NULL,
  `status` varchar(45) NOT NULL,
  `clave` varchar(45) DEFAULT NULL,
  `ban` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `valoraciones`
--

DROP TABLE IF EXISTS `valoraciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `valoraciones` (
  `id` int NOT NULL AUTO_INCREMENT,
  `idUsuario` int DEFAULT NULL,
  `idVideojuego` int DEFAULT NULL,
  `valoracion` int DEFAULT NULL,
  `cesta` tinyint DEFAULT '0',
  `comprado` tinyint DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `idUsuario` (`idUsuario`,`idVideojuego`),
  KEY `idVideojuego` (`idVideojuego`),
  CONSTRAINT `valoraciones_ibfk_1` FOREIGN KEY (`idUsuario`) REFERENCES `users` (`id`),
  CONSTRAINT `valoraciones_ibfk_2` FOREIGN KEY (`idVideojuego`) REFERENCES `videojuegos` (`idVideojuego`),
  CONSTRAINT `valoraciones_chk_1` CHECK ((`valoracion` between 1 and 5))
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `videojuegos`
--

DROP TABLE IF EXISTS `videojuegos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `videojuegos` (
  `idVideojuego` int NOT NULL AUTO_INCREMENT,
  `titulo` varchar(255) NOT NULL,
  `descripcion` varchar(999) DEFAULT NULL,
  `precio` decimal(10,2) DEFAULT NULL,
  `imagen` longblob,
  `fecha_salida` date DEFAULT NULL,
  `genero` varchar(45) DEFAULT NULL,
  `plataforma` varchar(45) DEFAULT NULL,
  `desarrollador` varchar(45) DEFAULT NULL,
  `editor` varchar(45) DEFAULT NULL,
  `modo_de_juego` varchar(45) DEFAULT NULL,
  `clasificacion_de_edades` varchar(45) DEFAULT NULL,
  `requisitos` varchar(999) DEFAULT NULL,
  `idiomas` varchar(45) DEFAULT NULL,
  `dlc` varchar(999) DEFAULT NULL,
  `valoracion` int DEFAULT NULL,
  `num_ventas` int DEFAULT NULL,
  PRIMARY KEY (`idVideojuego`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-02-24 12:16:16
