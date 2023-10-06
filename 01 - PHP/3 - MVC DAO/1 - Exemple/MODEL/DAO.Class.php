<?php
class DAO
{
    public static function select(string $table, ?array $colonnes = null, ?array $conditions = null, ?array $orderBy = null, ?string $limit = null, ?bool $debug = false)
    {
        // verif ;
        $verif = $table . json_encode($colonnes) . json_encode($conditions) . json_encode($orderBy) . $limit;
        if (!strpos($verif, ";"))
        {
            $classe = ucfirst($table);
            $liste = [];
            $db = DbConnect::getDb();
            $requete = "SELECT ";
            $requete .= self::setColonnes($colonnes);
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

    private static function setColonnes(?array $colonnes)
    {
        if ($colonnes != null)
        {
            return implode(', ', $colonnes);
        }

        return '*';
    }

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
