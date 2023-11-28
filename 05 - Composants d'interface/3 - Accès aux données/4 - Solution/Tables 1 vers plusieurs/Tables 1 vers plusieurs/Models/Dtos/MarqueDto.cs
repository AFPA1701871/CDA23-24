using System;
using System.Collections.Generic;

namespace Tables_1_vers_plusieurs.Models.Dtos;

public  class MarqueDtoAvecModeles
{/* RELATION DTO Avec relation sans boucle */
    public int IdMarque { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<ModeleDtoSansMarque> ListeModeles { get; set; } = new List<ModeleDtoSansMarque>();
}
public class MarqueDtoSansModeles
{/* RELATION DTO Sans relation */
    public int IdMarque { get; set; }

    public string Libelle { get; set; } = null!;
}

