<?php

class Pyramides extends Triangles
{

	/*****************Attributs***************** */

	private $_profondeur;

	/*****************Accesseurs***************** */

	public function getProfondeur()
	{
		return $this->_profondeur;
	}

	public function setProfondeur($profondeur)
	{
		$this->_profondeur = $profondeur;
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
	// public function hydrate($data)
	// {
	// 	foreach ($data as $key => $value)
	// 	{
	// 		$methode = "set" . ucfirst($key); //ucfirst met la 1ere lettre en majuscule
	// 		if (is_callable(([$this, $methode]))) // is_callable verifie que la methode existe
	// 		{
	// 			$this->$methode($value);
	// 		}
	// 	}
	// }

	/*****************Autres Méthodes***************** */

	/**
	* Transforme l'objet en chaine de caractères
	*
	* @return String.
	*/
	public function __toString()
	{
		return parent::__toString()."\n profondeur : ".$this->getProfondeur()."\nPérimètre :".$this->perimetre()."\n"."Volume :".$this->volume()."\n";
	}
	/**
	* Renvoi vrai si l'objet en paramètre est égal à l'objet appelant
	*
	* @param [type] $obj
	* @return bool
	*/
	public function equalsTo ($obj)
	{
		return true;
	}
	

	public function perimetre()//Calcul du périmètre
	{
		return parent::perimetre()*2+$this->getProfondeur()*3;
	}

	public function volume() //Calcul du volume
	{
		//return $this->aire()*$this->getProfondeur(); // les 2 écritures fonctionnent
		return parent::aire()*$this->getProfondeur();
	}
}