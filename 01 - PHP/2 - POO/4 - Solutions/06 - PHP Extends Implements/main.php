<?php
function ChargerClasse($classe)
{
    require $classe.".Class.php";
}
spl_autoload_register("ChargerClasse");

$user1 = new AuthorEditor();
$user1 -> setUsername("Balthazar");
$user1 -> setAuthorPrivileges(["write text","add punctuation"]);
$user1 -> setEditorPrivileges(["edit text", "edit punctuation"]);

echo $user1;