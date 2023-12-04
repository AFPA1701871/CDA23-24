using System;
using System.Collections.Generic;

namespace AlimDatasource;

public partial class Article
{
    public int IdArticle { get; set; }

    public string? DescriptionArticle { get; set; }

    public int? PrixArticle { get; set; }

    public int IdCategorie { get; set; }


    public virtual string LaCategorie { get; set; } = null!;
    public Article()
    {
            
    }

    public Article(int idArticle, string? descriptionArticle, int? prixArticle, int idCategorie, string laCategorie)
    {
        IdArticle = idArticle;
        DescriptionArticle = descriptionArticle;
        PrixArticle = prixArticle;
        IdCategorie = idCategorie;
        LaCategorie = laCategorie;
    }
}
