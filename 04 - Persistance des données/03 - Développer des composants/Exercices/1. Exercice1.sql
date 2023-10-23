
--
-- Base de données :  `exercice1`
--
CREATE DATABASE IF NOT EXISTS `exercice1` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `exercice1`;

-- --------------------------------------------------------

--
-- Structure de la table `articles`
--

DROP TABLE IF EXISTS `articles`;
CREATE TABLE IF NOT EXISTS `articles` (
  `idArticle` int(11) NOT NULL AUTO_INCREMENT,
  `descriptionArticle` varchar(50) DEFAULT NULL,
  `prixArticle` int(11) DEFAULT NULL,
  PRIMARY KEY (`idArticle`)
)  ENGINE=INNODB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `articles`
--

INSERT INTO `articles` (`idArticle`, `descriptionArticle`, `prixArticle`) VALUES
(1, 'ciseaux', 6),
(2, 'règle 30 cm', 4),
(3, 'règle 20 cm', 3),
(4, 'stylo plume', 12),
(5, 'feutre tableau blanc', 4),
(6,'feuille',2);

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
) ENGINE=INNODB  DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `clients`
--

INSERT INTO `clients` (`idClient`, `nomClient`, `prenomClient`, `dateEntreeClient`) VALUES
(1, 'talon', 'marc', '1999-10-22'),
(2, 'talon', 'sophie', '2004-11-16'),
(3, 'talleux', 'vincent', '2005-06-21'),
(4,'durand','sophie','2006-12-21'),
(5,'durant','serge','2005-04-05'),
(6,'dupond','yves','2005-12-04');

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
  PRIMARY KEY (`idCommande`)
) ENGINE=INNODB DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `commandes`
--

INSERT INTO `commandes` (`idCommande`, `idClient`, `idArticle`, `dateCommande`, `quantiteCommande`) VALUES
(1, 2, 6, '2014-07-07', 9),
(2, 2, 5, '2014-07-08', 1),
(3, 3, 1, '2014-07-09', 12),
(4, 4, 5, '2014-07-08', 2),
(5, 5, 1, '2014-07-07', 5),
(6, 5, 2, '2014-07-07', 1);

