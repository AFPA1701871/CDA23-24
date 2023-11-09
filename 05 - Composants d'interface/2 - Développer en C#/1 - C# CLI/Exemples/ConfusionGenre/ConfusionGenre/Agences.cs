using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfusionGenre
{
    public class Agence
    {
        public string Nom { get; set; }
        public int NbPC { get; set; }
        public static int NbAgence { get; set; } = 0;

        public Agence()
        {
            Nom = "test";
            NbPC = 0;
            NbAgence++;
        }
    }
}
