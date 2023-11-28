using System;
using System.Collections.Generic;
using Tables_1_vers_plusieurs.Models.Data;

namespace Tables_1_vers_plusieurs.Models.Dtos;

public  class ModeleDtoAvecMarque
{/* RELATION DTO Avec relation sans boucle */
    public int IdModele { get; set; }

    public string? Libelle { get; set; }

    public int MarqueId { get; set; }
    public virtual MarqueDtoSansModeles LaMarque { get; set; } = null!;

}
public class ModeleDtoSansMarque
{/* RELATION DTO Sans relation */
    public int IdModele { get; set; }

    public string? Libelle { get; set; }

    public int MarqueId { get; set; }

}
