DROP DATABASE IF EXISTS LutinsPereNoel;
CREATE DATABASE LutinsPereNoel DEFAULT CHARACTER SET Utf8;

Use LutinsPereNoel;


CREATE TABLE Enfants(
    IdEnfant INT AUTO_INCREMENT PRIMARY KEY,
    NomEnfant VARCHAR(100),
    PrenomEnfant VARCHAR(100),
    AdresseEnfant VARCHAR(255),
    Sexe VARCHAR(1),
    Voeu TEXT,
    PourcentageSagesse DOUBLE
) ENGINE = InnoDB;

CREATE TABLE Lutins(
    IdLutin INT AUTO_INCREMENT PRIMARY KEY,
    NumeroLutin VARCHAR(10) UNIQUE,
    NomLutin VARCHAR(100),
    PrenomLutin VARCHAR(100)
) ENGINE = InnoDB;

CREATE TABLE Traineaux(
    IdTraineau INT AUTO_INCREMENT PRIMARY KEY,
    NumeroTraineau VARCHAR(10) UNIQUE,
    TailleTraineau INT,
    DateMiseEnService DATE,
    DateDerniereRevision DATE
) ENGINE = InnoDB;

CREATE TABLE Rennes(
    IdRenne INT AUTO_INCREMENT PRIMARY KEY,
    NomRenne VARCHAR(100) UNIQUE,
    SexeRenne VARCHAR(1),
    DateNaissance DATE
) ENGINE = InnoDB;

CREATE TABLE Tournees(
    IdTournee INT AUTO_INCREMENT PRIMARY KEY,
    NumeroTournee VARCHAR(10) UNIQUE,
    HeureDepart TIME,
    IdLutin INT NOT NULL,
    IdTraineau INT NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Cadeaux(
    IdCadeau INT AUTO_INCREMENT PRIMARY KEY,
    NumeroCadeau VARCHAR(10) UNIQUE,
    Designation VARCHAR(100),
    IdTournee INT NOT NULL,
    IdEnfant INT NOT NULL
) ENGINE = InnoDB;

CREATE TABLE Attelages(
    IdAttelages INT AUTO_INCREMENT PRIMARY Key,
    IdTraineau INT,
    IdRenne INT
) ENGINE = InnoDB;

CREATE TABLE Responsables(
    IdResponsables INT AUTO_INCREMENT PRIMARY Key,
    IdLutin INT,
    IdTraineau INT,
    DateResponsabilite DATE
) ENGINE = InnoDB;


ALTER TABLE
    Tournees
ADD
    CONSTRAINT FK_Tournees_Lutins FOREIGN KEY(IdLutin) REFERENCES Lutins(IdLutin),
ADD
    CONSTRAINT FK_Tournees_Traineaux FOREIGN KEY(IdTraineau) REFERENCES Traineaux(IdTraineau);

ALTER TABLE
    Cadeaux
ADD
    CONSTRAINT FK_Cadeaux_Tournees FOREIGN KEY(IdTournee) REFERENCES Tournees(IdTournee),
ADD
    CONSTRAINT FK_Cadeaux_Enfants FOREIGN KEY(IdEnfant) REFERENCES Enfants(IdEnfant);


ALTER TABLE
    Attelages
ADD
    CONSTRAINT FK_Attelages_Traineaux FOREIGN KEY(IdTraineau) REFERENCES Traineaux(IdTraineau),
ADD
    CONSTRAINT FK_Attelages_Rennes FOREIGN KEY(IdRenne) REFERENCES Rennes(IdRenne);



ALTER TABLE
    Responsables
ADD
    CONSTRAINT FK_Responsables_Lutins FOREIGN KEY(IdLutin) REFERENCES Lutins(IdLutin),
ADD
    CONSTRAINT FK_Responsables_Traineaux FOREIGN KEY(IdTraineau) REFERENCES Traineaux(IdTraineau)