CREATE DATABASE `recipebook` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;

CREATE TABLE `users` (
  `UserId` int NOT NULL,
  `FirstName` varchar(45) DEFAULT NULL,
  `LastName` varchar(45) DEFAULT NULL,
  `Username` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `EmailAddress` varchar(60) DEFAULT NULL,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `recipes` (
  `RecipeId` int NOT NULL,
  `Title` varchar(45) NOT NULL,
  `Description` varchar(200) NOT NULL,
  `PrepTime` time DEFAULT NULL,
  `CookTime` time DEFAULT NULL,
  `Instructions` json DEFAULT NULL,
  `Ingredients` json DEFAULT NULL,
  `Image` blob,
  `UserId` int DEFAULT NULL,
  PRIMARY KEY (`RecipeId`),
  KEY `fk_recipe_owner_idx` (`UserId`),
  CONSTRAINT `fk_recipe_owner` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

CREATE TABLE `user_favorites` (
  `UserId` int NOT NULL,
  `RecipeId` int NOT NULL,
  PRIMARY KEY (`UserId`,`RecipeId`),
  KEY `fk_user_favorites_recipes1_idx` (`RecipeId`),
  CONSTRAINT `fk_recipe_id` FOREIGN KEY (`RecipeId`) REFERENCES `recipes` (`RecipeId`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `fk_user_id` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;