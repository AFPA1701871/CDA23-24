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
    private $_enfants = [];
    private static $_compteur = 0;

    /*****************Accesseurs***************** */

    public function getNom()
    {
        return $this->_nom;
    }

    public function setNom($nom)
    {
        $this->_nom = $nom;
    }

    public function getPrenom()
    {
        return $this->_prenom;
    }

    public function setPrenom($prenom)
    {
        $this->_prenom = $prenom;
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

    public function getEnfants()
    {
        return $this->_enfants;
    }

    /**
     * Affecte tous les enfants à l'employe
     *
     * @param array $enfants
     * @return void
     */
    public function setEnfants(array $enfants)
    {
        $this->_enfants = $enfants;
    }

    /**
     * Permet d'ajouter un enfant à la liste
     *
     * @param Enfant $enfant
     * @return void
     */
    public function setEnfant(Enfant $enfant)
    {
        $this->_enfants[] = $enfant;
    }
    public static function getCompteur()
    {
        return self::$_compteur;
    }

    public static function setCompteur($compteur)
    {
        self::$_compteur = $compteur;
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
        $aff .= $this->recoitChequeVacances() ? "Ce salarié bénéficie de chèques vacances\n" : "Ce salarié ne bénéficie pas de chèques vacances\n";
        $aff .= "\n*** AGENCE ***\n" . $this->getAgence()->toString();
        $aff .= "\n*** ENFANTS ***\n";
        if (count($this->getEnfants()) > 0)
        {
            foreach ($this->getEnfants() as $enfant)
            {
                $aff .= $enfant->toString();
            }
        }
        else
        {
            $aff .= "Pas d'enfant";
        }
        $aff .= "\n*** CHEQUES NOEL ***\n";
        $cheques = $this->recoitChequeNoel();
        if (array_sum($cheques) > 0)
        {
            foreach ($cheques as $key=>$nbCheque) // on parcours le tableau de chèques
            {
                if ($nbCheque > 0)    //  si le nombre de chèque est supérieur à 0
                {
                    $aff .= $nbCheque . " chèque(s) de ".$key."\n";   //$nbCheque contient le nombre de chèques  et $key, la valeur du chèque
                }
            }
        }
        else
        {
            $aff .= "Pas de chèques de Noël";
        }
        return $aff;
    }

    /**
     * Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
     *
     * @param [type] obj
     * @return bool
     */
    public function equalsTo($obj)
    {
        return true;
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
     * Compare 2 objets sur le nom et le prénom
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

    /**
     *
     * verifie si l'employé est eligible aux cheques vacances
     *
     * @return string oui ou non selon si l'employé est eligible ou pas
     */
    public function recoitChequeVacances()
    {

        return ($this->anciennete() >= 1); // on verifie par rapport a l'anciennete si l employé est dans l'entreprise depuis plus d'un an
    }
    /**
     * renvoi un tableau contenant le nombre de chèque de chaque montant
     *
     * @return array
     */
    public function recoitChequeNoel()
    {
        $cheque = ["0" => 0, "20" => 0, "30" => 0, "50" => 0];
        foreach ($this->getEnfants() as $enfant)
        {
            $cheque[$enfant->montantChequeNoel()] += 1; // on augmente la valeur liée à l'étiquette correspondant au montant retourné par la fonction
        }
        $cheque["0"] = 0;       // pour que la somme du tableau corresponde au nombre de chèques à distibuer
        return $cheque;
    }
}
