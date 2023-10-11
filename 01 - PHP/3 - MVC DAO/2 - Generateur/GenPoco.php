<?php 
class GenPoco {

    /**
     * Fonction pour générer les attributs et les accesseurs
     * toto = classe et le tableau = $colonnes
     *
     * @param string $table
     * @param array $colonnes
     * @return string
     */
    public static function createPoco($table,$colonnes): string
    {
        $pocoStr  = self::generateAttributes($table,$colonnes);
        $pocoStr .= self::generateConstruct();
        return $pocoStr .= self::generateToString($colonnes);
    }

    /**
     * Fonction pour générer les constructeurs
     *
     * @return string
     */
    private static function generateAttributes($table,$colonnes)
    {
        $return= "<?php" . "\n";
        $return.= "\n" ;
        $return.= "class " . ucfirst($table) . "\n" ;
        $return.= "{" . "\n" ;
        //Attributs
        $return.= " /*****************Attributs*********************/ \n";
        $listeAttributs="";
        $attr="";
        $access="";
        foreach ($colonnes as $key => $value) {
            $attr.= " private ". '$_' . $key. ";". "\n";
            $attr.= "\n" ;
            $listeAttributs.=$key.", ";
            //getter
            $access.= "     public function get" . ucfirst($key) . "()\n";
            $access.= " {\n";
            $access.= "     return " . '$this' . '->_' . $key . ";" ."\n";
            $access.= " }\n" ;
            $access.= "\n" ;
            //setter
            // Modifier pour utiliser le type.json
            if (str_contains($va, 'id')){
                $type = "?int";
            } else if (str_contains($key, 'date')){
                $type ="date";
            } else {
                $type = "string";
            }
            $access.= "     public function set" . ucfirst($key) . "(?" . $type . " " . '$' . $key . ")" . "\n";
            $access.= " {" . "\n";
            $access.= '     $this' . '->_' . $value . " = " . '$' . $value . ";" . "\n";
            $access.= " }" . "\n" ;
            $access.= "\n" ;
        }
        $return.= $attr;
        $return.= " private static " . '$_attributes' . "[".substr($listeAttributs,0,-2)."];";
        
        $return.= "\n\n";
        //Accesseurs
        $return.= " /******************Accesseurs*******************/\n";
        $return.= "\n" ;

        
            // dans ce cas :
            // $key => int(0), int(1) etc
            // $value => "nom de la colonne"
            // Dans le cas du tableau "Id... => int" remplacer $value par $key
            
            
        // fonction get attributes
        $return.= "     public static function getAttributes()". "\n";
        $return.= " {". "\n";
        $return.= "     return self::" . '$_attributes' . ";" . "\n";
        $return.= " }". "\n" ;
        $return.= " }". "\n";
        //var_dump($return);
        return $return;
    }
        
    /**
     * Permet de créer la fonction construct et hydrate
     *
     * @return void
     */
    private static function generateConstruct()
    {
        $aff = '';

        $aff .= "public function __construct(array \$options = [])\n";
        $aff .= "   {\n";
        $aff .= "    if (!empty(\$options))\n";
        $aff .= "    {\n";
        $aff .= "        \$this->hydrate(\$options);\n";
        $aff .= "    }\n";
        $aff .= "   }\n\n";

        $aff .= "public function hydrate(\$data)\n";
        $aff .= "   {\n";
        $aff .= "    foreach (\$data as \$key => \$value) {\n";
        $aff .= "        \$method = \"set\" . ucfirst(\$key);\n";
        $aff .= "        if (is_callable([\$this, \$method]))\n";
        $aff .= "        {\n";
        $aff .= "            \$this->\$method(\$value);\n";
        $aff .= "        }\n";
        $aff .= "    }\n";
        $aff .= "   }\n";

        return $aff;
    }

    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return string
     */
     public static function generateToString(array $tableauColonnes)
     {
         $aff = '/**'."\n";
         $aff .= ' * Transforme l\'objet en chaîne de caractères'."\n";
         $aff .= ' *'."\n";
         $aff .= ' * @return string'."\n";
         $aff .= ' */'."\n";
         $aff .= 'public function toString(){'."\n";
         $aff .= '{'."\n";
         $aff .= '   return';
         $tableauAff = [];
         foreach($tableauColonnes as $colonnes => $value)
         {
             if($value == "array")
             {
                 $tableauAff[$colonnes] = ' "'.ucfirst($colonnes).' : [".';
                 $tableauAff[$colonnes] .= "implode(";
                 $tableauAff[$colonnes] .= '", ",$this->get'; 
                 $tableauAff[$colonnes] .= ucfirst($colonnes);
                 $tableauAff[$colonnes] .= '())."] . ';
             }
             else
             {
                 $tableauAff[$colonnes] = ' "'.ucfirst($colonnes).' : "';
                 $tableauAff[$colonnes] .= ". \$this->get"; 
                 $tableauAff[$colonnes] .= ucfirst($colonnes);
                 $tableauAff[$colonnes] .= "() . ";
             }
         }
         $aff .= implode('", " .',$tableauAff);
         $aff .= '"\n";'."\n";
         $aff .= '}'."\n";
         return $aff;
     }
}

// public function toString()
// {
//     $properties = get_object_vars($this);
//     $output = [];
//     foreach ($properties as $name => $value) {
//         $output[] = "$name : $value";
//     }
//     return implode($output);
// }
    

//  touche pas c'est pour Theo 
//  foreach(ProjectGen::recupBDD()as $nomTable =>$value){   
//    self::createPoco($nomTable,$value);
//  }
