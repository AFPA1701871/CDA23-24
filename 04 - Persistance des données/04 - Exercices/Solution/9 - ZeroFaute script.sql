CREATE DATABASE IF NOT EXISTS ZeroFaute; 
USE ZeroFaute;

#========================================
# Table : Categories
#========================================

DROP TABLE IF EXISTS Categories;
CREATE TABLE Categories(
   IdCategorie INT AUTO_INCREMENT PRIMARY KEY ,
   NomCategorie VARCHAR(50) ,
   DescriptionCategorie TEXT,
   IdCategoriePere INT NOT NULL
) ENGINE = InnoDB, CHARSET = UTF8;


#========================================
# Table : Modeles
#========================================

DROP TABLE IF EXISTS Modeles;
CREATE TABLE Modeles(
   codeModele VARCHAR(8) AUTO_INCREMENT PRIMARY KEY ,
   NomModele VARCHAR(50) ,
   DateModele DATE,
)ENGINE = InnoDB,CHARSET = UTF8;


#========================================
# Table : Produits
#========================================

DROP TABLE IF EXISTS Produits;
CREATE TABLE Produits(
   IdProduit INT AUTO_INCREMENT PRIMARY KEY,
   NumSerie VARCHAR(6) ,
   NumProduit VARCHAR(4) ,
   codeModele VARCHAR(8)  NOT NULL  
) ENGINE = InnoDB, CHARSET = UTF8;


#========================================
# Table : Fautes
#========================================

DROP TABLE IF EXISTS Fautes;
CREATE TABLE Fautes(
   IdFaute INT AUTO_INCREMENT PRIMARY KEY,
   Titre_Faute VARCHAR(50) ,
   DateDetection DATE,
   Commentaire TEXT,
   DateReparation DATE,
   IdProduit INT NOT NULL,
   IdCategorie INT NOT NULL
)ENGINE = InnoDB,CHARSET = UTF8;

ALTER TABLE Categories ADD CONSTRAINT FK_Categories_Categories FOREIGN KEY(IdCategoriePere) REFERENCES Categories(IdCategorie);
ALTER TABLE Produits ADD CONSTRAINT FK_Produits_Modeles  FOREIGN KEY(codeModele) REFERENCES Modeles(codeModele);
ALTER TABLE Fautes ADD CONSTRAINT FK_Fautes_Produits   FOREIGN KEY(IdProduit) REFERENCES Produits(IdProduit);
ALTER TABLE Fautes ADD CONSTRAINT FK_Fautes_Categories   FOREIGN KEY(IdCategorie) REFERENCES Categories(IdCategorie);