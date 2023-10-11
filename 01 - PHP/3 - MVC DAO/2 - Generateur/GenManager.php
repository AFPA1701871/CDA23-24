<?php 

class GenManager
{
       //**********************************Générateur Manager***************************************/

#manager
    /**
     * Permet d'ouvrir la balise PHP et la Class
     *
     * @param string $className Nom de la table
     * @return string
     */
    private static function startClassManager(string $className)
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
     * @return string
     */
    private static function createAdd(string $className)
    {
        $aff = "static public function add(" . ucfirst($className) . " \$object) \n";
        $aff .= "{ \n";
        $aff .= "   return DAO::add(\$object); \n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le UPDATE
     *
     * @param string $className Nom de la Table
     * @return string
     */
    private static function createUpdate(string $className)
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
     * @return string
     */
    private static function createDelete(string $className)
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
     * @return string
     */
    private static function createFindById(string $className)
    {
        $aff = "static public function findById(\$id) \n";
        $aff .= "{ \n";
        $aff .= '   return DAO::select("' . ucfirst($className) . '",' . ucfirst($className) . '::getAttributes(),["id' . ucfirst($className) . '"=> $id])[0];' . "\n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de créer le GetList
     *
     * @param string $className nom de table
     * @return string
     */
    private static function createGetList(string $className)
    {
        $aff = "static public function getList(array \$nomColonnes=null,  array \$conditions = null, string \$orderBy = null, string \$limit = null, bool \$api = false, bool \$debug = false) \n";
        $aff .= "{ \n";
        $aff .= "   \$nomColonnes = (\$nomColonnes == null) ?" . ucfirst($className) . "::getAttributes() : \$nomColonnes;" . " \n";
        $aff .= '   return DAO::select("' . ucfirst($className) . '"' . ", \$nomColonnes, \$conditions, \$orderBy, \$limit, \$api, \$debug);" . "\n";
        $aff .= "} \n \n";

        return $aff;
    }

    /**
     * Permet de fermer la Class
     *
     * @return string
     */
    private static function endClassManager()
    {
        $aff = "}";
        return $aff;
    }

    /**
     * Permet de tous écrire
     *
     * @param string $className
     * @return string
     */
    public static function createManager(string $className): string
    {
        $aff  = self::startClassManager($className);
        $aff .= self::createAdd($className);
        $aff .= self::createUpdate($className);
        $aff .= self::createDelete($className);
        $aff .= self::createFindById($className);
        $aff .= self::createGetList($className);
        $aff .= self::endClassManager();

        return $aff;
    }
#endmanager
    //********************************Fin Générateur Manager*************************************/

}