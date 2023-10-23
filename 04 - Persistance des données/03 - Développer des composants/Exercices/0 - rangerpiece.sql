
--
-- Base de données :  `rangerpiece`
--

-- --------------------------------------------------------

--
-- Structure de la table `marque`
--

DROP TABLE IF EXISTS `marque`;
CREATE TABLE IF NOT EXISTS `marque` (
  `idMarque` int(11) NOT NULL AUTO_INCREMENT,
  `nomMarque` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idMarque`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `marque`
--

INSERT INTO `marque` (`idMarque`, `nomMarque`) VALUES(1, 'Non Indiqué');
INSERT INTO `marque` (`idMarque`, `nomMarque`) VALUES(2, 'ZALI');
INSERT INTO `marque` (`idMarque`, `nomMarque`) VALUES(3, 'TERN');
INSERT INTO `marque` (`idMarque`, `nomMarque`) VALUES(4, 'FORD');

-- --------------------------------------------------------

--
-- Structure de la table `pieces`
--

DROP TABLE IF EXISTS `pieces`;
CREATE TABLE IF NOT EXISTS `pieces` (
  `idPiece` int(11) NOT NULL AUTO_INCREMENT,
  `idType` int(11) NOT NULL,
  `idMarque` int(11) NOT NULL,
  `RefPiece` varchar(50) DEFAULT NULL,
  `numeroPiece` int(11) DEFAULT NULL,
  PRIMARY KEY (`idPiece`),
  KEY `FK_pieces_idType` (`idType`),
  KEY `FK_pieces_idMarque` (`idMarque`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `pieces`
--

INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(1, 1, 1, '12d45fd', 13);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(2, 2, 1, '17887d', 140);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(3, 3, 3, NULL, 56);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(4, 4, 2, '456232', 13);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(5, 5, 1, '45788', 456);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(6, 6, 4, '45sd544', NULL);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(7, 7, 3, '45sd89', 15);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(8, 7, 3, '45sd89', 18);
INSERT INTO `pieces` (`idPiece`, `idType`, `idMarque`, `RefPiece`, `numeroPiece`) VALUES(9, 7, 3, '45sd89', 140);

-- --------------------------------------------------------

--
-- Structure de la table `typepiece`
--

DROP TABLE IF EXISTS `typepiece`;
CREATE TABLE IF NOT EXISTS `typepiece` (
  `idType` int(11) NOT NULL AUTO_INCREMENT,
  `Type` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`idType`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;

--
-- Déchargement des données de la table `typepiece`
--

INSERT INTO `typepiece` (`idType`, `Type`) VALUES(1, 'Vanne');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(2, 'CapteurTemperature');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(3, 'Verrin');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(4, 'Levier');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(5, 'Flexible');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(6, 'Moteur');
INSERT INTO `typepiece` (`idType`, `Type`) VALUES(7, 'Bouchon');

--
-- Contraintes pour les tables déchargées
--

--
-- Contraintes pour la table `pieces`
--
ALTER TABLE `pieces`
  ADD CONSTRAINT `FK_pieces_idMarque` FOREIGN KEY (`idMarque`) REFERENCES `marque` (`idMarque`),
  ADD CONSTRAINT `FK_pieces_idType` FOREIGN KEY (`idType`) REFERENCES `typepiece` (`idType`);

