using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    public class DAOJson
    {


        //Méthodes

        static public void EcrireFichier(List<Produits> liste, string path)
        {
            string[] contenu = { JsonConvert.SerializeObject(liste) };
            File.WriteAllLines(path, contenu);
        }
        static public List<Object> LireFichier(string path)
        //Renvoi un tableau de chaine contenant les records stockées dans le fichier records
        {
            string contenu;
            List<Object> liste = new List<Object>();
            //Lecture et stockage 
            contenu = File.ReadAllText(path);
            //transformation en liste d'object
            liste = JsonConvert.DeserializeObject<List<Object>>(contenu);
            return liste; // renvoi la liste des tableaux
        }
    }

}
