CREATE DATABASE exercice3; 
USE    exercice3;
CREATE TABLE etudiants(
    idEtudiant int AUTO_INCREMENT,
    nomEtudiant VARCHAR(20) NOT NULL,
    prenomEtudiant VARCHAR(20),
    adresseEtudiant VARCHAR(40),
    villeEtudiant VARCHAR(10),
    codePostalEtudiant int,
    telephoneEtudiant VARCHAR(14),
    dateEntreeEtudiant DATE,
    anneeEtudiant int,
    remarqueEtudiant VARCHAR(40),
    sexeEtudiant CHAR(1),
    dateNaissanceEtudiant DATE,
    PRIMARY KEY(idEtudiant)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE enseignants(
    idEnseignant int AUTO_INCREMENT,
    nomEnseignant VARCHAR(20) NOT NULL,
    prenomEnseignant VARCHAR(20),
    fonctionEnseignant VARCHAR(25),
    adresseEnseignant VARCHAR(40),
    villeEnseignant VARCHAR(10),
    codePostalEnseignant int,
    telephoneEnseignant VARCHAR(14),
    dateNaissanceEnseignant DATE,
    dateEmbaucheEnseignant DATE,
    PRIMARY KEY(idEnseignant)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE modules(
    idModule int AUTO_INCREMENT,
    nomModule VARCHAR(15) NOT NULL,
    coefficientModule int,
    PRIMARY KEY(idModule)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE matieres(
    idMatiere int AUTO_INCREMENT,
    nomMatiere VARCHAR(15) NOT NULL,
    idModule int,
    coefficientMatiere int,
    PRIMARY KEY(idMatiere)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE epreuves(
    idEpreuve int AUTO_INCREMENT,
    libelleEpreuve VARCHAR(20),
    idEnseignantEpreuve int NOT NULL,
    idMatiereEpreuve int NOT NULL,
    dateEpreuve DATE,
    CoefficientEpreuve int NOT NULL,
    anneeEpreuve int,
    PRIMARY KEY(idEpreuve)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE avoir_note(
    idAvoirNote INT AUTO_INCREMENT,
    idEtudiant int,
    idEpreuve int,
    note int,
    PRIMARY KEY(idAvoirNote)
) ENGINE = INNODB DEFAULT CHARSET = utf8; 
CREATE TABLE faire_cours(
    idFaireCours INT AUTO_INCREMENT,
    idEnseignant int,
    idMatiere int,
    annee int,
    PRIMARY KEY(idFaireCours)
) ENGINE = INNODB DEFAULT CHARSET = utf8;

-- Contraintes --
ALTER TABLE `avoir_note`
  ADD CONSTRAINT `FK_AvoirNote_Epreuves` FOREIGN KEY (`idEpreuve`) REFERENCES `epreuves` (`idEpreuve`),
  ADD CONSTRAINT `FK_AvoirNote_Etudiants` FOREIGN KEY (`idEtudiant`) REFERENCES `etudiants` (`idEtudiant`);

ALTER TABLE `epreuves`
  ADD CONSTRAINT `FK_epreuves_enseignants` FOREIGN KEY (`idEnseignantEpreuve`) REFERENCES `enseignants` (`idEnseignant`),
  ADD CONSTRAINT `FK_epreuves_matieres` FOREIGN KEY (`idMatiereEpreuve`) REFERENCES `matieres` (`idMatiere`);

ALTER TABLE `faire_cours`
  ADD CONSTRAINT `FK_FaireCours_Enseignants` FOREIGN KEY (`idEnseignant`) REFERENCES `enseignants` (`idEnseignant`),
  ADD CONSTRAINT `FK_FaireCours_Matieres` FOREIGN KEY (`idMatiere`) REFERENCES `matieres` (`idMatiere`);

ALTER TABLE `matieres`
  ADD CONSTRAINT `FK_matieres_modules` FOREIGN KEY (`idModule`) REFERENCES `modules` (`idModule`);