<?php

require "./UTILS/genelog.php";

function loadClass($class)
{
    if (file_exists("./PHP/CONTROLLER/CLASS/".$class.".Class.php"))
    require "./PHP/CONTROLLER/CLASS/".$class.".Class.php";
    else if (file_exists("./PHP/MODEL/MANAGER/".$class.".Class.php"))
    require "./PHP/MODEL/MANAGER/".$class.".Class.php";
}
spl_autoload_register("loadClass");

Parameter::setParam();
DbConnect::init();
echo '<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>';
    
require "./PHP/VIEW/LIST/ArticlesList.php";
echo '</body>
</html>';