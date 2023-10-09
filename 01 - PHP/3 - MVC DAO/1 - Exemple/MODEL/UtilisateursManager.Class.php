<?php

class UtilisateursManager 
{

	public static function add(Utilisateurs $obj)
	{
 		return DAO::add($obj);
	}

	public static function update(Utilisateurs $obj)
	{
 		return DAO::update($obj);
	}

	public static function delete(Utilisateurs $obj)
	{
 		return DAO::delete($obj);
	}

	public static function findById($id)
	{
 		return DAO::select("Utilisateurs",Utilisateurs::getAttributes(),["idUtilisateur" => $id])[0];
	}

	public static function getList(array $nomColonnes=null,  array $conditions = null, string $orderBy = null, string $limit = null, bool $api = false, bool $debug = false)
	{
 		$nomColonnes = ($nomColonnes==null)?Utilisateurs::getAttributes():$nomColonnes;
		return DAO::select("Utilisateurs", $nomColonnes , $conditions ,  $orderBy,  $limit ,  $api,  $debug );	}
}