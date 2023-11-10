using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Representants : Commerciaux
    {
        private const int NB_IRIS_PAR_PRIME = 5;
        private const int NB_IRIS_PAR_DEPLACEMENT = 1;
        private const int SALAIRE_DE_BASE  = 50;

        public int NbDeplacements { get; set; }

        public Representants(string nom, string prenom, int age, int nbPrimes, int nbDeplacements) : base(nom, prenom, age, SALAIRE_DE_BASE , nbPrimes)
        {
            NbDeplacements = nbDeplacements;
        }

        public override double CalculSalaire()
        {
            return SALAIRE_DE_BASE + ( NbPrimes * NB_IRIS_PAR_PRIME) + (NbDeplacements * NB_IRIS_PAR_DEPLACEMENT); // les ( ) ne sont pas obligatoires
        }

        public override string ToString()
        {
            return base.ToString() + "\tdont Salaire de " + SALAIRE_DE_BASE + " + " + NbPrimes + " primes à " + NB_IRIS_PAR_PRIME + " + " +  NbDeplacements + "  déplacements à " + NB_IRIS_PAR_DEPLACEMENT;
        }
    }
}
