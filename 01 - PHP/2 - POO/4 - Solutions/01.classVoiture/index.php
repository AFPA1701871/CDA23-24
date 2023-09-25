<?php
require 'voiture.class.php';
$voitureUn = new Voiture(["marque"=>"Citroen", "modele"=> "C4","nbDeKilometres"=>10000]);
$voitureDeux = new Voiture(array("couleur"=> 'rouge' , "marque"=>"renault", "modele"=> "kadjar"));


echo $voitureUn->description();
echo "\n";
echo $voitureDeux->description();
$voitureUn->rouler(2350);
echo "\n";
echo $voitureUn->description();