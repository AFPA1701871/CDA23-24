<?php
class DAO
{

    public static function add($obj)
	{
		$db = DbConnect::getDb();
		$class = get_class($obj);
		$colonnes = $class::getAttributes();
		$requ = "INSERT INTO ". $class . "(";
		$values = "";

		for ($i = 1; $i < count($colonnes); $i++) {
			$methode = "get" . ucfirst($colonnes[$i]);
			if ($obj->$methode() !== null) {
				$requ .= $colonnes[$i] . ",";
				$values .= ":" . $colonnes[$i] . ",";
			}
		}
		$requ = substr($requ, 0, strlen($requ) - 1);
		$values = substr($values, 0, strlen($values) - 1);
		$requ .= ") VALUES (" . $values . ")";
		$q = $db->prepare($requ);

		for ($i = 1; $i < count($colonnes); $i++) {
			$methode = "get" . ucfirst($colonnes[$i]);
			if ($obj->$methode() !== null)
				$q->bindValue(":" . $colonnes[$i], $obj->$methode());
		}
		$q->execute();
		return $db->lastInsertId();
	}

	public static function update($obj)
	{
		$db = DbConnect::getDb();
		$class = get_class($obj);
		$colonnes = $class::getAttributes();
		$requ = "UPDATE ". $class . " SET ";

		for ($i = 1; $i < count($colonnes); $i++) {
			$requ .= $colonnes[$i] . "=:" . $colonnes[$i] . ",";
		}
		$requ = substr($requ, 0, strlen($requ) - 1);
		$requ .= " WHERE " . $colonnes[0] . "=:" . $colonnes[0];

		$q = $db->prepare($requ);

		for ($i = 0; $i < count($colonnes); $i++) {
			$methode = "get" . ucfirst($colonnes[$i]);
			$q->bindValue(":" . $colonnes[$i], $obj->$methode());
		}
		return $q->execute();
	}

	public static function delete($obj)
	{
		$db = DbConnect::getDb();
		$class = get_class($obj);
		$colonnes = $class::getAttributes();
		$methode = "get" . ucfirst($colonnes[0]);
		return $db->query("DELETE FROM ". $class . " WHERE " . $colonnes[0] . " = " . $obj->$methode());
	}

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
    public static function select(string $table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {
        // INJECTION SQL : verif ;
        $verif = $table . json_encode($colonnes) . json_encode($conditions) . json_encode($orderBy) . $limit;
        if (!strpos($verif, ";"))
        {
            $classe = ucfirst($table);
            $liste = [];
            $db = DbConnect::getDb();
            $requete = "SELECT ";
            $requete .= self::setColonnes($colonnes,$classe);
            $requete .= " FROM " . $table;
            $requete .= self::setConditions($conditions);
            $requete .= self::setOrderBy($orderBy, $requete);
            $requete .= $limit != null ? " LIMIT " . $limit : "";
            if ($debug)
            {
                var_dump($requete);
            }

            $req = $db->prepare($requete);
            $req->execute();
            while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
            {
                $liste[] = new $classe($donnees);
            }
            $req->closeCursor();
            return count($liste) > 0 ? $liste : false;
        }
        return false;
    }
    /**
     * Transforme le tableau de colonnes en une liste,ou  retrouve la liste des colonnes associés à la classe
     *
     * @param array|null $colonnes  Les colonnes à utiliser
     * @param string|null $class    La classe pour retrouver les colonnes
     * @return string Liste des colonnes à utiliser
     */
    private static function setColonnes(?array $colonnes,?string $class)
    {
        if ($colonnes != null)
        {
            return implode(', ', $colonnes);
        }
        return implode($colonnes = $class::getAttributes(new $class));
    }
/**
 * Transforme le tableau de condition en un string implémentant les conditions
 *
 * @param array|null $conditions    Tableau de conditions
 * @return string   Les conditions du select
 */
    private static function setConditions(?array $conditions)
    {
        $requete = "";
        if ($conditions != null)
        {
            $requete = " WHERE ";
            foreach ($conditions as $key => $value)
            {
                // var_dump( strpos($value, "<" )!==false || strpos($value, ">")!==false);
                if (is_array($value))
                {
                    $requete .= $key . " IN ('" . implode("','", $value) . "')";
                }
                elseif ($value == "")
                {
                    $requete .= $key . " IS NULL";
                }
                elseif (strpos($value, "->"))
                {
                    $value = str_replace("->", ' AND ', $value);
                    $requete .= $key . " BETWEEN " . $value;
                }
                elseif (strpos($value, "<") !== false || strpos($value, ">") !== false)
                {
                    $requete .= $key . $value;
                }
                elseif (strpos($value, "!") !== false)
                {
                    $requete .= $key . "!=" . substr($value, 1);
                }
                elseif (strpos($value, "%") !== false)
                {
                    $requete .= $key . " LIKE '" . $value . "'";
                }
                else
                {
                    $requete .= $key . " = '" . $value . "'";
                }

                $requete .= " AND ";
            }
            $requete = substr($requete, 0, -4);

        }
        return $requete;
    }
/**
 * Transforme le tableau donnant les tris à appliquer en string à intégrer au select
 *
 * @param array|null $orderBy   Conditions de tris
 * @return string   string à intégrer au select
 */
    private static function setOrderBy(?array $orderBy = null)
    {
        $retour = '';
        if ($orderBy != null)
        {
            $retour = ' ORDER BY ';
            foreach ($orderBy as $key => $value)
            {
                $retour .= $key . ' ' . ($value ? "" : ' DESC ') . ', ';
            }
            $retour = substr($retour, 0, -2);
        }
        return $retour;
    }
}
