<?php

//Permet de simuler un lancer de dés retournant un chiffre entre 1 et 6
class De
{
	static public function lanceLeDe()
	{// La méthode est static pour être appelée depuis d'autres classes
		return rand(1, 6);
	}
}
