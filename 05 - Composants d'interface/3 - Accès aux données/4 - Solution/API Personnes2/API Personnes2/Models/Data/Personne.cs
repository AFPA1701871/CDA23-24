using System;
using System.Collections.Generic;

namespace API_Personnes2.Models.Data;

public partial class Personne
{
    public int IdPersonne { get; set; }

    public string Nom { get; set; } = null!;

    public string Prenom { get; set; } = null!;

    public string? Adresse { get; set; }

    public string? Ville { get; set; }
}
