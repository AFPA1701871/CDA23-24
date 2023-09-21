<?php 

// DEBUT PROGRAMME

//initalisation du debut du jeu
init();

// FONCTIONS

/**
 * Permet de créer un controle select numérique
 *
 * @param [type] $nbDebut valeur de début
 * @param [type] $nbFin valeur de fin
 * @param [type] $id id du futur select
 * @return void
 */
function creerSelect($nbDebut,$nbFin,$id)
{
   $retour =  ' <select id="'.$id.'">';
   $retour.= '<option selected value >Entrer une valeur</option>';
    for($i=$nbDebut;$i<=$nbFin;$i++){
        $retour.= '<option value="'.$i.'">'.$i.'</option>';
    }
    $retour.= ' </select>';
    return $retour;
}

/**
 * Création des composants permettant de rendre fonctionnel le jeu
 *
 * @return void
 */
function init(){

    echo '<!DOCTYPE html>
    <html lang="fr">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <link rel="stylesheet" href="./style.css">
        <title>Memory</title>
    </head>
    <body>
    <main>';
    AffichageConfigurationDebutPartie();
   
    echo'
    <section class=cards></section>
    </main>'; 
    AffichageTypeCarte();
    echo '<script src="./script.js"></script>
    </body>
    </html>';
}

/**
 * Visuel type d'une card
 *
 * @return void
 */
function AffichageTypeCarte( ){
    echo '<template><img  src="./Images/plage.jpg" data-image="DATAIMAGE"></img></template>';  
}


/**
 * Affichage des configurations du jeu
 *
 * @return void
 */
function AffichageConfigurationDebutPartie(){
    echo '<section>
    <div>
    <label>Nombre de joueurs : </label>'.
    creerSelect(1,3,'nbJoueur')
    .'</div><div>
    <label>Nombre de paires de cartes à mémoriser : </label>'.
    creerSelect(3,8,'nbPaire')
    .'</div><div>
    <button id="start" disabled type="button">Démarrer</button>
    <button id="reset"  type="button">Reset</button>
    </div></section>';
}
