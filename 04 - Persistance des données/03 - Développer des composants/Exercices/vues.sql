DROP VIEW IF EXISTS etudiants_epreuves;
CREATE VIEW etudiants_epreuves AS
SELECT
    e.idEtudiant,
    e.nomEtudiant,
    e.prenomEtudiant,
    e.adresseEtudiant,
    e.villeEtudiant,
    e.codePostalEtudiant,
    e.telephoneEtudiant,
    e.dateEntreeEtudiant,
    e.anneeEtudiant,
    e.remarqueEtudiant,
    e.sexeEtudiant,
    e.dateNaissanceEtudiant,
    e.HOBBY,
    ep.libelleEpreuve,
    ep.idEnseignantEpreuve,
    ep.idMatiereEpreuve,
    ep.dateEpreuve,
    ep.CoefficientEpreuve,
    ep.anneeEpreuve,
    a.note,
    a.idAvoirNote
FROM
    avoir_note a
INNER JOIN etudiants e ON
    e.idEtudiant = a.idEtudiant
INNER JOIN epreuves ep ON
    ep.idEpreuve = a.idEpreuve;