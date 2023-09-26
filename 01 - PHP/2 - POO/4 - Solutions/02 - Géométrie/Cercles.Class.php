<?php

class Cercles
{

    /*****************Attributs***************** */
    private $_diametre;
    private $_rayon;

    /*****************Accesseurs***************** */
    public function getDiametre()
    {
        return $this->_diametre;
    }

    public function setDiametre($diametre)
    {
        $this->_diametre = $diametre;
        $this->_rayon = $diametre/2;
    }
    protected function getRayon()
    {
        return $this->_rayon;
    }
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
    }
    public function hydrate($data)
    {
        foreach ($data as $key => $value)
        {
            $methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
            if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
            {
                $this->$methode($value);
            }
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
        return "\nDiametre :".$this->getDiametre()."\tRayon :".($this->getDiametre()/2)."\tPerimetre :".$this->perimetre()."\tAire :".$this->aire();
    }

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] $obj
     * @return bool
     */
    public function equalsTo($obj)
    {
        return true;
    }
    /**
     * Compare 2 objets
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareTo($obj1, $obj2)
    {
        return 0;
    }

    public function perimetre()
    {   //pi D
        return pi() *$this->getDiametre();
     }

    public function aire()
    {   //pi R²
        // 1ere technique
        return pi() *pow(($this->getDiametre()/2),2);
        //2eme technique 
        return pi() *pow($this->getRayon(),2);
        
    }
    

   
}