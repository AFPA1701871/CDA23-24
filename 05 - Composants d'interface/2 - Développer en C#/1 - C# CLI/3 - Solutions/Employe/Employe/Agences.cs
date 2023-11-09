using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employe
{
    class Agences
    {
        public string Nom { get; set; }
        public string Adresse { get; set; }
        public int CodePostal { get; set; }
        public string Ville { get; set; }
        public bool Restaurant { get; set; }

        public Agences(string nom, string adresse, int codePostal, string ville, bool resto)
        {
            Nom = nom;
            Adresse = adresse;
            CodePostal = codePostal;
            Ville = ville;
            Restaurant = resto;
        }

        public override string ToString()
        {
            return
                "\n***AGENCE***" +
                "\nNom                  :" + this.Nom +
                "\nAdresse              : " + this.Adresse +
                "\nCode postal          : " + this.CodePostal +
                "\nVille                : " + this.Ville +
                "\nMode de restauration : " + this.ModeRestauration();
        }

        public string ModeRestauration()
        {
            return Restaurant ? "Restaurant disponible" : "Tickets restaurant";
        }
    }
}
