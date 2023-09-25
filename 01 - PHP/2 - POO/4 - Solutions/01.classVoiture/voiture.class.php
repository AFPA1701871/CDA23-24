<?php
class Voiture
{

    /*****************Attributs***************** */
    private $_couleur;
    private $_marque;
    private $_modele;
    private $_nbDeKilometres;
    private $_motorisation;
    /*****************Accesseurs***************** */
    public function getCouleur()
    {
        return $this->_couleur;
    }

    public function setCouleur(?string $couleur)
    {
        $this->_couleur = $couleur;
    }

    public function getMarque()
    {
        return $this->_marque;
    }

    public function setMarque(?string $marque)
    {
        $this->_marque = $marque;
    }

    public function getModele()
    {
        return $this->_modele;
    }

    public function setModele(?string $modele)
    {
        $this->_modele = $modele;
    }

    public function getNbDeKilometres()
    {
        return $this->_nbDeKilometres;
    }

    public function setNbDeKilometres(?int $nbDeKilometres)
    {
        $this->_nbDeKilometres = $nbDeKilometres;
    }

    public function getMotorisation()
    {
        return $this->_motorisation;
    }

    public function setMotorisation(?string $motorisation)
    {
        $this->_motorisation = $motorisation;
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
            if (is_callable([$this, $methode])) // is_callable verifie que la methode existe

            {
                $this->$methode($value);
            }
        }
    }
    /*****************Methode***************** */
    public function description()
    {
        return $this->__toString();
    }

    public function __toString()
    {
        return "Cette voiture est un " . $this->getModele() . " de la marque " . $this->getMarque() . ", de couleur " . $this->getCouleur() . " de motorisation " . $this->getMotorisation() . " avec " . $this->getNbDeKilometres() . " kilometres";
    }

    public function rouler($value)
    {
        $this->setNbDeKilometres($this->getNbDeKilometres() + $value);
    }
}
