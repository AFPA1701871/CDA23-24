using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    public class ProduitsServices
    {
        static public string Path { get; set; } = "../../../Produits.json";

        static public List<Produits> GetAllProduits()
        {
            List<Produits> liste = Profiles.FromObjectToProduits( DAOJson.LireFichier(Path));

            return liste;
        }
    }
}
