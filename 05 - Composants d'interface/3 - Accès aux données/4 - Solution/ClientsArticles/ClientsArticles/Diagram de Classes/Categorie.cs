using System;
using System.Collections.Generic;

namespace ClientsArticles.Models.Data;

public partial class Categorie
{
    public int IdCategorie { get; set; }

    public string LibelleCategorie { get; set; } = null!;

    public virtual ICollection<Article> ListeArticles { get; set; } = new List<Article>();
}
