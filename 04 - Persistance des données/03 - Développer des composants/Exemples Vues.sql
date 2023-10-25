-- requetes sur 3 tales
SELECT
    e.nomEtudiant,
    e.prenomEtudiant,
    note,
    ep.libelleEpreuve
FROM avoir_note AS a
INNER JOIN etudiants AS e ON a.idEtudiant = e.idEtudiant
INNER JOIN EPREUVES ep ON a.idEpreuve = ep.idEpreuve

-- creation de la vue

CREATE View etudiants_epreuves as
SELECT e.*,
		ep.*,
        a.idAvoirNote,
        a.note
FROM avoir_note AS a
INNER JOIN etudiants AS e ON a.idEtudiant = e.idEtudiant
INNER JOIN EPREUVES ep ON a.idEpreuve = ep.idEpreuve;

--nouvelle version de la requete
SELECT
    nomEtudiant,
    prenomEtudiant,
    note,
    libelleEpreuve
FROM etudiants_epreuves;

-- jointure de la vue avec une autre table
SELECT `idEnseignant`, `nomEnseignant`, `prenomEnseignant`, `fonctionEnseignant`, `adresseEnseignant`, `villeEnseignant`, `codePostalEnseignant`, `telephoneEnseignant`, `datnaiens`, `dateEmbaucheEnseignant` 
,`idEpreuve`, `libelleEpreuve`, `idMatiereEpreuve`, `dateEpreuve`, `CoefficientEpreuve`, `anneeEpreuve` 
FROM etudiants_epreuves
INNER JOIN `enseignants` ON etudiants_epreuves.idEnseignantEpreuve = enseignants.idEnseignant;


--2eme vue
CREATE VIEW enseignants_epreuves as 
SELECT `idEnseignant`, `nomEnseignant`, `prenomEnseignant`, `fonctionEnseignant`, `adresseEnseignant`, `villeEnseignant`, `codePostalEnseignant`, `telephoneEnseignant`, `datnaiens`, `dateEmbaucheEnseignant` 
,`idEpreuve`, `libelleEpreuve`, `idMatiereEpreuve`, `dateEpreuve`, `CoefficientEpreuve`, `anneeEpreuve` 
FROM `epreuves`
INNER JOIN `enseignants` ON epreuves.idEnseignantEpreuve = enseignants.idEnseignant