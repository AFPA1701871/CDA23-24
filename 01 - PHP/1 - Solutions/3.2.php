<?php

// On collecte les prix
$total = 0; // contient le prix total
$nbArticle = 0;
do
{
    // on demande les prix un par un
    do
    {
        $prix = readline("prix article : ");
    }
    // while(is_numeric($prix) && intval($prix)==$prix && $prix>=0);
    // is_numeric($prix)   vérifie que la chaine saisie ne contient que des chiffres
    // intval($prix)==$prix vérifie que le prix est entier

    while (!preg_match("/^[\d]+$/", $prix) || $prix < 0); // test si la saisie correpond au modèle de la regex c'est à dire numéric sans virgule
    $total += $prix;
    $nbArticle++;
} while ($prix != 0); // on s'arrete quand le prix est = à 0

// On récupère l'argent
echo 'Vous avez acheté ' . --$nbArticle . ' articles pour ' . $total . " euros\n";
do
{
    $prixPaye = readline("montant payé : ");

} while (!preg_match("/^[\d]+$/", $prixPaye) || $prixPaye < $total);

// On rend la monnaie
$reste = $prixPaye - $total; // monnaie à rendre
while ($reste >= 10)
{
    echo "billet de 10\n";
    $reste -= 10;
}
if ($reste >= 5)
{ // il ne peut y avoir qu'un seul billet de 5€
    echo "billet de 5\n";
    $reste -= 5;
}
while ($reste >= 1)
{
    echo "pièce de 1\n";
    $reste -= 1;
}
