using ClientsArticles.Models.Data;

namespace ClientsArticles.Models.DTOs
{
    public class ClientsDtoIN
    {
        public string? NomClient { get; set; }

        public string? PrenomClient { get; set; }

        public DateTime? DateEntreeClient { get; set; }
    }
    public class ClientsDtoOUT
    {
        public int IdClient { get; set; }

        public string? NomClient { get; set; }

        public string? PrenomClient { get; set; }

        public DateTime? DateEntreeClient { get; set; }
    }
    public class ClientsDtoAvecCommandes // inutile pûisque équivalent à ClientsDtoOUT
    {
        public int IdClient { get; set; }

        public string? NomClient { get; set; }

        public string? PrenomClient { get; set; }

        public DateTime? DateEntreeClient { get; set; }

        public virtual ICollection<CommandesDtoOUT> ListeCommandes { get; set; } = new List<CommandesDtoOUT>();
    }
}
