DROP DATABASE IF EXISTS Camping;
CREATE DATABASE Camping;
USE Camping;
CREATE TABLE Zones(
   idZone INT AUTO_INCREMENT PRIMARY KEY,
   libelleZone VARCHAR(50)  NOT NULL
);

CREATE TABLE Clients(
   idClient INT AUTO_INCREMENT PRIMARY KEY,
   nomClient VARCHAR(50)  NOT NULL,
   prenomClient VARCHAR(50)  NOT NULL,
   adresseClient VARCHAR(80)  NOT NULL,
   numTelClient VARCHAR(20)  NOT NULL,
   emailClient VARCHAR(50)  NOT NULL
);

CREATE TABLE Activites(
   idActivité INT AUTO_INCREMENT PRIMARY KEY,
   libelleActivite VARCHAR(50)  NOT NULL,
   prixActivite DECIMAL(5,2)  ,
   idZone INT NOT NULL
);

CREATE TABLE Periodes(
   idPeriode INT AUTO_INCREMENT PRIMARY KEY,
   libellePeriode VARCHAR(50)  NOT NULL,
   dateDebutPeriode DATE NOT NULL,
   dateFinPeriode DATE NOT NULL,
   prixDuPoint INT
);

CREATE TABLE TypeEmplacements(
   idTypeEmplacement INT AUTO_INCREMENT PRIMARY KEY,
   libelleType VARCHAR(50)  NOT NULL
);

CREATE TABLE Options(
   idOption INT AUTO_INCREMENT PRIMARY KEY,
   libelleOptions VARCHAR(50)  NOT NULL,
   pointsOptions INT
);

CREATE TABLE Emplacements(
   idEmplacement INT AUTO_INCREMENT PRIMARY KEY,
   num INT NOT NULL,
   parking BOOLEAN NOT NULL,
   ombre BOOLEAN NOT NULL,
   electricite BOOLEAN NOT NULL,
   point INT NOT NULL,
   idTypeEmplacement INT NOT NULL,
   idZone INT NOT NULL
);

CREATE TABLE Reservations(
   idReservation INT AUTO_INCREMENT PRIMARY KEY,
   idEmplacement INT,
   idClient INT,
   idPeriode INT,
   idOption INT,
   dateReservation DATE,
   dateDebutSejour DATE,
   dateFinSejour DATE,
   etatAcompte INT
   
);

ALTER TABLE Activites ADD CONSTRAINT FK_Activites_Zones FOREIGN KEY(idZone) REFERENCES Zones(idZone);
ALTER TABLE Emplacements ADD CONSTRAINT FK_Emplacements_TypeEmplacements  FOREIGN KEY(idTypeEmplacement) REFERENCES TypeEmplacements(idTypeEmplacement);
ALTER TABLE Emplacements ADD CONSTRAINT FK_Emplacements_Zones   FOREIGN KEY(idZone) REFERENCES Zones(idZone);

ALTER TABLE Reservations ADD CONSTRAINT FK_Reservations_Emplacements FOREIGN KEY(idEmplacement) REFERENCES Emplacements(idEmplacement);
ALTER TABLE Reservations ADD CONSTRAINT FK_Reservations_Clients   FOREIGN KEY(idClient) REFERENCES Clients(idClient);
ALTER TABLE Reservations ADD CONSTRAINT FK_Reservations_Periodes   FOREIGN KEY(idPeriode) REFERENCES Periodes(idPeriode);
ALTER TABLE Reservations ADD CONSTRAINT FK_Reservations_Options   FOREIGN KEY(idOption) REFERENCES Options(idOption);