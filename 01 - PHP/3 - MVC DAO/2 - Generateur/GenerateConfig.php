<?php
class GenerateConfig
{
    /**
     * Boucle sur les éléments de la config de connexion à la base de donnée
     *
     * @param object $dataconfig Array avec les valeurs de connexion
     * @return string
     */
    static private function getConfig(object $dataconfig)
    {
        $aff = "";
        foreach ($dataconfig as $data => $value) {
            $aff .= '   "' . $data . '" : "' . $value . '",' . "\n";
        }

        return substr($aff, 0, -2);
    }

    /**
     * Créé le le contenu de config.json grace à un tableau asso.
     *
     * @param object $dataconfig Tableau asso avec les données de connexion
     * @return string
     */
    static public function createConfigJSON(object $dataconfig)
    {
        $aff  = "{ \n";
        $aff .= self::getConfig($dataconfig);
        $aff .= "\n";
        $aff .= "}";

        return $aff;
    }
}
