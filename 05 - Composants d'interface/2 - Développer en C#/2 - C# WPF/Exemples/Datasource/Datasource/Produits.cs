using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datasource
{
    class Produits
    {
        public int IdProduit { get; set; }
        public string LibelleProduit { get; set; }
        public int Quantite { get; set; }

        public Produits(int idProduit, string libelleProduit, int quantite)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            Quantite = quantite;
        }
    }
}
