<?php

class ProjectGen
{

    private static $_projectDir; // nom du projet avec le path

    private static $_host;
    private static $_port;
    private static $_dbname;
    private static $_charset;
    private static $_user;
    private static $_password;

    private static $_dbData;

    private static $_db;

#getter
    public static function getHost()
    {
        return self::$_host;
    }

    public static function getPort()
    {
        return self::$_port;
    }

    public static function getDbname()
    {
        return self::$_dbname;
    }

    public static function getCharset()
    {
        return self::$_charset;
    }

    public static function getUser()
    {
        return self::$_user;
    }

    public static function getPassword()
    {
        return self::$_password;
    }

    public static function getDbData()
    {
        return self::$_dbData;
    }

    public static function getDb()
    {
        return self::$_db;
    }
#endgetter

    public static function init()
    {
        try {
            if (file_exists("projet.json"))
            {
                // access to project config json file
                $obj = json_decode(file_get_contents("./projet.json"));
                // project source dir
                self::$_projectDir = $obj->pathProject . "/" . $obj->projectName;
                // database arguments
                self::$_host = $obj->database->host;
                self::$_port = $obj->database->port;
                self::$_dbname = $obj->database->dbname;
                self::$_charset = $obj->database->charset;
                self::$_user = $obj->database->user;
                self::$_password = $obj->database->password;
                //db data list
                self::$_dbData = $obj->database; // contient le config.json du projet créé

                // Connection MySQL
                self::$_db = new PDO('mysql:host=' . self::getHost() . ';
                                    dbname=' . self::getDbname() . ';
                                    port=' . self::getPort() . ';
                                    charset=' . self::getCharset(),
                    self::getUser(),
                    self::getPassword());
            }
            else{
                echo "le fichier n'existe pas";
                die();
            }
        }
        catch (Exception $e)
        {
            // Retourne l'erreur et arrete le script courant
            die('Erreur : ' . $e->getMessage());
        }
    }

    public static function dirGen()
    {
        // Create project directory
        mkdir(self::$_projectDir, 0777); // 0777 = chmod tous les droits

        copy('./ressources/index.php', self::$_projectDir . "/index.php");

        //  Create MCV
        mkdir(self::$_projectDir . "/PHP", 0777);
        // MODEL
        mkdir(self::$_projectDir . "/PHP/MODEL", 0777);
        mkdir(self::$_projectDir . "/PHP/MODEL/MANAGER", 0777);
        copy('./ressources/DbConnect.Class.php', self::$_projectDir . "/PHP/MODEL/MANAGER/DbConnect.Class.php");
        copy('./ressources/DAO.Class.php', self::$_projectDir . "/PHP/MODEL/MANAGER/DAO.Class.php");
        //VIEW
        mkdir(self::$_projectDir . "/PHP/VIEW", 0777);
        mkdir(self::$_projectDir . "/PHP/VIEW/LIST", 0777);
        mkdir(self::$_projectDir . "/PHP/VIEW/FORM", 0777);
        // CONTROLLER
        mkdir(self::$_projectDir . "/PHP/CONTROLLER", 0777);
        mkdir(self::$_projectDir . "/PHP/CONTROLLER/ACTION", 0777);
        mkdir(self::$_projectDir . "/PHP/CONTROLLER/CLASS", 0777);
        copy('./ressources/Parameter.Class.php', self::$_projectDir . "/PHP/CONTROLLER/CLASS/Parameter.Class.php");

        // Create html/css file
        mkdir(self::$_projectDir . "/HTML", 0777);
        mkdir(self::$_projectDir . "/CSS", 0777);

        // UTtils file
        mkdir(self::$_projectDir . "/UTILS", 0777);
        copy('./ressources/genelog.php', self::$_projectDir . "/UTILS/genelog.php");

        // Log file
        mkdir(self::$_projectDir . "/LOG", 0777);

    }

