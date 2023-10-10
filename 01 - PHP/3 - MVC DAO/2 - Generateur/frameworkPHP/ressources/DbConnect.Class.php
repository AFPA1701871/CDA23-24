<?php

    // PDO
    class DbConnect
    {
        private static $_db;

        public static function getDb()
        {
            return DbConnect::$_db;
        }

        public static function init()
        {
            try{
                Parameter::setParam();
                // Connection MySQL
                self::$_db = new PDO ( 'mysql:host='.Parameter::getHost().';
                                        dbname='.Parameter::getDbname().';
                                        charset='.Parameter::getCharset(), 
                                        Parameter::getUser(), 
                                        Parameter::getPassword());
            } catch ( Exception $e ) {
                // Retourne l'erreur et arrete le script courant
                die ( 'Erreur : ' . $e->getMessage() );
            }
        }
    }