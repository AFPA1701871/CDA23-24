<?php

class MonstreFacile
{
    /***************************** Attributs ******************************************/
    private const DEGATS = 10; //dégat subit par le héros quand le monstre gagne l'attaque c'est une constante
    private static $_nombreFacile = 0; // compte le nombre de monstrefacile vaincu STATIC Variable de classe
    protected $_estVivant = true; // donne l'état du monstre TRUE pour vivant, FALSE pour Mort
    /***************************** Getter / Setter ***********************************/
    public static function getNombreFacile()
    {
        return self::$_nombreFacile;
    }
    private static function incrementNombreFacile()
    {
        self::$_nombreFacile ++;
    }
    public function getEstVivant()
    {
        return $this->_estVivant;
    }
    public function setEstVivant($estVivant)
    {
        $this->_estVivant = $estVivant;
        return $this;
    }
    /***************************** Constructeur ******************************************/
    //Le constructeur n'est pas utile car les attributs sont déja initialisé */
    public function __construct(array $options = [])
    {
        if (!empty($options)) {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value) {
            $method = 'set' . ucfirst($key);

            if (is_callable([$this, $method])) {
                $this->$method($value);
            }
        }
    }
    /***************************** Autres méthodes ******************************************/
    public function attaque(Joueur $joueur, $trace)
    { //Cette méthode simule l'attaque du monstre sur un joueur et modifie le joueur en consequence (subitdegat)
        $valMonstre = $this->lanceLeDe();
        $valJoueur = $joueur->lanceLeDe();
        if ($trace) {
            echo "Monstre  attaque: " . $valMonstre . "  mon héros : " . $valJoueur."\n";
        }

        if ($valMonstre > $valJoueur) {
            $joueur->subitDegats(self::DEGATS,$trace);
        }
    }
    public function subitDegats()
    { // cette méthode affecte les dégats au monstre, pour l'instant ca le tue directement
        $this->setEstVivant(false);
        //on incremente le nombre de monstre facile
        self::incrementNombreFacile();
    }

    public function lanceLeDe()
    { //Cette métjode simule le lancer de dé.
        return De::lanceLeDe(); // pour l'instant un simple lancer. Pour ameliorer le jeu, on pourra choisir le meilleur de 3 lancer par exemple
    }
}
