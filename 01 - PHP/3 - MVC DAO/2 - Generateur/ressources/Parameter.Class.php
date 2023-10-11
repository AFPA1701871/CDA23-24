<?php

class Parameter
{
    private static $_host;
    private static $_dbname;
    private static $_charset;
    private static $_user;
    private static $_password;

    public static function setParam()
    {
        if (file_exists("config.json"))
        {
            $jsonObj = json_decode(file_get_contents("config.json"));
            self::$_host = $jsonObj->host;
            self::$_dbname = $jsonObj->dbname;
            self::$_charset = $jsonObj->charset;
            self::$_user = $jsonObj->user;
            self::$_password = $jsonObj->password;
        }
    }

    public static function getHost()
    {
        return self::$_host;
    }

    public static function getDbname()
    {
        return self::$_dbname;
    }

    public static function getCharset()
    {
        return self::$_charset;
    }

    public static function getUser()
    {
        return self::$_user;
    }

    public static function getPassword()
    {
        return self::$_password;
    }
}
