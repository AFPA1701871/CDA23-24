using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Commerciaux : Employes
    {
        public int NbPrimes { get; set; }

        public Commerciaux(string nom, string prenom, int age, double salaire,int nbPrimes) : base(nom, prenom, age, salaire)
        {
            NbPrimes = nbPrimes;
        }
    }
}
