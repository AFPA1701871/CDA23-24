<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

//CREATION DU RECTANGLE
$r = new Rectangles(["Largeur" => 10, "Longueur" => 5]);
echo "\nLe RECTANGLE\n".$r; // AFFICHAGE DE RECTANGLE

//CREATION DU TRIANGLE
$t1 = new Triangles(["Base" => 10, "Hauteur" => 5]);
echo "\nLe TRIANGLE\n".$t1; //AFFICHAGE DU TRIANGLE


//CREATION De CERCLE
$c1 = new Cercles(["Diametre" => 10]);
echo "\n\nLe CERCLE\n".$c1."\n"; //AFFICHAGE De CERCLE

//CREATION De PAVE
$p1 = new Paves(["Largeur" => 10,"Longueur"=>5,"Hauteur"=>7]);
echo "\nLe PAVE\n".$p1;

//CREATION De SPHERE
$s1 = new Spheres(["Diametre" => 6]);
echo "\nLa SPHERE\n".$s1;

//CREATION De Pyramide
$py1 = new Pyramides(["Base" => 10, "Hauteur" => 5, "Haut"=>7]);
echo "\nLa PYRAMIDE\n".$py1;