using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    public class Produits
    {
        public int IdProduit { get; set; }
        public string LibelleProduit { get; set; }
        public int NumeroProduit { get; set; }
        public int Quantite { get; set; }


        public Produits(int idProduit, string libelleProduit, int numeroProduit, int quantite)
        {
            IdProduit = idProduit;
            LibelleProduit = libelleProduit;
            NumeroProduit = numeroProduit;
            Quantite = quantite;
        }

        public Produits()
        {
        }
    }
}
