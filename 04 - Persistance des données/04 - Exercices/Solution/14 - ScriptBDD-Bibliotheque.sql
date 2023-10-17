DROP DATABASE IF EXISTS Bibliotheque;
CREATE DATABASE IF NOT EXISTS Bibliotheque;
USE Bibliotheque;

--
--  EtatsReserves
--

CREATE TABLE EtatsReserves(
   IdEtatReserve INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   LibelleEtatReserve VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Themes
--

CREATE TABLE Themes(
   IdTheme INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   NomTheme VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Auteurs
--

CREATE TABLE Auteurs(
   IdAuteur INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   NomAutheur VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Genres
--

CREATE TABLE Genres(
   IdGenre INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   NomGenre VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Editeurs
--

CREATE TABLE Editeurs(
   IdEditeur INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   NomEditeur VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Usures
--

CREATE TABLE Usures(
   IdUsure INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   CodeUsure VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  CategoriesProfessionnelles
--

CREATE TABLE CategoriesProfessionnelles(
   IdCategorieProfessionnelle INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   LibelleCategPro VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  MotsCles
--

CREATE TABLE MotsCles(
   IdMotCle INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   LibelleMotCle VARCHAR(50)
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Livres
--

CREATE TABLE Livres(
   IdLivre INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   TitreLivre VARCHAR(50) ,
   CodeCatalogue VARCHAR(50) ,
   IdEditeur INT NOT NULL,
   IdTheme INT NOT NULL
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Exemplaires
--

CREATE TABLE Exemplaires(
   IdExemplaire INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   DateAcquisition DATE,
   Disponibilite BOOLEAN,
   CodeRayon VARCHAR(50) ,
   IdUsure INT NOT NULL,
   IdLivre INT NOT NULL
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Abonnes
--

CREATE TABLE Abonnes(
   IdAbonne INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   MatriculeAbonne VARCHAR(50) ,
   NomAbonne VARCHAR(50) ,
   AdresseAbonne VARCHAR(50) ,
   TelephoneAbonne VARCHAR(50) ,
   DateAdhesion DATE,
   DateNaissance DATE,
   IdCategorieProfessionnelle INT NOT NULL
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Reservations
--

CREATE TABLE Reservations(
   IdReservations INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   IdEtatReserve INT,
   IdLivre INT,
   IdAbonne INT,
   DateDebutReservation DATETIME,
   DateDemandeReservation DATETIME
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Definitions
--

CREATE TABLE Definitions(
   IdDefinitions INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   IdGenre INT,
   IdLivre INT
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Compositions
--

CREATE TABLE Compositions(
   IdCompositions INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   IdAuteur INT,
   IdLivre INT
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  EmpruntExemplaires
--

CREATE TABLE EmpruntExemplaires(
   IdEmpruntExemplaires INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   IdExemplaire INT,
   IdAbonne INT,
   DateEmprunt DATETIME,
   DateRetourEffective DATETIME
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

--
--  Identifications
--

CREATE TABLE Identifications(
   IdIdentification INT AUTO_INCREMENT NOT NULL PRIMARY KEY,
   IdLivre INT,
   IdMotCle INT
)ENGINE=InnoDB CHARSET=utf8 COLLATE=utf8_general_ci;

ALTER TABLE 
   Livres
ADD
   CONSTRAINT FK_Livres_Editeurs FOREIGN KEY(IdEditeur) REFERENCES Editeurs(IdEditeur),
ADD
   CONSTRAINT FK_Livres_Themes FOREIGN KEY(IdTheme) REFERENCES Themes(IdTheme);

ALTER TABLE
   Exemplaires
ADD
   CONSTRAINT FK_Exemplaires_Usures FOREIGN KEY(IdUsure) REFERENCES Usures(IdUsure),
ADD
   CONSTRAINT FK_Exemplaires_Livres FOREIGN KEY(IdLivre) REFERENCES Livres(IdLivre);

ALTER TABLE
   Abonnes
ADD
   CONSTRAINT FK_Abonnes_CategoriesProfessionnelles FOREIGN KEY(IdCategorieProfessionnelle) REFERENCES CategoriesProfessionnelles(IdCategorieProfessionnelle);

ALTER TABLE
   Reservations
ADD
   CONSTRAINT FK_Reservations_EtatsReserves FOREIGN KEY(IdEtatReserve) REFERENCES EtatsReserves(IdEtatReserve),
ADD
   CONSTRAINT FK_Reservations_Livres FOREIGN KEY(IdLivre) REFERENCES Livres(IdLivre),
ADD
   CONSTRAINT FK_Reservations_Abonnes FOREIGN KEY(IdAbonne) REFERENCES Abonnes(IdAbonne);

ALTER TABLE
   Definitions
ADD
   CONSTRAINT FK_Definitions_Genres FOREIGN KEY(IdGenre) REFERENCES Genres(IdGenre),
ADD
   CONSTRAINT FK_Definitions_Livres FOREIGN KEY(IdLivre) REFERENCES Livres(IdLivre);

ALTER TABLE
   Compositions
ADD
   CONSTRAINT FK_Compositions_Auteurs FOREIGN KEY(IdAuteur) REFERENCES Auteurs(IdAuteur),
ADD
   CONSTRAINT FK_Compositions_Livres FOREIGN KEY(IdLivre) REFERENCES Livres(IdLivre);

ALTER TABLE
   EmpruntExemplaires
ADD
   CONSTRAINT FK_EmpruntExemplaires_Exemplaires FOREIGN KEY(IdExemplaire) REFERENCES Exemplaires(IdExemplaire),
ADD
   CONSTRAINT FK_EmpruntExemplaires_Abonnes FOREIGN KEY(IdAbonne) REFERENCES Abonnes(IdAbonne);

ALTER TABLE
   Identifications
ADD
   CONSTRAINT FK_Identifications_Livres FOREIGN KEY(IdLivre) REFERENCES Livres(IdLivre),
ADD
   CONSTRAINT FK_Identifications_MotsCles FOREIGN KEY(IdMotCle) REFERENCES MotsCles(IdMotCle);