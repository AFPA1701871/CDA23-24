using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_des_fichiers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../MonFichier.txt";
            string[] tableau = new string[10];
            string[] tableauRetour = new string[10];
            tableau = PrepareLeTableaauAEnregistrer(tableau);
            AfficherTableau(tableau);
            EcrireFichier(tableau, path);
            tableauRetour = LireFichier(path);
            if (tableauRetour != null)
            {
                Console.WriteLine("\n Tableau Récupéré");
                AfficherTableau(tableauRetour);
            }
            Console.Read();
        }
        static string[] PrepareLeTableaauAEnregistrer(string[] tab)
        //remplit un tableau
        {
            for (int i = 0; i < 10; i++)
            {
                tab[i] = "nom " + (i + 1) + "  info : " + i;
            }
            return tab;
        }
        static string[] LireFichier(string path)
        // Renvoi un tableau de chaine contenant les informations stockées dans le fichier 
        {
            string[] chaine = new string[10];
            try
            { 
                // Lecture et stockage dans chaine
                chaine = File.ReadAllLines(path);
            }
            catch (Exception e)
            {
                Console.WriteLine("Une exception s'est produite : " + e.Message );
                Console.WriteLine("Indiquer le path :");
                chaine = LireFichier(Console.ReadLine());
            }
            return chaine;
        }
        static void EcrireFichier(string[] chaine, string path)
        // Ecris dans le fichier  
        {
            File.WriteAllLines(path, chaine);
        }

        static void AfficherTableau(string[] tab)
        // Affiche le tableau
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(tab[i]);
            }
        }
    }
}
