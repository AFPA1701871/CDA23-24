using System;
using System.Collections.Generic;

namespace ClientsArticles.Models.Data;

public partial class Commande
{
    public int IdCommande { get; set; }

    public int? IdClient { get; set; }

    public int? IdArticle { get; set; }

    public DateTime? DateCommande { get; set; }

    public int? QuantiteCommande { get; set; }

    public virtual Article? LArticle { get; set; }

    public virtual Client? LeClient { get; set; }
}
