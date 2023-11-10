using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Interimaires : Techniciens
    {
        public int NbHeures { get; set; }
        private const Double NB_IRIS_PAR_HEURE = 0.5;

        public Interimaires(string nom, string prenom, int age, int nbHeures) : base(nom, prenom, age)
        {
            NbHeures = nbHeures;
        }
        public override double CalculSalaire()
        {
            return NbHeures * NB_IRIS_PAR_HEURE;
        }

    }
}
