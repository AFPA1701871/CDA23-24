using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_JSON
{
    public class CategoriesServices
    {
        static public string Path { get; set; } = "../../../Categories.json";

        //static public List<Categories> GetAllCategories()
        //{
        //    List<Categories> liste = Profiles.FromObjectToCategories( DAOJson.LireFichier(Path));

        //    return liste;
        //}
    }
}
