executer les 2 instructions suivantes sur la base
ALTER TABLE commandes ADD cde_total int;
UPDATE commandes SET cde_total = quantiteCommande * (select prixArticle from articles where articles.idArticle = commandes.idArticle)

Affichez le contenu de la table commande. Qu'y a-t-il de changé dans cette table ? Comment le total de la
commande a-t-il été calculé ? 

Ecrire des requêtes SELECT. Vous vérifierez que le résultat de la requête correspond à votre inspection des
tables correspondantes. 
A)Afficher le montant le plus élevé de commande.
B) Afficher le montant moyen des commandes.
C) Afficher le montant le plus bas de commande.
D) Afficher le nombre de commandes qui ont été passées.
E) Afficher le montant moyen de commande par client
F) Afficher le montant le plus élevé de commande par client.
G) Afficher le nombre de commandes par client.
H) Afficher le nombre d 'articles commandés en moyenne par client
I) Afficher le nombre d'articles commandés en moyenne par article.
J) Afficher le nombre total d'articles commandés par article.
K) Afficher le nombre moyen d'articles par client et par date.
L) Afficher le nombre de commandes par jour.
M) Afficher le nombre de clients dans la table.
N) Afficher le nombre de clients différents qui ont passé commande.
O) Afficher le nombre d' articles différents qui ont été commandés.
P) Afficher le nombre de jours différents de commandes