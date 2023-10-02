<?php
class PersonnesManager{
    public static function add(Personnes $p)
    {
        $db=DbConnect::getDb();
        $query = $db->prepare("INSERT INTO Personnes (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
        $query->bindValue(":nom",$p->getNom());
        $query->bindValue(":prenom",$p->getPrenom());
        $query->bindValue(":adresse",$p->getAdresse());
        $query->bindValue(":ville",$p->getVille());
        $query->execute();
    }

    public static function update(Personnes $p)
    {
        $db=DbConnect::getDb();
        $query = $db->prepare("UPDATE  Personnes SET nom=:nom,prenom=:prenom,adresse=:adresse,ville=:ville WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne",$p->getIdPersonne());
        $query->bindValue(":nom",$p->getNom());
        $query->bindValue(":prenom",$p->getPrenom());
        $query->bindValue(":adresse",$p->getAdresse());
        $query->bindValue(":ville",$p->getVille());
        $query->execute();
    }

    public static function delete(Personnes $p)
    {
        $db=DbConnect::getDb();
        $query = $db->prepare("DELETE FROM Personnes WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne",$p->getIdPersonne());
        $query->execute();
    }

    
}