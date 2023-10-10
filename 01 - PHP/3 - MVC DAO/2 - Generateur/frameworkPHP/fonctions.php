<?php

class projectGen {

    private static $_projectDir;

    private static $_host;
    private static $_dbname;
    private static $_charset;
    private static $_user;
    private static $_password;

    private static $_db;

#getter
    public static function getHost()
    {
        return self::$_host;
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
    public static function getDb()
    {
        return self::$_db;
    }
#endgetter

    public static function init()
    {
        try{
            self::dirGen();
            // Connection MySQL
            self::$_db = new PDO ( 'mysql:host='.self::getHost().';
                                    dbname='.self::getDbname().';
                                    charset='.self::getCharset(), 
                                    self::getUser(), 
                                    self::getPassword());
        } catch ( Exception $e ) {
            // Retourne l'erreur et arrete le script courant
            die ( 'Erreur : ' . $e->getMessage() );
        }
    }
    
    public static function dirGen() 
    {
        $obj          = json_decode(file_get_contents("projet.json"));
        $projectName  = $obj->projectName;
        $pathProject  = $obj->pathProject;
        self::$_projectDir   = $pathProject."/".$projectName;

        // Create project path
        mkdir(self::$_projectDir, 0777); // 0777 = chmod tout les droits

        //  Create MCV
        mkdir(self::$_projectDir."/PHP", 0777);
        copy('./ressources/index.php', self::$_projectDir."/PHP/index.php");
            // MODEL
        mkdir(self::$_projectDir."/PHP/MODEL", 0777);
        mkdir(self::$_projectDir."/PHP/MODEL/MANAGER", 0777);
        copy('./ressources/DbConnect.Class.php', self::$_projectDir."/PHP/MODEL/MANAGER/DbConnect.Class.php");
        copy('./ressources/DAO.Class.php', self::$_projectDir."/PHP/MODEL/MANAGER/DAO.Class.php");
            //VIEW
        mkdir(self::$_projectDir."/PHP/VIEW", 0777);
        mkdir(self::$_projectDir."/PHP/VIEW/LIST", 0777);
        mkdir(self::$_projectDir."/PHP/VIEW/FORM", 0777);
            // CONTROLLER
        mkdir(self::$_projectDir."/PHP/CONTROLLER", 0777);
        mkdir(self::$_projectDir."/PHP/CONTROLLER/CLASS", 0777);
        mkdir(self::$_projectDir."/PHP/CONTROLLER/ACTION", 0777);

        // Create html/css file
        mkdir(self::$_projectDir."/HTML", 0777);
        mkdir(self::$_projectDir."/CSS", 0777);

        // UTtils file
        mkdir(self::$_projectDir."/UTILS", 0777);
        copy('./ressources/genelog.php', self::$_projectDir."/UTILS/genelog.php");

        // Log file
        mkdir(self::$_projectDir."/LOG", 0777);

        //Create config.json
        copy('./ressources/config.json', self::$_projectDir."/config.json");
    }

    public static function classCompiler(string $code, ?string $path)
    {
        $manager = "testmanager";
        $table   = "testtable";

        mkdir(self::$_projectDir."/PHP/MODEL/MANAGER/", 0777);
    }

    function recupTables()
    {
        $db = self::getDb();

        $requete = "SHOW TABLES";
        $req = $db->prepare($requete);
        $req->execute();
        while ($donnees = $req->fetch(PDO::FETCH_ASSOC)) {
            $liste[] = $donnees;
        }
        $req->closeCursor();
        return $liste;
    }

    function recupColumns()
    {
        $db = self::getDb();
        $listeTables = self::recupTables();

        foreach ($listeTables as $table) {
            foreach ($table as $value) {
                $requete = "SHOW COLUMNS FROM " . $value;
                $req = $db->prepare($requete);
                $req->execute();
                while ($donnees = $req->fetch(PDO::FETCH_ASSOC)) {
                    $tableauColonnes[$donnees['Field']] = $donnees['Type'];
                }
                $req->closeCursor();
                $tableau[$value] = $tableauColonnes;
                $tableauColonnes = [];
            }
        }
        return $tableau;
    }
    //**********************************Générateur Manager***************************************/
    /**
     * Permet d'ouvrir la balise PHP et la Class
     *
     * @param string $className Nom de la table
     * @return void
     */
    function startClassManager(string $className)
    {
        $aff = "<?php \n";
        $aff .= "class " . ucfirst($className) . "Manager \n";
        $aff .= "{ \n \n";

        return $aff;
    }

    /**
     * Permet de créer le CREATE
     *
     * @param string $className Nom de la table
     * @return void
     */
    function createAdd(string $className)
    {
        $aff = "static public function create(" . ucfirst($className) . " \$object) \n";
        $aff .= "{ \n";
        $aff .= "   return DAO::create(\$object); \n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le UPDATE
     *
     * @param string $className Nom de la Table
     * @return void
     */
    function createUpdate(string $className)
    {
        $aff = "static public function update(" . ucfirst($className) . "  \$object) \n";
        $aff .= "{ \n";
        $aff .= "   return DAO::update(\$object); \n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le DELETE
     *
     * @param string $className Nom de la classe
     * @return void
     */
    function createDelete(string $className)
    {
        $aff = "static public function delete(" . ucfirst($className) . "  \$object) \n";
        $aff .= "{ \n";
        $aff .= "   return DAO::delete(\$object); \n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le FindById
     *
     * @param string $className Nom de la classe
     * @return void
     */
    function createFindById(string $className)
    {
        $aff = "static public function findById(\$id) \n";
        $aff .= "{ \n";
        $aff .= '   return DAO::select("' . ucfirst($className) . '",' . ucfirst($className) . '::getAttributs(),["id' . ucfirst($className) . '"=> $id])[0];' . "\n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le GetList
     *
     * @param string $className nom de table
     * @return void
     */
    function createGetList(string $className)
    {
        $aff = "static public function getList(array \$nomColonnes=null,  array \$conditions = null, string \$orderBy = null, string \$limit = null, bool \$api = false, bool \$debug = false) \n";
        $aff .= "{ \n";
        $aff .= "   \$nomColonnes = (\$nomColonnes == null) ?" . ucfirst($className) . "::getAttributs() : \$nomColonnes;" . " \n";
        $aff .= '   return DAO::select("' . ucfirst($className) . '"' . ", \$nomColonnes, \$conditions, \$orderBy, \$limit, \$api, \$debug);" . "\n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de fermer la Class
     *
     * @return void
     */
    function endClassManager()
    {
        $aff = "}";
        return $aff;
    }

    /**
     * Permet de tous écrire
     *
     * @param string $className
     * @return void
     */
    function createManager(string $className)
    {
        $aff = '';
        $aff .= startClassManager($className);
        $aff .= createAdd($className);
        $aff .= createUpdate($className);
        $aff .= createDelete($className);
        $aff .= createFindById($className);
        $aff .= createGetList($className);
        $aff .= endClassManager();

        return $aff;
    }
    //********************************Fin Générateur Manager*************************************/

}