    /**
     * Create and fill manager class, pocos, list and form , can take a string in argument as custom path
     *
     * @param string|null $path
     */
    public static function classesGen()
    {
        $tableList = self::recupTables();
        // $managersDir = $path ? self::$_projectDir . $path : self::$_projectDir . "/PHP"; //init path
         $managersDir =  self::$_projectDir . "/PHP"; //init path

        for ($i = 0; $i < count($tableList); $i++) // do as many class than table in db

        {
            // define path for different class
            $managerPath = $managersDir . "/MODEL/MANAGER/" . ucfirst($tableList[$i]) . "Manager.Class.php";
            $pocoPath = $managersDir . "/CONTROLLER/CLASS/" . ucfirst($tableList[$i]) . ".Class.php";
            $listPath = $managersDir . "/VIEW/LIST/" . ucfirst($tableList[$i]) . "List.php";
            $formPath = $managersDir . "/VIEW/FORM/" . ucfirst($tableList[$i]) . "Form.php";
            // get columns list from table name
            $tableAssoc = self::recupColonne($tableList[$i]);
            // get code content as string
            $managerStr = GenManager::createManager($tableList[$i]);
            $pocoStr = GenPoco::createPoco($tableList[$i], $tableAssoc);
            $listStr = GenList::createList($tableList[$i]);
            // $formStr = GenForm::createForm($tableAssoc);
            // Create and fill manager class
            $managerFile = fopen($managerPath, "w") ?: var_dump("Can't open file: " . $managerPath);
            fwrite($managerFile, $managerStr) ?: var_dump("Can't write to file: " . $managerPath);
            fclose($managerFile);
            // Create and fill pocos class
            $pocoFile = fopen($pocoPath, "w") ?: var_dump("Can't open file: " . $pocoPath);
            fwrite($pocoFile, $pocoStr) ?: var_dump("Can't write to file: " . $pocoPath);
            fclose($pocoFile);
            // Create and fill data table class
            $listFile = fopen($listPath, "w") ?: var_dump("Can't open file: " . $listPath);
            fwrite($listFile, $listStr) ?: var_dump("Can't write to file: " . $listPath);
            fclose($listFile);
            // Create and fill data table form class
            // $formFile = fopen($formPath, "w") ?: var_dump("Can't open file: " . $formPath);
            // fwrite($formFile, $formStr) ?: var_dump("Can't write to file: " . $formPath);
            // fclose($formFile);
        }
        // Create and fill config.json
        $configPath = self::$_projectDir . "/config.json";
        $dataconfig = GenerateConfig::createConfigJSON(self::getDbData());

        $configFile = fopen($configPath, "w") ?: var_dump("Can't open file: " . $configPath);
        fwrite($configFile, $dataconfig) ?: var_dump("Can't write to file: " . $configPath);
        fclose($configFile);
    }

//****************************************** PRIVATE FUNCTION ****************************************************************** */

/**
 * Récupère les tables de la base de données
 *
 * @return array
 */
    private static function recupTables()
    {
        $db = self::getDb();

        $requete = "SHOW TABLES";
        $req = $db->prepare($requete);
        $req->execute();
        // $db->exec($requete);
        while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
        {
            $liste[] = $donnees['Tables_in_' . self::getDbName()];
        }
        $req->closeCursor();
        return $liste;
    }

    /**
     * retourne un tableau avec en clef le nom des colonnes et en valeur le type
     *
     * @param string $table le nom de la table duquel on veut les colonnes
     * @return array
     */
    private static function recupColonne($table)
    {
        $db = self::getDb();
        $requete = "SHOW COLUMNS FROM " . $table;
        $req = $db->prepare($requete);
        $req->execute();
        while ($donnees = $req->fetch(PDO::FETCH_ASSOC))
        {
            $tableauColonnes[$donnees['Field']] = $donnees['Type'];
        }
        $req->closeCursor();
        return $tableauColonnes;
    }

    /**
     * retourne un tableau associatif avec comme clef le nom de la table et comme valeur un tableau associatif avec comme clef le nom des colonnes et en valeur leur type
     *
     * @return array
     */
    public static function recupBDD()
    {
        $listeTables = self::recupTables();

        foreach ($listeTables as $value)
        {
            $tableauColonnes = self::recupColonne($value);
            $tableau[$value] = $tableauColonnes;
        }
        return $tableau;
    }
}
