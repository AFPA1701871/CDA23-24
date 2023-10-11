<?php 

/**
 * Permet de loger les infos dans des fichiers de log correspondants
 *
 * @param string $file : le nom du fichier
 * @param string $message : message à afficher 
 * @param bool $isError : true si le message représente une erreur, false sinon
 * @return void
 */
function genelog(string $file, string $message, bool $isError)
{
    // 
    date_default_timezone_set('Europe/Paris');

    $dateUTC = new DateTime('now');

    $date_format = $dateUTC->format('Y-m-d H:i:s');

    // création du fichier de log
    $logFile = fopen(__DIR__ . "/../LOG/" . $file . '.log', "a"); 

    // écriture des logs dans le fichiers 
    fwrite($logFile, $date_format . " :" . ($isError ? "!ERROR! " : '') . $message . PHP_EOL);

    //fermeture du fichier.
    fclose($logFile);
}

// penser à require dans le main
// formalisme d'utilisation : 
// genelog(get_class() . "-" . __FUNCTION__ , "initialisation de la base de donnée", false);