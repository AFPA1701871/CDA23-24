-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le :  lun. 22 oct. 2018 à 07:58
-- Version du serveur :  5.7.21-log
-- Version de PHP :  7.1.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données :  `voitures_nosql`
--

-- --------------------------------------------------------

--
-- Structure de la table `marques`
--

DROP TABLE IF EXISTS `marques`;
CREATE TABLE IF NOT EXISTS `marques` (
  `mar_id` int(11) NOT NULL AUTO_INCREMENT,
  `mar_nom` varchar(20) NOT NULL,
  PRIMARY KEY (`mar_id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `marques`
--

INSERT INTO `marques` (`mar_id`, `mar_nom`) VALUES
(1, 'Citroën'),
(2, 'Peugeot'),
(3, 'Renault');

-- --------------------------------------------------------

--
-- Structure de la table `modeles`
--

DROP TABLE IF EXISTS `modeles`;
CREATE TABLE IF NOT EXISTS `modeles` (
  `mod_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `mod_mar_id` int(11) NOT NULL,
  `mod_nom` varchar(20) NOT NULL,
  `mod_cylindree` decimal(2,1) UNSIGNED NOT NULL,
  `mod_prix` int(10) UNSIGNED NOT NULL,
  `mod_date_dispo` date DEFAULT NULL,
  `mod_date_ajout` date DEFAULT NULL,
  PRIMARY KEY (`mod_id`),
  KEY `fk_modeles_mar_id` (`mod_mar_id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `modeles`
--

INSERT INTO `modeles` (`mod_id`, `mod_mar_id`, `mod_nom`, `mod_cylindree`, `mod_prix`, `mod_date_dispo`, `mod_date_ajout`) VALUES
(1, 1, 'C3', '1.0', 13500, NULL, '2018-10-18'),
(2, 1, 'Cactus', '1.0', 18470, '2019-01-02', '2018-10-18'),
(3, 3, 'Espace', '2.0', 40000, '2019-01-02', '2018-10-18'),
(4, 3, 'Clio', '1.0', 14080, '2019-01-02', '2018-10-18'),
(5, 2, '5008', '1.2', 33250, '2019-01-02', '2018-10-18'),
(6, 2, '308', '1.2', 23630, '2019-01-02', '2018-10-18'),
(7, 3, 'Mégane', '1.3', 26740, '2019-01-02', '2018-10-18'),
(8, 1, 'Picasso', '1.2', 29100, '2019-01-02', '2018-10-18'),
(9, 3, 'Kadjar', '1.2', 26950, '2019-01-02', '2018-10-18'),
(10, 3, 'Koléos', '1.5', 34900, '2019-01-02', '2018-10-18');

-- --------------------------------------------------------

--
-- Structure de la table `modeles_options`
--

DROP TABLE IF EXISTS `modeles_options`;
CREATE TABLE IF NOT EXISTS `modeles_options` (
  `om_id` int(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `om_mod_id` int(11) UNSIGNED NOT NULL COMMENT 'Clé de la table modeles',
  `om_opt_id` int(11) UNSIGNED NOT NULL COMMENT 'Clé de la table options',
  PRIMARY KEY (`om_id`),
  KEY `om_mod_id` (`om_mod_id`),
  KEY `om_opt_id` (`om_opt_id`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `modeles_options`
--

INSERT INTO `modeles_options` (`om_id`, `om_mod_id`, `om_opt_id`) VALUES
(1, 6, 2),
(2, 6, 4),
(3, 5, 1),
(4, 5, 3),
(5, 5, 4),
(6, 5, 2);

-- --------------------------------------------------------

--
-- Structure de la table `options`
--

DROP TABLE IF EXISTS `options`;
CREATE TABLE IF NOT EXISTS `options` (
  `opt_id` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
  `opt_libelle` varchar(50) NOT NULL,
  `opt_prix` smallint(5) UNSIGNED NOT NULL,
  PRIMARY KEY (`opt_id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `options`
--

INSERT INTO `options` (`opt_id`, `opt_libelle`, `opt_prix`) VALUES
(1, 'Jantes alu', 600),
(2, 'GPS', 450),
(3, 'Toit ouvrant', 870),
(4, 'Peinture métallisée', 275);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `modeles`
--
ALTER TABLE `modeles`
  ADD CONSTRAINT `fk_modeles_mar_id` FOREIGN KEY (`mod_mar_id`) REFERENCES `marques` (`mar_id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

--
-- Contraintes pour la table `modeles_options`
--
ALTER TABLE `modeles_options`
  ADD CONSTRAINT `modeles_options_ibfk_1` FOREIGN KEY (`om_mod_id`) REFERENCES `modeles` (`mod_id`),
  ADD CONSTRAINT `modeles_options_ibfk_2` FOREIGN KEY (`om_opt_id`) REFERENCES `options` (`opt_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
