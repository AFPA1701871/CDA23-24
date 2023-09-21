# Image Docker sur laquelle est basée la nouvelle image que nous allons créer
FROM postgres:15
# Utilisateur "administrateur" du système de gestion de base de données
ENV POSTGRE_USER postgres
# Mot de passe (complexe, s'il vous plait) de l'utilisateur administrateur
ENV POSTGRES_PASSWORD B@nLgU4qz*9?D~3n83
# Création d'une base de données avec un nom prédéfini : "society"
ENV POSTGRES_DB society
# Copie du fichier de création de BDD dans l'image
# ce script sera démarré automatiquement au lancement du conteneur
COPY society-postgresql.sql /docker-entrypoint-initdb.d/