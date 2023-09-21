-- --------------------------------------------------------
-- Hôte:                         127.0.0.1
-- Version du serveur:           10.8.3-MariaDB - mariadb.org binary distribution
-- SE du serveur:                Win64
-- HeidiSQL Version:             11.3.0.6295
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Listage de la structure de la base pour users-api
CREATE DATABASE IF NOT EXISTS `users-api` /*!40100 DEFAULT CHARACTER SET utf8mb3 */;
USE `users-api`;

-- Listage de la structure de la table users-api. city
CREATE TABLE IF NOT EXISTS `city` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(50) DEFAULT NULL,
  `post_code` varchar(8) DEFAULT NULL,
  `id_country` int(11) DEFAULT NULL,
  `latitude` double DEFAULT NULL,
  `longitude` double DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK1_COUNTRY` (`id_country`),
  CONSTRAINT `FK1_COUNTRY` FOREIGN KEY (`id_country`) REFERENCES `country` (`id`) ON DELETE NO ACTION ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table users-api.city : ~7 rows (environ)
/*!40000 ALTER TABLE `city` DISABLE KEYS */;
INSERT INTO `city` (`id`, `name`, `post_code`, `id_country`, `latitude`, `longitude`) VALUES
	(9, 'London', 'E1 5AB', 20, 51.520841, -0.064052),
	(10, 'Chicago', 'IL 60641', 66, 41.95795013478338, -87.72953277238744),
	(11, 'Saint Paul', 'MN 55117', 66, 44.966641, -93.103841),
	(12, 'Bronxville', 'NY 10708', 66, 40.939616, -73.824122),
	(13, 'Paris', '75008', 19, 48.868646, 2.350779),
	(22, 'Rochefort', '17300', 19, 45.936698, -0.961697),
	(24, 'Rome', '00042', 71, 41.94564137457693, 12.557900544775428);
/*!40000 ALTER TABLE `city` ENABLE KEYS */;

-- Listage de la structure de la table users-api. comment
CREATE TABLE IF NOT EXISTS `comment` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `text` varchar(200) DEFAULT NULL,
  `id_user` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_comment_user` (`id_user`),
  CONSTRAINT `FK_comment_user` FOREIGN KEY (`id_user`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table users-api.comment : ~0 rows (environ)
/*!40000 ALTER TABLE `comment` DISABLE KEYS */;
INSERT INTO `comment` (`id`, `text`, `id_user`) VALUES
	(1, 'C\'est super cette chose !', 4);
/*!40000 ALTER TABLE `comment` ENABLE KEYS */;

-- Listage de la structure de la table users-api. country
CREATE TABLE IF NOT EXISTS `country` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL DEFAULT '0',
  `iso_code` varchar(3) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`),
  FULLTEXT KEY `iso_code` (`iso_code`)
) ENGINE=InnoDB AUTO_INCREMENT=72 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table users-api.country : ~70 rows (environ)
/*!40000 ALTER TABLE `country` DISABLE KEYS */;
INSERT INTO `country` (`id`, `name`, `iso_code`) VALUES
	(1, 'Andorra', 'AD'),
	(2, 'Argentina', 'AR'),
	(3, 'American Samoa', 'AS'),
	(4, 'Austria', 'AT'),
	(5, 'Australia', 'AU'),
	(6, 'Bangladesh', 'BD'),
	(7, 'Belgium', 'BE'),
	(8, 'Bulgaria', 'BG'),
	(9, 'Brazil', 'BR'),
	(10, 'Canada', 'CA'),
	(11, 'Switzerland', 'CH'),
	(12, 'Czech Republic', 'CZ'),
	(13, 'Germany', 'DE'),
	(14, 'Denmark', 'DK'),
	(15, 'Dominican Republic', 'DO'),
	(16, 'Spain', 'ES'),
	(17, 'Finland', 'FI'),
	(18, 'Faroe Islands', 'FO'),
	(19, 'France', 'FR'),
	(20, 'Great Britain', 'GB'),
	(21, 'French Guyana', 'GF'),
	(22, 'Guernsey', 'GG'),
	(23, 'Greenland', 'GL'),
	(24, 'Guadeloupe', 'GP'),
	(25, 'Guatemala', 'GT'),
	(26, 'Guam', 'GU'),
	(27, 'Guyana', 'GY'),
	(28, 'Croatia', 'HR'),
	(29, 'Hungary', 'HU'),
	(30, 'Isle of Man', 'IM'),
	(31, 'India', 'IN'),
	(32, 'Iceland', 'IS'),
	(34, 'Jersey', 'JE'),
	(35, 'Japan', 'JP'),
	(36, 'Liechtenstein', 'LI'),
	(37, 'Sri Lanka', 'LK'),
	(38, 'Lithuania', 'LT'),
	(39, 'Luxembourg', 'LU'),
	(40, 'Monaco', 'MC'),
	(41, 'Moldavia', 'MD'),
	(42, 'Marshall Islands', 'MH'),
	(43, 'Macedonia', 'MK'),
	(44, 'Northern Mariana Islands', 'MP'),
	(45, 'Martinique', 'MQ'),
	(46, 'Mexico', 'MX'),
	(47, 'Malaysia', 'MY'),
	(48, 'Holland', 'NL'),
	(49, 'Norway', 'NO'),
	(50, 'New Zealand', 'NZ'),
	(51, 'Phillippines', 'PH'),
	(52, 'Pakistan', 'PK'),
	(53, 'Poland', 'PL'),
	(54, 'Saint Pierre and Miquelon', 'PM'),
	(55, 'Puerto Rico', 'PR'),
	(56, 'Portugal', 'PT'),
	(57, 'French Reunion', 'RE'),
	(58, 'Russia', 'RU'),
	(59, 'Sweden', 'SE'),
	(60, 'Slovenia', 'SI'),
	(61, 'Svalbard & Jan Mayen Islands', 'SJ'),
	(62, 'Slovak Republic', 'SK'),
	(63, 'San Marino', 'SM'),
	(64, 'Thailand', 'TH'),
	(65, 'Turkey', 'TR'),
	(66, 'United States', 'US'),
	(67, 'Vatican', 'VA'),
	(68, 'Virgin Islands', 'VI'),
	(69, 'Mayotte', 'YT'),
	(70, 'South Africa', 'ZA'),
	(71, 'Italy', 'IT');
/*!40000 ALTER TABLE `country` ENABLE KEYS */;

-- Listage de la structure de la table users-api. user
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `lastname` varchar(50) DEFAULT NULL,
  `firstname` varchar(50) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `additional_address` varchar(50) DEFAULT NULL,
  `id_city` int(11) DEFAULT NULL,
  `phone_number` varchar(50) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `picture_path` varchar(50) DEFAULT NULL COMMENT 'Chemin de stockage vers la photo de profil de l''utilisateur.',
  `role` enum('Admin','Common','Superadmin') DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `FK_CITY` (`id_city`),
  CONSTRAINT `FK_CITY` FOREIGN KEY (`id_city`) REFERENCES `city` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8mb3;

-- Listage des données de la table users-api.user : ~7 rows (environ)
/*!40000 ALTER TABLE `user` DISABLE KEYS */;
INSERT INTO `user` (`id`, `lastname`, `firstname`, `address`, `additional_address`, `id_city`, `phone_number`, `birthdate`, `email`, `picture_path`, `role`) VALUES
	(2, 'Lovelace', 'Ada', '61 Vallance Rd', NULL, 9, '+442031050125', '1815-12-10', 'ada.lovelace@genius.com', NULL, NULL),
	(3, 'Babbage', 'Charles', '61 Vallance Rd', NULL, 9, '+442031050126', '1871-12-26', 'charles.babbage@pioneer.com', NULL, NULL),
	(4, 'Aaron', 'Swartz', '4218 N Keystone Ave', NULL, 10, '+17734812917', '1986-11-08', 'aaron.swartz@mit.com', NULL, NULL),
	(5, 'Appelbaum', 'Jacob', '89 Atwater St W', NULL, 11, '+17734818917', '1982-04-01', 'jacob.appelbaum@tor.com', NULL, NULL),
	(6, 'Ritchie', 'Dennis', '19 Summit Ave', NULL, 12, '+17739818917', '1941-09-09', 'd.rtichie@unix.com', NULL, NULL),
	(7, 'Zimmermann', 'Jérémie', '3 rue du Temple', NULL, 13, '+17739818917', '1978-10-02', 'jerem.zimmermann@freedom.fr', NULL, NULL),
	(8, 'Bernard', 'Bernard', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Superadmin'),
	(9, 'Bernard', 'Bernard', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Admin');
/*!40000 ALTER TABLE `user` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
