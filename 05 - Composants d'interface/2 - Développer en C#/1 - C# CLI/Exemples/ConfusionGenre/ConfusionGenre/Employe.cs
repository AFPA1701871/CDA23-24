using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusionGenre
{
    public class Employe
    {
        public  string  Nom { get; set; }
        public Agence AgenceEmploye { get; set; }

        public override string  ToString ()
        {
            return Nom + AgenceEmploye + AgenceEmploye.NbPC + Agence.NbAgence;
        }
    }
}
