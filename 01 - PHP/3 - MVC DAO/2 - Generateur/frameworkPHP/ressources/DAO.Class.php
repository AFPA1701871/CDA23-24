<?php

class DAO{

    /**
	 * permet de faire un select paramétré sur une table
     * 
	 * @param string $table => contient Nom de la table sur laquelle la requête sera effectuée.
	 * Exemple : nomTable => "FROM nomTable"
     * 
	 * @param array $nomColonnes => contient le noms des champs désirés dans la requête.
	 * Exemple :  [nomColonne1,nomColonne2] => "SELECT nomColonne1, nomColonne2"
	 *
	 * @param array $conditions => null par défaut, attendu un tableau associatif 
	 * qui peut prendre plusieurs formes en fonction de la complexité des conditions.
	 *  Exemples : tableau associatif
	 *  [nomColonne => '1'] => "WHERE nomColonne = 1"
	 *  [nomColonne => '!1'] => "WHERE nomColonne != 1"
	 *  [nomColonne => ''] => "WHERE nomColonne is null "
	 *  [nomColonne => ['1','3']] => "WHERE nomColonne in (1,3)"
	 *  [nomColonne => '%abcd%'] => "WHERE nomColonne like "%abcd%" "
	 *  [nomColonne => '1->5'] => "WHERE nomColonne BETWEEN 1 and 5 "
	 *  [nomColonne => '>5'] => "WHERE nomColonne > 5 "
	 *  Si il y a plusieurs conditions alors :
	 *  [nomColonne1 => '1', nomColonne2 => '%abcd%' ] => "WHERE nomColonne1 = 1 AND nomColonne2 LIKE "%abcd%"
	 * 	
	 * @param string $orderBy => null par défaut, contient un tableau qui contient les noms de colonnes et un boolean vrai si le tri est ascendant
	 * Exemple :["nomColonne1"=>false , "nomColonne2"=>true] => "Order By nomColonne1 , nomColonne2 DESC"
	 *
	 * @param string $limit  => null par défaut, contient un string pour donner la délimitations des enregistrements de la BDD
	 * Exemples :
	 * "1" => "LIMIT 1"
	 * "1,2"=> "LIMIT 1,2"
	 *
	 * @param bool $debug => contient faux par défaut mais s'il on le met a vrai, on affiche la requete qui est effectuée.
	 *
	 * @return [array] $liste => résultat de la requête revoie false si la requête s'est mal passé sinon renvoie un tableau.
	 */
    public static function select(string $table,?array $row=null,?array $conditions=null,?array $orderBy=null,?string $limit ,?bool $debug=false) {
        //Pour prévenir les injection SQL : verif ;
        $verif = $table . json_encode($row) . json_encode($conditions) . json_encode($orderBy) . $limit;
        if (!strpos($verif, ";")){
            $class = ucfirst($table);
            $list = [];
            $db = DbConnect::getDb();
            $request = "SELECT ";
            $request .= self::setRow($row);
            $request .= " FROM ". $table;
            $request .= self::setCondition($conditions);
            $request .= self::setOrderBy($orderBy);
            $request .= $limit != null ? " LIMIT " . $limit : "";;
            $query = $db->prepare($request);
            $query->execute();

            ($debug) ? console.log($query) : null ;
            $i=0;
            while ($donnees = $query->fetch(PDO::FETCH_ASSOC)) {
                $list[$i] = new Personne($donnees);
                $i++;
            }
            $query->closeCursor();
            return count($list) > 0 ? $list : false;
        }
        return false;
    }

    static public function setRow(?array $row) {
        $retour = '*';
        if ($row != null) {
            $retour = implode(', ',$row);
        }
        return $retour;
    }

