<?php

class Spheres extends Cercles
{

    /*****************Attributs***************** */
    

    /*****************Accesseurs***************** */

    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
       // parent::__construct($options);   Appel optionnel
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function __toString()
    {
        return parent::__toString()." - Volume de la sphère : ".$this->volume();
    }

    /**
     * Retourne le volume de la sphere
     *
     * @param Void
     * @return Float
     */
    public function volume()
    {       // 4/3 PI R3
        return 4/3*pi()*pow($this->getRayon(),3);
    }
}