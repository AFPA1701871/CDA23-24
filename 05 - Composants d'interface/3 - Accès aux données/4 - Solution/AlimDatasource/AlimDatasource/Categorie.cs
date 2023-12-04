using System;
using System.Collections.Generic;

namespace AlimDatasource;

public partial class Categorie
{
    public Categorie(int idCategorie, string libelleCategorie)
    {
        IdCategorie = idCategorie;
        LibelleCategorie = libelleCategorie;
    }

    public int IdCategorie { get; set; }

    public string LibelleCategorie { get; set; } = null!;

    public virtual ICollection<Article> ListeArticles { get; set; } = new List<Article>();
}
