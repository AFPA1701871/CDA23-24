#----------------------------------------------
# Script STAGIAIRESAFPA
#----------------------------------------------

DROP DATABASE IF EXISTS StagiairesAfpa;
CREATE DATABASE IF NOT EXISTS StagiairesAfpa;
ALTER DATABASE StagiairesAfpa charset = UTF8;

USE StagiairesAfpa;

#----------------------------------------------
# Table : Stagiaires
#----------------------------------------------

CREATE TABLE Stagiaires(
    idStagiaire int auto_increment NOT NULL PRIMARY KEY,
    nomStagiaire varchar(25) NOT NULL,
    prenomStagiaire varchar(25) NOT NULL,
    adresseStagiaire varchar(50) NOT NULL,
    ville varchar(25) NOT NULL,
    codePostal int NOT NULL,
    telStagiaire varchar(14) NOT NULL,
    dateEntree date NOT NULL,
    SexeStagiaire varchar(1),
    dateNaissance date NOT NULL,
    idFormation int NOT NULL,
    idFormateur int NOT NULL,
    idHebergement int NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Groupes
#----------------------------------------------

CREATE TABLE Groupes(
    idGroupe int auto_increment NOT NULL PRIMARY KEY,
    libelleGroupe varchar(50)
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Formations
#----------------------------------------------

CREATE TABLE Formations(
    idFormation int auto_increment NOT NULL PRIMARY KEY,
    libelleFormation varchar(50) NOT NULL,
    idGroupe int NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Formateurs
#----------------------------------------------

CREATE TABLE Formateurs(
    idFormateur int auto_increment NOT NULL PRIMARY KEY,
    nomFormateur varchar(25) NOT NULL,
    prenomFormateur varchar(25) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Hebergements
#----------------------------------------------

CREATE TABLE Hebergements(
    idHebergement int auto_increment NOT NULL PRIMARY KEY,
    libelleHebergement varchar(50) NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Matieres
#----------------------------------------------

CREATE TABLE Matieres(
    idMatiere int auto_increment NOT NULL PRIMARY KEY,
    nomMatiere varchar(25)
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Animations
#----------------------------------------------

CREATE TABLE Animations(
    idAnimation int auto_increment NOT NULL PRIMARY KEY,
    idFormateur int NOT NULL,
    idFormation int NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Constitutions
#----------------------------------------------

CREATE TABLE Constitutions(
    idConstitution int auto_increment NOT NULL PRIMARY KEY,
    idFormation int NOT NULL,
    idMatiere int NOT NULL
) ENGINE = InnoDB DEFAULT charset = UTF8;

#----------------------------------------------
# Table : Suivis
#----------------------------------------------

CREATE TABLE Suivis(
    idSuivi int auto_increment NOT NULL PRIMARY KEY,
    idStagiaire int NOT NULL,
    idMatiere int NOT NULL,
    note float 
) ENGINE = InnoDB DEFAULT charset = UTF8;

ALTER TABLE Stagiaires
    ADD CONSTRAINT FK_Stagiaires_Hebergements FOREIGN KEY (idHebergement) REFERENCES Hebergements(idHebergement),
    ADD CONSTRAINT FK_Stagiaires_Formateurs FOREIGN KEY (idFormateur) REFERENCES Formateurs(idFormateur),
    ADD CONSTRAINT fk_Stagiaires_Formations FOREIGN KEY (idFormation) REFERENCES Formations(idFormation);

ALTER TABLE Formations
    ADD CONSTRAINT FK_Formations_Groupes FOREIGN KEY (idGroupe) REFERENCES Groupes(idGRoupe);

ALTER TABLE Animations
    ADD CONSTRAINT FK_Animations_Formations FOREIGN KEY (idFormation) REFERENCES Formations(idFormation),
    ADD CONSTRAINT FK_Animations_Formateurs FOREIGN KEY (idFormateur) REFERENCES Formateurs(idFormateur);

ALTER TABLE Constitutions
    ADD CONSTRAINT FK_Constitutions_Formations FOREIGN KEY (idFormation) REFERENCES Formations(idFormation),
    ADD CONSTRAINT FK_Constitutions_Matieres FOREIGN KEY (idMatiere) REFERENCES Matieres(idMatiere);

ALTER TABLE Suivis
    ADD CONSTRAINT FK_Suivis_Stagiaires FOREIGN KEY (idStagiaire) REFERENCES Stagiaires(idStagiaire),
    ADD CONSTRAINT FK_Suivis_Matieres FOREIGN KEY (idMatiere) REFERENCES Matieres(idMatiere);
