#========================================
#             SCRIPT MYSQL
#========================================

DROP DATABASE IF EXISTS agenceVoyages  ;
CREATE DATABASE agenceVoyages DEFAULT CHARACTER SET utf8;
USE agenceVoyages;

#========================================
# Table : Clients
#========================================
CREATE TABLE Clients(
	numero INT PRIMARY KEY,
	nom VARCHAR(100)  NOT NULL ,
	prenom VARCHAR(100) 
)ENGINE = InnoDB;

#========================================
# Table : type
#========================================
CREATE TABLE type(
	idType INT AUTO_INCREMENT PRIMARY KEY ,
	libelleType VARCHAR(50)  NOT NULL
)ENGINE = InnoDB;

#========================================
# Table : Prestations
#========================================
CREATE TABLE Prestations(
	codePrestation INT PRIMARY KEY,
	niveauPrestation INT ,
	prixPublic DECIMAL(15,2)   ,
	photo TEXT ,
	intitulé VARCHAR(50)  ,
	description TEXT ,
	lieu VARCHAR(200)  ,
	idType INT  NOT NULL
)ENGINE = InnoDB;

#========================================
# Table : Achats
#========================================
CREATE TABLE Achats(
	idAchats INT AUTO_INCREMENT PRIMARY KEY ,	codePrestation INT ,
	numero INT ,
	prix DECIMAL(6,2)   NOT NULL
)ENGINE = InnoDB;

ALTER TABLE Prestations ADD CONSTRAINT FK_Prestations_type FOREIGN KEY(idType) REFERENCES type(idType);
ALTER TABLE Achats ADD CONSTRAINT FK_Achats_Prestations FOREIGN KEY(codePrestation) REFERENCES Prestations(codePrestation);
ALTER TABLE Achats ADD CONSTRAINT FK_Achats_Clients FOREIGN KEY(numero) REFERENCES Clients(numero);