using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace Employe
{
    class Program
    {
        static void Main(string[] args)
        {
            Agences prapage = new Agences("Prapage", "96 Rue de la paix", 62200, "Boulogne", true);
            Agences afpa = new Agences("Afpa", "407 avenue de la gironde", 59111, "Dunkerque", false);

            Enfants paul = new Enfants("Paul", "Parker", new DateTime(2012, 05, 04));
            Enfants lola = new Enfants("Lola", "Blanpain", new DateTime(2010, 02, 08));
            Enfants lucie = new Enfants("Lucie", "Dupont", new DateTime(2015, 05, 12));


            Employes bruno = new Employes("MAYEUX","Bruno",  new DateTime(2000, 10, 15), "Chef de projet", 45500, "Front-End",prapage, new List<Enfants>() { paul, lola });
            Employes pierre = new Employes("COURQUIN","Pierre",  new DateTime(2020, 5, 1), "Developpeur", 67500, "Front-End",afpa, new List<Enfants>() { });
            Employes martine = new Employes("POIX", "Martine", new DateTime(2021, 11, 01), "Stagiaire", 0, "Café", prapage, new List<Enfants>() { lucie });
            Employes quentin = new Employes("BALAIR", "Quentin", new DateTime(2017, 02, 15), "Developpeur", 0, "Back-End", prapage, new List<Enfants>() { });
            Employes maxence = new Employes("THACKER","Maxence",  new DateTime(2021, 11, 01), "Stagiaire", -1000, "Menage",afpa, new List<Enfants>() { });
            Console.WriteLine(pierre.NbAnneesAnciennete());
            //Console.WriteLine(bruno.Prime());

            List<Employes> listeEmployes = new List<Employes>()
            {
            bruno,
            pierre };
            listeEmployes.Add(martine);
            listeEmployes.Add(quentin);
            listeEmployes.Add(maxence);

            //Console.WriteLine("Nombre d'employer dans la societe : " + listeEmployes.Count);

            //Console.WriteLine("\n Avant TRI\n");
            //foreach (var item in listeEmployes)
            //{
            //    Console.WriteLine(item);
            //}

            // Autre technique de tri. Ne nécessite pas les méthodes compareTo dans Employés
            listeEmployes.OrderBy(o => o.Nom).ThenBy(o => o.Prenom).ToList();

            //listeEmployes.Sort(Employes.ClassementService); // tri de la liste en utilisant la methode de comparaison Classement

            //Console.WriteLine("\n APRES TRI\n");
            //foreach (var item in listeEmployes)
            //{
            //    Console.WriteLine(item);
            //}


            ///* Masse salariale*/
            //double masseSalarialeAnnuelle=0;
            //foreach (var item in listeEmployes)
            //{
            //    masseSalarialeAnnuelle += item.MasseSalariale();
            //}
            //Console.WriteLine("La masse salariale annuelle est de " + masseSalarialeAnnuelle);




        }
        public enum ValeurChequeNoel
        {
            C20,
            C30,
            C50
        }
    }
    

    
}
