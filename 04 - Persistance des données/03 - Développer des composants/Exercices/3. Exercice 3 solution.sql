Ecrire des requêtes SELECT. Vous vérifierez que le résultat de la requête correspond à votre inspection des
tables correspondantes. 


A)Les noms des étudiants nés avant l''étudiant « JULES LECLERCQ »
SELECT `nomEtudiant`, `prenomEtudiant`, `dateNaissanceEtudiant` FROM `etudiants` WHERE `dateNaissanceEtudiant` <( SELECT `dateNaissanceEtudiant` FROM `etudiants` WHERE `nomEtudiant` = "LECLERCQ" AND prenomEtudiant = "Jules" )
B) Les noms et notes des étudiants qui ont,à l''épreuve 4, une note supérieure à la moyenne de cette épreuve.
SELECT CONCAT( etudiants.nomEtudiant, " ", etudiants.prenomEtudiant ) AS nom, note FROM etudiants INNER JOIN avoir_note ON etudiants.idEtudiant = avoir_note.idEtudiant WHERE avoir_note.idEpreuve = 4 AND note >( SELECT ROUND(AVG(note)) FROM avoir_note WHERE avoir_note.idEpreuve = 4 )
C) Le nom des étudiants qui ont obtenu un 12 ou plus.
SELECT e.nomEtudiant,e.prenomEtudiant, note FROM etudiants as e INNER JOIN avoir_note as a ON e.idEtudiant = a.idEtudiant WHERE note >=12
D)Le nom des étudiants qui ont dans l''épreuve 4 une note supérieure à celle obtenue par « LUC DUPONT »(à cette même épreuve).
SELECT e.nomEtudiant, e.prenomEtudiant, note FROM avoir_note AS a INNER JOIN etudiants AS e ON a.idEtudiant = e.idEtudiant WHERE note >( SELECT note FROM avoir_note INNER JOIN etudiants ON avoir_note.idEtudiant = etudiants.idEtudiant WHERE nomEtudiant = "DUPONT" AND prenomEtudiant = "LUC" AND avoir_note.idEpreuve = 4 ) AND a.idEpreuve = 4
E) Le nom des étudiants qui partagent une ou plusieurs notes avec « LUC DUPONT ».
SELECT e.nomEtudiant, e.prenomEtudiant, note FROM avoir_note AS a INNER JOIN etudiants AS e ON a.idEtudiant = e.idEtudiant WHERE note IN ( SELECT note FROM avoir_note INNER JOIN etudiants ON avoir_note.idEtudiant = etudiants.idEtudiant WHERE nomEtudiant = "DUPONT" AND prenomEtudiant = "LUC" )
F) Ajoutez une colonne HOBBY à la table ETUDIANT. Cette colonne est de type chaine sur 20 caractères.
Par défaut le HOBBY est mis à SPORT. 
ALTER TABLE etudiants ADD HOBBY varchar(20) NOT NULL DEFAULT "Sport"
G) Ajouter à la table ETUDIANT une colonne NEWCOL de type INTEGER (vérifier en affichant la
structure de la table) puis la supprimer (vérifier de nouveau la suppression).
ALTER TABLE etudiants ADD NewCol int 
ALTER TABLE etudiants DROP NewCol
H) Vérifiez que PREnomEtudiant peut ne pas avoir de contenu puis indiquez que la colonne PREnomEtudiant
doit obligatoirement avoir une valeur. Vérifiez sur la description de la table.
ALTER TABLE etudiants MODIFY prenomEtudiant VARCHAR(50) NOT NULL
ALTER TABLE etudiants CHANGE prenomEtudiant prenomEtudiant VARCHAR(50) NULL
I)Insérez les enregistrements suivants: 7, 'interro écrite',9,1,'21-oct-96',1 dans EPREUVE 
INSERT INTO `epreuves`(`idEpreuve`, `libelleEpreuve`, `idEnseignantEpreuve`, `idMatiereEpreuve`, `dateEpreuve`, `CoefficientEpreuve`, `anneeEpreuve`) VALUES (7,'interro ecrite',9,1,'1996-10-21',1,null);
1,7,10
2,7,08
3,7,05
4,7,09 
17,3,15 dans AVOIR_NOTE
INSERT INTO `avoir_note`(`idAvoirNote`, `idEtudiant`, `idEpreuve`, `note`) VALUES (null,1,7,10),(null,2,7,8),(null,3,7,5),(null,4,7,9),(null,17,3,15);
J) Changez la note de n°3 dans l''épreuve7, elle passe à 07. Vérifiez les valeurs avant et après la requête.
UPDATE avoir_note SET note = 7 WHERE idEtudiant=3 and idEpreuve=7;
K) N°1 a mis de la bonne volonté, on augmente sa note dans l'épreuve 7 de 1 point. Vérifiez.
UPDATE avoir_note SET note = note +1 WHERE idEtudiant=1 and idEpreuve=7
L) Détruisez l'épreuve 7 qui a été annulée pour cause de tricherie et les notes qui lui correspondent. Vérifiez.
DELETE FROM avoir_note WHERE idEpreuve=7;
DELETE FROM epreuves WHERE idEpreuve=7;
M)Réflexion : N''y aurait-il pas eu moyen de détruire les notes de l''épreuve automatiquement dès la destruction de l''épreuve ?
ALTER TABLE `avoir_note` DROP FOREIGN KEY `FK_AvoirNote_Epreuves`; 
ALTER TABLE `avoir_note` ADD CONSTRAINT `FK_AvoirNote_Epreuves` FOREIGN KEY (`idEpreuve`) REFERENCES `epreuves`(`idEpreuve`) ON DELETE CASCADE ON UPDATE RESTRICT;
N) Changez toutes les notes de MARKE dans la matière « BASES DE DONNEES ». Suite à un mauvais comportement, elles diminuent toutes de 3 points. Attention, la requête doit intégrer le nom de la matière.
(et non chercher à repérer le numéro avant de la taper.)
UPDATE avoir_note 
    SET avoir_note.note = avoir_note.note -3
    WHERE avoir_note.idEpreuve IN (
        SELECT epreuves.idEpreuve
        FROM epreuves
        WHERE epreuves.idMatiereEpreuve =(
            SELECT matieres.idMatiere
            FROM matieres
            WHERE matieres.nomMatiere="BD"))
    AND avoir_note.idEtudiant = (
        SELECT etudiants.idEtudiant
        FROM etudiants
        WHERE etudiants.nomEtudiant="MARKE");
