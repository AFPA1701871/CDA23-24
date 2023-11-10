using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Vendeurs : Commerciaux
    {
        private const int NB_IRIS_PAR_PRIME = 2;
        private const int SALAIRE_DE_BASE  = 50;

        public Vendeurs(string nom, string prenom, int age, int nbPrimes) : base(nom, prenom, age, SALAIRE_DE_BASE , nbPrimes)
        {
        }

        public override double CalculSalaire()
        {
            return SALAIRE_DE_BASE + ( NbPrimes * NB_IRIS_PAR_PRIME) ; // les ( ) ne sont pas obligatoires
        }

        public override string ToString()
        {
            return base.ToString() + "\tdont Salaire de " + SALAIRE_DE_BASE + " + " + NbPrimes + " primes à " + NB_IRIS_PAR_PRIME;
        }
    }
}
