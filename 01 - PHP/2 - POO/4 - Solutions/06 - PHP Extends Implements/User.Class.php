<?php
class User
{
    protected $username;

    public function setUsername($name)
    {
        $this->username = $name;
    }

    public function getUsername()
    {
        return $this->username;
    }
    public function isReading()
    {
        return rand() - 0.5 > 0;
    }
    public function __toString()
    {
        $result = $this->getUsername();
        $result .= $this->isReading() ? " is reading.\n" : "is not reading.\n";
        return $result;
    }
}
