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

        static public void EcrireFichier(StructureJson sj, string path)
        {
            string[] contenu = { JsonConvert.SerializeObject(sj) };
            File.WriteAllLines(path, contenu);
        }
        static public StructureJson LireFichier(string path)
        //Renvoi un tableau de chaine contenant les records stockées dans le fichier records
        {
            string contenu;
            //Lecture et stockage 
            contenu = File.ReadAllText(path);
            //transformation en liste d'object
            StructureJson sj = JsonConvert.DeserializeObject<StructureJson>(contenu);
            return sj; // renvoi la liste des tableaux
        }
    }

}
