-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : ven. 01 déc. 2023 à 09:02
-- Version du serveur : 5.7.36
-- Version de PHP : 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `clientsarticlesdb`
--
CREATE DATABASE IF NOT EXISTS `clientsarticlesdb` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `clientsarticlesdb`;

-- --------------------------------------------------------

--
-- Structure de la table `articles`
--

DROP TABLE IF EXISTS `articles`;
CREATE TABLE IF NOT EXISTS `articles` (
  `idArticle` int(11) NOT NULL AUTO_INCREMENT,
  `descriptionArticle` varchar(50) DEFAULT NULL,
  `prixArticle` int(11) DEFAULT NULL,
  `idCategorie` int(11) NOT NULL,
  PRIMARY KEY (`idArticle`),
  KEY `fk_articles_categories` (`idCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `articles`
--

INSERT INTO `articles` (`idArticle`, `descriptionArticle`, `prixArticle`, `idCategorie`) VALUES
(1, 'ciseaux', 6, 1),
(2, 'règle 30 cm', 4, 2),
(3, 'règle 20 cm', 3, 2),
(4, 'stylo plume', 12, 1),
(5, 'feutre tableau blanc', 4, 1),
(6, 'feuille', 2, 1);

-- --------------------------------------------------------

--
-- Structure de la table `categories`
--

DROP TABLE IF EXISTS `categories`;
CREATE TABLE IF NOT EXISTS `categories` (
  `idCategorie` int(11) NOT NULL AUTO_INCREMENT,
  `libelleCategorie` varchar(50) NOT NULL,
  PRIMARY KEY (`idCategorie`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `categories`
--

INSERT INTO `categories` (`idCategorie`, `libelleCategorie`) VALUES
(1, 'categ 1 '),
(2, 'categ 2');

-- --------------------------------------------------------

--
-- Structure de la table `clients`
--

DROP TABLE IF EXISTS `clients`;
CREATE TABLE IF NOT EXISTS `clients` (
  `idClient` int(11) NOT NULL AUTO_INCREMENT,
  `nomClient` varchar(50) DEFAULT NULL,
  `prenomClient` varchar(50) DEFAULT NULL,
  `dateEntreeClient` date DEFAULT NULL,
  PRIMARY KEY (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `clients`
--

INSERT INTO `clients` (`idClient`, `nomClient`, `prenomClient`, `dateEntreeClient`) VALUES
(1, 'talon', 'marc', '1999-10-22'),
(2, 'talon', 'sophie', '2004-11-16'),
(3, 'ralleux', 'vincent', '2005-06-21'),
(4, 'durand', 'sophie', '2006-12-21'),
(5, 'durant', 'serge', '2005-04-05'),
(6, 'dupond', 'yves', '2005-12-04');

-- --------------------------------------------------------

--
-- Structure de la table `commandes`
--

DROP TABLE IF EXISTS `commandes`;
CREATE TABLE IF NOT EXISTS `commandes` (
  `idCommande` int(11) NOT NULL AUTO_INCREMENT,
  `idClient` int(11) DEFAULT NULL,
  `idArticle` int(11) DEFAULT NULL,
  `dateCommande` date DEFAULT NULL,
  `quantiteCommande` int(11) DEFAULT NULL,
  PRIMARY KEY (`idCommande`),
  KEY `FK_Articles` (`idArticle`),
  KEY `FK_Clients` (`idClient`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `commandes`
--

INSERT INTO `commandes` (`idCommande`, `idClient`, `idArticle`, `dateCommande`, `quantiteCommande`) VALUES
(1, 1, 6, '2014-07-07', 9),
(2, 1, 5, '2014-07-08', 1),
(3, 3, 1, '2014-07-09', 12),
(4, 4, 5, '2014-07-08', 2),
(5, 5, 1, '2014-07-07', 5),
(6, 5, 2, '2014-07-07', 1),
(7, 1, 6, '2023-05-01', 100),
(8, 6, 1, '2023-10-19', 1);

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `articles`
--
ALTER TABLE `articles`
  ADD CONSTRAINT `fk_articles_categories` FOREIGN KEY (`idCategorie`) REFERENCES `categories` (`idCategorie`);

--
-- Contraintes pour la table `commandes`
--
ALTER TABLE `commandes`
  ADD CONSTRAINT `FK_Articles` FOREIGN KEY (`idArticle`) REFERENCES `articles` (`idArticle`),
  ADD CONSTRAINT `FK_Clients` FOREIGN KEY (`idClient`) REFERENCES `clients` (`idClient`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
