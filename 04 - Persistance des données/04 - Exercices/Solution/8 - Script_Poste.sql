DROP DATABASE IF EXISTS Poste;
CREATE DATABASE Poste DEFAULT CHARACTER SET utf8;
Use Poste;

-- 
-- Table Bureaux
--

CREATE TABLE Bureaux(
   idBureau INT AUTO_INCREMENT PRIMARY KEY,
   codePostal VARCHAR(6)
)ENGINE=InnoDB;

-- 
-- Table Types
--

CREATE TABLE Types(
   idType INT AUTO_INCREMENT PRIMARY KEY,
   libelleType VARCHAR(50)
)ENGINE=InnoDB;

-- 
-- Table Courriers
--

CREATE TABLE Courriers(
   idCourrier INT AUTO_INCREMENT PRIMARY KEY,
   rueDestinataire VARCHAR(150)  NOT NULL,
   numDestintaire VARCHAR(5)  NOT NULL,
   rueEmetteur VARCHAR(150) ,
   numEmetteur VARCHAR(50) ,
   idType INT NOT NULL
)ENGINE=InnoDB;

-- 
-- Table Transports
--

CREATE TABLE Transports(
   idTransport INT AUTO_INCREMENT PRIMARY KEY,
   libelleTransport VARCHAR(50) ,
   taxeCarbonne INT
)ENGINE=InnoDB;

-- 
-- Table CentresDeTri
--

CREATE TABLE CentresDeTri(
   idCentresDeTri INT AUTO_INCREMENT PRIMARY KEY,
   nomCentreDeTri VARCHAR(50)
)ENGINE=InnoDB;

-- 
-- Table Acheminements
--

CREATE TABLE Acheminements(
   idAcheminement INT AUTO_INCREMENT PRIMARY KEY,
   idBureau INT,
   idTransport INT,
   idCentresDeTri INT
)ENGINE=InnoDB;

-- 
-- Table Gestions
--

CREATE TABLE Gestions(
   idGestion INT AUTO_INCREMENT PRIMARY KEY,
   idBureau INT,
   idCourrier INT,
   dateEnvoi DATE,
   dateReception DATE
)ENGINE=InnoDB;

ALTER TABLE Courriers ADD CONSTRAINT FK_Courriers_Types FOREIGN KEY(idType) REFERENCES Types(idType);
ALTER TABLE Acheminements 
ADD CONSTRAINT FK_Acheminements_Bureaux FOREIGN KEY(idBureau) REFERENCES Bureaux(idBureau),
ADD CONSTRAINT FK_Acheminements_Transports FOREIGN KEY(idTransport) REFERENCES Transports(idTransport),
ADD CONSTRAINT FK_Acheminements_CentresDeTri FOREIGN KEY(idCentresDeTri) REFERENCES CentresDeTri(idCentresDeTri);
ALTER TABLE Gestions 
ADD CONSTRAINT FK_Gestions_Bureaux FOREIGN KEY(idBureau) REFERENCES Bureaux(idBureau),
ADD CONSTRAINT FK_Gestions_Courriers FOREIGN KEY(idCourrier) REFERENCES Courriers(idCourrier);