    /**
     * Transforme le tableau de condition en un string implémentant les conditions
     *
     * @param array|null $conditions    Tableau de conditions
     * @return string   Les conditions du select
     */
    static public function setCondition(?array $conditions) {
        $retour = "";
        if ($conditions != null) {
            $retour =" WHERE ";
            foreach ($conditions as $key => $value) {
                if ($value == "") {
                    $retour .= $key." IS NULL";
                }else if (strpos($value,"<") !== false || strpos($value,">") !== false) {
                    $retour .= $key." ".$value;
                }else if (strpos($value,"!") !== false) {
                    $retour .= $key." != '".substr($value, 1)."'";
                }else if (strpos($value,"%") !== false) {
                    $retour .= $key." LIKE '".$value."'";
                }else if (strpos($value,'->') !== false) {
                    $retour .= $key.' BETWEEN '.str_replace('->',' AND ',$value);
                }else if (is_array($value)) {
                    $retour .= $key." IN ('" . implode("','", $value) . "')";                              
                }else {
                    $retour .= $key.' = \''.$value.'\'';
                }
                $retour .= ' AND ';
            }
            $retour = substr($retour,0,-4);
        }
        return $retour;
    }

    /**
     * Transforme le tableau donnant les tris à appliquer en string à intégrer au select
     *
     * @param array|null $orderBy   Conditions de tris
     * @return string   string à intégrer au select
     */
    static public function setOrderBy(?array $orderBy) {
        $retour='';
        if ($orderBy != null) {
            $retour=' ORDER BY ';
            foreach ($conditions as $key => $value) {
                $retour .= $key.' '.($value)?:' DESC '.', ';
            }
            $retour = substr($retour,0,-2);
        }
        return $retour;
    }

    private static function getProperties(string $classe)
    {
        // Instanciatin de la classe
        $obj = new $classe();

        // récupération des propriétés de la classe
        $properties = (new ReflectionClass($obj))->getProperties();

        $propertiesListe = [];
        // création de la liste des propriétés
        foreach($properties as $property)
        {
            $propertiesListe[] = substr($property->getName(), 1);
        }
        
        // conversion en chaine de caractères
        $propertiesStr = implode(", ", $propertiesListe);
        
        return $propertiesStr;
    }

#endregion

#region add

    public static function add($objet){
        $db = DbConnect::getDb();
        $row = $objet->getProperties();
        $values = "";
        $request = "INSERT INTO ".get_class($objet)."(";
        
        
        for ($i=1; $i < count($row); $i++) { 
            $methode = "get" . ucfirst($row[$i]);
            if ($objet->$methode() !== null) {
                $request .= $row[$i] . ",";
                $values .= ":" . $row[$i] . ",";
            }
        }
        $request = substr($request,0,-1);
        $values = substr($values,0,-1);
        $request .= ") VALUES (".$values.")";
        // var_dump($request);
        $query = $db->prepare($request);
        for ($i=1; $i < count($row); $i++) { 
            $methode = "get" . ucfirst($row[$i]);
            if ($objet->$methode() !== null) {
                $query->bindValue(":$row[$i]", $objet->$methode());
            }
        }
        $query->execute();
        return $db->lastInsertId();
    }


#endregion

#region update

public static function update($objet){
    $db = DbConnect::getDb();
    $row = $objet->getProperties();
    $values = "";
    $request = "UPDATE ".get_class($objet)." SET ";
     
    for ($i=1; $i < count($row); $i++) { 
        $methode = "get" . ucfirst($row[$i]);
        if ($objet->$methode() !== null) {
            $request .= $row[$i] . " = :" . $row[$i] ." ,";
        }
    }
    $request = substr($request,0,-1);
    $request .= " WHERE ".$row[0] . " = :" . $row[0];
    $query = $db->prepare($request);
    for ($i=0; $i < count($row); $i++) { 
        $methode = "get" . ucfirst($row[$i]);
        if ($objet->$methode() !== null) {
            $query->bindValue(":$row[$i]", $objet->$methode());
        }
    }
    return $query->execute();
}


#endregion

#region delete  

    static public function delete($objet){
        $db = DbConnect::getDb();
        $row = $objet->getProperties();
        $query = $db->prepare("DELETE FROM ".get_class($objet)." WHERE ".$row[0]." = :".$row[0]);
        $methode = "get" . ucfirst($row[0]);
        $query->bindValue(":$row[0]", $objet->$methode());
        return $query->execute();
    }

#endregion

}