UPDATE avoir_note
INNER Join etudiants ON avoir_note.idEtudiant = etudiants.idEtudiant
INNER JOIN epreuves ON avoir_note.idEpreuve = epreuves.idEpreuve
INNER JOIN matieres ON epreuves.idMatiereEpreuve = matieres.idMatiere
Set note = note -3
Where  nomEtudiant = "Marke"
AND nomMatiere = "BD"
);
O) DEWA a manqué l''épreuve 4. Vu son niveau, on décide de lui créer une entrée dans AVOIR_NOTE en lui
attribuant la moyenne des notes obtenues à cette épreuve par ses collègues*0.9. Attention, la requête doit
intégrer le nom de l''étudiant (et non chercher à repérer le numéro avant de la taper.)
INSERT INTO avoir_note VALUES(NULL,
        (SELECT etudiants.idEtudiant
        FROM etudiants
        WHERE etudiants.nomEtudiant = "DEWA")
    ,4,
        (SELECT (AVG(anote.note)*0.9)
        FROM avoir_note as anote
        WHERE anote.idEpreuve = 4)
    );
ou
START TRANSACTION;
SELECT @newNote:=ROUND(AVG(note)*0.9,2) FROM Avoir_note WHERE idEpreuve = 4;
SELECT @newID:=idEtudiant FROM Etudiants WHERE UPPER(nomEtudiant)="DEWA";
INSERT INTO Avoir_note (idEtudiant, idEpreuve, note) VALUES (@newID, 4, @newNote);
COMMIT;
P)Insérez un nouvel étudiant dont vous ne connaissez que le numéro, le nom, le prénom, le hobby et
l''année: 25, 'DARTE','REMY','SCULPTURE',1.
INSERT INTO etudiants (idEtudiant,`nomEtudiant`,`prenomEtudiant`,`hobbyEtudiant`,`anneeEtudiant`)
    VALUES (25,"DARTE", "REMY", "SCULPTURE", 1)