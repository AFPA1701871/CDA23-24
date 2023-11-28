using System;
using System.Collections.Generic;
using Tables_1_vers_plusieurs.Models.Dtos;

namespace Tables_1_vers_plusieurs.Models.Data;

public partial class Modele
{
    public int IdModele { get; set; }

    public string? Libelle { get; set; }

    public int MarqueId { get; set; }
    /* RELATION  */
    public virtual Marque LaMarque { get; set; } = null!;
}
