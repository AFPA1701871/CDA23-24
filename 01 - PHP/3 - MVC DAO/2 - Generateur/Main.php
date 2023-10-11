<?php

function loadClass($class)
{
    require $class.".php";
}
spl_autoload_register("loadClass");

ProjectGen::init(); // initialise la connection à la base de données
ProjectGen::dirGen(); // genère l'arborescence du projet et copy les fichiers invariants
ProjectGen::classesGen();