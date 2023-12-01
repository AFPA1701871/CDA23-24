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

        public virtual ICollection<ArticlesDtoOUT> ListeArticles { get; set; } = new List<ArticlesDtoOUT>();
    }
    public class CategoriesDtoAvecArticles  // inutile pûisque équivalent à CategoriesDtoOUT
    {
        public int IdCategorie { get; set; }

        public string LibelleCategorie { get; set; } = null!;

        public virtual ICollection<ArticlesDtoOUT> ListeArticles { get; set; } = new List<ArticlesDtoOUT>();
    }
}
