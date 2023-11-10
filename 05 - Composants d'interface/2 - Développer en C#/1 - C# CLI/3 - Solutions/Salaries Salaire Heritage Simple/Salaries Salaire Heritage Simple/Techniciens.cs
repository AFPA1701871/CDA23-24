using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Salaries_Salaire_Heritage_Simple
{
    class Techniciens : Employes
    {
        private const int SALAIRE_DE_BASE = 40;

        public Techniciens(string nom, string prenom, int age) : base(nom, prenom, age, SALAIRE_DE_BASE)
        {
        }

    }
}
