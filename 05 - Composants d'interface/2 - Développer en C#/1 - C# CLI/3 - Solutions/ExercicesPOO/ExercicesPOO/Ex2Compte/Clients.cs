using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExercicesPOO.Ex2Compte
{
    class Clients
    {
        public string CIN { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Tel { get; set; }

        public Clients(string cin, string nom, string prenom, string tel)
        {
            this.CIN = cin;
            this.Nom = nom;
            this.Prenom = prenom;
            this.Tel = tel;
        }

        public Clients(string cin, string nom, string prenom)
        {
            this.CIN = cin;
            this.Nom = nom;
            this.Prenom = prenom;
        }

        public override string ToString()
        {
            return "CIN: " + this.CIN + "\nNom: " + this.Nom + "\nPrenom: " + this.Prenom + "\nTél: " + this.Tel;
        }

        public void Afficher()
        {
            Console.WriteLine(this);            // équivalent à Console.WriteLine(this.ToString());
        }
    }
}
