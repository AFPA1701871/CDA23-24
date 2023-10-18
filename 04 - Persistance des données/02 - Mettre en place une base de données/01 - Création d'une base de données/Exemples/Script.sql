CREATE DATABASE IF NOT EXISTS test;
USE test;
-- DROP TABLE IF EXISTS Utilisateurs;
CREATE TABLE Utilisateurs(
   idUtilisateur INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   nomUtilisateur VARCHAR(50)  NOT NULL,
   dateDebut DATE ,
   dateFin DATE ,
   email VARCHAR(50) NOT NULL UNIQUE
);
ALTER TABLE Utilisateurs ADD COLUMN prenom VARCHAR(50) AFTER nomUtilisateur;

-- relation 0.1 - 1.1
-- 
-- Table Joueurs
--
CREATE TABLE Joueurs(
   idJoueur INT AUTO_INCREMENT PRIMARY KEY,
   nomJoueur VARCHAR(100) 
) ENGINE=InnoDB;

-- 
-- Table Equipes
--
CREATE TABLE Equipes(
   idEquipe INT AUTO_INCREMENT PRIMARY KEY,
   nomEquipe VARCHAR(100) ,
   idJoueur INT NOT NULL UNIQUE
)ENGINE=InnoDB;

ALTER TABLE equipes ADD CONSTRAINT FK_Equipes_Joueurs FOREIGN KEY (idJoueur) REFERENCES joueurs(idJoueur);

-- relation 0.1 - 1.n
DROP TABLE Equipes, Joueurs;
CREATE TABLE Equipes(
   idEquipe INT AUTO_INCREMENT PRIMARY KEY,
   nomEquipe VARCHAR(100) 
)ENGINE=InnoDB;

-- 
-- Table Joueurs
--
CREATE TABLE Joueurs(
   idJoueur INT AUTO_INCREMENT PRIMARY KEY,
   nomJoueur VARCHAR(100) ,
   idEquipe INT
)ENGINE=InnoDB;

ALTER TABLE Joueurs ADD CONSTRAINT FK_Joueurs_Equipes FOREIGN KEY(idEquipe) REFERENCES Equipes(idEquipe);

-- 2 relations (dirige et participe)
DROP TABLE Equipes, Joueurs;
CREATE TABLE Equipes(
   idEquipe INT AUTO_INCREMENT PRIMARY KEY,
   nomEquipe VARCHAR(100),
   idJoueur INT 
)ENGINE=InnoDB;

-- 
-- Table Joueurs
--
CREATE TABLE Joueurs(
   idJoueur INT AUTO_INCREMENT PRIMARY KEY,
   nomJoueur VARCHAR(100) ,
   idEquipe INT
)ENGINE=InnoDB;

ALTER TABLE Joueurs ADD CONSTRAINT FK_Joueurs_Equipes FOREIGN KEY(idEquipe) REFERENCES Equipes(idEquipe);
ALTER TABLE Equipes ADD CONSTRAINT FK_Equipes_Joueurs FOREIGN KEY (idJoueur) REFERENCES Joueurs(idJoueur);

--table associative
DROP DATABASE Test;
CREATE DATABASE IF NOT EXISTS test;
USE test;
-- Table Joueurs
--
CREATE TABLE Joueurs(
   idJoueur INT AUTO_INCREMENT PRIMARY KEY,
   nomJoueur VARCHAR(100) 
)ENGINE=InnoDB;

-- 
-- Table Equipes
--
CREATE TABLE Equipes(
   idEquipe INT AUTO_INCREMENT PRIMARY KEY,
   nomEquipe VARCHAR(100) 
)ENGINE=InnoDB;

-- 
-- Table Participations
--
-- AVANT
-- CREATE TABLE Participations(
--    idJoueur INT,
--    idEquipe INT,
--    PRIMARY KEY(idJoueur, idEquipe),
--    FOREIGN KEY(idJoueur) REFERENCES Joueurs(idJoueur),
--    FOREIGN KEY(idEquipe) REFERENCES Equipes(idEquipe)
-- );


CREATE TABLE Participations(
   idParticipation INT AUTO_INCREMENT PRIMARY KEY,
   idJoueur INT,
   idEquipe INT
)ENGINE=InnoDB;

-- constraintes clés étrangères
ALTER TABLE Participations ADD CONSTRAINT FK_Participations_Joueurs FOREIGN KEY(idJoueur) REFERENCES Joueurs(idJoueur);
ALTER TABLE Participations ADD CONSTRAINT FK_Participations_Equipes FOREIGN KEY(idEquipe) REFERENCES Equipes(idEquipe);


--Vider la table
Truncate Joueurs;

-- relation récursive
CREATE TABLE JoueursRecurs(
   idJoueur INT AUTO_INCREMENT PRIMARY KEY,
   nomJoueur VARCHAR(100) ,
   dirigeant INT COMMENT "contient un idJoueur"
  
);

 ALTER TABLE JoueursRecurs ADD CONSTRAINT FK_Joueurs_Joueurs FOREIGN KEY(dirigeant) REFERENCES JoueursRecurs(idJoueur);

 -- Gestion des droits
 ALTER TABLE `equipes` 
    ADD `dateCreation` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP , 
    ADD `dateModification` DATETIME on update CURRENT_TIMESTAMP NULL DEFAULT NULL;