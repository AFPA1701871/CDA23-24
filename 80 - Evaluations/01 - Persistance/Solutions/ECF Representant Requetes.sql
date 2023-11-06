#1 - Tous les détails de tous les clients.

SELECT idClient, NomClient,VilleClient 
FROM clients;

#2 - Les numéros et les noms des produits de couleur rouge et de poids supérieur à 2000.

SELECT `IdProduit`,`NomProduit`
FROM produits 
WHERE `CouleurProduit`= "Rouge" AND `PoidsProduit`> 2000;

#3 - Les noms des représentants ayant vendu au moins un produit.

SELECT DISTINCT representants.IdRepres, nomRepres 
FROM representants 
INNER JOIN ventes ON representants.IdRepres = ventes.IdRepres 
ORDER BY nomRepres;

#4 - Les noms des clients de Paris ayant acheté un produit pour une quantité supérieure à 180.

SELECT DISTINCT NomClient 
FROM clients 
INNER JOIN ventes ON clients.IdClient = ventes.IdClient 
WHERE quantite > 180 AND clients.VilleCLient = "Paris" ;


#5 - Les noms des représentants et les clients à qui ces représentants ont vendu un produit de couleur rouge pour une quantité supérieure à 100.

SELECT NomRepres, NomClient 
FROM representants 
INNER JOIN ventes ON representants.IdRepres = ventes.IdRepres 
INNER JOIN clients ON clients.IdClient = ventes.IdClient 
INNER JOIN produits ON ventes.IdProduit = produits.IdProduit 
WHERE produits.CouleurProduit = "rouge" AND quantite > 100 
GROUP BY NomRepres;


#6 - Le nombre de produits vendus

SELECT nomproduit, SUM(quantite) 
FROM produits 
INNER JOIN ventes ON produits.IdProduit = ventes.IdProduit 
GROUP BY NomProduit

#7 - Les clients ayant achetés plus que la moyenne.

SELECT DISTINCT clients.NomClient
FROM clients
INNER JOIN ventes on ventes.IdClient=clients.IdClient
WHERE quantite>(
SELECT avg(Quantite) FROM `ventes` )


#8 - Créer une vue pleine entre clients et ventes

CREATE VIEW ClientVentes AS SELECT
    clients.NomClient,
    clients.VilleClient,
    ventes.*
    FROM clients
INNER JOIN ventes ON clients.IdClient = ventes.IdClient
