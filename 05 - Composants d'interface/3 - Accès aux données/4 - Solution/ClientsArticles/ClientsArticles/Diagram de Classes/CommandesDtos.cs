using ClientsArticles.Models.Data;

namespace ClientsArticles.Models.DTOs
{
    public class CommandesDtoIN
    {

        public int? IdClient { get; set; }

        public int? IdArticle { get; set; }

        public DateTime? DateCommande { get; set; }

        public int? QuantiteCommande { get; set; }

    }
    public class CommandesDtoOUT
    {
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

        public int? IdArticle { get; set; }

        public DateTime? DateCommande { get; set; }

        public int? QuantiteCommande { get; set; }
    }
    public class CommandesDtoAvecArticle
    {
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

        public int? IdArticle { get; set; }

        public DateTime? DateCommande { get; set; }

        public int? QuantiteCommande { get; set; }

        public virtual ArticlesDtoOUT? LArticle { get; set; }
    }
    public class CommandesDtoAvecClient
    {
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

        public int? IdArticle { get; set; }

        public DateTime? DateCommande { get; set; }

        public int? QuantiteCommande { get; set; }

        public virtual ClientsDtoOUT? LeClient { get; set; }
    }
    public class CommandesDtoAvecClientEtArticle
    {
        public int IdCommande { get; set; }

        public int? IdClient { get; set; }

        public int? IdArticle { get; set; }

        public DateTime? DateCommande { get; set; }

        public int? QuantiteCommande { get; set; }

        public virtual ArticlesDtoOUT? LArticle { get; set; }

        public virtual ClientsDtoOUT? LeClient { get; set; }
    }
}
