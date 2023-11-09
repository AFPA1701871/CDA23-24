using System;
using System.Collections.Generic;
using System.Text;
using static Employe.Program;

namespace Employe
{
    class Enfants
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public DateTime Ddn { get; set; }

        public Enfants(string nom, string prenom, DateTime ddn)
        {
            Nom = nom;
            Prenom = prenom;
            Ddn = ddn;
        }

        public int Age()
        {
            TimeSpan ecart = DateTime.Today - Ddn;
            return ((int)ecart.TotalDays / 365);
        }

        public int ChequeNoel()
        {
            int age = this.Age();
            if (age < 11)
                return 20;
            else if (age < 16)
                return 30;
            else if (age < 19)
                return 50;
            return 0;
        }

        public ValeurChequeNoel ChequeNoel2()
        {
            int age = this.Age();
            if (age < 11)
                return ValeurChequeNoel.C20;
            else if (age < 16)
                return ValeurChequeNoel.C30;
            else if (age < 19)
                return ValeurChequeNoel.C50;
            return 0;
        }

        public override string ToString()
        {
            return
                "\n***************************************************" +
                "\nNom                      : " + this.Nom +
                "\nPrenom                   : " + this.Prenom +
                "\nDate de naissance        : " + this.Ddn.ToString("dd/MM/yyyy") +
                "\n***************************************************";

        }
    }

}
