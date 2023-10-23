executer les 2 instructions suivantes sur la base
ALTER TABLE commandes ADD cde_total int;
UPDATE commandes SET cde_total = quantiteCommande * (select prixArticle from articles where articles.idArticle = commandes.idArticle)

Affichez le contenu de la table commande. Qu'' y a-t-il de changé dans cette table ? Comment le total de la
commande a-t-il été calculé ? 

Ecrire des requêtes SELECT. Vous vérifierez que le résultat de la requête correspond à votre inspection des
tables correspondantes. 
A) Afficher le montant le plus élevé de commande.
SELECT max(`cde_total`) FROM `commandes`;
SELECT MAX(`quantiteCommande`*articles.prixArticle) FROM `commandes` INNER JOIN articles ON commandes.idArticle = articles.idArticle;
B) Afficher le montant moyen des commandes.
SELECT ROUND(AVG(`cde_total`),2) FROM `commandes`;
SELECT ROUND(AVG( quantiteCommande * prixArticle ),2) as "montant moyen commande " FROM `commandes` INNER JOIN articles ON commandes.idArticle = articles.idArticle;
C) Afficher le montant le plus bas de commande.
SELECT MIN(`cde_total`) FROM `commandes`;
D) Afficher le nombre de commandes qui ont été passées.
SELECT COUNT(*) FROM `commandes`;
E) Afficher le montant moyen de commande par client
SELECT cl.`NomClient`, cl.`PrenomClient`, ROUND(AVG(co.`cde_total`), 2) AS "montant moyen de commande" FROM `commandes` AS co INNER JOIN `clients` AS cl ON co.idClient = cl.idClient GROUP BY co.idClient;
SELECT cl.`NomClient`, cl.`PrenomClient`, ROUND(AVG(co.quantiteCommande*a.prixArticle), 2) AS "montant moyen de commande" 
FROM `commandes` AS co 
INNER JOIN `clients` AS cl ON co.idClient = cl.idClient 
INNER JOIN articles as a ON co.idArticle = a.idArticle
GROUP BY co.idClient;
SELECT cl.`NomClient`, cl.`PrenomClient`, ROUND(AVG(co.`cde_total`), 2) AS "montant moyen de commande" FROM `commandes` AS co, `clients` AS cl WHERE co.idClient = cl.idClient GROUP BY co.idClient;
F) Afficher le montant le plus élevé de commande par client.
SELECT cl.`NomClient`, cl.`PrenomClient`, MAX(co.`cde_total`) AS "montant le plus élevé " FROM `commandes` AS co INNER JOIN `clients` AS cl ON co.idClient = cl.idClient GROUP BY co.idClient;
G) Afficher le nombre de commandes par client.
SELECT CONCAT(`nomClient`, " ", `prenomClient`) as nomClient, COUNT(idCommande) as "nb commandes" FROM `commandes` AS co INNER JOIN `clients` AS cl ON co.idClient = cl.idClient GROUP BY co.idClient;
H) Afficher le nombre d ''articles commandés en moyenne par client
SELECT CONCAT(`nomClient`, " ", `prenomClient`) as nomClient, ROUND(AVG(`quantiteCommande`),2) as "nb articles moyen" FROM `commandes` AS co INNER JOIN `clients` AS cl ON co.idClient = cl.idClient GROUP BY co.idClient;
I) Afficher le nombre d''articles commandés en moyenne par article.
SELECT articles.descriptionArticle, AVG(`quantiteCommande`) AS "moyenne des articles" FROM `commandes` INNER JOIN articles ON commandes.idArticle = articles.idArticle GROUP BY commandes.idArticle;
J) Afficher le nombre total d''articles commandés par article.
SELECT articles.descriptionArticle, SUM(`quantiteCommande`) AS "nb articles" FROM `commandes` INNER JOIN articles ON commandes.idArticle = articles.idArticle GROUP BY commandes.idArticle;
K) Afficher le nombre moyen d''articles par client et par date.
SELECT CONCAT(`nomClient`, " ", `prenomClient`) AS nomClient, co.dateCommande, ROUND(AVG(`quantiteCommande`), 2) AS "nb articles moyen" FROM commandes AS co INNER JOIN `clients` AS cl ON co.idClient = cl.idClient GROUP BY co.idClient, co.dateCommande;
L) Afficher le nombre de commandes par jour.
SELECT `dateCommande`, COUNT(*) FROM `commandes` GROUP BY `dateCommande`
M) Afficher le nombre de clients dans la table.
SELECT COUNT(*) FROM `clients` 
N) Afficher le nombre de clients différents qui ont passé commande.
SELECT COUNT(distinct idClient) FROM `commandes`;
O) Afficher le nombre d'' articles différents qui ont été commandés.
SELECT COUNT(distinct idArticle) FROM `commandes`;
P) Afficher le nombre de jours différents de commandes
SELECT COUNT(distinct `dateCommande`) FROM `commandes`;