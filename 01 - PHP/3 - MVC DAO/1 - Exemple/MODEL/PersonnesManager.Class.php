<?php
class PersonnesManager
{
    public static function add(Personnes $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("INSERT INTO Personnes (nom,prenom,adresse,ville) VALUES (:nom,:prenom,:adresse,:ville)");
        $query->bindValue(":nom", $p->getNom());
        $query->bindValue(":prenom", $p->getPrenom());
        $query->bindValue(":adresse", $p->getAdresse());
        $query->bindValue(":ville", $p->getVille());
        $query->execute();
    }

    public static function update(Personnes $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("UPDATE  Personnes SET nom=:nom,prenom=:prenom,adresse=:adresse,ville=:ville WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->bindValue(":nom", $p->getNom());
        $query->bindValue(":prenom", $p->getPrenom());
        $query->bindValue(":adresse", $p->getAdresse());
        $query->bindValue(":ville", $p->getVille());
        $query->execute();
    }

    public static function delete(Personnes $p)
    {
        $db = DbConnect::getDb();
        $query = $db->prepare("DELETE FROM Personnes WHERE idPersonne=:idPersonne");
        $query->bindValue(":idPersonne", $p->getIdPersonne());
        $query->execute();
    }

    // public static function findById($id)
    // {
    //     $db = DbConnect::getDb();
    //     $id = (int) $id;
    //     $q = $db->query("SELECT * from Personnes WHERE idPersonne =" . $id);
    //     $results = $q->fetch(PDO::FETCH_ASSOC);
    //     // die(var_dump($results));
    //     if ($results != false)
    //     {
    //         return new Personnes($results);
    //     }
    //     return false;
    // }
    // public static function getList()
    // {
    //     $db = DbConnect::getDb();
    //     $liste = [];
    //     $q = $db->query("SELECT * from Personnes ");
    //     while ($donnees = $q->fetch(PDO::FETCH_ASSOC))
    //     {
    //         if ($donnees != false)
    //         {
    //             $liste[] = new Personnes($donnees);
    //         }
    //     }
    //     return $liste;
    // }


    public static function findById($id)
    {
        DAO::select("Personnes",null,["idPersonne"=>$id]);
    }
    
    public static function getList( ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
     {
        DAO::select("Personnes",$colonnes,$conditions,$orderBy,$limit,$debug);
     }

}
