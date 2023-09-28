<?php
// Autoload pour les classes
function chargerClasse($classe)
{
    require $classe . ".class.php";
}
spl_autoload_register("chargerClasse");

function lancerJeu($trace)
{ //methode qui lance le jeu
    $monHeros = new Joueur(["pV" => 50, "nom" => "monHeros"]);
    while ($monHeros->estVivant()) // Tant que le héros est vivant, il comnbat des monstres
    {
        $monstre = FabriqueDeMonstre();
        while ($monstre->getEstVivant() && $monHeros->estVivant()) // Attaque succéssive jusqu'à ce que l'un des 2 soit tués
        {
            $monHeros->attaque($monstre,$trace);
            if ($monstre->getEstVivant()) {
                $monstre->attaque($monHeros,$trace);
            }
        }

        if ($trace and $monHeros->estVivant()) {
            echo "************************************  Monstre Suivant"."\n";
        }

    }
	echo "Dommage, vous êtes mort...\n";
	echo "Cela dit, vous avez tué " . MonstreFacile::getNombreFacile() . " monstres faciles et " . MonstreDifficile::getNombreDifficile() . " monstres difficiles. \n";
	echo "Vous avez ".(MonstreFacile::getNombreFacile() + MonstreDifficile::getNombreDifficile() * 2)." points."."\n";
}
function FabriqueDeMonstre()
{ //Méthode qui fabrique (instancie des Monstres faciles ou difficiles)
    //Renvoi une instance de Monstre (Comme MonstreDifficile herite de MonstreFacile, les 2 sont permis)
    if (rand(1, 2) == 1) {
        return new MonstreFacile();
    } else {
        return new MonstreDifficile();
    }

}

//on determine si on affiche les traces
do {
    $reponse = strtoupper(readline("Jouer en mode Trace ? (O/N) "));
} while ($reponse != "O" and $reponse != "N");

if ($reponse == "O") {
    $trace = true;
} else {
    $trace = false;
}

lancerJeu($trace);
