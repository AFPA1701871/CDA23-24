using System;
using System.Collections.Generic;

namespace ClientsArticles.Models.Data;

public partial class Client
{
    public int IdClient { get; set; }

    public string? NomClient { get; set; }

    public string? PrenomClient { get; set; }

    public DateTime? DateEntreeClient { get; set; }

    public virtual ICollection<Commande> ListeCommandes { get; set; } = new List<Commande>();
}
