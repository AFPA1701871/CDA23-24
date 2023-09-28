<?php

class Joueur
{
    /***************************** Attributs ******************************************/
    private $_pV; //Point de vie du joueur
    private $_nom; //nom du joueur

    /***************************** Getter / Setter ***********************************/
    public function getPV()
    {
        return $this->_pV;
    }
    private function setPV($_pV) /* Point de vie est en lecture seule, la methode set est en private*/
    {
        $this->_pV = $_pV;
    }
    public function getNom()
    {
        return $this->_nom;
    }
    public function setNom($_nom)
    {
        $this->_nom = $_nom;

        return $this;
    }
    /***************************** Constructeur ******************************************/

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
    public function estVivant()
    { // cette methode renvoi vrai si le joueur est vivant
        return ($this->getPV() > 0); // il est vivant si ses points de vie sont strictement supérieur à 0
    }

    public function lanceLeDe()
    { //Cette méthode simule le lancer de dé.
        return De::lanceLeDe(); // pour l'instant un simple lancer. Pour ameliorer le jeu, on pourra choisir le meilleur de 3 lancer par exemple
    }

    public function attaque(MonstreFacile $monstre, $trace) //on force le parametre à être un monstre, comme MonstreDifficile herite de monstreFacile, les 2 repondent au critere MonstreFacile

    { //Cette méthode simule l'attaque du joueur sur un monstre et modifie le monstre en consequence (subitdegat)
        //Lancer de dé
        $valjoueur = $this->lanceLeDe();
        $valmonstre = $monstre->lanceLeDe();
        //on affiche les données
        if ($trace) {
            echo $this->getNom() . " attaque : " . $valjoueur . "  le Monstre : " . $valmonstre."\n";
        }

        //Compare les lancés de dé :
        //Si le joueur fait autant ou plus que le monstre, le joueur gagne
        if ($valjoueur >= $valmonstre) {
            $monstre->subitDegats(); //le monstre subit des dégats (dans la version actuelle du jeu, il meurt)
            if ($trace) {
                echo "***              " . $this->getNom() . " gagne "."\n";
            }

        }
    }

    public function subitDegats($degats, $trace)
    { // cette methode reporte les dégats au joueur en fonction du résultat du bouclier
        if (!$this->bouclierFonctionne($trace)) {
            $this->setPV($this->getPV() - $degats);
            if ($trace) {
                echo "***              héros subit des dégats " . $degats . "   reste : " . $this->getPV()."\n";
            }

        }
    }
    private function bouclierFonctionne($trace) /* La methode est private car ne peut etre appelee que depuis la classe*/
    { // cette méthode renvoi vrai si le bouclier fonctionne
        $bouclier = $this->lanceLeDe();
        if ($trace) {
            echo "***              bouclier " . $bouclier."\n";
        }

        return ($bouclier <= 2); // on compare le bouclier à 2
    }

}
