using System;
using System.Collections.Generic;
using Tables_1_vers_plusieurs.Models.Dtos;
namespace Tables_1_vers_plusieurs.Models.Data;

public partial class Marque
{
    public int IdMarque { get; set; }

    public string Libelle { get; set; } = null!;
    /* RELATION  */
    public virtual ICollection<Modele> ListeModeles { get; set; } = new List<Modele>();
}
