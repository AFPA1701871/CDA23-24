<?php
class Rectangles
{

    /*****************Attributs***************** */
    private $_longueur;
    private $_largeur;

    /*****************Accesseurs***************** */
    public function getLongueur()
    {
        return $this->_longueur;
    }

    public function setLongueur($longueur)
    {
        $this->_longueur = $longueur;
    }

    public function getLargeur()
    {
        return $this->_largeur;
    }

    public function setLargeur($largeur)
    {
        $this->_largeur = $largeur;
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
        $reponse =  "Longueur : " . $this->getLongueur() . " - Largeur : " . $this->getLargeur() . " - Périmètre : " . $this->perimetre() . " - Aire : " . $this->aire() . " - ";
        
        $reponse .= $this->estCarre()?"Il s'agit d'un carré ":"Il ne s'agit pas d'un carré ";
        return $reponse;
    }
    /**
     * Retourne le perimetre du rectangle
     *
     * @return int
     */
    public function perimetre()
    {
        return ($this->getLongueur()+$this->getLargeur())*2;
    }
    /**
     * Retourne l'aire du rectangle
     *
     * @return int
     */
    public function aire()
    {      return ($this->getLongueur()*$this->getLargeur());
  
    }
    /**
     * renvoi vrai si le rectangle est un carré
     *
     * @return void
     */
    public function estCarre()
    {      return $this->getLongueur()==$this->getLargeur();
  
    }
   
}
