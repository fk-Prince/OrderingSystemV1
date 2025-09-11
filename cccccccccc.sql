-- MySQL dump 10.13  Distrib 8.0.41, for Win64 (x86_64)
--
-- Host: localhost    Database: mydb
-- ------------------------------------------------------
-- Server version	8.0.41

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
-- Table structure for table `branches`
--

DROP TABLE IF EXISTS `branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `branches` (
  `branches_id` bigint NOT NULL AUTO_INCREMENT,
  `branches_code` bigint NOT NULL,
  `branches_name` varchar(255) NOT NULL,
  PRIMARY KEY (`branches_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `branches`
--

LOCK TABLES `branches` WRITE;
/*!40000 ALTER TABLE `branches` DISABLE KEYS */;
INSERT INTO `branches` VALUES (1,1001,'Davao City'),(2,1002,'Tagum'),(3,1003,'Panabo'),(4,1004,'Samal');
/*!40000 ALTER TABLE `branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `category`
--

DROP TABLE IF EXISTS `category`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `category` (
  `category_id` bigint NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) NOT NULL,
  PRIMARY KEY (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `category`
--

LOCK TABLES `category` WRITE;
/*!40000 ALTER TABLE `category` DISABLE KEYS */;
INSERT INTO `category` VALUES (1,'Fries'),(2,'Dishes'),(3,'Package'),(4,'Dessert'),(5,'Beverages'),(6,'Seafoods'),(7,'Test');
/*!40000 ALTER TABLE `category` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `coupon`
--

DROP TABLE IF EXISTS `coupon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `coupon` (
  `coupon_code` varchar(255) NOT NULL,
  `expiry_date` timestamp NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now()),
  `rate` decimal(5,3) NOT NULL,
  `status` enum('Used','Not-Used') NOT NULL DEFAULT 'Not-Used',
  `coupon_description` varchar(255) NOT NULL,
  PRIMARY KEY (`coupon_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `coupon`
--

LOCK TABLES `coupon` WRITE;
/*!40000 ALTER TABLE `coupon` DISABLE KEYS */;
/*!40000 ALTER TABLE `coupon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `discount`
--

DROP TABLE IF EXISTS `discount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `discount` (
  `discount_id` bigint NOT NULL AUTO_INCREMENT,
  `rate` decimal(5,3) NOT NULL,
  `until_date` datetime NOT NULL,
  PRIMARY KEY (`discount_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `discount`
--

LOCK TABLES `discount` WRITE;
/*!40000 ALTER TABLE `discount` DISABLE KEYS */;
/*!40000 ALTER TABLE `discount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredient_stock`
--

DROP TABLE IF EXISTS `ingredient_stock`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredient_stock` (
  `ingredient_stock_id` bigint NOT NULL AUTO_INCREMENT,
  `ingredient_id` bigint NOT NULL,
  `current_stock` decimal(10,2) NOT NULL,
  `expiry_date` date NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now()),
  PRIMARY KEY (`ingredient_stock_id`),
  KEY `ingredient_stock_ibfk_1` (`ingredient_id`),
  CONSTRAINT `ingredient_stock_ibfk_1` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`ingredient_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredient_stock`
--

LOCK TABLES `ingredient_stock` WRITE;
/*!40000 ALTER TABLE `ingredient_stock` DISABLE KEYS */;
INSERT INTO `ingredient_stock` VALUES (1,1,50.00,'2026-01-01','2025-09-08 13:18:19'),(2,2,38.00,'2026-02-01','2025-09-08 13:18:19'),(3,3,28.00,'2027-01-01','2025-09-08 13:18:19'),(4,4,49.00,'2025-12-31','2025-09-08 13:18:19'),(5,5,50.00,'2025-12-31','2025-09-08 13:18:19'),(6,6,50.00,'2025-12-31','2025-09-08 13:18:19'),(7,7,50.00,'2025-12-31','2025-09-08 13:18:19'),(8,8,50.00,'2025-11-01','2025-09-08 13:18:19'),(9,9,50.00,'2025-11-01','2025-09-08 13:18:19'),(10,10,50.00,'2026-06-01','2025-09-08 13:18:19'),(11,11,50.00,'2026-06-01','2025-09-08 13:18:19'),(12,12,50.00,'2025-11-05','2025-09-08 13:18:19'),(13,13,50.00,'2026-03-01','2025-09-08 13:18:19'),(14,14,50.00,'2027-01-01','2025-09-08 13:18:19'),(15,15,50.00,'2025-10-15','2025-09-08 13:18:19'),(16,16,50.00,'2025-09-30','2025-09-08 13:18:19'),(17,17,50.00,'2026-01-01','2025-09-08 13:18:19'),(18,18,50.00,'2026-01-01','2025-09-08 13:18:19'),(19,19,50.00,'2026-01-01','2025-09-08 13:18:19'),(20,20,50.00,'2025-09-20','2025-09-08 13:18:19'),(21,21,50.00,'2025-12-31','2025-09-08 13:18:19'),(22,22,50.00,'2026-01-01','2025-09-08 13:18:19'),(23,23,50.00,'2025-09-15','2025-09-08 13:18:19'),(24,24,50.00,'2025-12-31','2025-09-08 13:18:19'),(25,25,48.00,'2025-10-10','2025-09-08 13:18:19'),(26,26,50.00,'2026-03-01','2025-09-08 13:18:19'),(27,27,50.00,'2027-01-01','2025-09-08 13:18:19'),(28,28,50.00,'2026-05-15','2025-09-08 13:18:19'),(29,29,50.00,'2025-10-20','2025-09-08 13:18:19'),(30,30,50.00,'2025-10-25','2025-09-08 13:18:19'),(31,31,50.00,'2025-10-18','2025-09-08 13:18:19'),(32,32,20.00,'2025-10-19','2025-09-08 13:18:19'),(33,33,50.00,'2026-04-01','2025-09-08 13:18:19'),(34,34,50.00,'2025-10-15','2025-09-08 13:18:19');
/*!40000 ALTER TABLE `ingredient_stock` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ingredients`
--

DROP TABLE IF EXISTS `ingredients`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `ingredients` (
  `ingredient_id` bigint NOT NULL AUTO_INCREMENT,
  `branches_id` bigint NOT NULL,
  `ingredient_name` varchar(255) NOT NULL,
  `unit` enum('Kg','Piece') NOT NULL DEFAULT 'Piece',
  `removable` enum('Yes','No') NOT NULL DEFAULT 'Yes',
  `created_at` timestamp NOT NULL DEFAULT (now()),
  `updated_at` timestamp NOT NULL DEFAULT (now()),
  PRIMARY KEY (`ingredient_id`),
  KEY `branches_id` (`branches_id`),
  CONSTRAINT `ingredients_ibfk_1` FOREIGN KEY (`branches_id`) REFERENCES `branches` (`branches_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ingredients`
--

LOCK TABLES `ingredients` WRITE;
/*!40000 ALTER TABLE `ingredients` DISABLE KEYS */;
INSERT INTO `ingredients` VALUES (1,1,'Potatoes','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(2,1,'Cooking Oil','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(3,1,'Salt','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(4,1,'Cheese Sauce','Kg','Yes','2025-09-08 13:17:50','2025-09-08 13:17:50'),(5,1,'Sour Cream Powder','Kg','Yes','2025-09-08 13:17:50','2025-09-08 13:17:50'),(6,1,'BBQ Seasoning','Kg','Yes','2025-09-08 13:17:50','2025-09-08 13:17:50'),(7,1,'Chili Meat','Kg','Yes','2025-09-08 13:17:50','2025-09-08 13:17:50'),(8,1,'Chicken','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(9,1,'Pork','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(10,1,'Soy Sauce','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(11,1,'Vinegar','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(12,1,'Pork Ribs','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(13,1,'Tamarind Mix','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(14,1,'Water','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(15,1,'Vegetables','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(16,1,'Eggs','Piece','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(17,1,'Evaporated Milk','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(18,1,'Condensed Milk','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(19,1,'Sugar','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(20,1,'Mangoes','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(21,1,'Crushed Ice','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(22,1,'Syrup','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(23,1,'Tuna Belly','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(24,1,'Garlic','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(25,1,'Lemon','Piece','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(26,1,'Beef','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(27,1,'Rice','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(28,1,'Pancit Noodles','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(29,1,'Shrimp','Kg','Yes','2025-09-08 13:17:50','2025-09-08 13:17:50'),(30,1,'Squid','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(31,1,'Tilapia','Piece','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(32,1,'Pork Belly','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(33,1,'Coconut Milk','Kg','No','2025-09-08 13:17:50','2025-09-08 13:17:50'),(34,1,'Pineapple','Piece','No','2025-09-08 13:17:50','2025-09-08 13:17:50');
/*!40000 ALTER TABLE `ingredients` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `invoice`
--

DROP TABLE IF EXISTS `invoice`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `invoice` (
  `invoice_id` varchar(255) NOT NULL,
  `waiting_number` bigint NOT NULL,
  `order_id` varchar(255) NOT NULL,
  `staff_id` bigint NOT NULL,
  `payment_id` bigint NOT NULL,
  `total_amount` decimal(10,2) NOT NULL,
  `created_at` timestamp NOT NULL DEFAULT (now()),
  PRIMARY KEY (`invoice_id`),
  KEY `payment_id` (`payment_id`),
  KEY `order_id` (`order_id`),
  KEY `staff_id` (`staff_id`),
  CONSTRAINT `invoice_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`),
  CONSTRAINT `invoice_ibfk_3` FOREIGN KEY (`payment_id`) REFERENCES `payment` (`payment_id`),
  CONSTRAINT `invoice_ibfk_4` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`staff_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `invoice`
--

LOCK TABLES `invoice` WRITE;
/*!40000 ALTER TABLE `invoice` DISABLE KEYS */;
/*!40000 ALTER TABLE `invoice` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu`
--

DROP TABLE IF EXISTS `menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu` (
  `menu_id` bigint NOT NULL AUTO_INCREMENT,
  `category_id` bigint NOT NULL,
  `menu_name` varchar(255) NOT NULL,
  `menu_description` varchar(255) NOT NULL,
  `image` longblob,
  `isAvailable` enum('Yes','No') NOT NULL DEFAULT 'Yes',
  `created_at` timestamp NOT NULL DEFAULT (now()),
  `updated_at` timestamp NOT NULL DEFAULT (now()),
  PRIMARY KEY (`menu_id`),
  UNIQUE KEY `menu_name_UNIQUE` (`menu_name`),
  KEY `category_id` (`category_id`),
  CONSTRAINT `menu_ibfk_1` FOREIGN KEY (`category_id`) REFERENCES `category` (`category_id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu`
--

LOCK TABLES `menu` WRITE;
/*!40000 ALTER TABLE `menu` DISABLE KEYS */;
INSERT INTO `menu` VALUES (1,2,'Chicken Joy','Chicken',NULL,'Yes','2025-09-10 14:19:13','2025-09-10 14:19:13'),(2,1,'Siomai','Siomai',NULL,'Yes','2025-09-10 14:21:02','2025-09-10 14:21:02'),(3,5,'Coke','Coke',NULL,'Yes','2025-09-10 14:21:02','2025-09-10 14:21:02'),(4,1,'Fries','Fries',NULL,'Yes','2025-09-10 14:21:02','2025-09-10 14:21:02'),(5,4,'Ice Cream','Chocolate',NULL,'Yes','2025-09-10 14:21:02','2025-09-10 14:21:02');
/*!40000 ALTER TABLE `menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_branches`
--

DROP TABLE IF EXISTS `menu_branches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_branches` (
  `branches_id` bigint NOT NULL,
  `menu_id` bigint NOT NULL,
  KEY `branches_id` (`branches_id`),
  KEY `menu_id` (`menu_id`),
  CONSTRAINT `menu_branches_ibfk_1` FOREIGN KEY (`branches_id`) REFERENCES `branches` (`branches_id`),
  CONSTRAINT `menu_branches_ibfk_2` FOREIGN KEY (`menu_id`) REFERENCES `menu` (`menu_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_branches`
--

LOCK TABLES `menu_branches` WRITE;
/*!40000 ALTER TABLE `menu_branches` DISABLE KEYS */;
INSERT INTO `menu_branches` VALUES (1,2),(2,4),(1,1),(1,5),(1,3);
/*!40000 ALTER TABLE `menu_branches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_bundle`
--

DROP TABLE IF EXISTS `menu_bundle`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_bundle` (
  `menu_detail_id` bigint NOT NULL,
  `bundle_price` decimal(10,2) NOT NULL,
  KEY `asdcsadc_idx` (`menu_detail_id`),
  CONSTRAINT `asdcsadc` FOREIGN KEY (`menu_detail_id`) REFERENCES `menu_detail` (`menu_detail_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_bundle`
--

LOCK TABLES `menu_bundle` WRITE;
/*!40000 ALTER TABLE `menu_bundle` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_bundle` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_customized`
--

DROP TABLE IF EXISTS `menu_customized`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_customized` (
  `order_item_id` bigint NOT NULL,
  `ingredient_id` bigint NOT NULL,
  KEY `ingredient_id` (`ingredient_id`),
  KEY `order_item_id` (`order_item_id`),
  CONSTRAINT `menu_customized_ibfk_1` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`ingredient_id`),
  CONSTRAINT `menu_customized_ibfk_2` FOREIGN KEY (`order_item_id`) REFERENCES `order_item` (`order_item_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_customized`
--

LOCK TABLES `menu_customized` WRITE;
/*!40000 ALTER TABLE `menu_customized` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_customized` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_detail`
--

DROP TABLE IF EXISTS `menu_detail`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_detail` (
  `menu_detail_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_id` bigint NOT NULL,
  `price` decimal(10,2) NOT NULL,
  `estimated_time` time NOT NULL,
  `size_id` bigint NOT NULL DEFAULT '1',
  PRIMARY KEY (`menu_detail_id`),
  KEY `menu_id` (`menu_id`),
  KEY `zxczxcxcxcxcxc11_idx` (`size_id`),
  CONSTRAINT `menu_detail_ibfk_1` FOREIGN KEY (`menu_id`) REFERENCES `menu` (`menu_id`),
  CONSTRAINT `zxczxcxcxcxcxc11` FOREIGN KEY (`size_id`) REFERENCES `size` (`size_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_detail`
--

LOCK TABLES `menu_detail` WRITE;
/*!40000 ALTER TABLE `menu_detail` DISABLE KEYS */;
INSERT INTO `menu_detail` VALUES (1,1,99.99,'00:30:00',1),(2,2,49.99,'00:30:00',2),(3,2,54.99,'00:30:00',3),(4,2,59.99,'00:30:00',1),(5,3,50.00,'00:30:00',2),(6,3,65.00,'00:30:00',3),(7,3,70.00,'00:30:00',1),(8,4,49.00,'00:30:00',2),(9,5,49.00,'00:30:00',2),(10,5,53.00,'00:30:00',3),(11,4,59.00,'00:30:00',1);
/*!40000 ALTER TABLE `menu_detail` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_discount`
--

DROP TABLE IF EXISTS `menu_discount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_discount` (
  `discount_id` bigint NOT NULL,
  `menu_id` bigint NOT NULL,
  KEY `menu_discount_ibfk_1_idx` (`menu_id`),
  KEY `zxczxc_idx` (`discount_id`),
  CONSTRAINT `menu_discount_ibfk_1` FOREIGN KEY (`menu_id`) REFERENCES `menu` (`menu_id`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `zxczxc` FOREIGN KEY (`discount_id`) REFERENCES `discount` (`discount_id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_discount`
--

LOCK TABLES `menu_discount` WRITE;
/*!40000 ALTER TABLE `menu_discount` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_discount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_ingredient`
--

DROP TABLE IF EXISTS `menu_ingredient`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_ingredient` (
  `menu_detail_id` bigint NOT NULL,
  `ingredient_id` bigint NOT NULL,
  `quantity` decimal(10,2) NOT NULL DEFAULT '1.00',
  KEY `menu_detail_id` (`menu_detail_id`),
  KEY `ingredient_id` (`ingredient_id`),
  CONSTRAINT `menu_ingredient_ibfk_1` FOREIGN KEY (`menu_detail_id`) REFERENCES `menu_detail` (`menu_detail_id`),
  CONSTRAINT `menu_ingredient_ibfk_2` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`ingredient_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_ingredient`
--

LOCK TABLES `menu_ingredient` WRITE;
/*!40000 ALTER TABLE `menu_ingredient` DISABLE KEYS */;
INSERT INTO `menu_ingredient` VALUES (1,25,1.00),(2,5,1.00),(3,16,1.00),(4,30,1.00),(5,8,1.00),(6,14,1.00),(7,12,1.00),(8,18,1.00),(9,20,1.00),(10,16,1.00),(11,12,1.00);
/*!40000 ALTER TABLE `menu_ingredient` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `menu_package`
--

DROP TABLE IF EXISTS `menu_package`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `menu_package` (
  `from_menu_detail_id` bigint NOT NULL,
  `included_menu_detail_id` bigint NOT NULL,
  `quantity` bigint NOT NULL DEFAULT '1',
  KEY `from_menu_detail_id` (`from_menu_detail_id`),
  KEY `included_menu_detail_id` (`included_menu_detail_id`),
  CONSTRAINT `menu_package_ibfk_1` FOREIGN KEY (`from_menu_detail_id`) REFERENCES `menu_detail` (`menu_detail_id`),
  CONSTRAINT `menu_package_ibfk_2` FOREIGN KEY (`included_menu_detail_id`) REFERENCES `menu_detail` (`menu_detail_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `menu_package`
--

LOCK TABLES `menu_package` WRITE;
/*!40000 ALTER TABLE `menu_package` DISABLE KEYS */;
/*!40000 ALTER TABLE `menu_package` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `monitor_inventory`
--

DROP TABLE IF EXISTS `monitor_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `monitor_inventory` (
  `inventory_id` bigint NOT NULL AUTO_INCREMENT,
  `staff_id` bigint NOT NULL,
  `ingredient_id` bigint NOT NULL,
  `type` enum('Add','Deduct') NOT NULL DEFAULT 'Add',
  `created_at` timestamp NOT NULL DEFAULT (now()),
  `quantity` bigint NOT NULL,
  PRIMARY KEY (`inventory_id`),
  KEY `staff_id` (`staff_id`),
  KEY `ingredient_id` (`ingredient_id`),
  CONSTRAINT `monitor_inventory_ibfk_1` FOREIGN KEY (`ingredient_id`) REFERENCES `ingredients` (`ingredient_id`),
  CONSTRAINT `monitor_inventory_ibfk_2` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`staff_id`)
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `monitor_inventory`
--

LOCK TABLES `monitor_inventory` WRITE;
/*!40000 ALTER TABLE `monitor_inventory` DISABLE KEYS */;
INSERT INTO `monitor_inventory` VALUES (1,1,1,'Add','2025-09-08 13:19:40',50),(2,1,2,'Add','2025-09-08 13:19:40',50),(3,1,3,'Add','2025-09-08 13:19:40',50),(4,1,4,'Add','2025-09-08 13:19:40',50),(5,1,5,'Add','2025-09-08 13:19:40',50),(6,1,6,'Add','2025-09-08 13:19:40',50),(7,1,7,'Add','2025-09-08 13:19:40',50),(8,1,8,'Add','2025-09-08 13:19:40',50),(9,1,9,'Add','2025-09-08 13:19:40',50),(10,1,10,'Add','2025-09-08 13:19:40',50),(11,1,11,'Add','2025-09-08 13:19:40',50),(12,1,12,'Add','2025-09-08 13:19:40',50),(13,1,13,'Add','2025-09-08 13:19:40',50),(14,1,14,'Add','2025-09-08 13:19:40',50),(15,1,15,'Add','2025-09-08 13:19:40',50),(16,1,16,'Add','2025-09-08 13:19:40',50),(17,1,17,'Add','2025-09-08 13:19:40',50),(18,1,18,'Add','2025-09-08 13:19:40',50),(19,1,19,'Add','2025-09-08 13:19:40',50),(20,1,20,'Add','2025-09-08 13:19:40',50),(21,1,21,'Add','2025-09-08 13:19:40',50),(22,1,22,'Add','2025-09-08 13:19:40',50),(23,1,23,'Add','2025-09-08 13:19:40',50),(24,1,24,'Add','2025-09-08 13:19:40',50),(25,1,25,'Add','2025-09-08 13:19:40',50),(26,1,26,'Add','2025-09-08 13:19:40',50),(27,1,27,'Add','2025-09-08 13:19:40',50),(28,1,28,'Add','2025-09-08 13:19:40',50),(29,1,29,'Add','2025-09-08 13:19:40',50),(30,1,30,'Add','2025-09-08 13:19:40',50),(31,1,31,'Add','2025-09-08 13:19:40',50),(32,1,32,'Add','2025-09-08 13:19:40',50),(33,1,33,'Add','2025-09-08 13:19:40',50),(34,1,34,'Add','2025-09-08 13:19:40',50);
/*!40000 ALTER TABLE `monitor_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `new_view`
--

DROP TABLE IF EXISTS `new_view`;
/*!50001 DROP VIEW IF EXISTS `new_view`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `new_view` AS SELECT 
 1 AS `menu_id`,
 1 AS `category_id`,
 1 AS `category_name`,
 1 AS `menu_name`,
 1 AS `menu_description`,
 1 AS `image`,
 1 AS `isAvailable`,
 1 AS `menu_detail_id`,
 1 AS `menu_details`*/;
SET character_set_client = @saved_cs_client;

--
-- Table structure for table `order_coupon`
--

DROP TABLE IF EXISTS `order_coupon`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_coupon` (
  `order_id` varchar(255) NOT NULL,
  `coupon_code` varchar(255) NOT NULL,
  KEY `order_id` (`order_id`),
  KEY `coupon_code` (`coupon_code`),
  CONSTRAINT `order_coupon_ibfk_1` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`),
  CONSTRAINT `order_coupon_ibfk_2` FOREIGN KEY (`coupon_code`) REFERENCES `coupon` (`coupon_code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_coupon`
--

LOCK TABLES `order_coupon` WRITE;
/*!40000 ALTER TABLE `order_coupon` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_coupon` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item`
--

DROP TABLE IF EXISTS `order_item`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_item` (
  `order_item_id` bigint NOT NULL AUTO_INCREMENT,
  `menu_detail_id` bigint NOT NULL,
  `quantity` bigint NOT NULL,
  `order_id` varchar(255) NOT NULL,
  PRIMARY KEY (`order_item_id`),
  KEY `menu_detail_id` (`menu_detail_id`),
  KEY `order_id` (`order_id`),
  CONSTRAINT `order_item_ibfk_1` FOREIGN KEY (`menu_detail_id`) REFERENCES `menu_detail` (`menu_detail_id`),
  CONSTRAINT `order_item_ibfk_2` FOREIGN KEY (`order_id`) REFERENCES `orders` (`order_id`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item`
--

LOCK TABLES `order_item` WRITE;
/*!40000 ALTER TABLE `order_item` DISABLE KEYS */;
INSERT INTO `order_item` VALUES (1,1,1,'ORD-0001'),(2,1,1,'ORD-0001'),(3,2,1,'ORD-0001'),(4,3,1,'ORD-0001'),(5,2,1,'ORD-0001'),(6,5,1,'ORD-0002'),(7,2,1,'ORD-0002'),(8,8,1,'ORD-0001');
/*!40000 ALTER TABLE `order_item` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `order_item_discount`
--

DROP TABLE IF EXISTS `order_item_discount`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `order_item_discount` (
  `order_item_id` bigint NOT NULL,
  `discount_id` bigint NOT NULL,
  PRIMARY KEY (`order_item_id`),
  KEY `discount_id` (`discount_id`),
  CONSTRAINT `order_item_discount_ibfk_1` FOREIGN KEY (`order_item_id`) REFERENCES `order_item` (`order_item_id`),
  CONSTRAINT `order_item_discount_ibfk_2` FOREIGN KEY (`discount_id`) REFERENCES `discount` (`discount_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `order_item_discount`
--

LOCK TABLES `order_item_discount` WRITE;
/*!40000 ALTER TABLE `order_item_discount` DISABLE KEYS */;
/*!40000 ALTER TABLE `order_item_discount` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `orders`
--

DROP TABLE IF EXISTS `orders`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `orders` (
  `order_id` varchar(255) NOT NULL,
  `estimated_max_time` time NOT NULL,
  `available_until` datetime NOT NULL,
  `total_amount` decimal(18,2) NOT NULL,
  `status` enum('Pending','Paid') NOT NULL DEFAULT 'Pending',
  `brancheS_id` bigint NOT NULL,
  PRIMARY KEY (`order_id`),
  KEY `brancheS_id` (`brancheS_id`),
  CONSTRAINT `orders_ibfk_1` FOREIGN KEY (`brancheS_id`) REFERENCES `branches` (`branches_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `orders`
--

LOCK TABLES `orders` WRITE;
/*!40000 ALTER TABLE `orders` DISABLE KEYS */;
INSERT INTO `orders` VALUES ('ORD-0001','00:30:00','2029-12-29 00:00:00',2000.00,'Pending',1),('ORD-0002','00:30:00','2029-12-29 00:00:00',1000.00,'Pending',2);
/*!40000 ALTER TABLE `orders` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `payment`
--

DROP TABLE IF EXISTS `payment`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `payment` (
  `payment_id` bigint NOT NULL AUTO_INCREMENT,
  `payment_method` enum('Cash','Credit-Card') NOT NULL DEFAULT 'Cash',
  PRIMARY KEY (`payment_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `payment`
--

LOCK TABLES `payment` WRITE;
/*!40000 ALTER TABLE `payment` DISABLE KEYS */;
/*!40000 ALTER TABLE `payment` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `size`
--

DROP TABLE IF EXISTS `size`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `size` (
  `size_id` bigint NOT NULL AUTO_INCREMENT,
  `size_name` varchar(255) NOT NULL,
  PRIMARY KEY (`size_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `size`
--

LOCK TABLES `size` WRITE;
/*!40000 ALTER TABLE `size` DISABLE KEYS */;
INSERT INTO `size` VALUES (1,'Regular'),(2,'Large'),(3,'Extra Large');
/*!40000 ALTER TABLE `size` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `staff` (
  `staff_id` bigint NOT NULL AUTO_INCREMENT,
  `branches_id` bigint NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `firstName` varchar(255) NOT NULL,
  `lastName` varchar(255) NOT NULL,
  `phone` varchar(20) DEFAULT NULL,
  `hire_date` timestamp NOT NULL DEFAULT (now()),
  `role` enum('Cashier','Manager') DEFAULT 'Cashier',
  `status` enum('Active','Inactive') DEFAULT 'Active',
  `updated_at` timestamp NOT NULL DEFAULT (now()),
  PRIMARY KEY (`staff_id`),
  KEY `branches_id` (`branches_id`),
  CONSTRAINT `staff_ibfk_1` FOREIGN KEY (`branches_id`) REFERENCES `branches` (`branches_id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,1,'aeyc','aeyc','aeyc','aeyc',NULL,'2025-05-24 16:00:00','Cashier','Active','2025-09-08 13:03:59');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Temporary view structure for view `x_retrieve_menu`
--

DROP TABLE IF EXISTS `x_retrieve_menu`;
/*!50001 DROP VIEW IF EXISTS `x_retrieve_menu`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `x_retrieve_menu` AS SELECT 
 1 AS `menu_id`,
 1 AS `category_id`,
 1 AS `menu_name`,
 1 AS `menu_description`,
 1 AS `image`,
 1 AS `isAvailable`,
 1 AS `created_at`,
 1 AS `updated_at`,
 1 AS `branches_id`,
 1 AS `menu_detail`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `x_retrieve_menu_v2`
--

DROP TABLE IF EXISTS `x_retrieve_menu_v2`;
/*!50001 DROP VIEW IF EXISTS `x_retrieve_menu_v2`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `x_retrieve_menu_v2` AS SELECT 
 1 AS `menu_id`,
 1 AS `category_id`,
 1 AS `category_name`,
 1 AS `menu_name`,
 1 AS `menu_description`,
 1 AS `image`,
 1 AS `isAvailable`,
 1 AS `menu_detail_id`,
 1 AS `branches_id`,
 1 AS `size_name`,
 1 AS `price`,
 1 AS `discount_rate`,
 1 AS `max-order`*/;
SET character_set_client = @saved_cs_client;

--
-- Temporary view structure for view `x_retrieve_reserved_ingredients`
--

DROP TABLE IF EXISTS `x_retrieve_reserved_ingredients`;
/*!50001 DROP VIEW IF EXISTS `x_retrieve_reserved_ingredients`*/;
SET @saved_cs_client     = @@character_set_client;
/*!50503 SET character_set_client = utf8mb4 */;
/*!50001 CREATE VIEW `x_retrieve_reserved_ingredients` AS SELECT 
 1 AS `order_id`,
 1 AS `menu_detail_id`,
 1 AS `ingredient_id`,
 1 AS `total_ingredient_used`,
 1 AS `current_stock`,
 1 AS `branches_id`*/;
SET character_set_client = @saved_cs_client;

--
-- Dumping events for database 'mydb'
--

--
-- Dumping routines for database 'mydb'
--
/*!50003 DROP PROCEDURE IF EXISTS `x_retrieve_fot` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_0900_ai_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'NO_AUTO_VALUE_ON_ZERO' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `x_retrieve_fot`(
IN p_menu_id BIGINT,
IN p_branches_id BIGINT
)
BEGIN
	IF (
        SELECT COUNT(*)
        FROM order_item oi
        INNER JOIN menu_detail md ON md.menu_detail_id = oi.menu_detail_id
        INNER JOIN menu m ON m.menu_id = md.menu_id
        INNER JOIN menu_branches mb ON mb.menu_id = m.menu_id
        WHERE m.menu_id = p_menu_id AND mb.branches_id = p_branches_id
    ) > 0 THEN 

	
        SELECT 
            rm.*
        FROM order_item oi
        INNER JOIN x_retrieve_menu_v2 rm ON rm.menu_detail_id = oi.menu_detail_id
		WHERE oi.order_id IN (
            SELECT oi2.order_id
            FROM order_item oi2
             INNER JOIN menu_detail md2 ON oi2.menu_detail_id = md2.menu_detail_id 
             WHERE md2.menu_id = p_menu_id 
         )
		AND rm.menu_id <> p_menu_id AND rm.branches_id =p_branches_id
        GROUP BY rm.menu_detail_id, rm.branches_id
        LIMIT 5;
    ELSE

        SELECT *
        FROM x_retrieve_menu_v2
        ORDER BY RAND()
        LIMIT 5;

    END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;

--
-- Final view structure for view `new_view`
--

/*!50001 DROP VIEW IF EXISTS `new_view`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `new_view` AS select `m`.`menu_id` AS `menu_id`,`m`.`category_id` AS `category_id`,`c`.`category_name` AS `category_name`,`m`.`menu_name` AS `menu_name`,`m`.`menu_description` AS `menu_description`,`m`.`image` AS `image`,`m`.`isAvailable` AS `isAvailable`,`md`.`menu_detail_id` AS `menu_detail_id`,group_concat(concat('ID: ',`md`.`menu_detail_id`,' | ServingSize: ',`s`.`size_name`,' | Price: ',`md`.`price`,' | DiscountedPrice: ',round((`md`.`price` - (`md`.`price` * coalesce(`d`.`rate`,0))),2),' | Max-Order: ',coalesce(greatest(ifnull(`mx`.`max_order`,0),ifnull(`y`.`max_order`,0)),0)) separator ', ') AS `menu_details` from (((((((`menu` `m` join `menu_detail` `md` on((`md`.`menu_id` = `m`.`menu_id`))) join `size` `s` on((`md`.`size_id` = `s`.`size_id`))) join `category` `c` on((`c`.`category_id` = `m`.`category_id`))) left join `menu_discount` `dc` on((`dc`.`menu_id` = `m`.`menu_id`))) left join `discount` `d` on((`d`.`discount_id` = `dc`.`discount_id`))) left join (select `mi`.`menu_detail_id` AS `menu_detail_id`,floor(min((`cs`.`current_stock` / `mi`.`quantity`))) AS `max_order` from (`menu_ingredient` `mi` join (select `os`.`ingredient_id` AS `ingredient_id`,(sum(`os`.`current_stock`) - coalesce(`rm`.`total_ingredient_used`,0)) AS `current_stock` from (`ingredient_stock` `os` left join (select `x_retrieve_reserved_ingredients`.`ingredient_id` AS `ingredient_id`,sum(`x_retrieve_reserved_ingredients`.`total_ingredient_used`) AS `total_ingredient_used` from `x_retrieve_reserved_ingredients` group by `x_retrieve_reserved_ingredients`.`ingredient_id`) `rm` on((`os`.`ingredient_id` = `rm`.`ingredient_id`))) where (`os`.`expiry_date` > now()) group by `os`.`ingredient_id`) `cs` on((`mi`.`ingredient_id` = `cs`.`ingredient_id`))) group by `mi`.`menu_detail_id`) `mx` on((`md`.`menu_detail_id` = `mx`.`menu_detail_id`))) left join (select `mp`.`from_menu_detail_id` AS `menu_detail_id`,floor(min(greatest((coalesce(`cs`.`current_stock`,0) / (`mi`.`quantity` * `mp`.`quantity`)),0))) AS `max_order` from ((`menu_package` `mp` join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `mp`.`included_menu_detail_id`))) left join (select `os`.`ingredient_id` AS `ingredient_id`,(sum(`os`.`current_stock`) - coalesce(`rm`.`total_ingredient_used`,0)) AS `current_stock` from (`ingredient_stock` `os` left join (select `x_retrieve_reserved_ingredients`.`ingredient_id` AS `ingredient_id`,sum(`x_retrieve_reserved_ingredients`.`total_ingredient_used`) AS `total_ingredient_used` from `x_retrieve_reserved_ingredients` group by `x_retrieve_reserved_ingredients`.`ingredient_id`) `rm` on((`os`.`ingredient_id` = `rm`.`ingredient_id`))) where (`os`.`expiry_date` > now()) group by `os`.`ingredient_id`) `cs` on((`mi`.`ingredient_id` = `cs`.`ingredient_id`))) group by `mp`.`from_menu_detail_id`) `y` on((`md`.`menu_detail_id` = `y`.`menu_detail_id`))) group by `md`.`menu_detail_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `x_retrieve_menu`
--

/*!50001 DROP VIEW IF EXISTS `x_retrieve_menu`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `x_retrieve_menu` AS select `m`.`menu_id` AS `menu_id`,`m`.`category_id` AS `category_id`,`m`.`menu_name` AS `menu_name`,`m`.`menu_description` AS `menu_description`,`m`.`image` AS `image`,`m`.`isAvailable` AS `isAvailable`,`m`.`created_at` AS `created_at`,`m`.`updated_at` AS `updated_at`,`mb`.`branches_id` AS `branches_id`,group_concat(concat('ID: ',`md`.`menu_detail_id`,' | Price: ',`md`.`price`,' | DiscountRate: ',round(coalesce(`d`.`rate`,0.000),3),' | SizeName: ',`ss`.`size_name`,' | Max-Order: ',coalesce(`ms`.`max_order`,0)) order by `md`.`price` ASC separator ', ') AS `menu_detail` from ((((((`menu` `m` join `menu_detail` `md` on((`md`.`menu_id` = `m`.`menu_id`))) join `size` `ss` on((`ss`.`size_id` = `md`.`size_id`))) join `menu_branches` `mb` on((`m`.`menu_id` = `mb`.`menu_id`))) left join `menu_discount` `mdc` on((`mdc`.`menu_id` = `m`.`menu_id`))) left join `discount` `d` on((`mdc`.`discount_id` = `d`.`discount_id`))) left join (select `md2`.`menu_detail_id` AS `menu_detail_id`,`mb2`.`branches_id` AS `branches_id`,greatest(min(floor(((coalesce(`s`.`current_stock`,0) - coalesce(`r`.`reserved_total_ingredient`,0)) / `mi`.`quantity`))),0) AS `max_order` from (((((`menu_detail` `md2` join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `md2`.`menu_detail_id`))) join `menu` `m2` on((`m2`.`menu_id` = `md2`.`menu_id`))) join `menu_branches` `mb2` on((`m2`.`menu_id` = `mb2`.`menu_id`))) left join (select `i`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`s`.`current_stock`) AS `current_stock` from (`ingredients` `i` join `ingredient_stock` `s` on((`s`.`ingredient_id` = `i`.`ingredient_id`))) where (`s`.`expiry_date` > now()) group by `i`.`ingredient_id`,`i`.`branches_id`) `s` on(((`s`.`ingredient_id` = `mi`.`ingredient_id`) and (`s`.`branches_id` = `mb2`.`branches_id`)))) left join (select `r`.`ingredient_id` AS `ingredient_id`,`r`.`branches_id` AS `branches_id`,sum(`r`.`total_ingredient_used`) AS `reserved_total_ingredient` from `x_retrieve_reserved_ingredients` `r` group by `r`.`ingredient_id`,`r`.`branches_id`) `r` on(((`r`.`ingredient_id` = `mi`.`ingredient_id`) and (`r`.`branches_id` = `mb2`.`branches_id`)))) group by `md2`.`menu_detail_id`,`mb2`.`branches_id`) `ms` on(((`ms`.`menu_detail_id` = `md`.`menu_detail_id`) and (`ms`.`branches_id` = `mb`.`branches_id`)))) group by `m`.`menu_id`,`mb`.`branches_id` union all select `m`.`menu_id` AS `menu_id`,`m`.`category_id` AS `category_id`,`m`.`menu_name` AS `menu_name`,`m`.`menu_description` AS `menu_description`,`m`.`image` AS `image`,`m`.`isAvailable` AS `isAvailable`,`m`.`created_at` AS `created_at`,`m`.`updated_at` AS `updated_at`,`mb`.`branches_id` AS `branches_id`,group_concat(concat('ID: ',`md`.`menu_detail_id`,' | Price: ',`md`.`price`,' | DiscountedRate: ',round(coalesce(`d`.`rate`,0.000),3),' | SizeName: ',`ss`.`size_name`,' | Max-Order: ',coalesce(`ms`.`max_order`,0)) order by `md`.`price` ASC separator ', ') AS `menu_detail` from ((((((((`menu` `m` join `menu_detail` `md` on((`md`.`menu_id` = `m`.`menu_id`))) join `menu_package` `pg` on((`pg`.`from_menu_detail_id` = `md`.`menu_detail_id`))) left join `menu_discount` `mdc` on((`mdc`.`menu_id` = `m`.`menu_id`))) left join `discount` `d` on((`mdc`.`discount_id` = `d`.`discount_id`))) left join `menu_detail` `included_md` on((`included_md`.`menu_detail_id` = `pg`.`included_menu_detail_id`))) left join `size` `ss` on((`ss`.`size_id` = `included_md`.`size_id`))) join `menu_branches` `mb` on((`m`.`menu_id` = `mb`.`menu_id`))) left join (select `pg2`.`from_menu_detail_id` AS `from_menu_detail_id`,`md2`.`menu_detail_id` AS `menu_detail_id`,`mb2`.`branches_id` AS `branches_id`,greatest(min(floor(((coalesce(`s`.`current_stock`,0) - coalesce(`r`.`reserved_total_ingredient`,0)) / `mi`.`quantity`))),0) AS `max_order` from (((((((`menu_package` `pg2` join `menu_detail` `md2` on((`pg2`.`included_menu_detail_id` = `md2`.`menu_detail_id`))) join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `md2`.`menu_detail_id`))) join `menu_detail` `parent_md` on((`pg2`.`from_menu_detail_id` = `parent_md`.`menu_detail_id`))) join `menu` `m2` on((`m2`.`menu_id` = `parent_md`.`menu_id`))) join `menu_branches` `mb2` on((`m2`.`menu_id` = `mb2`.`menu_id`))) left join (select `i`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`s`.`current_stock`) AS `current_stock` from (`ingredients` `i` join `ingredient_stock` `s` on((`s`.`ingredient_id` = `i`.`ingredient_id`))) where (`s`.`expiry_date` > now()) group by `i`.`ingredient_id`,`i`.`branches_id`) `s` on(((`s`.`ingredient_id` = `mi`.`ingredient_id`) and (`s`.`branches_id` = `mb2`.`branches_id`)))) left join (select `r`.`ingredient_id` AS `ingredient_id`,`r`.`branches_id` AS `branches_id`,sum(`r`.`total_ingredient_used`) AS `reserved_total_ingredient` from `x_retrieve_reserved_ingredients` `r` group by `r`.`ingredient_id`,`r`.`branches_id`) `r` on(((`r`.`ingredient_id` = `mi`.`ingredient_id`) and (`r`.`branches_id` = `mb2`.`branches_id`)))) group by `pg2`.`from_menu_detail_id`,`md2`.`menu_detail_id`,`mb2`.`branches_id`) `ms` on(((`ms`.`from_menu_detail_id` = `md`.`menu_detail_id`) and (`ms`.`menu_detail_id` = `included_md`.`menu_detail_id`) and (`ms`.`branches_id` = `mb`.`branches_id`)))) group by `m`.`menu_id`,`mb`.`branches_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `x_retrieve_menu_v2`
--

/*!50001 DROP VIEW IF EXISTS `x_retrieve_menu_v2`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `x_retrieve_menu_v2` AS select `m`.`menu_id` AS `menu_id`,`m`.`category_id` AS `category_id`,`c`.`category_name` AS `category_name`,`m`.`menu_name` AS `menu_name`,`m`.`menu_description` AS `menu_description`,`m`.`image` AS `image`,`m`.`isAvailable` AS `isAvailable`,`md`.`menu_detail_id` AS `menu_detail_id`,`mb`.`branches_id` AS `branches_id`,`s`.`size_name` AS `size_name`,`md`.`price` AS `price`,round(coalesce(`d`.`rate`,0.000),3) AS `discount_rate`,coalesce(greatest(ifnull(`mx`.`max_order`,0),ifnull(`y`.`max_order`,0)),0) AS `max-order` from ((((((((`menu_detail` `md` join `menu` `m` on((`md`.`menu_id` = `m`.`menu_id`))) join `size` `s` on((`md`.`size_id` = `s`.`size_id`))) join `category` `c` on((`c`.`category_id` = `m`.`category_id`))) left join `menu_branches` `mb` on((`mb`.`menu_id` = `m`.`menu_id`))) left join `menu_discount` `dc` on((`dc`.`menu_id` = `m`.`menu_id`))) left join `discount` `d` on((`d`.`discount_id` = `dc`.`discount_id`))) left join (select `mi`.`menu_detail_id` AS `menu_detail_id`,`mb2`.`branches_id` AS `branches_id`,floor(min(((`cs`.`current_stock` - coalesce(`rm`.`reserved_total`,0)) / `mi`.`quantity`))) AS `max_order` from (((`menu_ingredient` `mi` join `menu_branches` `mb2` on((`mi`.`menu_detail_id` = `mi`.`menu_detail_id`))) join (select `os`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`os`.`current_stock`) AS `current_stock` from (`ingredient_stock` `os` join `ingredients` `i` on((`os`.`ingredient_id` = `i`.`ingredient_id`))) where (`os`.`expiry_date` > now()) group by `os`.`ingredient_id`,`i`.`branches_id`) `cs` on(((`cs`.`ingredient_id` = `mi`.`ingredient_id`) and (`cs`.`branches_id` = `mb2`.`branches_id`)))) left join (select `x_retrieve_reserved_ingredients`.`ingredient_id` AS `ingredient_id`,`x_retrieve_reserved_ingredients`.`branches_id` AS `branches_id`,sum(`x_retrieve_reserved_ingredients`.`total_ingredient_used`) AS `reserved_total` from `x_retrieve_reserved_ingredients` group by `x_retrieve_reserved_ingredients`.`ingredient_id`,`x_retrieve_reserved_ingredients`.`branches_id`) `rm` on(((`rm`.`ingredient_id` = `mi`.`ingredient_id`) and (`rm`.`branches_id` = `mb2`.`branches_id`)))) group by `mi`.`menu_detail_id`,`mb2`.`branches_id`) `mx` on(((`mx`.`menu_detail_id` = `md`.`menu_detail_id`) and (`mx`.`branches_id` = `mb`.`branches_id`)))) left join (select `mp`.`from_menu_detail_id` AS `menu_detail_id`,`mb2`.`branches_id` AS `branches_id`,floor(min(greatest((coalesce(`cs`.`current_stock`,0) / (`mi`.`quantity` * `mp`.`quantity`)),0))) AS `max_order` from (((`menu_package` `mp` join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `mp`.`included_menu_detail_id`))) join `menu_branches` `mb2` on((`mp`.`from_menu_detail_id` = `mi`.`menu_detail_id`))) left join (select `os`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`os`.`current_stock`) AS `current_stock` from (`ingredient_stock` `os` join `ingredients` `i` on((`os`.`ingredient_id` = `i`.`ingredient_id`))) where (`os`.`expiry_date` > now()) group by `os`.`ingredient_id`,`i`.`branches_id`) `cs` on(((`cs`.`ingredient_id` = `mi`.`ingredient_id`) and (`cs`.`branches_id` = `mb2`.`branches_id`)))) group by `mp`.`from_menu_detail_id`,`mb2`.`branches_id`) `y` on(((`y`.`menu_detail_id` = `md`.`menu_detail_id`) and (`y`.`branches_id` = `mb`.`branches_id`)))) group by `md`.`menu_detail_id`,`mb`.`branches_id` order by `md`.`menu_detail_id` */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;

--
-- Final view structure for view `x_retrieve_reserved_ingredients`
--

/*!50001 DROP VIEW IF EXISTS `x_retrieve_reserved_ingredients`*/;
/*!50001 SET @saved_cs_client          = @@character_set_client */;
/*!50001 SET @saved_cs_results         = @@character_set_results */;
/*!50001 SET @saved_col_connection     = @@collation_connection */;
/*!50001 SET character_set_client      = utf8mb4 */;
/*!50001 SET character_set_results     = utf8mb4 */;
/*!50001 SET collation_connection      = utf8mb4_0900_ai_ci */;
/*!50001 CREATE ALGORITHM=UNDEFINED */
/*!50013 DEFINER=`root`@`localhost` SQL SECURITY DEFINER */
/*!50001 VIEW `x_retrieve_reserved_ingredients` AS select `o`.`order_id` AS `order_id`,`oi`.`menu_detail_id` AS `menu_detail_id`,`mi`.`ingredient_id` AS `ingredient_id`,(`mi`.`quantity` * `oi`.`quantity`) AS `total_ingredient_used`,`stock`.`current_stock` AS `current_stock`,`o`.`brancheS_id` AS `branches_id` from ((((`orders` `o` join `order_item` `oi` on((`oi`.`order_id` = `o`.`order_id`))) join `menu_detail` `md` on((`md`.`menu_detail_id` = `oi`.`menu_detail_id`))) join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `md`.`menu_detail_id`))) join (select `ss`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`ss`.`current_stock`) AS `current_stock` from (`ingredients` `i` join `ingredient_stock` `ss` on((`i`.`ingredient_id` = `ss`.`ingredient_id`))) where (`ss`.`expiry_date` > now()) group by `ss`.`ingredient_id`) `stock` on((`mi`.`ingredient_id` = `stock`.`ingredient_id`))) where (`o`.`available_until` > now()) union all select `o`.`order_id` AS `order_id`,`pg`.`from_menu_detail_id` AS `from_menu_detail_id`,`mi`.`ingredient_id` AS `ingredient_id`,(`mi`.`quantity` * `oi`.`quantity`) AS `total_ingredient_used`,`stock`.`current_stock` AS `current_stock`,`o`.`brancheS_id` AS `branches_id` from ((((`orders` `o` join `order_item` `oi` on((`oi`.`order_id` = `o`.`order_id`))) join `menu_package` `pg` on((`pg`.`from_menu_detail_id` = `oi`.`menu_detail_id`))) join `menu_ingredient` `mi` on((`mi`.`menu_detail_id` = `pg`.`included_menu_detail_id`))) join (select `ss`.`ingredient_id` AS `ingredient_id`,`i`.`branches_id` AS `branches_id`,sum(`ss`.`current_stock`) AS `current_stock` from (`ingredients` `i` join `ingredient_stock` `ss` on((`i`.`ingredient_id` = `ss`.`ingredient_id`))) where (`ss`.`expiry_date` > now()) group by `ss`.`ingredient_id`) `stock` on((`mi`.`ingredient_id` = `stock`.`ingredient_id`))) where (`o`.`available_until` > now()) */;
/*!50001 SET character_set_client      = @saved_cs_client */;
/*!50001 SET character_set_results     = @saved_cs_results */;
/*!50001 SET collation_connection      = @saved_col_connection */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2025-09-12  0:08:03
