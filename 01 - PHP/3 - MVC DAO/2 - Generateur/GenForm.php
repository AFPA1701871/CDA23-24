<?php

class GenForm {

    /**
     * Retourne un formulaire, selon la table
     *
     * @param array $table
     * @return string
     */
    public static function createForm(array $table) {
        $datas=json_decode(file_get_contents('type.json'),true);
        $form="<form method='post' action=''>\n";
        // $sql=["Personnes"=>["idPersonne"=>'INT',"nom"=>"VARCHAR","prenom"=>"VARCHAR",'adresse'=>'VARCHAR','ville'=>'VARCHAR']];
        $sql= ProjectGen::recupBDD();
        $classe=get_class($table[0]);
        $colonnes=$classe::getAttributes();

        for ($i = 0; $i < count($table); $i++) {
            for($x = 0; $x < count($colonnes); $x++){
                if(str_contains($colonnes[$x],"email")===true){
                    $typeInput="email";
                }
                else{
                    $typeSQL=$sql[$classe][$colonnes[$x]]; // recup le type de la colonne en SQL
                    $typeInput=$datas[$typeSQL][1]; // recup le type de la colonne en input
                }      
                $methode = "get" . ucfirst($colonnes[$x]);
                $form.="<label for='".$colonnes[$x]."'>". $colonnes[$x]. "</label>\n";
                $form.="<input type='".$typeInput."' id='".$colonnes[$x]."' name='".$colonnes[$x].($i+1)."' value='". $table[$i]->$methode(). "'>\n";                 
            }
        }
        $form.="</form>";
        return $form;
    }
}

