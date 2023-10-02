<?php
class DbConnect{
    private static $_db;

    

    public static function getDb()
    {
        return self::$_db;
    }

    public static function init()
    {
        try {
            self::$_db =new PDO ('mysql:host=localhost;port=3306;dbname=personnesdb;charset=utf8',"root","");
        } catch (Exception $e) {
            die('Erreur : '.$e->getMessage());
        }
    }
}