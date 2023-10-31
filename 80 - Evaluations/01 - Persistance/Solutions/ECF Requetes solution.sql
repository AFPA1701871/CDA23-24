

# 1. Obtenir la liste des villes qui ont un nom d''au moins 40 lettres
SELECT ville_nom 
FROM villes_france 
WHERE length(Ville_nom)>=40;

# 2. Obtenir la liste des départements d’outres-mer, c’est-à-dire ceux dont le numéro de département commence par “97”

SELECT departement_nom 
FROM departements 
WHERE departement_code LIKE '97%';

# 3. Obtenir la liste des départements  des Hauts-de-France trier par ordre alphabétique des noms de département (sans jointure)
SELECT departement_nom 
FROM departements 
WHERE departement_regionId = (select region_id from regions where regions.region_nom="Hauts-de-France")
ORDER BY departement_nom ;

# 4. Obtenir le nom de toutes les villes, ainsi que le nom du département associé.
# Les plus peuplées en 2012 apparaitront en premier

SELECT ville_nom, departement_nom 
FROM villes_france 
LEFT JOIN departements ON departement_code = ville_departement
ORDER BY ville_population_2012 DESC ;

# 5. Obtenir la liste du nom de chaque département, associé à son code et du nombre de commune au sein de ces départements, en triant afin d’obtenir en priorité les départements qui possèdent le plus de communes

SELECT departement_nom, departement_code, COUNT(*) AS nbr_items 
FROM villes_france 
LEFT JOIN departements ON departement_code = ville_departement
GROUP BY ville_departement
ORDER BY nbr_items DESC;

# 6. Obtenir la liste des départements, classés en fonction de leur superficie (plus grand en premier)

SELECT departement_nom, departement_code, FLOOR(SUM(ville_surface)) AS dpt_surface 
FROM villes_france 
LEFT JOIN departements ON departement_code = ville_departement
GROUP BY ville_departement  
ORDER BY dpt_surface  DESC;

# 7. Compter le nombre de villes dont le nom commence par “Saint”

SELECT COUNT(*) 
FROM villes_france 
WHERE ville_nom LIKE 'saint%';

# 8. Obtenir la liste des villes qui ont un nom existants plusieurs fois, et trier afin d’obtenir en premier celles dont le nom est le plus souvent utilisé par plusieurs communes

SELECT ville_nom, COUNT(*) AS nbt_item 
FROM villes_france 
GROUP BY ville_nom 
#HAVING COUNT(*)>1
ORDER BY nbt_item DESC;

# 9. Obtenir la liste des villes dont la superficie est supérieure à la superficie moyenne

SELECT ville_nom, ville_surface 
FROM villes_france 
WHERE ville_surface > (SELECT AVG(ville_surface) FROM villes_france);

# 10. Obtenir la liste des codes départements qui possèdent plus de 1.5 millions d’habitants en 2012

SELECT ville_departement, SUM(ville_population_2012) AS population_2012
FROM villes_france 
GROUP BY ville_departement
HAVING population_2012 > 1500000
ORDER BY population_2012 DESC;

# 11. Remplacez les tirets par un espace vide, pour toutes les villes commençant par “SAINT-” (dans la colonne qui contient les noms en majuscule)

#UPDATE villes_france 
#SET ville_nom = REPLACE(ville_nom, '-', ' ') 
#WHERE ville_nom LIKE 'SAINT-%';



# 12. Facultatif. Obtenir la liste des 50 villes ayant la plus faible superficie

SELECT DISTINCT ville_nom
FROM villes_france 
ORDER BY ville_surface ASC 
LIMIT 50;

# 13. Ajouter une colonne region_nbDepartement dans la table regions (mettre le code dans le script de réponse)

ALTER TABLE regions ADD region_nbDepartement INT NULL;

# 14. Ecrire une procédure stockée, qui vient mettre à jour cette colonne

DELIMITER $$
CREATE PROCEDURE MAJRegion()
update regions set region_nbDepartement = (select count(*) from departements where departements.departement_regionId=regions.region_id)
$$
DELIMITER ;

# 15. Créer une vue qui regroupe les 3 tables
CREATE VIEW France as
SELECT
    v.ville_id,
    v.ville_departement,
    v.ville_slug,
    v.ville_nom,
    v.ville_nom_simple,
    v.ville_nom_reel,
    v.ville_nom_soundex,
    v.ville_nom_metaphone,
    v.ville_code_postal,
    v.ville_commune,
    v.ville_code_commune,
    v.ville_arrondissement,
    v.ville_canton,
    v.ville_amdi,
    v.ville_population_2010,
    v.ville_population_1999,
    v.ville_population_2012,
    v.ville_densite_2010,
    v.ville_surface,
    v.ville_longitude_deg,
    v.ville_latitude_deg,
    v.ville_longitude_grd,
    v.ville_latitude_grd,
    v.ville_longitude_dms,
    v.ville_latitude_dms,
    v.ville_zmin,
    v.ville_zmax,
    d.departement_id,
    d.departement_code,
    d.departement_nom,
    d.departement_nom_uppercase,
    d.departement_slug,
    d.departement_nom_soundex,
    r.region_id,
    r.region_nom,
    r.region_nbDepartement
FROM
    villes_france as v
    INNER JOIN departements as d ON v.ville_departement=d.departement_code
    INNER JOIN regions as r ON d.departement_regionId=r.region_id
