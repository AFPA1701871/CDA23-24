<?php
/**
 * initialise les paramètres du jeu
 *
 * @return array Tableau associatif qui retourne toute les variables d'initialisation
 */
function init(){}

/**
 * Demande le niveau de difficulté à l'utilisateur
 *
 * @return int niveau de difficulte
 */
function saisirDifficulte(){}

/**
 * Demande le nombre de joueur
 *
 * @return int nombre de joueurs
 */
function saisirNbJoueur(){}

/**
 * Demande le nombre de vie aux joueurs
 *
 * @return int nombre de vie
 */
function saisirNbVie(){}

/**
 * Choisi au hasard un mot dans une liste
 *
 * @return string mot qui doit être trouvé par les joueurs
 */
function determinerMotAChercher(){}

function jeu($motAChercher,$difficulte,$nbJoueur,$nbVie){}

/**
 * Construit un tableau du mot en fonction de la difficulté
 *
 * @param string $mot Mot à chercher
 * @param integer $difficulte Difficulté de la partie indiquée
 * @return array Le tableau du mot
 */
function coderMot(string $mot, int $difficulte){}

/**
 * Affiche le mot codé
 *
 * @param array $motCode Tableau du mot codé
 * @return void
 */
function afficherMotCode(array $motCode){}

/**
 * Permet de décider qui va jouer
 *
 * @param integer $nbJoueur Le nombre de joueur
 * @param integer $joueurEnCours Le joueur qui vient de jouer
 * @return void
 */
function joueurSuivant(int $nbJoueur, int $joueurEnCours){}

/**
 * Permet au joueur en cours de proposer une lettre
 *
 * @param integer $joueurEnCours Celui qui doit jouer
 * @return string La lettre ayant été proposée
 */
function saisirLettre(int $joueurEnCours){}

/**
 * Vérifie si la lettre fait partie du mot ou pas
 *
 * @param string $lettre La lettre entrée par le joueur
 * @param array $motCode La partie du mot que le joueur connait
 * @param string $mot Le mot que le joueur doit trouvé
 * @param int $difficulte La difficulte de la partie
 * @param string $propositions Les lettre déjà proposées
 * @return void
 */
function verifierLettre(string $lettre, array $motCode, string $mot, int $difficulte, string $propositions){}

/**
 * Vérifie si la lettre est correcte et pas encore ajoutée
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @return bool
 */
function estCorrecte(string $lettre, array $motcode, string $mot){}

/**
 * Ajoute la lettre au mot codé en fonction du niveau de difficulté
 *
 * @param string $lettre
 * @param array $motcode
 * @param string $mot
 * @param integer $difficulte
 * @return array Le mot codé
 */
function ajouterLettre(string $lettre, array $motcode, string $mot, int $difficulte){}

/**
 * Clear la console et réaffiche le jeu dans l'état actuel
 *
 * @param integer $nbVie
 * @param array $motCode
 * @param integer $joueurEnCours
 * @param string $propositions
 * @return void
 */
function affichageGlobal(int $nbVie, array $motCode, int $joueurEnCours, string $propositions){}

/**
 * Affiche le nombre de vie restante + pendu ?
 *
 * @param integer $nbVie
 * @return void
 */
function affichageVie(int $nbVie){}

/**
 * Undocumented function
 *
 * @param array $motCode
 * @return int Etat de la partie (0 -1 1
 * 0 = en cours
 * -1 = perdu
 * 1 = gagne
 * */
function estGagne(array $motCode){}

/**
 * Conclu le jeu Gagné ou Perdu
 *
 * @param boolean $resultat
 * @return void
 */
function conclusion($resultat){}