<?php
require "classe.php";
$c = new Toto();
echo $c;

function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");