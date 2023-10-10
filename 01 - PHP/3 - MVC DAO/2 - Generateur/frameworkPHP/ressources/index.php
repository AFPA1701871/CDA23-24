<?php

require "./../UTILS/genelog.php";
require "./fonctions.php";
function loadClass($class)
{
    if (file_exists("./CONTROLLER/".$class.".Class.php"))
    require "./CONTROLLER/".$class.".Class.php";
    else if (file_exists("./MODEL/".$class.".Class.php"))
    require "./MODEL/".$class.".Class.php";
}
spl_autoload_register("loadClass");
Parametre::init();
DbConnect::init();
$tabTables = recupTables();
foreach ($tabTables as $tables){
    foreach($tables as $table)
        createManager($table);
}
