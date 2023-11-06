

--
-- Base de données :  gestionrepresentant
--
DROP DATABASE IF EXISTS gestionrepresentant;
CREATE DATABASE IF NOT EXISTS gestionrepresentant ;
USE gestionrepresentant;

-- --------------------------------------------------------

--
-- Structure de la table clients
--

DROP TABLE IF EXISTS clients;
CREATE TABLE IF NOT EXISTS clients (
  IdClient int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  NomClient varchar(25) DEFAULT NULL,
  VilleClient varchar(25) DEFAULT NULL
) ENGINE=InnoDB ;

--
-- Déchargement des données de la table clients
--

INSERT INTO clients (IdClient, NomClient, VilleClient) VALUES
(1, 'Alice', 'Lyon'),
(2, 'Bruno', 'Paris'),
(3, 'Charles', 'Compiègne'),
(4, 'Denis', 'Paris'),
(5, 'Emile', 'Strasbourg'),
(6, 'Charles', 'Paris');

-- --------------------------------------------------------

--
-- Structure de la table produits
--

DROP TABLE IF EXISTS produits;
CREATE TABLE IF NOT EXISTS produits (
  IdProduit int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  NomProduit varchar(25) DEFAULT NULL,
  CouleurProduit varchar(25) DEFAULT NULL,
  PoidsProduit int(11) DEFAULT NULL
) ENGINE=InnoDB ;

--
-- Déchargement des données de la table produits
--

INSERT INTO produits (IdProduit, NomProduit, CouleurProduit, PoidsProduit) VALUES
(1, 'Aspirateur', 'Rouge', 3546),
(2, 'Trottinette', 'Bleu', 1423),
(3, 'Chaise', 'Blanc', 3827),
(4, 'Tapis', 'Rouge', 1423),
(5, 'Bureau', 'Rouge', 2152);

-- --------------------------------------------------------

--
-- Structure de la table representants
--

DROP TABLE IF EXISTS representants;
CREATE TABLE IF NOT EXISTS representants (
  IdRepres int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  NomRepres varchar(25) DEFAULT NULL,
  VilleRepres varchar(25) DEFAULT NULL
) ENGINE=InnoDB ;

--
-- Déchargement des données de la table representants
--

INSERT INTO representants (IdRepres, NomRepres, VilleRepres) VALUES
(1, 'Stephane', 'Lyon'),
(2, 'Benjamin', 'Paris'),
(3, 'Leonard', 'Lyon'),
(4, 'Antoine', 'Brest'),
(5, 'Bruno', 'Bayonne');

-- --------------------------------------------------------

--
-- Structure de la table ventes
--

DROP TABLE IF EXISTS ventes;
CREATE TABLE IF NOT EXISTS ventes (
  IdVente int(11) NOT NULL AUTO_INCREMENT PRIMARY KEY,
  IdRepres int(11) DEFAULT NULL,
  IdProduit int(11) DEFAULT NULL,
  IdClient int(11) DEFAULT NULL,
  Quantite int(11) DEFAULT NULL
) ENGINE=InnoDB ;

--
-- Déchargement des données de la table ventes
--

INSERT INTO ventes (IdVente, IdRepres, IdProduit, IdClient, Quantite) VALUES
(1, 1, 1, 1, 1),
(2, 1, 1, 2, 1),
(3, 2, 2, 3, 1),
(4, 4, 3, 3, 200),
(5, 3, 4, 2, 190),
(6, 1, 3, 2, 300),
(7, 3, 1, 2, 120),
(8, 3, 1, 4, 120),
(9, 3, 4, 4, 2),
(10, 3, 1, 1, 3),
(11, 3, 4, 1, 5),
(12, 3, 1, 3, 1),
(13, 1, 3, 6, 200),
(14, 2, 5, 6, 200),
(15, 3, 1, 2, 3),
(16, 4, 2, 4, 2);

--
-- Contraintes pour la table ventes
--
ALTER TABLE ventes
  ADD CONSTRAINT ventes_ibfk_1 FOREIGN KEY (IdClient) REFERENCES clients (IdClient),
  ADD CONSTRAINT ventes_ibfk_2 FOREIGN KEY (IdProduit) REFERENCES produits (IdProduit),
  ADD CONSTRAINT ventes_ibfk_3 FOREIGN KEY (IdRepres) REFERENCES representants (IdRepres);
