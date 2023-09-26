<?php

class Paves extends Rectangles
{

    /*****************Attributs***************** */
    private $_hauteur;

    /*****************Accesseurs***************** */

    public function getHauteur()
    {
        return $this->_hauteur;
    }

    public function setHauteur($hauteur)
    {
        $this->_hauteur = $hauteur;
    }
    
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
		//parent::__construct($options); appel optionnel
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    // La fonction hydrate est optionnelle, si elle n'est pas présente, celle du parent sera appelée
    // public function hydrate($data)
    // {
    //     foreach ($data as $key => $value)
    //     {
    //         $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
    //         if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
    //         {
    //             $this->$methode($value);
    //         }
    //     }
    // }

    /*****************Autres Méthodes***************** */
    
    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function __toString()
    {
        return parent::__toString()." - Hauteur : ".$this->getHauteur()." - Volume : ".$this->volume()." - Perimetre : ".$this->perimetre()."\n";
    }

    /**
     * Renvoi le perimetre du pave
     *
     * @param Void
     * @return Float
     */
    public function perimetre()
    {   //appel à la méthode parent périmètre (Surcharge)
        return parent::perimetre()*2+$this->getHauteur()*4;
    }

    /**
     * Renvoi l'aire du pave
     *
     * @param Void
     * @return Float
     */
    public function volume()
    {
        return parent::aire()*$this->getHauteur();
    }
}