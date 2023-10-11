<?php

class GenList
{
    private static function getData($nomTable){
        $db = ProjectGen::getDb();
        $requete = "SELECT * FROM ". $nomTable;
        $req = $db->prepare($requete);
        $req->execute();
        while ($donnees = $req->fetch(PDO::FETCH_ASSOC)) {
            $tableau[] = $donnees;
        }
        $req->closeCursor();
        return $tableau;
    }
    public static function createList(string $nomTable)
    {
        $liste = '<?php $test =ucfirst("'.$nomTable.'")' .'."Manager";'. "\n";
        $liste .= '$listeDonnees = $test::getList();?>'."\n";
        $liste .= '<div class="titre">Liste '.$nomTable.' </div>'."\n";
        $liste .= "<button class='btnAdd'>Ajoute</button>\n";
        $liste .= "<div'class='ligne'>\n";
        $liste .= '<?php $tabColonne='.$nomTable.'::getAttributes();';
        $liste .= 'foreach($tabColonne as $nomColonne => $typeColonne){ ?>'. "\n";
        $liste .= '<p class="nomColonne"><?= $nomColonne ?></p>'."\n";
        $liste .= "<?php } ?>\n";
        $liste .= "<div class='nomColonne'>Supprimer</div>\n";
        $liste .= "<div class='nomColonne'>Mise a jour</div>\n";
        $liste .="</div>\n";

        $liste .= '<?php foreach ($listeDonnees as $ligneDonnee) {'."\n";
        $liste .= ' $ligneDonnees = (array) $ligneDonnee;?>';
        $liste .= "<div class='ligne'>\n";
        $liste .= '    <?php foreach ($ligneDonnees as $donne){ ?>' . "\n";
        $liste .= '<p class="donnee"> <?=$donne?></p>'. "\n";
        $liste .= '<?php }?>'; 
        $liste .= "<button class='btnDelete'>supprime</button>\n";
        $liste .= "<button class='btnUpdate'>Maj</button>\n";
        $liste .= '<?php }?>';
        $liste .= "</div>\n";

        return  $liste;
    }
}