<?php

class MonstreDifficile extends MonstreFacile
{
    /***************************** Attributs ******************************************/
    private static $_nombreDifficile; //Valeur statique comptant le nombre de monstres difficiles vaincus
    private const DEGATSORT = 5; //dégat subit par le héros quand le monstre gagne l'attaque c'est une constante
    /***************************** Getter / Setter ***********************************/
    public static function getNombreDifficile()
    {
        return self::$_nombreDifficile;
    }
    // Increment the value of _nombreDifficile
    private static function incrementeNombreDifficile()
    {
        self::$_nombreDifficile ++;
    }
/***************************** Constructeur ******************************************/
    //Le constructeur n'est pas utile car les attributs sont déja initialisé */

    /***************************** Autres méthodes ******************************************/

    public function attaque(JOUEUR $joueur, $trace)
    {
        if ($trace) {
                echo "C'est un monstre difficile"."\n";
        }

        //On effectue l'attaque du monstre facile
        parent::attaque($joueur, $trace);
        //on applique le sort aux dégats
        $joueur->subitDegats($this->sortMagique($trace),$trace);
    }

    private function sortMagique($trace)
    {
        $valeur = $this->lanceLeDe();
        if ($trace) {
            echo "***              sort magique " . $valeur."\n";
        }

        if ($valeur == 6) {
            return 0;
        }
        return (self::DEGATSORT * $valeur);
	}
	public function subitDegats() // on surcharge la methode pour compter les monstres difficiles
    { // cette méthode affecte les dégats au monstre, pour l'instant ca le tue directement
        $this->setEstVivant(false);
        //on incremente le nombre de monstre facile
        self::incrementeNombreDifficile();
    }
}
