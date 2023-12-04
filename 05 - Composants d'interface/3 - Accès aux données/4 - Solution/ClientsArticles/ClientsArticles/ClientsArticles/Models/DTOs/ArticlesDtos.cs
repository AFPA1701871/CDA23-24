using ClientsArticles.Models.Data;

namespace ClientsArticles.Models.DTOs
{
    public class ArticlesDtoIN
    {

        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public int IdCategorie { get; set; }
    }
    public class ArticlesDtoOUT
    {
        public int IdArticle { get; set; }

        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public int IdCategorie { get; set; }
    }
    public class ArticlesDtoAvecCategorie
    {
        public int IdArticle { get; set; }

        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public int IdCategorie { get; set; }

        public virtual CategoriesDtoOUT LaCategorie { get; set; } = null!;
    }

    public class ArticlesDtoAvecCommandes
    {
        public int IdArticle { get; set; }

        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public int IdCategorie { get; set; }

        public virtual ICollection<CommandesDtoOUT> ListeCommandes { get; set; } = new List<CommandesDtoOUT>();


    }
    public class ArticlesDtoAvecCategorieEtCommandes
    {
        public int IdArticle { get; set; }

        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public int IdCategorie { get; set; }

        public virtual ICollection<CommandesDtoOUT> ListeCommandes { get; set; } = new List<CommandesDtoOUT>();

        public virtual CategoriesDtoOUT LaCategorie { get; set; } = null!;
    }

    public class ArticlesDtoAplati
    {
       
        public string? DescriptionArticle { get; set; }

        public int? PrixArticle { get; set; }

        public string CategorieAplatie { get; set; }
    }

}
