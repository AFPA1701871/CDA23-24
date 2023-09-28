<?php
class Employe
{

    /*****************Attributs***************** */
    private $_nom;
    private $_prenom;
    private $_dateEmbauche;
    private $_fonction;
    private $_salaireAnnuel;
    private $_service;
    private Agence $_agence;
    private static $compteur = 0;

    /*****************Accesseurs***************** */
#region 
    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = ucFirst($nom);
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = ucFirst($prenom);
    }
    public function getDateEmbauche()
    {
        return $this->_dateEmbauche;
    }

    public function setDateEmbauche(DateTime $dateEmbauche)
    {
        $this->_dateEmbauche = $dateEmbauche;
    }

    public function getSalaireAnnuel()
    {
        return $this->_salaireAnnuel;
    }

    public function setSalaireAnnuel($salaireAnnuel)
    {
        $this->_salaireAnnuel = $salaireAnnuel;
    }

    public function getFonction()
    {
        return $this->_fonction;
    }

    public function setFonction($fonction)
    {
        $this->_fonction = $fonction;
    }

    public function getService()
    {
        return $this->_service;
    }

    public function setService($service)
    {
        $this->_service = ucfirst($service);
    }

    public function getAgence()
    {
        return $this->_agence;
    }

    public function setAgence(Agence $agence)
    {
        $this->_agence = $agence;
    }

    public static function getCompteur()
    {
        return self::$compteur;
    }

    public static function setCompteur($compteur)
    {
        self::$compteur = $compteur;
    }
    /*****************Constructeur***************** */

    public function __construct(array $options = [])
    {
        if (!empty($options)) // empty : renvoi vrai si le tableau est vide
        {
            $this->hydrate($options);
        }
        self::setCompteur(self::getCompteur() + 1); //on increment le compteur
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
#endregion
    /*****************Autres Méthodes***************** */

    /**
     * Transforme l'objet en chaine de caractères
     *
     * @return String
     */
    public function toString()
    {
        $aff = "\n\n*** SALARIE ***\n";
        $aff .= "Nom :" . $this->getNom() . "\nPrenom :" . $this->getPrenom() . "\nDateEmbauche :" . $this->getDateEmbauche()->format('Y-m-d') . "\nPosteEntreprise :" . $this->getFonction() . "\nSalaire annuel :" . $this->getSalaireAnnuel() . "K\nService :" . $this->getService() . "\n";
        
        $aff .= "\n*** AGENCE ***\n" . $this->getAgence()->toString();
        
        return $aff;
    }

    
    /**
     * Compare 2 objets sur le nom et le prénom
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareToNomPrenom($obj1, $obj2)
    {
        // if ($obj1->getNom() < $obj2->getNom())
        // {
        //     return -1;
        // }
        // else if ($obj1->getNom() > $obj2->getNom())
        // {
        //     return 1;
        // }// ils ont le meme nom
        // else if ($obj1->getPrenom() < $obj2->getPrenom())
        // {
        //     return -1;
        // }
        // else if ($obj1->getPrenom() > $obj2->getPrenom())
        // {
        //     return 1;
        // }
        // // ils ont le meme nom et prenom
        // return 0;

        /* *** version courte *** */
            if (strcmp($obj1->getNom(),$obj2->getNom())==0)
            {
                return strcmp($obj1->getPrenom(),$obj2->getPrenom());
            }
            return strcmp($obj1->getNom(),$obj2->getNom());
    }
    /**
     * Compare 2 objets sur le service puis le nom et le prénom
     * Renvoi 1 si le 1er est >
     *        0 si ils sont égaux
     *        -1 si le 1er est <
     *
     * @param [type] $obj1
     * @param [type] $obj2
     * @return void
     */
    public static function compareToServiceNomPrenom($obj1, $obj2)
    {
        if ($obj1->getService() < $obj2->getService())
        {
            return -1;
        }
        else if ($obj1->getService() > $obj2->getService())
        {
            return 1;
        }
        else
        {
            return self::compareToNomPrenom($obj1, $obj2);
        }

    }
    /**
     * Renvoi l'anciennete de l'employe
     *
     * @return int  le nombre d'annee d'ancienneté
     */
    public function anciennete()
    {
        $auj = new DateTime('now');
        $interval = $auj->diff($this->getDateEmbauche(), true); //diff renvoi une DateIntervalle, true oblige cet interval a être positif
        var_dump($auj,$interval);
        $annee = $interval->format('%y') * 1; // on *1 pour avoir un int
        return $annee;
    }

    /**
     * methode pour pour calculer la prime salaire
     *
     * @return  double  le montant de la prime salaire
     */
    private function primeSalaire()
    {
        return $this->getSalaireAnnuel() * 1000 * 0.05; // on retourne le montant de la prime annuelle
    }

    /**
     * methode pour pour calculer la prime d'ancienneté
     *
     * @return   double le montant de la prime d'ancienneté
     */
    private function primeAnciennete()
    {
        return $this->getSalaireAnnuel() * 1000 * 0.02 * $this->anciennete(); // on retourne le montant de la prime annuelle
    }

    /**
     * methode pour pour calculer la prime annuelle
     *
     * @return  double  le montant de la prime annuelle
     *
     *
     */
    public function prime()
    {
        return $this->primeSalaire() + $this->primeAnciennete(); // on retourne le montant de la prime annuelle
    }
    /**
     * Renvoi la masse salariale de l'employé
     *
     * @return int
     */
    public function masseSalariale()
    {
        return $this->getSalaireAnnuel() * 1000 + $this->prime();
    }

    

}
