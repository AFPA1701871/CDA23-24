using ClientsArticles.Models.Data;

namespace ClientsArticles.Models.DTOs
{
    public class CategoriesDtoIN
    {

        public string LibelleCategorie { get; set; } = null!;
    }
    public class CategoriesDtoOUT
    {
        public int IdCategorie { get; set; }

        public string LibelleCategorie { get; set; } = null!;
    }
    public class CategoriesDtoAvecArticles  
    {
        public int IdCategorie { get; set; }

        public string LibelleCategorie { get; set; } = null!;

        public virtual ICollection<ArticlesDtoOUT> ListeArticles { get; set; } = new List<ArticlesDtoOUT>();
    }
}
