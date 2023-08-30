<?php
// Les fonctions de bases


/**
 * Bonus : Demande à l'utilisateur de saisir une valeur avec l'invite en paramètre
 * Vérifie que la saisie correspond au besoin c'est à dire un entier
 * Si $positif est vrai alors l'entier saisi doit être positif
 *
 * @param string $invite
 * @param boolean $positif définit si l'entier doit être positif
 * @return int renvoi l'entier saisi par l'utilisateur
 */
function demanderEntier(string $invite,bool $positif=false)
{
    // on demande un nombre à l'utilisateur
    do
    {
        $nb = readline($invite);
    }
    while (!preg_match("/^(-)?[\d]+$/", $nb) || ($positif && $nb < 0)); // test si la saisie correpond au modèle de la regex c'est à dire numéric sans virgule
    return $nb;
}

/**
 * 4.1.1 Créer un tableau rempli à partir d'une saisie utilisateur terminée par 0
 * 
 * $invite string invite proposée à l'utilisateur pour lui demander la saisie
 * 
 * return array
 */

function creerTableau(string $invite)
{
    do
    {
        // on demande les prix un par un
        $nombre = DemanderEntier($invite);
        $tab[]=$nombre;
    } while ($nombre != 0); // on s'arrete quand le nombre est = à 0
    array_pop($tab);
    return $tab;
}

/**
 * Fonction qui affiche un tableau en séparant ses élément par un tiret
 *
 * @param array $tab Tableau à afficher
 */
function afficheTableau(array $tab){
    echo implode("\t", $tab)."\n";
}

/**
 * Compare 2 valeurs entre elles
 *
 * @param mixed $val1 
 * @param mixed $val2
 * @return bool 
 */
// function compareTo($val1, $val2) {
//     if ($val1 == $val2) {
//         return 0;
//     }
//     return ($val1 > $val2) ? 1 : -1; 
// }
function compareTo($val1, $val2) {
   return  rand(0,1)>0.5? -1:1;
}

/**
 * Créer les traits de séparation pour la présentation du tableau
 *
 * @param [type] $nbColonne
 * @return string   traits à afficher
 */
function faireTraits($nbColonne)
{
    $traits = "" ;
    for ($j = 0; $j < $nbColonne; $j++) {

        $traits .= "----------------";
    }
    $traits .= "\n";
    return $traits;
}


function remplirTableau2Dimentions($x,$y){
    for ($i = 0 ; $i <= $x; $i++) {     
       $tab[]= array_fill(0,$y,"X");
    }
    return $tab;
}
/**
 * affiche un tableau a 2 dimensions 
 *
 * @param array $tab tableau 2 dimensions
 * @return void
 */
function afficherTableau2Dimentions($tab){
    // Calcul du nombre de colonnes ($x) et de lignes ($y) dans le tableau
    $colonnes = count($tab[0]);
    $lignes = count($tab);
    
    // Génération de la ligne de traits pour la bordure supérieure
    $traits = faireTraits(count($tab[0])+1);
    echo $traits;
    
    // Initialisation de la variable alpha à 'A' pour les étiquettes de colonne
    $alpha = 'A';
    
    // Affichage de la première ligne avec les étiquettes de colonne
    echo "| \t  \t";
    for ($i = 0; $i < $colonnes; $i++){
        echo "| \t" . $alpha . " \t"; // Affiche l'étiquette de colonne
        $alpha++; // Incrémente la lettre de l'étiquette de colonne
    }
    echo "| \t  \t \n"; // Nouvelle ligne pour les données
    echo $traits; // Affiche la ligne de traits sous les étiquettes de colonne

    // Boucle pour afficher les données du tableau
    for ($i = 0; $i < $lignes; $i++){
        echo "| \t" . ($i+1) . " \t"; // Affiche l'étiquette de ligne
        for ($j = 0; $j < $colonnes; $j++){
            echo "| \t" . $tab[$i][$j] . " \t"; // Affiche la valeur de la cellule
        }
        echo "|\n"; // Nouvelle ligne pour la prochaine ligne de données
        echo $traits; // Affiche la ligne de traits après chaque ligne de données
    }
}

//  echo DemanderEntier("note :", false)."\n";
// echo DemanderEntier("note positive:", true)."\n";
// echo DemanderEntier("entrer une valeur :", false)."\n";
// $notes = creerTableau("entrer une note : ");
// afficheTableau($notes);
// usort($notes, 'compareTo');
// afficheTableau($notes);
// usort($notes,function ($a,$b){return $a>$b;});
// AfficheTableau($notes);


$plateau = remplirTableau2Dimentions(6,5);
afficherTableau2Dimentions($plateau);