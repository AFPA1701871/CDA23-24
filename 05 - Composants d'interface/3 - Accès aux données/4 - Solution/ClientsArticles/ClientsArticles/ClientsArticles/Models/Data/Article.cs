using System;
using System.Collections.Generic;

namespace ClientsArticles.Models.Data;

public partial class Article
{
    public int IdArticle { get; set; }

    public string? DescriptionArticle { get; set; }

    public int? PrixArticle { get; set; }

    public int IdCategorie { get; set; }

    public virtual ICollection<Commande> ListeCommandes { get; set; } = new List<Commande>();

    public virtual Categorie LaCategorie { get; set; } = null!;
}
