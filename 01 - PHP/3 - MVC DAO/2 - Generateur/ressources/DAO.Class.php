<?php

class DAO{

#select

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
    public static function select(string $table,?array $colonnes=null,?array $conditions=null,?array $orderBy=null,?string $limit=null ,?bool $debug=false) {
        //Pour prévenir les injection SQL : verif ;
        $verif = $table . json_encode($colonnes) . json_encode($conditions) . json_encode($orderBy) . $limit;
        if (!strpos($verif, ";")){
            $class = ucfirst($table);
            $list = [];
            $db = DbConnect::getDb();
            $request = "SELECT ";
            $request .= self::setColonnes($class,$colonnes);
            $request .= " FROM ". $table;
            $request .= self::setCondition($conditions);
            $request .= self::setOrderBy($orderBy);
            $request .= $limit != null ? " LIMIT " . $limit : "";;
            $query = $db->prepare($request);
            $query->execute();
            ($debug) ? var_dump($query) : null ;
            $i=0;
            while ($donnees = $query->fetch(PDO::FETCH_ASSOC)) {
                $list[$i] = new $class($donnees);
                $i++;
            }
            $query->closeCursor();
            return count($list) > 0 ? $list : false;
        }
        return false;
    }

    static public function setColonnes(string $class,?array $colonnes) {
        if ($colonnes != null) {
            return implode(', ',$colonnes);
        }
        $objet = new $class();
        $class = get_class($objet);
        $colonnes = $class::getAttributes();
        $retour = implode(",", $colonnes);
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
            foreach ($orderBy as $key => $value) {
                $retour .= $key.' '.($value)?:' DESC '.', ';
            }
            $retour = substr($retour,0,-2);
        }
        return $retour;
    }

#add

    /**
     * permet de faire un insert into pour ajouté un élément en base de donnée
     *
     * @param $objet Objet a ajouté
     * @return string|false
     */
    public static function add($objet){
        $db = DbConnect::getDb();  
        $class = get_class($objet);
        $colonnes = $class::getAttributes();
        $values = "";
        $request = "INSERT INTO ".get_class($objet)."(";
        
        
        for ($i=1; $i < count($colonnes); $i++) { 
            $methode = "get" . ucfirst($colonnes[$i]);
            if ($objet->$methode() !== null) {
                $request .= $colonnes[$i] . ",";
                $values .= ":" . $colonnes[$i] . ",";
            }
        }
        $request = substr($request,0,-1);
        $values = substr($values,0,-1);
        $request .= ") VALUES (".$values.")";
        $query = $db->prepare($request);
        for ($i=1; $i < count($colonnes); $i++) { 
            $methode = "get" . ucfirst($colonnes[$i]);
            if ($objet->$methode() !== null) {
                $query->bindValue(":$colonnes[$i]", $objet->$methode());
            }
        }
        $query->execute();
        return $db->lastInsertId();
    }




#update

    /**
     * permet de faire un insert into pour modifié un élément en base de donnée
     *
     * @param $objet Objet a modifié
     * @return string|false
     */
    public static function update($objet){
        $db = DbConnect::getDb();  
        $class = get_class($objet);
        $colonnes = $class::getAttributes();
        $request = "UPDATE ".get_class($objet)." SET ";
        
        for ($i=0; $i < count($colonnes); $i++) { 
            $methode = "get" . ucfirst($colonnes[$i]);
            if ($objet->$methode() !== null) {
                $request .= $colonnes[$i] . " = :" . $colonnes[$i] ." ,";
            }
        }
        $request = substr($request,0,-1);
        $request .= " WHERE ".$colonnes[0] . " = :" . $colonnes[0];
        $query = $db->prepare($request);
        for ($i=0; $i < count($colonnes); $i++) { 
            $methode = "get" . ucfirst($colonnes[$i]);
            if ($objet->$methode() !== null) {
                $query->bindValue(":$colonnes[$i]", $objet->$methode());
            }
        }
        return $query->execute();
    }



#delete  

    /**
     * permet de faire un delete pour supprimé un élément en base de donnée
     *
     * @param $objet Objet a supprimé
     * @return string|false
     */
    static public function delete($objet){
        $db = DbConnect::getDb();  
        $class = get_class($objet);
        $colonnes = $class::getAttributes();
        $query = $db->prepare("DELETE FROM ".get_class($objet)." WHERE ".$colonnes[0]." = :".$colonnes[0]);
        $methode = "get" . ucfirst($colonnes[0]);
        $query->bindValue(":$colonnes[0]", $objet->$methode());
        return $query->execute();
    }

}