<?php
function autoload($classe)
{
    require $classe . ".Class.php";
}
spl_autoload_register("autoload");

/*
Description : Affiche les éléments du tableau séparés par une tabulation // Utilisation du foreach
$tab : tableau à afficher
 */
function afficheTableau($tab)
{
    echo "\n";
    foreach ($tab as $elt) // le tableau est parcouru de la 1ere à la dernière case, les cases sont mises tour à tous dans $elt
    {
        echo $elt->toString() . "\n";
    }
    echo "\n";
}
$a1 = new agence(["Nom" => "tutu", "adresse" => "12 rue toto","restauration" => "restaurant d'entreprise" ,"codePostal" => "59520" , "ville" => "Lille"]);
$a2 = new agence(["Nom" => "toto", "adresse" => "154 rue tata","restauration" =>"ticket restaurant" ,"codePostal" => "62102", "ville" => "Lens"]);
$a3 = new agence(["Nom" => "tata", "adresse" => "132 rue tutu","restauration" =>"restaurant d'entreprise" ,"codePostal" => "52013", "ville" => "Marseille"]);
$enfant[] = new Enfant(["Nom" => "Premier", "Prenom" => "Alcibiade", "Age" => 12]);
$enfant[] = new Enfant(["Nom" => "Deuxième", "Prenom" => "Walbert", "Age" => 8]);
$enfant[] = new Enfant(["Nom" => "Troisième", "Prenom" => "Maxanne", "Age" => 6]);
$enfant[] = new Enfant(["Nom" => "Quatrième", "Prenom" => "Dianthe", "Age" => 5]);
$enfant[] = new Enfant(["Nom" => "Cinquième", "Prenom" => "Quintilien", "Age" => 19]);
$e[] = new Employe(["Nom" => "Aarouss", "Prenom" => "Sofiane", "dateEmbauche" => new DateTime("01-12-2020"), "fonction" => "Eleveur de punaise", "salaireAnnuel" => "14", "Service" => "Nettoyage","agence"=>$a1,"enfants"=>[$enfant[1]]]);
$e[] = new Employe(["Nom" => "Courquin", "Prenom" => "Pierre", "dateEmbauche" => new DateTime("12-03-2006"), "fonction" => "Gynecologue", "salaireAnnuel" => "40", "Service" => "Medecine","agence"=>$a2,"enfants"=>[$enfant[0]]]);
$e[] = new Employe(["Nom" => "Rjeb", "Prenom" => "Zied", "dateEmbauche" => new DateTime("15-09-2015"), "fonction" => "Kebabiste", "salaireAnnuel" => "30", "Service" => "Restauration","agence"=>$a2,"enfants"=>[$enfant[2],$enfant[3]]]);
$e[] = new Employe(["Nom" => "Balair", "Prenom" => "Quentin", "dateEmbauche" => new DateTime("03-03-2003"), "fonction" => "Plaquiste", "salaireAnnuel" => "20", "Service" => "batiment","agence"=>$a1]);
$e[] = new Employe(["Nom" => "Cugny", "Prenom" => "Maxime", "dateEmbauche" => new DateTime("27-08-2007"), "fonction" => "Homme de menage", "salaireAnnuel" => "50", "Service" => "Nettoyage","agence"=>$a3,"enfants"=>[$enfant[4]]]);

echo "Il y a " . Employe::getCompteur() . " employé créé \n";

//TRI

//AfficheTableau($e);
//usort($e,array("Employe","compareToNomPrenom"));
//AfficheTableau($e);
usort($e, array("Employe", "compareToServiceNomPrenom"));
AfficheTableau($e);


//Masse Salariale
$masseSalarialeTotale = 0;
foreach ($e as $elt)
{
    $masseSalarialeTotale += $elt->masseSalariale();
}
echo "La masse salariale totale est de " . $masseSalarialeTotale . "\n";



//Ordre de transfert PRIME
$dateAujourdhui = new DateTime('now');
// $annee = $dateAujourdhui->format('Y');
// $jourDePrime = new DateTime('30-09-' . $annee);
$jourDePrime = (new DateTime())->setDate($dateAujourdhui->format('Y'), 9, 30);
// echo "Jour de prime :\n";
// var_dump($jourDePrime);
// echo "Jour aujourd'hui :\n";
// var_dump($dateAujourdhui);

if ($jourDePrime < $dateAujourdhui)
{ //on compare les dates
    foreach ($e as $elt)
    {
        echo "L'ordre de transfert a été envoyé à la banque pour " . $elt->getNom()." " . $elt->getPrenom(). " d'un montant de ".$elt->prime()."\n";
    }
}
else
{
    echo "L'ordre de transfert n'a pas été envoyé à la banque\n";
}
