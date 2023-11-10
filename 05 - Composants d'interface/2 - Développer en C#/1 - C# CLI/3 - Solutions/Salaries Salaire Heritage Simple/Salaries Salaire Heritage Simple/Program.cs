using System;
using System.Collections.Generic;

namespace Salaries_Salaire_Heritage_Simple
{
    class Program
    {
        static void Main(string[] args)
        {
            Entreprises e = new Entreprises("Promos IRIS");
            e.Embaucher(new Vendeurs("Dupond", "Paul   ", 30, 10));
            e.Embaucher(new Vendeurs("Dupond", "Pierre   ", 32, 5));
            e.Embaucher(new Vendeurs("Dupond", "Jacques", 31, 1));
            e.Embaucher(new Representants("Dupond", "Giselle", 31, 3, 10));
            e.Embaucher(new Representants("Dupond", "Georges", 30, 2, 8));
            e.Embaucher(new Techniciens("Dupond", "Robert  ", 23));
            e.Embaucher(new Techniciens("Dupond", "Raymond", 23));
            e.Embaucher(new Interimaires("Dupond", "Jean-Claude", 23, 75));
            e.Embaucher(new Interimaires("Dupond", "Jean-Paul", 23, 50));
            e.Embaucher(new Interimaires("Dupond", "Jean-Marie", 23, 50));
            e.Embaucher(new Interimaires("Dupond", "Jean-Jean", 23, 0));
            Console.WriteLine(e);

        }
    }
}
