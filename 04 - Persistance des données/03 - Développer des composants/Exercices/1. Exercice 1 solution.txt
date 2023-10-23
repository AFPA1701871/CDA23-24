Ecrivez des requêtes SELECT (A chaquefois ,vous stockerez la requete dans un fichier texte» pour
a. Affichez la totalité de la table « client ».
SELECT * FROM `clients`
b. Affichez les noms de tous les clients.
SELECT `nomClient` FROM `clients`
SELECT DISTINCT `nomClient` FROM `clients`
c. Affichez les différentes dates de commandes sans répétition.
SELECT distinct `dateCommande` FROM `commandes` 
d. Affichez les clients qui se prénomment « sophie ».
SELECT nomClient FROM `clients` WHERE `prenomClient`="Sophie"
e. Affichez les numéros des articles et leur quantite commandés par le client 2.
SELECT `idArticle`,`quantiteCommande` FROM `commandes` WHERE `idClient`=2
f. Affichez les noms des clients en majuscules-.
SELECT UPPER(`nomClient`) FROM `clients`
SELECT UCASE(`nomClient`) FROM `clients`
g. Affichez les noms des clients avec la première lettre en majuscule.
SELECT CONCAT(UPPER(LEFT(nomClient,1)),LOWER(substring(nomClient,2))) as Nom FROM `clients`
SELECT CONCAT( UPPER(SUBSTRING(nomClient, 1, 1)), LOWER(SUBSTRING(nomClient, 2)) ) AS Nom FROM `clients`
h. Affichez les noms des clients qui ont 5caractères.
SELECT `nomClient` FROM `clients` WHERE length(`nomClient`)=5
i. Affichez les noms des clients qui commencent par « t » ou qui ont un « l » en troisième position.
SELECT `nomClient` FROM `clients` WHERE `nomClient` like "__l%" or "t%"
SELECT `nomClient` FROM `clients` WHERE substring(`nomClient`,1,1) ="t" or substring(`nomClient`,3,1) ="l"
SELECT `nomClient` FROM `clients` WHERE nomClient like "t%" or substring(`nomClient`,3,1) ="l"
j. Affichez le numéro de client, le numéro de commande, la date de commande et la date de paiement
attendue des commandes (=date_cde+15jours).
SELECT `idClient`,`idCommande`,`dateCommande`,date_add(`dateCommande`,Interval 15 day) as "date de paiement" FROM `commandes`
SELECT `idClient`,`idCommande`,`dateCommande`,adddate(`dateCommande`, 15) as "date de paiement" FROM `commandes`
k. Affichez la date et l'heure actuelles.
SELECT now()
SELECT CURRENT_TIMESTAMP
l. Affichez l'ancienneté des clients.
SELECT `nomClient`,floor(datediff(now(), `dateEntreeClient`)/365) as anciennete FROM `clients` ORDER by anciennete
SELECT `nomClient`,round(datediff(now(), `dateEntreeClient`)/365) as anciennete FROM `clients` ORDER by anciennete
SELECT idClient, nomClient, prenomClient, TIMESTAMPDIFF(YEAR, dateEntreeClient, CURRENT_TIMESTAMP) AS Anciennete FROM Clients;
m. Affichez la quantite maximale achetée par un client.
SELECT Max(`quantiteCommande`) as "quantite max" FROM `commandes`
n. Affichez la quantite totale achetée par le client2.
SELECT SUM(`quantiteCommande`) AS "quantite totale" FROM `commandes` WHERE `idClient` = 2
o. Affichez la quantite moyenne achetée par le client 2.
SELECT AVG(`quantiteCommande`) AS "quantite moyenne" FROM `commandes` WHERE `idClient` = 2
SELECT round(AVG(`quantiteCommande`),2) AS "quantite moyenne" FROM `commandes` WHERE `idClient` = 2
p. Affichez les clients classés par ordre alphabétique de leur nom.
SELECT `nomClient`,`prenomClient` FROM `clients` ORDER BY `nomClient`
SELECT `nomClient`,`prenomClient` FROM `clients` ORDER BY `nomClient`,prenomClient
SELECT CONCAT(`nomClient`," ",`prenomClient`) as nom FROM `clients` ORDER BY nom
q. Affichez les articles classés selon leur prix décroissant. 
SELECT `descriptionArticle`,`prixArticle` FROM `articles` order by `prixArticle` desc
SELECT `descriptionArticle`,`prixArticle` FROM `articles` order by `prixArticle` desc, `descriptionArticle`