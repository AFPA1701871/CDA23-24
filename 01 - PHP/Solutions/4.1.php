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
function DemanderEntier(string $invite,bool $positif=false)
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

function CreerTableau(string $invite)
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


 echo DemanderEntier("note :", false)."\n";
// echo DemanderEntier("note positive:", true)."\n";
// echo DemanderEntier("entrer une valeur :", false)."\n";