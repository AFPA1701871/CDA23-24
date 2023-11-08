using System;
using ExercicesPOO.Ex1;
using ExercicesPOO.Ex2Compte;

namespace ExercicesPOO
{
    class Program
    {
        static void Main(string[] args)
        {
            //Voitures v1 = new Voitures("Noir", "Citroen", "C4", MotorisationEnum.Essence);
            //Voitures v2 = new Voitures("Rouge", "Renault", "Kadjar", MotorisationEnum.Diesel, 845);
            //Console.WriteLine(v1);
            //v1.Rouler(50);
            //Console.WriteLine(v1);
            //Console.WriteLine(v2);

            Clients omar = new Clients("EE111222", "Salim", "Omar", "0611111");
            //Clients samir = new Clients("EE333444", "Karimi", "samir", "0622222");
            //Comptes compte1 = new Comptes(omar);
            //Comptes compte2 = new Comptes(samir);
            omar.Afficher();
            omar.Dump();
            //compte1.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //compte1.Crediter(5000);  // il y a un seul paramètre, donc il appele la 1ère méthode
            //compte1.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //compte1.Debiter(1000);
            //compte1.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //compte2.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //compte2.Crediter(3000, compte1);    // il y a 2 paramètres, donc il appele la 2ème méthode
            //compte1.Debiter(1000, compte2);
            //compte1.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //compte2.Afficher();
            //Console.WriteLine("*****************************************************************************");
            //Comptes.afficherNbrDeCompte();      // la méthode est static , elle est appelé par la classe et pas par un objet

        }
    }
    public enum MotorisationEnum
    {
        Diesel,
        Essence
    }
}
