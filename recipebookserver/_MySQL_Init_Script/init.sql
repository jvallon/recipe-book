-- MySQL dump 10.13  Distrib 8.0.23, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: recipebook
-- ------------------------------------------------------
-- Server version	8.0.23

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
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `ingredients` (
  `IngredientId` int NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`IngredientId`),
  UNIQUE KEY `Name_UNIQUE` (`Name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (2,'Butter'),(1,'Potato');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measurement_qty`
--

DROP TABLE IF EXISTS `measurement_qty`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `measurement_qty` (
  `MeasurementQtyId` int NOT NULL,
  `Amount` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MeasurementQtyId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measurement_qty`
--

LOCK TABLES `measurement_qty` WRITE;
/*!40000 ALTER TABLE `measurement_qty` DISABLE KEYS */;
INSERT INTO `measurement_qty` VALUES (1,'1/2'),(2,'2');
/*!40000 ALTER TABLE `measurement_qty` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `measurement_units`
--

DROP TABLE IF EXISTS `measurement_units`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `measurement_units` (
  `MeasurementUnitsId` int NOT NULL,
  `MeasurementDescription` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`MeasurementUnitsId`),
  UNIQUE KEY `MeasurementDescription_UNIQUE` (`MeasurementDescription`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `measurement_units`
--

LOCK TABLES `measurement_units` WRITE;
/*!40000 ALTER TABLE `measurement_units` DISABLE KEYS */;
INSERT INTO `measurement_units` VALUES (2,'tbsp'),(1,'whole');
/*!40000 ALTER TABLE `measurement_units` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipe_ingredients`
--

DROP TABLE IF EXISTS `recipe_ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `recipe_ingredients` (
  `RecipeIngredientId` int NOT NULL AUTO_INCREMENT,
  `RecipeId` int DEFAULT NULL,
  `IngredientId` int NOT NULL,
  `MeasurementUnitsId` int NOT NULL,
  `MeasurementQtyId` int NOT NULL,
  PRIMARY KEY (`RecipeIngredientId`),
  KEY `fk_recipe_ingredients_recipes1_idx` (`RecipeId`),
  KEY `fk_recipe_ingredients_ingredients1_idx` (`IngredientId`),
  KEY `fk_recipe_ingredients_measurement_units1_idx` (`MeasurementUnitsId`),
  KEY `fk_recipe_ingredients_measurement_qty1_idx` (`MeasurementQtyId`),
  CONSTRAINT `fk_recipe_ingredients_ingredients1` FOREIGN KEY (`IngredientId`) REFERENCES `ingredients` (`IngredientId`),
  CONSTRAINT `fk_recipe_ingredients_measurement_qty1` FOREIGN KEY (`MeasurementQtyId`) REFERENCES `measurement_qty` (`MeasurementQtyId`),
  CONSTRAINT `fk_recipe_ingredients_measurement_units1` FOREIGN KEY (`MeasurementUnitsId`) REFERENCES `measurement_units` (`MeasurementUnitsId`),
  CONSTRAINT `fk_recipe_ingredients_recipes1` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipe_ingredients`
--

LOCK TABLES `recipe_ingredients` WRITE;
/*!40000 ALTER TABLE `recipe_ingredients` DISABLE KEYS */;
INSERT INTO `recipe_ingredients` VALUES (1,1,1,1,1),(2,1,2,2,1);
/*!40000 ALTER TABLE `recipe_ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `recipes`
--

DROP TABLE IF EXISTS `recipes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `recipes` (
  `RecipeId` int NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Description` varchar(200) NOT NULL,
  `PrepTime` time DEFAULT NULL,
  `CookTime` time DEFAULT NULL,
  `Instructions` json DEFAULT NULL,
  `ImageUrl` varchar(256) DEFAULT NULL,
  `UserId` varchar(36) DEFAULT NULL,
  PRIMARY KEY (`RecipeId`),
  KEY `fk_recipe_owner_idx` (`UserId`),
  CONSTRAINT `fk_recipe_owner` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `recipes`
--

LOCK TABLES `recipes` WRITE;
/*!40000 ALTER TABLE `recipes` DISABLE KEYS */;
INSERT INTO `recipes` VALUES (1,'Mashed Potatoes','Squish squish','00:30:00','00:30:00',NULL,'pancakes.jpg','1'),(2,'Hashbrowns','Golden goodness','00:30:00','00:15:00',NULL,NULL,'1'),(3,'French Fries','Crispy and salty','00:25:00','00:10:00',NULL,'avocado-toast.jpg','2'),(4,'Au Gratin Potatoes','So Cheesy','00:30:00','00:45:00',NULL,NULL,'3');
/*!40000 ALTER TABLE `recipes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `user_favorites`
--

DROP TABLE IF EXISTS `user_favorites`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `user_favorites` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `UserId` varchar(36) NOT NULL,
  `RecipeId` int NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`),
  KEY `fk_user_favorites_recipes1_idx` (`RecipeId`),
  KEY `fk_user_id` (`UserId`),
  CONSTRAINT `fk_recipe_id` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_user_id` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB AUTO_INCREMENT=68 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `user_favorites`
--

LOCK TABLES `user_favorites` WRITE;
/*!40000 ALTER TABLE `user_favorites` DISABLE KEYS */;
INSERT INTO `user_favorites` VALUES (44,'1',3),(50,'1',1),(51,'1',1),(55,'5',1),(56,'1',1),(63,'60b936f1d02f6500695a3b05',1);
/*!40000 ALTER TABLE `user_favorites` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `UserId` varchar(36) NOT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `EmailAddress` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  UNIQUE KEY `UserId_UNIQUE` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES ('1','Josh','Vallon','jvallon','password','joshua.vallon@gmail.com'),('2','Luke','Skywalker','jedi69','password','jedimaster69@gmail.com'),('3','Darth','Vader','iamyourfather','password','whosyourdaddy@theempire.com'),('4','Obi-wan','Kenobi','oldben','password','oldben13@jediorder.com'),('5','Josh','Vallon','auth0|60b936f1d02f6500695a3b05','password','joshua.vallon@gmail.com'),('60b936f1d02f6500695a3b05','whislin600rr@gmail.com','','whislin600rr',NULL,'whislin600rr@gmail.com');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2021-06-11 15:11:59
